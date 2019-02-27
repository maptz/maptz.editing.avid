using System;
using System.Text;
namespace Maptz.Editing.Avid.Ale
{

    public static class GlobalHeadingsExtensions
    {

        /// <summary>
        /// Clone a GlobalHeadings instance.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        internal static GlobalHeadings Clone(this GlobalHeadings g)
        {
            var retval = new GlobalHeadings();
            retval.AudioFormat = g.AudioFormat;
            retval.FilmFormat = g.FilmFormat;
            retval.Fps = g.Fps;
            retval.Tape = g.Tape;
            retval.VideoFormat = g.VideoFormat;
            return retval;
        }

       


    }
}