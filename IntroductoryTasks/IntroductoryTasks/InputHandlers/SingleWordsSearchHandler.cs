using IntroductoryTasks.Utils;

namespace IntroductoryTasks.InputHandlers
{
    public class SingleWordsSearchHandler : InputHandler
    {
        public override bool RequestHandle()
        {
            if (base.RequestHandle())
                return true;

            string inputString = Input;
            var separators = ReadSeparators();
            var result = SingleWordsSearchUtil.GetSingleWords(inputString, separators + " ");

            OutData("Result:");
            OutData(result, " ");
            return false;
        }

        private string ReadSeparators()
        {
            OutData("Enter string with separator symbols (space added by default):");
            ReadData();
            return Input;
        }

        protected override void OutHelpInfo()
        {
            OutData($"Enter string or { _quitKey } for exit:");
        }
    }
}
