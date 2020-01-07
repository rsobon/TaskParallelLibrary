using System;

namespace APM02
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public SomeResult TestMethod(int callDuration, int threadId)
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep(callDuration);
            var result = new SomeResult();
            result.ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            result.Result = $"My call time was {callDuration.ToString()}.";
            return result;
        }
    }

    public class SomeResult
    {
        public int ThreadId { get; set; }
        public string Result { get; set; }
    }

    public delegate SomeResult AsyncMethodCaller(int callDuration, int threadId);
}