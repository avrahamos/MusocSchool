using MusicScool.Model;
using MusicScool.Service;
using MusicScool.Service;
using MusicScool.Service;
using MusicScool.Service;
using MusicScool.Service;
using System;
using System;
using System;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text;
using System.Text;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Linq;
using System.Xml.Linq;
using System.Xml.Linq;
using System.Xml.Linq;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Configurtion.MusicSchoolConfiguration;

internal static class MusicSchoolServiceHelpers
{
    public static void AddMeniStudents(string classRommService, params StudentModel[] students)
    {

    }
        public static void AddMeniStudents(string classRommService ,params StudentModel[] students) 
        {

        }
        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);

            // Find the class-room element with the specified name
            XElement? classRoom = (from room in document.Descendants("class-room")
                                   where room.Attribute("name")?.Value == classRoomName
                                   select room).FirstOrDefault();

            if (classRoom == null)
            {
                // If class-room element doesn't exist, return or handle accordingly
                return;
            }

            // Create the new student element with the specified attributes
            XElement studentElement = new XElement("student",
                                        new XAttribute("name", studentName),
                                        new XAttribute("instrument", instrumentName));

            // Add the student element to the class-room element
            classRoom.Add(studentElement);

            // Save the changes back to the XML document
            document.Save(MusicSchoolPath);
        }
        public static void AddTecher(string classRoomName, string techerName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);
            XElement? classRoom = document.Descendants("class-room").FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);//Where(c =>(string) c.Attribute("name")== classRoomName).FirstOrDefault();
            if (classRoom == null) 
            {
                return;
            }
            XElement techer = new("techer", new XAttribute("name", techerName));
            classRoom.Add(techer);
            document.Save(MusicSchoolPath);

        }
        public static void CreateXmlIfNotExists()
        {
            if (!File.Exists(MusicSchoolPath))
            {
                //יצירת אובייקט חדש
                XDocument doc = new();
                //יצירת אלמנט
                XElement MusicSchool = new("music-school");
                //להוסיף את האלמנט לאובייקט
                doc.Add(MusicSchool);
                //שמירה של הקובץ בנתיב שלו
                doc.Save(MusicSchoolPath);


            }
        }
        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();
            if (musicSchool == null)
            {
                return;
            }
            XElement classRoom = new("class-room", new XAttribute("name", classRoomName));
            musicSchool.Add(classRoom);
            document.Save(MusicSchoolPath);

        }
}