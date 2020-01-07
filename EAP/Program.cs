using System;

namespace EAP
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var backgroundWorker = new System.ComponentModel.BackgroundWorker();
            AsyncDemo ad = new AsyncDemo();
            backgroundWorker.DoWork += ad.TestMethod;
            backgroundWorker.RunWorkerCompleted += OnRunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(3000);

            Console.WriteLine("Main thread {0} does some work.", System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        private static void OnRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result is TestMethodResult result)
            {
                Console.WriteLine(
                    "The call executed on thread {0}, with return value \"{1}\".",
                    result.ThreadId,
                    result.Result);
            }
        }
    }
}
