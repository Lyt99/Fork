using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork
{
    class FConsole
    {
        private bool newline;
        public FConsole()
        {
            this.newline = true;
        }

        public void WriteLine(string text)
        {
            this.newline = true;
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            this.newline = false;
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
            if(this.newline)
                Console.Write("> ");
            return Console.ReadLine();
        }


    }
}
