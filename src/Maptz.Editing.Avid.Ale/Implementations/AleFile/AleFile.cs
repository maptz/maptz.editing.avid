using System.Collections.Generic;

namespace Maptz.Editing.Avid.Ale
{

    /// <summary>
    /// An Avid ALE log file. 
    /// </summary>
    public class AleFile : IAleFile
    {
        /* #region Public Static Methods */
        /// <summary>
        /// Create a new ALE file from an input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static AleFile FromString(string input)
        {
            return AleFileHelpers.Deserialize(input);
        }
        /* #endregion Public Static Methods */
        /* #region Public Properties */
        /// <summary>
        /// Gets the clips
        /// </summary>
        public IEnumerable<IClip> Clips
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the columns
        /// </summary>
        public IColumns Columns
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the Global headings.
        /// </summary>
        public IGlobalHeadings GlobalHeadings
        {
            get;
            set;
        }
        /* #endregion Public Properties */

        /// <summary>
        /// Copy the AleFile instance.
        /// </summary>
        /// <param name="aleFile"></param>
        /// <returns></returns>
        public IAleFile Clone()
        {
            var retval = new AleFile();
            retval.GlobalHeadings = (this.GlobalHeadings as GlobalHeadings).Clone();
            retval.Columns = (this.Columns as Columns).Clone();
            var clips = new List<Clip>();
            foreach (var clip in this.Clips)
                clips.Add((clip as Clip).Clone());
            retval.Clips = clips;
            return retval;
        }

    }
}
