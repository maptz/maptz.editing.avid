using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Maptz.Editing.Avid.Markers.Xml;

namespace Maptz.Editing.Avid.Markers
{

    public class MarkersReader : IMarkersReader
    {
        /* #region Interface: 'Maptz.Editing.Avid.Markers.IMarkersReader' Methods */
        public async Task<IEnumerable<Marker>> ReadFromTextFileAsync(string filePath)
        {
            var markers = new List<Marker>();
            string str;
            using (var fs = new FileInfo(filePath).OpenText())
            {
                str = await fs.ReadToEndAsync();
            }

            foreach (var line in str.Split('\n'))
            {
                var parts = line.Split('\t');
                if (parts.Length < 2)
                    continue;
                var marker = new Marker();
                marker.Timecode = parts[1];
                marker.Content = parts[4];
                marker.Track = parts[2];
                marker.Color = parts[3];
                markers.Add(marker);
            }

            return markers;
        }

        public async Task<IEnumerable<Marker>> ReadFromXmlFileAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                var markers = new List<Marker>();
                XmlSerializer serializerSingle = new XmlSerializer(typeof(StreamItems)); //, new XmlRootAttribute("document"));
                StreamItems markersStreamItems;
                using (FileStream stream = File.OpenRead(filePath))
                {
                    markersStreamItems = (StreamItems)serializerSingle.Deserialize(stream);
                }

                foreach (var avClass in markersStreamItems.XMLFileData.OfType<AvClass>())
                {
                    var getValue = new Func<AvClass, string, string, string>((avc, propName, attributeType) =>
                    {
                        foreach (var listElem in avClass.List.ListElem)
                        {
                            if (listElem.AvProp.Any(q => q.Name == "OMFI:ATTB:Name" && q.Text == propName))
                            {
                                var retval = listElem.AvProp.Where(q => q.Name == attributeType).Select(p => p.Text).FirstOrDefault();
                                return retval;
                            }
                        }

                        return "";
                    }

                    );
                    var marker = new Marker()
                    { User = getValue(avClass, "_ATN_CRM_USER", "OMFI:ATTB:StringAttribute"), Date = getValue(avClass, "_ATN_CRM_DATE", "OMFI:ATTB:StringAttribute"), Time = getValue(avClass, "_ATN_CRM_TIME", "OMFI:ATTB:StringAttribute"), Content = getValue(avClass, "_ATN_CRM_COM", "OMFI:ATTB:StringAttribute"), Timecode = getValue(avClass, "_ATN_CRM_TC", "OMFI:ATTB:StringAttribute"), Color = getValue(avClass, "_ATN_CRM_COLOR", "OMFI:ATTB:StringAttribute"), Track = getValue(avClass, "_ATN_CRM_TRK", "OMFI:ATTB:StringAttribute"), Length = getValue(avClass, "_ATN_CRM_LENGTH", "OMFI:ATTB:IntAttribute"), };
                    markers.Add(marker);
                }

                return markers;
            }

            );
        }
        /* #endregion Interface: 'Maptz.Editing.Avid.Markers.IMarkersReader' Methods */
    }
}