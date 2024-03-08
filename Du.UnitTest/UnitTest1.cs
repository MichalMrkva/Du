using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Du.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [DataRow(5, 10, 30000)]
        public void BufferContentTest(int bufferSize, int newBufferSize, int logCount)
        {
            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(bufferSize);

            for (int i = 0; i < logCount; i++)
            {
                logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = $"Desc {i}", CreatedAt = DateTime.Now.AddDays(-i) });
            }

            var array = logCirkulaBuffer.ToArray();

            logCirkulaBuffer.ReSize(newBufferSize);

            logCirkulaBuffer.Clear();
        }
        [TestMethod]
        [DataRow(300,90000)]
        public void OnCreationListenerTest(int bufferSize, int logCount)
        {
            OnCreationListener<Log> listener = new OnCreationListener<Log>();

            LogCirkulaBuffer logCirkulaBuffer = new LogCirkulaBuffer(bufferSize, listener.HeardCreation);

            for (int i = 0; i < logCount; i++)
            {
                logCirkulaBuffer.Add(new Log { Priority = Priority.High, Desc = $"Desc {i}", CreatedAt = DateTime.Now.AddDays(-i) });
            }
        }
    }
}
