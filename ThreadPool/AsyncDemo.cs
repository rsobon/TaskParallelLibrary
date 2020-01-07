using System;

namespace ThreadPoolTest
{
    public class AsyncDemo
    {
        public event EventHandler<TestMethodCompletedEventArgs> TestMethodCompleted;

        public void TestMethod(object state)
        {
            Console.WriteLine("Test method begins.");
            var callDuration = (int)state;
            System.Threading.Thread.Sleep(callDuration);
            var result = $"My call time was {callDuration.ToString()}.";
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            TestMethodCompleted?.Invoke(this, new TestMethodCompletedEventArgs(result, threadId));
        }
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