using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Maptz.Editing.Avid.Markers.Xml
{

    [XmlRoot(ElementName = "List")]
    public class List
    {
        [XmlElement(ElementName = "ListElem")]

        public List<ListElem> ListElem { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}