using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLib
{
    public class FileLogger : IMyLogger
    {
        StreamWriter w = new StreamWriter("log.txt");
        public void Log(string message)
        {
            w.WriteLine(message);
            w.Flush();
        }

        public void Dispose()
        {
            w.Dispose();
        }
    }
}
