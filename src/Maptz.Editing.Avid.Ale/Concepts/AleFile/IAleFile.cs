using System.Collections.Generic;
namespace Maptz.Editing.Avid.Ale
{
    public interface IAleFile
    {
        /// <summary>
        /// Gets the clips
        /// </summary>
        IEnumerable<IClip> Clips
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the columns
        /// </summary>
        IColumns Columns
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the Global headings.
        /// </summary>
        IGlobalHeadings GlobalHeadings
        {
            get;
            set;
        }

        IAleFile Clone();
    }
}