using System;
using System.Linq;
namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Helper methods for Column instances. 
    /// </summary>
    internal static class ColumnsHelpers
    {
        internal static Columns Deserialize(string input)
        {
            var retval = new Columns();
            retval.Clear();
            var lines = input.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line == "Column" && i < lines.Length - 1)
                {
                    var headingsLine = lines[i + 1];
                    var headings = headingsLine.Split('\t');
                    retval.AddRange(headings.Where(p => !string.IsNullOrWhiteSpace(p)));
                    break;
                }
            }
            return retval;
        }

    }
}