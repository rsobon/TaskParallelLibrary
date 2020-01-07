using System;

namespace APM01
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep(callDuration);
            threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            return $"My call time was {callDuration.ToString()}.";
        }
    }

    public delegate string AsyncMethodCaller(int callDuration, out int threadId);
}