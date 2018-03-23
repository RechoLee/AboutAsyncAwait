using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        private static bool _isDone = false;

        static void Main(string[] args)
        {
            new Thread(Todo).Start();
            new Thread(Todo).Start();

            Console.ReadKey();
        }

        public static void Todo()
        {
            if (!_isDone)
            {
                Thread.Sleep(100);//等待后 这里会执行两次
                _isDone = true;
                Console.WriteLine($"执行：{_isDone}");
            }
        }
    }
}
