using System;
using System.Collections.Generic;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace _01.GenerateExelFile
{
    class ExcelTableManipulation
    {
        /// <summary>
        /// Sets formula which calculates average value between two cells from same column. Working only with cells with numerical values.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="cellForFormula"></param>
        /// <param name="startCell"></param>
        /// <param name="endCell"></param>
        public static void SetAverageFormulaToCell(ExcelWorksheet worksheet, string cell, string startCell, string endCell)
        {
            if (startCell[0] != endCell[0])
            {
                throw new ArgumentOutOfRangeException("Start cell and end cell must be from the same column!");
            }
            worksheet.Cells[cell].Formula = $"=AVERAGE({startCell}:{endCell})";
        }

        public static void CustomizeFirstHeaderRow(ExcelWorksheet worksheet, Color backgroundColor)
        {
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Row(1).Style.Fill.BackgroundColor.SetColor(backgroundColor);
        }


        public static void AddRowsWithRandomValues(int rowsCount, ExcelWorksheet worksheet)
        {
            Random random = new Random();
            for (int i = 0; i < rowsCount; i++)
            {
                string randomName = Utilities.Names[random.Next(0, Utilities.Names.Length - 1)];
                int randomAge = random.Next(Utilities.MinAge, Utilities.MaxAge);
                int randomScore = random.Next(Utilities.MinScore, Utilities.MaxScore);
                Person person = new Person(randomName, randomAge, randomScore);
                AddPersonToNextEmptyRow(person, worksheet);
            }
        }

        public static void SetFontColorToOddRows(ExcelWorksheet worksheet, Color color)
        {
            for (int i = 3; i <= worksheet.Dimension.Rows; i++)
            {
                if (i % 2 != 0)
                {
                    worksheet.Row(i).Style.Font.Color.SetColor(color);
                }
            }
        }

        public static void AddHeaderColumnsNames(ExcelWorksheet worksheet, Dictionary<string, string> headerCells)
        {
            foreach (var cell in headerCells)
            {
                worksheet.Cells[cell.Key].Value = cell.Value;
            }
        }

        private static void AddPersonToNextEmptyRow(Person person, ExcelWorksheet worksheet)
        {
            int row = worksheet.Dimension.Rows + 1;
            string nameCell = "A" + row;
            string ageCell = "B" + row;
            string scoreCell = "C" + row;
            worksheet.Cells[nameCell].Value = person.Name;
            worksheet.Cells[ageCell].Value = person.Age;
            worksheet.Cells[scoreCell].Value = person.Score;
        }
    }
}
