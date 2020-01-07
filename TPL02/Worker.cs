using System;
using System.Threading.Tasks;

namespace TPL02
{
    public class Worker : IWorker
    {
        public event EventHandler<TestMethodCompletedEventArgs> TestMethodCompleted;

        public Task DoWork(int callDuration)
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep(callDuration);
            var result = $"My call time was {callDuration.ToString()}.";
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            TestMethodCompleted?.Invoke(this, new TestMethodCompletedEventArgs(result, threadId));
            return Task.CompletedTask;
        }

        public class TestMethodCompletedEventArgs : EventArgs
        {
            public TestMethodCompletedEventArgs(string result, int threadId)
            {
                Result = result;
                ThreadId = threadId;
            }

            public string Result { get; }

            public int ThreadId { get; }
        }
    }
}
