using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maptz.Editing.Avid.Ale
{

    /// <summary>
    /// A clip in an AleFile. 
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Clip : Dictionary<string, string>, IClip
    {
        /* #region Interface: 'Maptz.Avid.Ale.IClip' Properties */

        /// <summary>
        /// Gets the clip name. 
        /// </summary>
        public string Name
        {
            get
            {
                if (this.ContainsKey("Name"))
                    return this["Name"];
                return null;
            }
        }

        /// <summary>
        /// Gets the number of values set for the clip. 
        /// </summary>
        public int ValueCount
        {
            get
            {

                return this.Keys.Count;
            }
        }
        /* #endregion Interface: 'Maptz.Avid.Ale.IClip' Properties */
        /* #region Public Constructors */
        public Clip()
        {

        }
        public Clip(IDictionary<string, string> dictionary)
            : base(dictionary)
        {

        }
        /* #endregion Public Constructors */

        /// <summary>
        /// Creates a new Clip instance from a string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="columnDefinitions"></param>
        /// <returns></returns>
        public static IEnumerable<Clip> FromString(string input, Columns columnDefinitions)
        {
            return ClipHelpers.Deserialize(input, columnDefinitions);
        }
        /* #region Public Methods */

        /// <summary>
        /// Converts the clip to a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var line1 = new List<string>();
            var line2 = new List<string>();
            foreach (var kvp in this)
            {
                line1.Add(kvp.Key);
                line2.Add(kvp.Value);
            }
            stringBuilder.AppendLine(string.Join("\t", line1));
            stringBuilder.AppendLine(string.Join("\t", line2));
            return stringBuilder.ToString();
        }
        /* #endregion Public Methods */
    }
}