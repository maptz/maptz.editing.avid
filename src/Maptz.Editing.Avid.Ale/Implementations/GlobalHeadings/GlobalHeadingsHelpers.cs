using System;
namespace Maptz.Editing.Avid.Ale
{
    /// <summary>
    /// Helper methods for global headings. 
    /// </summary>
    internal static class GlobalHeadingsHelpers
    {
        private static string DelimitedField(this string input, int index, char delimiter = '\t')
        {
            if (input == null)
                return null;
            var split = input.Split(delimiter);
            if (split.Length <= index)
                return string.Empty;
            return split[index];

        }


        /// <summary>
        /// Deserialize a string to a GlobalHeadings instance. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static GlobalHeadings Deserialize(string input)
        {
            GlobalHeadings retval = new GlobalHeadings();
            var lines = input.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.StartsWith(GlobalHeadingsConstants.VIDEO_FORMAT))
                    retval.VideoFormat = line.DelimitedField(1);
                if (line.StartsWith(GlobalHeadingsConstants.FILM_FORMAT))
                    retval.FilmFormat = line.DelimitedField(1);
                if (line.StartsWith(GlobalHeadingsConstants.AUDIO_FORMAT))
                    retval.AudioFormat = line.DelimitedField(1);
                if (line.StartsWith(GlobalHeadingsConstants.TAPE))
                    retval.Tape = line.DelimitedField(1);
                if (line.StartsWith(GlobalHeadingsConstants.FPS))
                    retval.Fps = line.DelimitedField(1);
            }

            return retval;

        }
    }
}