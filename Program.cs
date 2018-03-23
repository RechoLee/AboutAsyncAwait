using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"我是主线程：id为{Thread.CurrentThread.ManagedThreadId}");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Todo));

            Console.ReadKey();
        }

        public static void Todo(object state)
        {
            Console.WriteLine($"我是新的线程，id为：{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
