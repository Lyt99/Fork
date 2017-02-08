using ProjectFork.Exceptions;
using ProjectFork.Models;
using ProjectFork.ScriptLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class Helper
    {
        //创建
        public static ScriptLine CreateScriptLine(string line, ref int e, ScriptFile script, Models.ScriptLine belong)
        {
            string command = String.Empty, c = String.Empty;
            int pos = line.IndexOf(' ');
            if (pos == -1) command = line;
            else
            {
                command = line.Substring(0, pos).ToUpper();
                c = line.Substring(pos + 1);
            }

            if (String.IsNullOrEmpty(command) || line[0] == ';') command = "NOP";
            ScriptLine sl;

            Assembly ass = Assembly.GetExecutingAssembly();
            string cname = String.Format("ProjectFork.ScriptLines.{0}", command);

            sl = (ScriptLine)ass.CreateInstance(cname);

            if(sl == null) throw new Exceptions.ParserException(line, e, script);

            sl.Process(c, ref e, script, belong);
            return sl;

        }

        public static string GetRPath(string path1, string path2)
        {
            System.Uri uri1 = new Uri(path1);
            System.Uri uri2 = new Uri(path2);

            Uri relativeUri = uri2.MakeRelativeUri(uri1);

            return relativeUri.ToString();
        }

        public static int GetIndent(ref string text)
        {
            if (String.IsNullOrEmpty(text)) return 0;
            string t = text.Replace("\t", "    ");
            int i = 0;
            while (t[i] == ' ') ++i;
            if (i % 4 != 0) throw new Exceptions.IllegalIndentException();
            text = t.Substring(i);
            return (i + 1) / 4;
        }

        public static string Trim(string text)
        {
            return text.TrimStart(' ', '\t').TrimEnd();
        }

        public static string[] Split(string text)
        {
            int i = text.IndexOf(' ');
            if (i == -1) return new string[] { text, String.Empty };
            return new string[]{text.Substring(0, i), text.Substring(i + 1)};
        }

        public static long GetTime()
        {
            return Convert.ToInt64(((TimeSpan)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds);
        }
    }
}
