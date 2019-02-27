namespace Maptz.Editing.Avid.Ale
{

    /// <summary>
    /// Contains global headings for the ALE. 
    /// </summary>
    public class GlobalHeadings : IGlobalHeadings
    {
        /* #region Public Properties */
        /// <summary>
        /// The Audio format. 
        /// </summary>
        public string AudioFormat { get; set; }
        /// <summary>
        /// The film format. 
        /// </summary>
        public string FilmFormat { get; set; }
        /// <summary>
        /// The frames per second. 
        /// </summary>
        public string Fps { get; set; }
        /// <summary>
        /// The tape. 
        /// </summary>
        public string Tape { get; set; }
        /// <summary>
        /// THe Video format. 
        /// </summary>
        public string VideoFormat { get; set; }
        /* #endregion Public Properties */

        /* #region Public Methods */
        public override string ToString()
        {
            return this.Serialize();
        }
        /* #endregion Public Methods */

    }
}