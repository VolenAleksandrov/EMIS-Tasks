using System.Collections.Generic;

namespace _01.GenerateExcelFile
{
    using System;
    using System.Drawing;
    using GenerateExelFile;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    class GenerateExcelFile
    {
        static void Main()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("First sheet");
                AddHeaderColumnsNames(ws, Utilities.HeaderCells);
                ws.Row(1).Style.Font.Bold = true;
                ws.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Row(1).Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                GenerateRowsWithRandomValues(Utilities.RowsToGenerate, Utilities.Names, ws);
                SetFontColorToOddRows(ws, Color.Green);
                ws.Cells["E2"].Formula = "=AVERAGE(C2:C100001)";
                package.SaveAs(new System.IO.FileInfo(@"D:\EMIS\scores.xlsx"));
            }
        }

        private static void GenerateRowsWithRandomValues(int rowsCount, string[] names, ExcelWorksheet ws)
        {
            Random random = new Random();
            for (int i = 0; i < rowsCount; i++)
            {
                string randomName = names[random.Next(0, names.Length - 1)];
                int randomAge = random.Next(20, 80);
                int randomScore = random.Next(0, 100);
                Person person = new Person(randomName, randomAge, randomScore);
                AddPersonToNextEmptyRow(person, ws);
            }
        }

        private static void SetFontColorToOddRows(ExcelWorksheet ws, Color color)
        {
            for (int i = 3; i <= ws.Dimension.Rows; i++)
            {
                if (i % 2 != 0)
                {
                    ws.Row(i).Style.Font.Color.SetColor(color);
                }
            }
        }

        private static void AddHeaderColumnsNames(ExcelWorksheet ws, Dictionary<string, string> headerCells)
        {
            foreach (var cell in headerCells)
            {
                ws.Cells[cell.Key].Value = cell.Value;
            }
        }

        private static void AddPersonToNextEmptyRow(Person person, ExcelWorksheet ws)
        {
            int row = ws.Dimension.Rows + 1;
            string nameCell = "A" + row;
            string ageCell = "B" + row;
            string scoreCell = "C" + row;
            ws.Cells[nameCell].Value = person.Name;
            ws.Cells[ageCell].Value = person.Age;
            ws.Cells[scoreCell].Value = person.Score;
        }
    }
}
