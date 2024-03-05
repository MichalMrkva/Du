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
    }
}
