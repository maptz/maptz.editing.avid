using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Maptz.Editing.Avid.Markers.Xml;
using Microsoft.Extensions.Options;
namespace Maptz.Editing.Avid.Markers
{
    public interface IMarkersTextWriter
    {
        Task WriterToTextFileAsync(IEnumerable<Marker> markers, string outputFilePath);
    }
}