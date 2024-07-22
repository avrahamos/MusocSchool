using MusicScool.Configurtion;
using MusicScool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Model.StudentModel;

namespace MusicScool.Service
{
    internal static class MusicSchoolService
    {
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
        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);

            XElement? classRoom = (from room in document.Descendants("class-room")
                                   where room.Attribute("name")?.Value == classRoomName
                                   select room).FirstOrDefault();

            if (classRoom == null)
            {
                return;
            }

            XElement studentElement = new XElement("student",
                                        new XAttribute("name", studentName),
                                        new XAttribute("instrument", instrumentName));

            classRoom.Add(studentElement);

            document.Save(MusicSchoolPath);
        }
        public static void AddManyStudents(string classRoomName, params StudentModel[] students)
        {
            XDocument document = XDocument.Load(MusicSchoolConfiguration.MusicSchoolPath);

            XElement? classRoomElement = document.Descendants("class-room")
                                                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoomElement == null)
            {
                // אם לא נמצא אלמנט class-room, לסיים את הפונקציה
                return;
            }

            // יצירת רשימה של XElement לכל סטודנט בשימוש בLINQ
            var studentElements = students.Select(student =>
                                    new XElement("student",
                                        new XAttribute("name", student.StudentName),
                                        new XAttribute("instrument", student.InstrumentName.InstrumentName))
                                ).ToList();

            classRoomElement.Add(studentElements);

            document.Save(MusicSchoolPath);
        }
        public static void ChangeInstrment(StudentModel student ,InstrumentModel NewinstrumentName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);

            XElement? studentElement = document.Descendants("student")?.
                FirstOrDefault(st => st?.Attribute("name")?.Value == student.StudentName);
            
            if (studentElement == null) { return; }

            studentElement.SetAttributeValue("instrument", NewinstrumentName);
            studentElement.Save(MusicSchoolPath);
        }
        public static void ChangeTecher(string techerName, string newTecherName)
        {
            XDocument document = XDocument.Load(MusicSchoolPath);

            XElement? teacherElement = document.Descendants("teacher")
                                              .FirstOrDefault(t => t.Attribute("name")?.Value == techerName);

            if (teacherElement == null)
            {
                return;
            }

            teacherElement.Attribute("name").Value = newTecherName;

            document.Save(MusicSchoolPath);
        }


    }
}


    

