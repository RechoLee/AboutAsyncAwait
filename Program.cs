using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"主线程id:{Thread.CurrentThread.ManagedThreadId}");
            Test();

            Console.ReadKey();
        }

        static async Task Test()
        {
            var name=await GetName();
            Console.WriteLine($"线程id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(name);
        }

        static async Task<string> GetName()
        {
            await Task.Delay(1000);
            Console.WriteLine($"线程id:{Thread.CurrentThread.ManagedThreadId}");

            return "hello";
        }
    }
}
