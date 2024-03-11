using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace Du
{
    public class LogCirkulaBuffer : CirkularBuffer<Log>
    {
        public delegate void Loged(Log value);

        private event Loged OnLoged;

        public LogCirkulaBuffer(int bufferSize) : base(bufferSize) { }

        public LogCirkulaBuffer(int bufferSize, Loged loged) : base(bufferSize)
        {
            OnLoged = loged;
        }

        public override void Add(Log value)
        {
            OnLoged?.Invoke(value);
            base.Add(value);
        }

        public override Log[] ToArray()
        {
            Log[] bufferCopy = this.buffer;

            List<Log> sortedLogs = new List<Log>();

            Array.Sort(bufferCopy, (obj1, obj2) =>
            {
                if (obj1 == null)
                {
                    return obj2 == null ? 0 : 1;
                }
                else if (obj2 == null)
                {
                    return -1;
                }
                else
                {
                    return obj1.CreatedAt.CompareTo(obj2.CreatedAt);
                }
            });

            foreach (Log obj in bufferCopy)
            {
                if (obj != null)
                {
                    sortedLogs.Add(obj);
                }
            }

            return sortedLogs.ToArray();
        }
    }
}
