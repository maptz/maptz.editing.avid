using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Maptz.Editing.Avid.Markers.Xml
{



    [XmlRoot(ElementName = "StreamItems", Namespace = "http://www.avid.com")]
    public class StreamItems
    {
        [XmlArray(ElementName = "XMLFileData", Namespace = "http://www.avid.com")]
        [XmlArrayItem("AvProp", Type = typeof(AvProp), Namespace = "")]
        [XmlArrayItem("AvClass", Type = typeof(AvClass), Namespace = "")]
        public List<AvItem> XMLFileData { get; set; }

        [XmlAttribute(AttributeName = "Avid", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Avid { get; set; }
    }
}