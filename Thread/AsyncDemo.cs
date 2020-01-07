using System;

namespace ThreadTest
{
    public class AsyncDemo
    {
        private readonly int _callDuration;

        public event EventHandler<TestMethodCompletedEventArgs> TestMethodCompleted;

        public AsyncDemo(int callDuration)
        {
            _callDuration = callDuration;
        }

        public void TestMethod()
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep(_callDuration);
            var result = $"My call time was {_callDuration.ToString()}.";
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