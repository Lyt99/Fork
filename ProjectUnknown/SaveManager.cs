using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class SaveManager
    {
        public static SaveManager INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new SaveManager();
                return _instance;
            }
        }
        public static string Path = "SAV\\";

        private static SaveManager _instance;
        private string _path;

        public SaveManager()
        {
            var di = new DirectoryInfo(Path);
            if (!di.Exists) di.Create();
            this._path = di.FullName;
        }


        public void Save(string name)//保存VARS FLAGS LIST
        {
            var vars = DataManager.INSTANCE.GetVarsDictionary();
            var flags = DataManager.INSTANCE.GetFlagsDictionary();
            var lists = DataManager.INSTANCE.GetListsDictionary();



            FileStream fs = new FileStream(this._path + name, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("VARS");
            
            foreach (var i in vars)
            {
                string s = String.Format("{0} {1}", i.Key, i.Value);
                sw.WriteLine(s);
            }

            sw.WriteLine("FLAGS");
            foreach (var i in flags)
            {
                string s = String.Format("{0} {1}", i.Key, i.Value);
                sw.WriteLine(s);
            }

            sw.WriteLine("LISTS");
            foreach (var i in lists)
            {
                foreach(var i1 in i.Value)
                {
                    string s = String.Format("{0} {1}", i.Key, i1);
                    sw.WriteLine(s);
                }

            }

            sw.Close();
            fs.Close();
        }

        public bool Load(string name) {

            try
            {
                DataManager.INSTANCE.GetVarsDictionary().Clear();
                DataManager.INSTANCE.GetFlagsDictionary().Clear();
                DataManager.INSTANCE.GetListsDictionary().Clear();

                StreamReader sw = new StreamReader(this._path + name);

                object dict = null;
                string s;
                while ((s = sw.ReadLine()) != null)
                {
                    if (s == null) break;

                    if (s == "VARS")
                    {
                        dict = DataManager.INSTANCE.GetVarsDictionary();
                        continue;
                    }

                    if (s == "FLAGS")
                    {
                        dict = DataManager.INSTANCE.GetFlagsDictionary();
                        continue;
                    }

                    if (s == "LISTS")
                    {
                        dict = DataManager.INSTANCE.GetListsDictionary();
                        continue;
                    }

                    if (dict == null) throw new Exceptions.RuntimeException("Save file " + name + " can't be loaded.");

                    string[] r = Helper.Split(s);
                    if (dict is Dictionary<string, string>) ((Dictionary<string, string>)dict).Add(r[0], r[1]);
                    if (dict is Dictionary<string, bool>) ((Dictionary<string, bool>)dict).Add(r[0], r[1] == "True" ? true : false);
                    if (dict is Dictionary<string, List<string>>) DataManager.INSTANCE.AddToList(r[0], r[1]);

                }
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void DoSave()
        {
            Scripter.INSTANCE.Console.Write("Please input a name：");
            string name = Scripter.INSTANCE.Console.ReadLine();
            this.Save(name + ".sav");
            Scripter.INSTANCE.Console.WriteLine("Save succeed.");
        }

        public bool DoLoad()
        {
            FConsole console = Scripter.INSTANCE.Console;
            DirectoryInfo di = new DirectoryInfo(this._path);
            var list = di.GetFiles("*.sav");
            int count = list.Length;
            if (count == 0)
            {
                console.WriteLine("No save data.");
                return false;
            }

            console.WriteLine("Please select:");
            for(int i = 0;i < count; ++i)
            {
                string s = String.Format("[{0}]{1} {2}", i, list[i].Name, list[i].LastWriteTime.ToString());
                console.WriteLine(s);
            }

            while (true) {
                try
                {
                    int selection = Convert.ToInt32(console.ReadLine());
                    this.Load(list[selection].Name);
                    console.WriteLine("Load successful.");
                    return true;
                }
                catch(Exception)
                {
                    console.WriteLine("Invaild selection.");
                    return false;
                }
                }


        }

    }
}
