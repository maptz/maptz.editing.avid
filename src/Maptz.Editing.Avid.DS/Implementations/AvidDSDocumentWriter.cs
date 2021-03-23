using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public class AvidDSDocumentWriter : IAvidDSDocumentWriter
    {
        public void WriteToFile(IAvidDSDocument document, string filePath)
        {
            var content = WriteToString(document);
            File.WriteAllText(filePath, content);
        }

        public string WriteToString(IAvidDSDocument document)
        {
            return document.ToString();
        }
    }
}