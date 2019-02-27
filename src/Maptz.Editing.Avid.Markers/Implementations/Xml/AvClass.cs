using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Maptz.Editing.Avid.Markers.Xml
{

    [XmlRoot(ElementName = "AvClass")]
    public class AvClass : AvItem
    {
        [XmlElement(ElementName = "AvProp")]
        public AvProp AvProp { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}