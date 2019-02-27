using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Maptz.Editing.Avid.Markers.Xml
{

    [XmlRoot(ElementName = "ListElem")]
    public class ListElem
    {
        [XmlElement(ElementName = "AvProp")]
        public List<AvProp> AvProp { get; set; }
    }
}