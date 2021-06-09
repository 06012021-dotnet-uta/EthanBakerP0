using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodsClass asyncMethodsClass = new AsyncMethodsClass();

            string method1 = await asyncMethodsClass.Method1();
            System.Console.WriteLine($"Ethan says {method1}");
        }
    }
}
