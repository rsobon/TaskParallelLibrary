using System;
using System.Threading.Tasks;
using Autofac;

namespace TPL01
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Worker>().As<IWorker>();
            var container = builder.Build();

            var worker = container.Resolve<IWorker>();
            worker.TestMethodCompleted += OnRunWorkerCompleted;

            Task task = new Task(() => worker.DoWork(3000));
            task.Start();
            //Task.Factory.StartNew(() => worker.DoWork(3000));

            Console.WriteLine("Main thread {0} does some work.", System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        private static void OnRunWorkerCompleted(object sender, Worker.TestMethodCompletedEventArgs e)
        {
            Console.WriteLine(
                "The call executed on thread {0}, with return value \"{1}\".",
                e.ThreadId,
                e.Result);
        }
    }
}
