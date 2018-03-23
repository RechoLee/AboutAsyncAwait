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
                var task = Task.Run(() => { Todo(); });
                task.Wait();

                var strTask = Task.Run(() => Get());
                var result = strTask.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            Console.ReadKey();
        }

        //关于线程执行过程的异常
        static void Todo()
        {
            try
            {
                throw null;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        static string Get()
        {
            throw null;
        }
    }
}
