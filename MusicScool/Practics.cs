using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScool
{
    internal static class Practics
    {
        
        static Func<List<string>, bool> GetA = (list) => list.Any(item => item.StartsWith("a"));
        static List<string> Strings = ["avi", "moshe", "david", "alef"];
        static Func<List<string>, bool> IsEmpti = (list) => list.Any(item => item.StartsWith(""));

    }
}
