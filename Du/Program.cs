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

            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(3, listener.HeardCreation);

            for (int i = 0; i < 6; i++)
            {
                logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = $"Desc {i}", CreatedAt = DateTime.Now.AddDays(-i) });
            }

            var array = logCirkulaBuffer.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Item number: {i+1}\n{array[i].ToString()}");
            }

            logCirkulaBuffer.ReSize(60);

            logCirkulaBuffer.Clear();
        }
    }
}
