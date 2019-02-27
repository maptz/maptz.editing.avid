using System;
using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    public static class IGlobalHeadingsExtensions
    {
        /// <summary>
        /// Serialize an IGlobalHeadings instance. 
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static string Serialize(this IGlobalHeadings g)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Heading");
            stringBuilder.AppendLine(string.Format("{0}\tTABS", GlobalHeadingsConstants.FIELD_DELIM));
            if (!string.IsNullOrWhiteSpace(g.VideoFormat))
                stringBuilder.AppendLine(string.Format("{0}\t{1}", GlobalHeadingsConstants.VIDEO_FORMAT, g.VideoFormat));
            if (!string.IsNullOrWhiteSpace(g.FilmFormat))
                stringBuilder.AppendLine(string.Format("{0}\t{1}", GlobalHeadingsConstants.FILM_FORMAT, g.FilmFormat));
            if (!string.IsNullOrWhiteSpace(g.AudioFormat))
                stringBuilder.AppendLine(string.Format("{0}\t{1}", GlobalHeadingsConstants.AUDIO_FORMAT, g.AudioFormat)); //optional
            if (!string.IsNullOrWhiteSpace(g.Tape))
                stringBuilder.AppendLine(string.Format("{0}\t{1}", GlobalHeadingsConstants.TAPE, g.Tape)); //NOTE IF you omit this field, the tfile name becomes the global tape name. 
            if (!string.IsNullOrWhiteSpace(g.Fps))
                stringBuilder.AppendLine(string.Format("{0}\t{1}", GlobalHeadingsConstants.FPS, g.Fps));
            stringBuilder.Append(Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}