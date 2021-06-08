using System;

namespace DelegateSimple
{
    public class MethodsClass{
        public void Method1(){

            Console.WriteLine("This is method 1");

        }
        public void Method2(){

             Console.WriteLine("This is method 2");

        }
        
        public void Method3(){

             Console.WriteLine("This is method 3");

        }
        
        public void Method4(){

             Console.WriteLine("This is method 4");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegeteClass = new DelegateClass();
            MethodsClass myMethod = new MethodsClass();

            myDelegeteClass.mySimpleDelegate = myMethod.Method1;
            myDelegeteClass.mySimpleDelegate += myMethod.Method2;
            myDelegeteClass.mySimpleDelegate += myMethod.Method3;

            myDelegeteClass.mySimpleDelegate();
            
        }
    }
}
