using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public class AvidDSDocument : IAvidDSDocument
    {
        public string Header { get; set; }
        public IEnumerable<IAvidDSComponent> Components { get; set; } = new IAvidDSComponent[0];
        public override string ToString()
        {
            var head = "@ This file written with the Avid Caption plugin, version 1\r\n\r\n<begin subtitles>\r\n";
            var tail = "<end subtitles>";
            var sb = new StringBuilder();
            sb.Append(head);
            foreach(var component in Components)
            {
                sb.Append(component);
                sb.AppendLine();
                sb.AppendLine();
            }
            sb.Append(tail);
            var str = sb.ToString();
            return str;
        }
    }
}