using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Maptz.Editing.Avid.Markers.Xml
{

    [XmlRoot(ElementName = "AvProp")]
    public class AvProp : AvItem
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}