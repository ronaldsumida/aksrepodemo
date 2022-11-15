using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLib
{
    public class ConsoleLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {
        }
    }
}
