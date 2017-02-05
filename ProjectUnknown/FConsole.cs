using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class FConsole
    {
        public FConsole()
        {

        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void SetTextColor(string color)
        {
            try
            {
                ConsoleColor c = (ConsoleColor)System.Enum.Parse(typeof(ConsoleColor), color);
                Console.ForegroundColor = c;
            }catch
            {
                return;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }


    }
}
