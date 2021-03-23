using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public interface IAvidDSDocumentWriter
    {
        string WriteToString(IAvidDSDocument document);
        void WriteToFile(IAvidDSDocument document, string filePath);
    }

    public interface IAvidDSDocumentReader
    {
        IAvidDSDocument Read(string dsText);
    }
}