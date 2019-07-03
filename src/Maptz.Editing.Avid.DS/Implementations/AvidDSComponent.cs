using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    [DebuggerDisplay("{In}->{Out} {Content}")]
    public class AvidDSComponent : IAvidDSComponent
    {
        public string In { get; set; }
        public string Out { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{this.In} {this.Out}\r\n{this.Content}";
        }
    }
}