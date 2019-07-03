using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public interface IAvidDSComponent
    {
         string In { get;  }
         string Out { get;  }
         string Content { get;  }
    }
}