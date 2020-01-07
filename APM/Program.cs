using System;

namespace APM
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = ad.TestMethod;

            // Initiate the asynchronous call.
            IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);

            // Main thread continues work.
            Console.WriteLine("Main thread {0} does some work.", System.Threading.Thread.CurrentThread.ManagedThreadId);

            // Call EndInvoke to wait for the asynchronous call to complete and to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);

            Console.ReadKey();
        }
    }
}
