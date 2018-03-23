using System;
using System.Threading;
using System.Threading.Tasks;

namespace AboutAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Todo).Start();//.Net 1.0就有

            Task.Factory.StartNew(Todo); //.Net4.0引入TPl

            Task.Run(new Action(Todo));//.Net 4.5新增

        }

        public static void Todo()
        {
            Console.WriteLine("todo something");
        }
    }
}
