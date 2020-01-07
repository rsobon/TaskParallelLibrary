using System;

namespace APM02
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // The asynchronous method puts the thread id here.
            int threadId = 0;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;

            // Initiate the asynchronous call.
            var callback = new AsyncCallback(OnTestMethodCompleted);
            caller.BeginInvoke(3000, threadId, callback, null);

            Console.WriteLine("Main thread {0} does some work.", System.Threading.Thread.CurrentThread.ManagedThreadId);

            // We don't call EndInvoke to wait for the asynchronous call to complete, AsyncCallback will be called automatically

            Console.ReadKey();
        }

        private static void OnTestMethodCompleted(IAsyncResult result)
        {
            AsyncMethodCaller caller = (AsyncMethodCaller)((System.Runtime.Remoting.Messaging.AsyncResult)result).AsyncDelegate;

            SomeResult someResult = caller.EndInvoke(result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", someResult.ThreadId, someResult.Result);
        }
    }
}
