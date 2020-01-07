using System;
using System.Threading.Tasks;

namespace TPL01
{
    public interface IWorker
    {
        event EventHandler<Worker.TestMethodCompletedEventArgs> TestMethodCompleted;

        Task DoWork(int callDuration);
    }
}