using System;
using System.Linq;
using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    public static class IColumnsExtensions
    {
        /// <summary>
        /// Serialize an IColumns instance. 
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static string Serialize(this IColumns columns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Column");
            var tabbedLine = string.Join("\t", columns);
            stringBuilder.AppendLine(tabbedLine);
            stringBuilder.AppendLine(Environment.NewLine);
            return stringBuilder.ToString();
        }
    }
}