using System;
using System.Linq;
using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    
    /// <summary>
    /// Contains extension methods for a Columns definition.
    /// </summary>
    public static class ColumnsExtensions
    {
        /* #region Internal Static Methods */
        /// <summary>
        /// Clones a COlumnDefinition.
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        internal static Columns Clone(this Columns columns)
        {
            var retval = new Columns();
            retval.Clear();
            foreach (var str in columns)
                retval.Add(str);
            return retval;

        }

      
        /* #endregion Internal Static Methods */
    }
}