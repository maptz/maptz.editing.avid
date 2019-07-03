using OfficeOpenXml;
using System.IO;
namespace Maptz.Editing.Avid.DS.Converters
{
    public class AvidDSToExcelConverter : IAvidDSToExcelConverter
    {
        public void Convert(IAvidDSDocument avidDSDocument, string excelFilePath)
        {
            //Create a new ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                //excelPackage.Workbook.Properties.Author = "VDWWD";
                //excelPackage.Workbook.Properties.Title = "Title of Document";
                //excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                //excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "My first EPPlus spreadsheet!";
                //You could also use [line, column] notation:
                worksheet.Cells[1, 2].Value = "This is cell B1!";

                var lineNumber = 1;
                //Headers: 
                worksheet.Cells[ lineNumber,1].Value = "In";
                worksheet.Cells[ lineNumber,2].Value = "Out";
                worksheet.Cells[ lineNumber,3].Value = "Content";
                lineNumber++;

                foreach (var component in avidDSDocument.Components)
                {
                    worksheet.Cells[ lineNumber,1].Value = component.In;
                    worksheet.Cells[ lineNumber,2].Value = component.Out;
                    worksheet.Cells[ lineNumber,3].Value = component.Content;
                    lineNumber++;
                }

                //Save your file
                FileInfo fi = new FileInfo(excelFilePath);
                excelPackage.SaveAs(fi);
            }
        }
    }
}