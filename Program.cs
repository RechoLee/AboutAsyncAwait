using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                new Thread(Todo).Start();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        //关于线程执行过程的异常
        static void Todo()
        {
            throw null;
        }
    }
}
