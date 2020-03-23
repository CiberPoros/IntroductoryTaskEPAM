using System;
using System.Collections.Generic;
using System.Linq;
using IntroductoryTasks.Utils;

namespace IntroductoryTasks.InputHandlers
{
    public class BinarySearchHandler : InputHandler
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
                OutData("Integer numbers must be form [-2^31 .. 2^31).");
                return false;
            }

            if (!IsSorted(list))
                return false;

            HadnleSearch(list);
            return false;
        }

        private bool IsSorted(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
                if (list[i] < list[i - 1])
                {
                    OutData("Input array must be sorted.");
                    return false;
                }

            return true;
        }

        private void HadnleSearch(List<int> list)
        {
            for (; ; )
            {
                var key = ReadKeyValue();
                if (key == null)
                    return;

                var result = BinarySearchUtil.BinarySearch(list, (int)key);
                string isExists = result >= 0 ? "value is found; index = " : "value is not found; index of bit addition of first large (count if first large not exists) = ";
                OutData($"Result: { isExists }{ result }");
            }
        }

        private int? ReadKeyValue()
        {
            for (; ; )
            {
                OutData($"Enter value for seaching or \"{ _quitKey }\" for exit:");

                ReadDataWithTrim();
                if (CheckQuit())
                    return null;

                if (!Int32.TryParse(Input, out int result))
                {
                    OutData("Input error. Integer expected.");
                    continue;
                }

                return result;
            }
        }

        protected override void OutHelpInfo()
        {
            OutData($"Enter sorted array of integer separated by spaces or \"{ _quitKey }\" for exit:");
        }
    }
}
