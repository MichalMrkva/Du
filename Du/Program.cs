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
            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(6);
            logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = "Desc" , CreatedAt = DateTime.Now});
        }
    }

    public class CirkularBuffer<T>
    {
        private int index;
        private T[] buffer;
        public CirkularBuffer(int bufferSize)
        {
            index = 0;
            buffer = new T[bufferSize];
        }

        public virtual void Add(T value)
        {
            buffer[index++] = value;
            if (index > buffer.Length)
                index = 0;
        }

        public virtual T[] ToArray() => buffer;

        public void ReSize(int newSize) => Array.Resize(ref buffer, newSize);

        public void Clear() => buffer = new T[buffer.Length];
    }

    public class LogCirkulaBuffer : CirkularBuffer<Log>
    {
        public delegate void Loged();
        public event Loged OnLoged;

        public LogCirkulaBuffer(int bufferSize) : base(bufferSize) { }

        public LogCirkulaBuffer(int bufferSize, Loged loged) : base(bufferSize)
        {
            OnLoged = loged;
        }

        public override void Add(Log value)
        {
            if (!(OnLoged is null))
                OnLoged.Invoke();
            base.Add(value);
        }

    }

    public struct Log
    {
        public Priority Priority;
        public DateTime CreatedAt;
        public string Desc;
    }

    public enum Priority 
    {
        Low,
        Medium,
        High
    }
}
