using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maptz.Editing.Avid.Ale
{

    /// <summary>
    /// A definition for a set of columns.
    /// </summary>
    public class Columns : List<string>, IColumns
    {
        /* #region Public Constructors */
        public Columns()
        {
            //Column headings are case sensitive. 

            //The first headings are required.
            this.Add("Name");
            this.Add("Tracks");
            this.Add("Start");
            this.Add("End");
        }
        /* #endregion Public Constructors */
        /* #region Public Methods */

        /// <summary>
        /// Add a new column. 
        /// </summary>
        /// <param name="value"></param>
        public new void Add(string value)
        {
            //if (this.Count >= 64)
            //    throw new InvalidOperationException("A ColumnHeadings object cannot have more than 64 headings.");
            base.Add(value);
        }

        /// <summary>
        /// Add common column headings. 
        /// </summary>
        public void AddCommonHeadings()
        {
            this.Add("Audio");
            this.Add("Auxiliary Ink");
            this.Add("Auxiliary TC1");
            this.Add("Auxiliary TC2");
            this.Add("Auxiliary TC3");
            this.Add("Auxiliary TC4");
            this.Add("Auxiliary TC5");
            this.Add("Camera");
            this.Add("Camroll");
            this.Add("Duration");
            this.Add("FPS");
            this.Add("Film TC");
            this.Add("Ink Number");
            this.Add("Mark IN");
            this.Add("Mark OUT");
            this.Add("KN Duration");
            this.Add("KN End");
            this.Add("KN Start");
            this.Add("Labroll");
            this.Add("Perf");
            this.Add("Auxiliary TC5");
            this.Add("Pullin");
            this.Add("Pullout");
            this.Add("Reel #");
            this.Add("Scene");
            this.Add("Shoot date");
            this.Add("Sound TC");
            this.Add("Soundroll");
            this.Add("TC 24");
            this.Add("TC 25P");
            this.Add("TC 25");
            this.Add("TC 30");
            this.Add("Take");
            this.Add("Tape");
            this.Add("DESCRIPT");
            this.Add("COMMENTS");
        }

        /// <summary>
        /// Add of columns
        /// </summary>
        /// <param name="value"></param>
        public new void AddRange(IEnumerable<string> value)
        {
            //if (this.Count + value.Count() >= 64)
            //    throw new InvalidOperationException("A ColumnHeadings object cannot have more than 64 headings.");
            base.AddRange(value);
        }
        public override string ToString()
        {
            return this.Serialize();
        }
        /* #endregion Public Methods */

        public static Columns FromString(string input)
        {
            return ColumnsHelpers.Deserialize(input);
        }
    }
}