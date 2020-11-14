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

    public class MarkersTextWriter : IMarkersTextWriter
    {
        public MarkersTextWriter(IOptions<MarkersTextWriterSettings> settings)
        {
            this.Settings = settings.Value;
        }

        public MarkersTextWriterSettings Settings { get; }

        public async Task WriterToTextFileAsync(IEnumerable<Marker> markers, string outputFilePath)
        {
            await Task.Run(() =>
            {
                using (var sw = new FileInfo(outputFilePath).CreateText())
                {
                    foreach (var marker in markers)
                    {
                        var resolvedContent = marker.Content.Replace("\t", " ");
                        resolvedContent = resolvedContent.Replace("\r", "");
                        resolvedContent = resolvedContent.Replace("\n", " ");
                        //NOTE there is a maximum length when importing Markers into Avid.
                        if (resolvedContent.Length > 256)
                        {
                            //if (this.Settings.ThrowWhenContentTooLong)
                            //    throw new Exception($"Marker content is too long for marker at timecode {marker.Timecode}");
                        }
                        var items = new string[]
                        {
                         marker.User,
                         marker.Timecode,
                         marker.Track,
                         marker.Color,
                         resolvedContent,
                         "1"
                        };
                        var line = string.Join("\t", items) + "\n";
                        sw.Write(line);
                    }
                }
            });

        }

    }
}