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

            //Thread是不能返回值的
            //使用Task
            var returnStr = Task.Run<string>(() => Todo("return"));

            Console.WriteLine("返回值之前");

            Console.WriteLine($"返回值是：{returnStr.Result}");


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

        public static string Todo(string arg1)
        {
            Thread.Sleep(2000);
            return arg1;
        }
    }
}
