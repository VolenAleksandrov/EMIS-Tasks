using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenerateExelFile
{
    public static class Utilities
    {
        public static int RowsToGenerate { get; } = 100000;
        public static string[] Names = { "Ivan", "Petur", "Kiro", "Pesho", "Gosho", "Kristian", "Maria", "Kristina", "Gergana", "Vasilena" };
        public static Dictionary<string, string> HeaderCells = new Dictionary<string, string>()
            {
                { "A1", "Name" },
                { "B1", "Age" },
                { "C1", "Score" },
                { "E1", "Average Score" }
            };
    }
}
