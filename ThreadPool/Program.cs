using System;

namespace ThreadPoolTest
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            AsyncDemo ad = new AsyncDemo();
            ad.TestMethodCompleted += OnRunWorkerCompleted;

            System.Threading.ThreadPool.QueueUserWorkItem(q => ad.TestMethod(q), 3000);

            Console.WriteLine("Main thread {0} does some work.", System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        private static void OnRunWorkerCompleted(object sender, TestMethodCompletedEventArgs e)
        {
            Console.WriteLine(
                "The call executed on thread {0}, with return value \"{1}\".",
                e.ThreadId,
                e.Result);
        }
    }
}
