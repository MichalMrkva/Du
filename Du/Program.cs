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

            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(500, listener.Heard);

            for (int i = 0; i < 5000; i++)
            {
                logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = $"Desc {i}", CreatedAt = DateTime.Now.AddDays(-i) });
            }

            logCirkulaBuffer.Clear();
            logCirkulaBuffer.ReSize(500);
            var array = logCirkulaBuffer.ToArray();
        }
    }
}
