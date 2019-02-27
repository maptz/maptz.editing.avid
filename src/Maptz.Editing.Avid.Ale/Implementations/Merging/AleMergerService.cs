using System;
using System.Linq;

namespace Maptz.Editing.Avid.Ale
{

    /// <summary>
    /// A service used to Merge two ALE files. 
    /// </summary>
    public class AleMergerService : IAleMergerService
    {

        /// <summary>
        /// Merge two AleFile instances. 
        /// </summary>
        /// <param name="aleFile1"></param>
        /// <param name="aleFile2"></param>
        /// <param name="mergeMode"></param>
        /// <param name="clipComparison">An optional comparison predicate, used to determine if two clips are the same.</param>
        /// <returns></returns>
        public IAleFile Merge(IAleFile aleFile1, IAleFile aleFile2, MergeMode mergeMode, Func<IClip, IClip, bool> clipComparison = null)
        {
            var retval = aleFile1.Clone();
            MergeGlobalHeadings(retval.GlobalHeadings, aleFile2.GlobalHeadings, mergeMode);
            MergeColumns(retval.Columns, aleFile2.Columns, mergeMode);
            foreach (var clip in retval.Clips)
            {
                var clipName = clip.Name;
                var matchingClips = aleFile2.Clips.Where(p => p.Name == clip.Name);
                if (clipComparison != null)
                    matchingClips = aleFile2.Clips.Where(p => clipComparison(clip, p));

                if (matchingClips.Count() > 1)
                    throw new InvalidOperationException("The Clip Comparison shows more than one clip matches the source.");

                var matchingClip = matchingClips.FirstOrDefault();
                if (matchingClip != null)
                    MergeClip(clip as Clip, matchingClip as Clip, retval.Columns, mergeMode);
            }

            //Check for any clips in the second which aren't in the first. 
            var ale2ClipsNotIn1 =
                aleFile2.Clips.Where(p => !aleFile1.Clips.Any(q1 => string.Equals(q1["Name"], p["Name"])));

            var ale1ClipsNotIn2 =
                aleFile1.Clips.Where(p => !aleFile2.Clips.Any(q1 => string.Equals(q1["Name"], p["Name"])));

            return retval;


        }

        /// <summary>
        /// Merge two Global headings. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="globalHeadings"></param>
        /// <param name="mergeMode"></param>
        private void MergeGlobalHeadings(IGlobalHeadings g, IGlobalHeadings globalHeadings, MergeMode mergeMode)
        {
            if (mergeMode == MergeMode.AddOnly)
            {
                g.AudioFormat = g.AudioFormat != null ? g.AudioFormat : globalHeadings.AudioFormat;
                g.FilmFormat = g.FilmFormat != null ? g.FilmFormat : globalHeadings.FilmFormat;
                g.Fps = g.Fps != null ? g.Fps : globalHeadings.Fps;
                g.Tape = g.Tape != null ? g.Tape : globalHeadings.Tape;
                g.VideoFormat = g.VideoFormat != null ? g.VideoFormat : globalHeadings.VideoFormat;
            }
            else
                throw new NotImplementedException();
        }



        private void MergeClip(IClip clip, IClip matchingClip, IColumns columns, MergeMode mergeMode)
        {
            if (mergeMode == MergeMode.AddOnly)
            {
                foreach (var column in columns)
                {
                    if (matchingClip.ContainsKey(column))
                    {
                        if (!clip.ContainsKey(column))
                        {
                            clip.Add(column, matchingClip[column]);
                        }
                        else
                        {
                            if (clip[column] == null)
                                clip[column] = matchingClip[column];
                        }
                    }
                }
            }
        }


        private void MergeColumns(IColumns c, IColumns columns, MergeMode mergeMode)
        {
            if (mergeMode == MergeMode.AddOnly)
            {
                var columnsToAdd = columns.Except(c);
                foreach (var columnToAdd in columnsToAdd)
                {
                    c.Add(columnToAdd);
                }
            }
            else
                throw new NotImplementedException();
        }

    }
}
