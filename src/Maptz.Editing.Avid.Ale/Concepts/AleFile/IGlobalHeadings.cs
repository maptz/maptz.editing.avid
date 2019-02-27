namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Global headings for the ALE file. 
    /// </summary>
    public interface IGlobalHeadings
    {
        /// <summary>
        /// The Audio format. 
        /// </summary>
        string AudioFormat { get; set; }
        /// <summary>
        /// The film format. 
        /// </summary>
        string FilmFormat { get; set; }
        /// <summary>
        /// The frames per second. 
        /// </summary>
        string Fps { get; set; }
        /// <summary>
        /// The tape. 
        /// </summary>
        string Tape { get; set; }
        /// <summary>
        /// THe Video format. 
        /// </summary>
         string VideoFormat { get; set; }
    }
}