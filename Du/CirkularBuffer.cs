using System;

namespace Du
{
    public class CirkularBuffer<T>
    {
        protected int index;
        protected T[] buffer;
        public int Length { get => buffer.Length; }
        public CirkularBuffer(int bufferSize)
        {
            index = 0;
            buffer = new T[bufferSize];
        }

        public virtual void Add(T value)
        {
            buffer[index++] = value;
            if (index > buffer.Length - 1)
                index = 0;
        }

        public virtual T[] ToArray() => buffer;

        public virtual void ReSize(int newSize) => Array.Resize(ref buffer, newSize);

        public virtual void Clear() => buffer = new T[buffer.Length];
    }
}
