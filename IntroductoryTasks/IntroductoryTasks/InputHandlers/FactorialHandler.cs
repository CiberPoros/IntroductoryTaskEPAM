using System;
using IntroductoryTasks.Utils;

namespace IntroductoryTasks.InputHandlers
{
    public class FactorialHandler : InputHandler
    {
        public override bool RequestHandle()
        {
            if (base.RequestHandle())
                return true;

            if (!Int32.TryParse(Input, out int inputValue))
            {
                OutData("Input error. Integer expected.");
                return false;
            }

            try
            {
                OutData(FactorialUtil.GetBigIntFactorial(inputValue));
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutData(e.Message);
            }

            return false;
        }

        protected override void OutHelpInfo()
        {
            OutData($"Enter non negative integer (warning: large number takes a long time) or \"{ _quitKey }\" for exit:");
        }
    }
}
