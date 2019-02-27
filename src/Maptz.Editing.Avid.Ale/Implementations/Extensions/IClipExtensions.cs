using System.Text;
namespace Maptz.Editing.Avid.Ale
{
    public static class IClipExtensions
    {
        /// <summary>
        /// Serialize an IClip instance based on a set of columns. 
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="columnDefinitions"></param>
        /// <returns></returns>
        public static string Serialize(this IClip clip, IColumns columnDefinitions)
        {
            StringBuilder stringBuilder = new StringBuilder();


            foreach (var column in columnDefinitions)
            {
                if (clip.ContainsKey(column))
                    stringBuilder.Append(clip[column]);
                stringBuilder.Append("\t");
            }

            return stringBuilder.ToString();
        }

    }
}