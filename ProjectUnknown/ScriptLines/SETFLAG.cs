using ProjectFork.ScriptLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SETFLAG : SET
    {
        protected override void Set(string k, string s)
        {
            if (s == "True")
            {
                DataManager.INSTANCE.SetFlag(k, true);
            }
            else if (s == "False")
            {
                DataManager.INSTANCE.SetFlag(k, false);
            }
            else
            {
                throw new Exceptions.RuntimeException(s + " is not a Boolean value.");
            }
        }
        
    }
}
