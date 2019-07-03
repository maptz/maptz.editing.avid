using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Maptz.Editing.Avid.DS
{

    public class AvidDSDocumentReader : IAvidDSDocumentReader
    {

        private const string SMPTEREGEXSTRING = "(?<Hours>\\d{2}):(?<Minutes>\\d{2}):(?<Seconds>\\d{2})(?::|;)(?<Frames>\\d{2})";
        private const string TIMECODELINEREGEX = "^\\d{2}:\\d{2}:\\d{2}:\\d{2}\\s\\d{2}:\\d{2}:\\d{2}:\\d{2}$";


        public IAvidDSDocument Read(string dsText)
        {
            if (string.IsNullOrEmpty(dsText)) return new AvidDSDocument();
            var lines = dsText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            bool isParsing = false;
            AvidDSComponent current = null;
            List<IAvidDSComponent> components = new List<IAvidDSComponent>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line == "<begin subtitles>") { isParsing = true; continue; }
                if (line == "<end subtitles>") { isParsing = false; continue; }
                if (!isParsing) continue;

                var isTCStart = Regex.IsMatch(line, TIMECODELINEREGEX);
                if (isTCStart)
                {
                    var spl = line.Split(' ');
                    var inTC = spl[0];
                    var outTC = spl[1];
                    current = new AvidDSComponent();
                    current.In = inTC;
                    current.Out = outTC;
                    components.Add(current);
                }
                else
                {
                    if (current != null)
                    {
                        current.Content += string.IsNullOrEmpty(current.Content) ? line : Environment.NewLine + line;
                    }
                }

                //So we are parsing. 
            }

            foreach(AvidDSComponent component in components)
            {
                component.Content = component.Content.Substring(0, component.Content.Length - 2); //Remove hte \r\n
            }
            return new AvidDSDocument
            {
                Components = components
            };
        }
    }
}