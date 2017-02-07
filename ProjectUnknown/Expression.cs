using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionEvaluator;
using Antlr.Runtime;
using System.Text.RegularExpressions;

namespace ProjectFork
{
    class Expression
    {

        public static Expression INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new Expression();
                return _instance;
            }
        }

        private Random _random;
        private static Expression _instance;
        private TypeRegistry _registry;

        public Expression()
        {
            this._random = new Random();
            this._registry = new TypeRegistry();
            this._registry.Add("True", true);
            this._registry.Add("False", false);
        }

        public string CalcExp(string exp)
        {
            try
            {
                var i = new CompiledExpression(exp);
                i.TypeRegistry = this._registry;
                return i.Eval().ToString();
            }
            catch(Exception)
            {
                return exp;
            }
        }

        public string ReplaceVF(string text, ScriptFile localScript)
        {
            string pattern = @"\{([A-Z]+?):([\s.-_0-9a-zA-Z]+?)\}";

            while (true)
            {
                var r = Regex.Matches(text, pattern);
                if (r.Count == 0) break;
                foreach(Match i in r)
                {
                    string var = this.getVariable(i.Groups[1].Value, i.Groups[2].Value, localScript);
                    if (var != null)
                        text = text.Replace(i.Value, var);
                    else
                        throw new Exceptions.RuntimeException("Variable " + i.Groups[2] + " not found.");
                }
            }

            //特殊变量
            text = text.Replace("{RAND}", this._random.Next(0, 100).ToString());
            text = text.Replace("{TIME}", Helper.GetTime().ToString());

            return text;
            
        }

        private string getVariable(string type, string key, ScriptFile script)
        {
            switch (type)
            {
                case "FLAG":
                    {
                        var i = DataManager.INSTANCE.GetFlagsDictionary();
                        return i.ContainsKey(key) ? i[key].ToString() : null;
                    }

                case "LOCAL":
                    if (script != null)
                    {
                        var i = script.GetLocalVarDictionary();
                        return i.ContainsKey(key) ? i[key] : null;
                    }
                    else return null;

                case "VAR":
                    {
                        var i = DataManager.INSTANCE.GetVarsDictionary();
                        return i.ContainsKey(key) ? i[key] : null;
                    }

                case "DICT":
                    {
                        var i = DataManager.INSTANCE.GetDictDictionary();
                        return i.ContainsKey(key) ? i[key] : null;
                    }
                case "RDICT":
                    {
                        var i = DataManager.INSTANCE.GetDictDictionary();
                        return i.First((e) =>
                        {
                            return e.Value == key;
                        }).Key;
                    }
                default:
                    return null;
            }
        }

        public string RandR(string text, ScriptFile script)
        {
            string t = this.ReplaceVF(text, script);
            return this.CalcExp(t);
        }

        public string UnescapeCodes(string src)
        {
            return Regex.Unescape(src);
        }

    }
}
