using System;

namespace EAP
{
    public class AsyncDemo
    {
        public void TestMethod(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine("Test method begins.");
            System.Threading.Thread.Sleep((int)e.Argument);
            var result = new TestMethodResult
            {
                Result = $"My call time was {e.Argument}.",
                ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId
            };
            e.Result = result;
        }
    }

    public class TestMethodResult
    {
        public string Result { get; set; }

        public int ThreadId { get; set; }
    }
}