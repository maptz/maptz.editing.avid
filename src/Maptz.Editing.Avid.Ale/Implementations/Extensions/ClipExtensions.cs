using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Extension methods for Clip instances. 
    /// </summary>
    public static class ClipExtensions
    {
        /* #region Internal Static Methods */

        /// <summary>
        /// Clone a clip. 
        /// </summary>
        /// <param name="clip"></param>
        /// <returns></returns>
        internal static Clip Clone(this Clip clip)
        {
            return new Clip(clip);
        }

      
        /* #endregion Internal Static Methods */
    }
}