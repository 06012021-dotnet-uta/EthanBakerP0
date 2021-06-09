using System;

namespace DelegateSimple
{
    public class DelegateClass
    {
        public delegate void SimpleDelegate();
        public SimpleDelegate mySimpleDelegate;


        public Action myAction {get; set;}
        public Action<int> myActionParameter {get; set;}


        public Func<int> myFuncDelegate; 
        public Func<string> myFuncDelegateString; 

    }
}