using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class RDICTCONTAIN : DICTCONTAIN
    {
        public override bool Test(string k)
        {
            return DataManager.INSTANCE.GetDictDictionary().ContainsValue(k);
        }
    }
}
