using System;
using Xunit;
using Maptz.Testing;
using System.IO;

namespace Maptz.Editing.Avid.DS.Converters.Tests
{

    public class AvidDSToExcelConverterTests
    {
        /* #region Public Methods */
        [Fact]
        public void Convert_works()
        {
            using (var fixture = new UnitTestFixture())
            {
                /* #region Arrange */
                var ds = string.Empty;
                using (var str = this.GetType().Assembly.GetManifestResourceStream("Maptz.Editing.Avid.DS.Converters.Tests._resx.test.ds.txt"))
                using (var sr = new StreamReader(str))
                {
                    ds = sr.ReadToEnd();
                }

                var reader = new AvidDSDocumentReader();
                var dsDocument = reader.Read(ds);
                var excelFilePath = Path.Combine(fixture.Workspace.TempDirectoryPath, "test.xlsx");
                var converter = new AvidDSToExcelConverter();
                /* #endregion */

                /* #region Act */
                converter.Convert(dsDocument, excelFilePath);
                /* #endregion */

                /* #region Assert */
                Assert.True(File.Exists(excelFilePath));
                /* #endregion */
            }
        }
        /* #endregion Public Methods */
    }
}