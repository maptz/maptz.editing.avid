using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Maptz.Editing.Avid.Markers.Xml;
namespace Maptz.Editing.Avid.Markers
{

    public interface IMarkersReader
    {
        Task<IEnumerable<Marker>> ReadFromXmlFileAsync(string filePath);
        Task<IEnumerable<Marker>> ReadFromTextFileAsync(string filePath);
    }
}