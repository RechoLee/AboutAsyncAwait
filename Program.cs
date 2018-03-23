using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        //共享资源
        private static string shareRes="ss";
        /// <summary>
        /// 信号量 用于不同线程对共享资源的访问
        /// </summary>
        private static Semaphore _sem = new Semaphore(2,3);//初始允许进入的线程数量，最大允许多少个线程同时访问共享资源
        static void Main(string[] args)
        {
            for (int i = 1; i <9; i++)
            {
                new Thread(Enter).Start(i);
            }
            Console.ReadKey();
        }

        static void Enter(object id)
        {
            Console.WriteLine($"{id}号开始排队。。。");
            _sem.WaitOne();

            //共享的代码片段，需要用信号量控制
            Console.WriteLine($"{id}号进入了共享区");
            Thread.Sleep(2000);

            //出去时候释放
            _sem.Release();
            Console.WriteLine($"{id}执行完成");
        }
    }
}
