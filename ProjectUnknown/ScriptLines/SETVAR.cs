using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SETVAR : SET
    {
        protected override void Set(string k, string s)
        {
            DataManager.INSTANCE.SetVars(k, s);
        }
    }
}
