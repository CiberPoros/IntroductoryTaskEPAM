using System;
using System.Collections.Generic;

namespace IntroductoryTasks.InputHandlers
{
    public abstract class InputHandler
    {
        protected const string _quitKey = "q";

        protected string Input { get; private set; }

        protected abstract void OutHelpInfo();

        public virtual bool RequestHandle()
        {
            OutHelpInfo();

            ReadDataWithTrim();
            return CheckQuit();
        }

        protected void ReadDataWithTrim() => Input = Console.ReadLine().Trim(' ');

        protected void ReadData() => Input = Console.ReadLine();

        protected void OutData<T>(T data) => Console.WriteLine(data.ToString());

        protected void OutData<T>(IEnumerable<T> data, string separator)
        {
            foreach (var s in data)
                Console.Write(s.ToString() + separator);

            Console.WriteLine();
        }

        protected bool CheckQuit() => Input == _quitKey;
    }
}
