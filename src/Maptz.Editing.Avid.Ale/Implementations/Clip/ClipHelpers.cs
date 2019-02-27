using System;
using System.Collections.Generic;
namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Contains helper methods for clips. 
    /// </summary>
    internal static class ClipHelpers
    {
        /* #region Public Static Methods */
        /// <summary>
        /// Deserializes a clip from a string, based on a Column definition.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="columnDefinitions"></param>
        /// <returns></returns>
        internal static IEnumerable<Clip> Deserialize(string input, IColumns columnDefinitions)
        {
            List<Clip> clips = new List<Clip>();
            Clip lastClip = null;
            var lines = input.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line == "Data")
                {
                    if (lastClip != null)
                        clips.Add(lastClip);
                    lastClip = new Clip();
                }
                else if (lastClip != null && !string.IsNullOrEmpty(line))
                {
                    var lineSplit = line.Split('\t');
                    for (int j = 0; j < columnDefinitions.Count; j++)
                    {
                        var columnDefinition = columnDefinitions[j];
                        if (string.IsNullOrEmpty(columnDefinition))
                            continue;

                        if (j < lineSplit.Length)
                            lastClip.Add(columnDefinition, lineSplit[j]);
                        else
                            lastClip.Add(columnDefinition, null);
                    }
                    if (lastClip != null)
                        clips.Add(lastClip);
                    lastClip = new Clip();
                }
            }
            return clips;
        }
        /* #endregion Public Static Methods */
    }
}