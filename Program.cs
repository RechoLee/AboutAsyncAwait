using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Todo).Start("arg1");

            new Thread(() => { Todo("arg1", "arg2", "arg3"); }).Start();

            Task.Run(() => { Todo("arg1,task","arg2","arg3"); });

            Console.ReadKey();
        }

        public static void Todo(object state)
        {
            Console.WriteLine($"我是新的线程，id为：{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void Todo(string arg1, string arg2, string arg3)
        {
            //Todo
            Console.WriteLine($"{arg1} {arg2} {arg3}");
        }
    }
}
