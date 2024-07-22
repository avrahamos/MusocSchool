using static MusicScool.Practics;
using static MusicScool.Configurtion.MusicSchoolConfiguration;
using static MusicScool.Service.MusicSchoolService;
namespace MusicScool
{
    public partial class Form1 : Form
    {
        //List<string> Strings = ["avi", "moshe", "david", "alef", "rt"];


        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExists();

           // bool res = GetA(Strings);

            // bool res2 = IsEmpti(Strings);

            ////MessageBox.Show(string.Join(",", res2));
            ///
            //List<string> list = Huper(Strings);

            //MessageBox.Show(string.Join(", ", list));

            //List <string> list2 = HupTo3(Strings);

            //  MessageBox.Show(string.Join(", ", list2));

        }
        
      //  Func<List<string>, bool> GetA = (list) => list.Any(item => item.StartsWith("a"));

        // Func<List<string>, bool> IsEmpti = (list) => list.Any(string.IsNullOrEmpty);

        // Func<List<string>, List<string>> Huper = (list) => list.Select(l => l.ToUpper()).ToList();

       // Func<List<string>, List<string>> HupTo3 = (list) => list.Where(l => l.Length >= 3).ToList();

        



    }
}
