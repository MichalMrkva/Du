using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du
{
    internal class Program
    {
        static void Main(string[] args)
        {

            OnCreationListener<Log> listener = new OnCreationListener<Log>();

            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(6, listener.Heard);

            for (int i = 0; i < 500; i++)
            {
                logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = "Desc", CreatedAt = DateTime.Now.AddDays(-i) });
            }

            logCirkulaBuffer.Clear();
            logCirkulaBuffer.ReSize(500);
            var array = logCirkulaBuffer.ToArray();
        }
    }
}
