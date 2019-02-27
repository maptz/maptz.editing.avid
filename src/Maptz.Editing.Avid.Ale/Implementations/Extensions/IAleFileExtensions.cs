using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    public static class IAleFileExtensions
    {
        /// <summary>
        /// Serializes an ALE file to a string.
        /// </summary>
        /// <param name="aleFile"></param>
        /// <returns></returns>
        public static string Serialize(this IAleFile aleFile)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(aleFile.GlobalHeadings.Serialize());
            stringBuilder.Append(aleFile.Columns.Serialize());
            stringBuilder.AppendLine("Data");
            foreach (var clip in aleFile.Clips)
                stringBuilder.AppendLine(clip.Serialize(aleFile.Columns));
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Remove any empty columns from the IAleFile instance.
        /// </summary>
        /// <param name="aleFile"></param>
        public static void RemoveEmptyColumns(this IAleFile aleFile)
        {
            List<string> emptyColumns = new List<string>();
            foreach (var column in aleFile.Columns)
            {
                bool isEmpty = true;
                foreach (var clip in aleFile.Clips)
                {
                    if (!clip.ContainsKey(column))
                        continue;
                    if (string.IsNullOrWhiteSpace(clip[column]))
                        continue;
                    isEmpty = false;
                    break;
                }
                if (isEmpty)
                    emptyColumns.Add(column);
            }

            foreach (var emptyColumn in emptyColumns)
            {
                foreach (var clip in aleFile.Clips)
                    if (clip.ContainsKey(emptyColumn))
                        clip.Remove(emptyColumn);
                aleFile.Columns.Remove(emptyColumn);
            }
        }
    }
}