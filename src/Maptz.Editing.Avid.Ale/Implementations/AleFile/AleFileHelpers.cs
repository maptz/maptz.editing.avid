namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Helper functions for ALE Files. 
    /// </summary>
    internal static class AleFileHelpers
    {
        /// <summary>
        /// Deserialize an AleFile from a string. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static AleFile Deserialize(string input)
        {
            var retval = new AleFile();
            retval.GlobalHeadings = GlobalHeadingsHelpers.Deserialize(input);
            retval.Columns = ColumnsHelpers.Deserialize(input);
            retval.Clips = ClipHelpers.Deserialize(input, retval.Columns);
            return retval;
        }
    }
}