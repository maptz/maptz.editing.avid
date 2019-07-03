using OfficeOpenXml;
using System.IO;
namespace Maptz.Editing.Avid.DS.Converters
{

    public interface IAvidDSToExcelConverter
    {
        void Convert(IAvidDSDocument avidDSDocument, string excelFilePath);
    }
}