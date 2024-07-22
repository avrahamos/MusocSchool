using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScool.Configurtion
{
    internal static class MusicSchoolConfiguration
    {
        public static string MusicSchoolPath => Path.Combine(Directory.GetCurrentDirectory(),
            "MusicSchool.xml");
    }
}
