using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Maptz.Editing.Avid.Ale
{
    public interface IAleMergerService
    {
        /// <summary>
        /// Merges two ALE files. 
        /// </summary>
        /// <param name="aleFile1"></param>
        /// <param name="aleFile2"></param>
        /// <param name="mergeMode"></param>
        /// <param name="clipComparison"></param>
        /// <returns></returns>
        IAleFile Merge(IAleFile aleFile1, IAleFile aleFile2, MergeMode mergeMode, Func<IClip, IClip, bool> clipComparison = null);
    }
}