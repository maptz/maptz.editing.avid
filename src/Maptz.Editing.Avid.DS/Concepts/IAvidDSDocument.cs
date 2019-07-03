using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public interface IAvidDSDocument
    {
        string Header { get; }
        IEnumerable<IAvidDSComponent> Components { get; }
    }
}