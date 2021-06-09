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
        public void ActionMethod(int x){

             Console.WriteLine($"This is a method for an action delegation with int {x} ");
        }
        public int FuncMethod1(){

             Console.WriteLine($"Type a number");
             int usersInt;
             bool m = Int32.TryParse(Console.ReadLine(), out usersInt);
             return usersInt;
        }
        public string FuncMethod2(string x){

            Console.WriteLine($"This is a method for an action delegation with int {x} ");
            return x;
        }
    }
}
