using System;
using Xunit;
using Maptz.Testing;
using System.IO;
using System.Linq;

namespace Maptz.Editing.Avid.DS.Tests
{

    public class AvidDSDocumentReaderTests
    {
        /* #region Public Methods */
        [Fact]
        public void Read_Works()
        {
            var ds = string.Empty;
            using (var str = this.GetType().Assembly.GetManifestResourceStream("Maptz.Editing.Avid.DS.Tests._resx.test.ds.txt"))
            using (var sr = new StreamReader(str))
            {
                ds = sr.ReadToEnd();
            }

            var reader = new AvidDSDocumentReader();
            var dsDocument = reader.Read(ds);
            /* #region Arrange */
            /* #endregion */

            /* #region Act */
            /* #endregion */

            /* #region Assert */
            Assert.Equal(6, dsDocument.Components.Count());
            /* #endregion */
        }
        /* #endregion Public Methods */
    }
}