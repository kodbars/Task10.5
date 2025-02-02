using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._5
{
    interface ILogger
    {
        void ExceptionLogRed(string str);
        void EventLogBlue(string str);
    }
}
