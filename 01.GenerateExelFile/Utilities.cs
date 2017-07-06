namespace _01.GenerateExelFile
{
    using System.Collections.Generic;
    public static class Utilities
    {
        public static int RowsToGenerate = 100000;
        public static string[] Names = { "Ivan", "Petur", "Kiro", "Pesho", "Gosho", "Kristian", "Maria", "Kristina", "Gergana", "Vasilena" };
        public static Dictionary<string, string> HeaderCells = new Dictionary<string, string>()
            {
                { "A1", "Name" },
                { "B1", "Age" },
                { "C1", "Score" },
                { "E1", "Average Score" }
            };

        public static int MinAge = 20;
        public static int MaxAge = 80;
        public static int MinScore = 0;
        public static int MaxScore = 100;
        public static string FormulaCell = "E2";
        public static string StartFormulaCell = "C2";
        public static string EndFormulaCell = "C100001";
    }
}
