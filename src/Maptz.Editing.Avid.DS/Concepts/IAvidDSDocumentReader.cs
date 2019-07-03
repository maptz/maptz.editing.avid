using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public interface IAvidDSDocumentReader
    {
        IAvidDSDocument Read(string dsText);
    }
}