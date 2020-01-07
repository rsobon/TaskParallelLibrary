using System;
using System.Threading.Tasks;

namespace TPL02
{
    public interface IWorker
    {
        event EventHandler<Worker.TestMethodCompletedEventArgs> TestMethodCompleted;

        Task DoWork(int callDuration);
    }
}