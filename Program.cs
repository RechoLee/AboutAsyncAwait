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
            var task= Test();

            task.GetAwaiter().OnCompleted(
                ()=>Console.WriteLine("main:异步方法执行完成")
            );

            Console.WriteLine($"先执行异步方法之后的操作");
            Console.ReadKey();
        }

        static async Task Test()
        {
            var task=GetName();
            Console.WriteLine("先执行");
            Console.WriteLine($"线程id:{Thread.CurrentThread.ManagedThreadId}");

            //等待线程返回才会执行
            //Awaiter 不会挂起
            task.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("task执行完成 可以取数据了");

            });
            Console.WriteLine("继续执行。。。");

            //以下方法都会挂起此线程
            Console.WriteLine(await task);
            //等同与上
            Console.WriteLine(task.Result);

            //使用awaiter的getresult方法 等同于上面的方法，会挂起
            var result=task.GetAwaiter().GetResult();
        }

        static async Task<string> GetName()
        {
            await Task.Delay(3000);
            Console.WriteLine($"线程id:{Thread.CurrentThread.ManagedThreadId}");

            return "hello";
        }
    }
}
