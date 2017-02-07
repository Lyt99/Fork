using ProjectFork.Exceptions;
using ProjectFork.Models;
using ProjectFork.ScriptLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class Helper
    {
        //创建
        public static ScriptLine CreateScriptLine(string line, ref int e, ScriptFile script)
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
            switch(command)
            {
                case "PRINT":
                    sl = new PRINT();
                    break;
                case "PRINTL":
                    sl = new PRINTL();
                    break;
                case "SLEEP":
                    sl = new SLEEP();
                    break;
                case "RUN":
                    sl = new RUN();
                    break;
                case "SETVAR":
                    sl = new SETVAR();
                    break;
                case "PRINTVARS":
                    sl = new PRINTVARS();
                    break;
                case "PRINTMULTI":
                    sl = new PRINTMULTI();
                    break;
                case "IF":
                    sl = new IF();
                    break;
                case "EXIT":
                    sl = new EXIT();
                    break;
                case "LISTADD":
                    sl = new LISTADD();
                    break;
                case "LISTDEL":
                    sl = new LISTDEL();
                    break;
                case "FOR":
                    sl = new FOR();
                    break;
                case "SET":
                    sl = new SET();
                    break;
                case "LISTCONTAIN":
                    sl = new LISTCONTAIN();
                    break;
                case "COLOR":
                    sl = new COLOR();
                    break;
                case "SWITCH":
                    sl = new SWITCH();
                    break;
                case "BREAK":
                    sl = new BREAK();
                    break;
                case "CONTINUE":
                    sl = new CONTINUE();
                    break;
                case "INPUT":
                    sl = new INPUT();
                    break;
                case "NOP":
                    sl = new NOP();
                    break;
                case "SETFLAG":
                    sl = new SETFLAG();
                    break;
                case "ADDCMD":
                    sl = new ADDCMD();
                    break;
                case "CLEAR":
                    sl = new CLEAR();
                    break;
                case "PRINTFMT":
                    sl = new PRINTFMT();
                    break;
                case "PLAYSOUND":
                    sl = new PLAYSOUND();
                    break;
                case "STOPSOUND":
                    sl = new STOPSOUND();
                    break;
                case "PLAYBGM":
                    sl = new PLAYBGM();
                    break;
                case "STOPBGM":
                    sl = new STOPBGM();
                    break;
                case "SAVE":
                    sl = new SAVE();
                    break;
                case "LOAD":
                    sl = new LOAD();
                    break;
                case "SELECT":
                    sl = new SELECT();
                    break;
                case "TITLE":
                    sl = new TITLE();
                    break;
                case "PRINTX":
                    sl = new PRINTX();
                    break;
                case "PRINTC":
                    sl = new PRINTC();
                    break;
                default:
                    throw new ParserException(line, e, script);

            }

            sl.Process(c, ref e, script);
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
