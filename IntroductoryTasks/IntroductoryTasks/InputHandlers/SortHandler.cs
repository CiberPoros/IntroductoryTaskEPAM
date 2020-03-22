using System;
using System.Collections.Generic;
using System.Linq;
using IntroductoryTasks.Utils;

namespace IntroductoryTasks.InputHandlers
{
    public class SortHandler : InputHandler
    {
        public override bool RequestHandle()
        {
            if (base.RequestHandle())
                return true;

            List<string> values = Input.Split().Where(s => !string.IsNullOrEmpty(s)).ToList();
            List<int> list = null;

            try
            {
                list = (from val in values
                        select Convert.ToInt32(val)).ToList();
            }
            catch (FormatException)
            {
                OutData("Input string must contains only integer numbers.");
                return false;
            }
            catch (OverflowException)
            {
                OutData("Integer numbers must be from [-2^31 .. 2^31).");
                return false;
            }

            SortUtil.Sort(list);
            OutData("Result:");
            OutData(list, " ");
            return false;
        }

        protected override void OutHelpInfo()
        {
            OutData($"Enter array of integer separated by spaces or \"{ _quitKey }\" for exit:");
        }
    }
}
