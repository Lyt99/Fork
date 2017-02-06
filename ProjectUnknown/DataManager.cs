using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class DataManager
    {
        public static DataManager INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new DataManager();
                return _instance;
            }
        }

        public static string DictPath = "DICT\\";

        private static DataManager _instance;
        private Dictionary<string, string> _vars;
        private Dictionary<string, List<string>> _lists;
        private Dictionary<string, bool> _flags;
        private Dictionary<string, string> _dict;
        private string _dictpath;

        public DataManager()
        {
            this._dictpath = new DirectoryInfo(DictPath).FullName;
            this._lists = new Dictionary<string, List<string>>();
            this._vars = new Dictionary<string, string>();
            this._flags = new Dictionary<string, bool>();
            this._dict = new Dictionary<string, string>();
        }

        public void Start()
        {
            DirectoryInfo di = new DirectoryInfo(this._dictpath);
            foreach(var i in di.GetFiles("*.zd"))
            {
                this.AddToDict(i.FullName);
            }
        }

        public string GetVars(string key)
        {
            return _vars.ContainsKey(key) ? _vars[key] : null;
        }

        public List<string> GetList(string key)
        {
            if (!_lists.ContainsKey(key))
                _lists.Add(key, new List<string>());
            return _lists[key];

        }

        public void SetVars(string key, string value)
        {
            if (_vars.ContainsKey(key))
                _vars[key] = value;
            else
                _vars.Add(key, value);
        }

        public void AddToList(string key, string value)
        {
            if (!_lists.ContainsKey(key)) _lists.Add(key, new List<string>());
            _lists[key].Add(value);
        }

        public void DelFromList(string key, string value)
        {
            if (!_lists.ContainsKey(key)) return;
            _lists[key].Remove(value);
        }

        public void SetFlag(string key, bool flag)
        {
            if (_flags.ContainsKey(key))
                _flags[key] = flag;
            else
                _flags.Add(key, flag);
        }

        public bool GetFlag(string key)
        {
            return _flags.ContainsKey(key) ? _flags[key] : false;
        }

        public Dictionary<string, string> GetVarsDictionary()
        {
            return this._vars;
        }

        public Dictionary<string, bool> GetFlagsDictionary()
        {
            return this._flags;
        }

        public Dictionary<string, string> GetDictDictionary()
        {
            return this._dict;
        }

        private void AddToDict(string filename)
        {
            string[] r = File.ReadAllLines(filename);
            foreach(string i in r)
            {
                string[] a = Helper.Split(i);
                this._dict.Add(a[0], a[1]);
            }
        }
    }
}
