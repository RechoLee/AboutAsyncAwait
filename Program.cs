using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        private static bool _isDone = false;

        private static object _lock = new object();

        static void Main(string[] args)
        {
            new Thread(Todo).Start();
            new Thread(Todo).Start();

            Console.ReadKey();
        }

        public static void Todo()
        {
            //线程加锁  独占锁 在一个线程未执行完成之前别的线程不能访问

            lock(_lock){
                _isDone = true;
                Console.WriteLine($"执行：{_isDone}");
                Thread.Sleep(2000); //等待后 这里会执行两次 线程不安全

            }
        }
    }
}
