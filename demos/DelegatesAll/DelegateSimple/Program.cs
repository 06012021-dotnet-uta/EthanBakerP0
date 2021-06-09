namespace DelegateSimple
{

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
            

            myDelegeteClass.myAction = myMethod.Method1;
            myDelegeteClass.myAction += myMethod.Method2;
            myDelegeteClass.myAction += myMethod.Method3;
            myDelegeteClass.myAction();
            myDelegeteClass.myActionParameter = myMethod.ActionMethod;
            myDelegeteClass.myActionParameter(3);

            myDelegeteClass.myFuncDelegate = myMethod.FuncMethod1;
            myDelegeteClass.myFuncDelegate();


        }
    }
}
