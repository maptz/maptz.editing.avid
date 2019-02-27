using System.Collections.Generic;
namespace Maptz.Editing.Avid.Ale
{
    public interface IClip : IDictionary<string,string>
    {
        /// <summary>
        /// Gets the name of the Clip
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Get the number of values in the Clip. 
        /// </summary>
        int ValueCount { get; }
    }
}