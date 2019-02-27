using System.Collections.Generic;
using System.Text;

namespace Maptz.Editing.Avid.Markers
{
    public static class MarkersExtensions
    {
        /* #region Public Static Methods */
        public static string ToHtmlTable(this IEnumerable<Marker> markers)
        {
            StringBuilder tb = new StringBuilder();
            tb.AppendLine("<html><head><style>table { border-collapse: collapse;} table, th, td { border: 1px solid; padding: 10px; } .inner { display: block; min-height: 150px;}</style></head><body><table>");
            tb.AppendLine($"<thead><tr><th>Timecode</th><th>Content</th></tr></thead>");
            foreach (var marker in markers)
            {
                tb.AppendLine($"<tr><td><strong>{marker.Timecode}</strong></td><td>{marker.Content}</td></tr>");
                tb.AppendLine($"<tr><td><div class=\"inner\">&nbsp;</div></td><td></td></tr>");
            }

            tb.AppendLine("</table></body></html>");
            var retval = tb.ToString();
            return retval;
        }
        /* #endregion Public Static Methods */
    }
}