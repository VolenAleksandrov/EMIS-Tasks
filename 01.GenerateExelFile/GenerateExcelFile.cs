namespace _01.GenerateExcelFile
{
    using System.Drawing;
    using GenerateExelFile;
    using OfficeOpenXml;

    class GenerateExcelFile
    {
        static void Main()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("First sheet");
                ExcelTableManipulation.AddHeaderColumnsNames(worksheet, Utilities.HeaderCells);
                ExcelTableManipulation.CustomizeFirstHeaderRow(worksheet, Color.LightBlue);
                ExcelTableManipulation.AddRowsWithRandomValues(Utilities.RowsToGenerate, worksheet);
                ExcelTableManipulation.SetFontColorToOddRows(worksheet, Color.Green);
                ExcelTableManipulation.SetAverageFormulaToCell(worksheet, Utilities.FormulaCell, Utilities.StartFormulaCell, Utilities.EndFormulaCell);
                package.SaveAs(new System.IO.FileInfo(@"D:\EMIS\scores.xlsx"));
            }
        }
    }
}