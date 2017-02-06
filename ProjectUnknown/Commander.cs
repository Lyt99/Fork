using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class Commander
    {

        public static Commander INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new Commander();
                return _instance;
            }
        }

        private static Commander _instance;


        private Dictionary<string, Models.Command> _commandList;

        public Commander()
        {
            this._commandList = new Dictionary<string, Models.Command>();
        }

        public void AddCommand(string cmdwithpars, string script)
        {
            string[] r = Helper.Split(cmdwithpars);
            string cmd = r[0];
            if (this._commandList.ContainsKey(cmd)) throw new Exceptions.RuntimeException("Command " + cmd + " was already registered");
            Models.Command c = new Models.Command();
            c.cmd = cmd;
            c.script = "Command/" + script;

            int index = 0;
            foreach(var i in r[1].Split(' '))
            {
                if (String.IsNullOrEmpty(i)) continue;
                c.pars.Add(index++, i);
            }

            this._commandList.Add(cmd, c);
        }

        public void DelCommand(string cmd)
        {
            if (this._commandList.ContainsKey(cmd))
                this._commandList.Remove(cmd);
        }

        public void RunCommand(string cmdwithpars)
        {
            string[] r = Helper.Split(cmdwithpars);
            string cmd = r[0];
            if (!this._commandList.ContainsKey(cmd)) throw new Exceptions.CommandException("Command " + cmd + " not found.");
            var command = this._commandList[cmd];
            var scriptfile = Scripter.INSTANCE.GetScriptFile(command.script);

            string[] wa = r[1].TrimEnd().Split(' ');
            if (wa.Length != command.pars.Count && !(wa.Length == 1 && String.IsNullOrEmpty(wa[0]) && command.pars.Count == 0)) throw new Exceptions.CommandException("Paraments Wrong");
            foreach(var par in command.pars)
            {
                scriptfile.SetLocalVars(par.Value, wa[par.Key]);
            }

            scriptfile.Run(Scripter.INSTANCE.Console);
        }

        public void Start()
        {
            while (true)
            {
                FConsole console = Scripter.INSTANCE.Console;
                string cmd = console.ReadLine();

                try
                {
                    this.RunCommand(cmd);
                }
                catch(Exceptions.CommandException e)
                {
                    console.WriteLine(e.Message);
                    continue;
                }
            }
        }

    }
}