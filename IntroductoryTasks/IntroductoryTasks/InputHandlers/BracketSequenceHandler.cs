using System.Linq;
using IntroductoryTasks.Utils;

namespace IntroductoryTasks.InputHandlers
{
    public class BracketSequenceHandler : InputHandler
    {
        private string PermisChars => "{([])}";

        public override bool RequestHandle()
        {
            if (base.RequestHandle())
                return true;

            string inputSequence = Input;

            if (!IsValidInputSequence(inputSequence, PermisChars))
            {
                OutData($"Bracket sequence must contains only words in { PermisChars }.");
                return false;
            }

            if (inputSequence.Length % 2 == 1)
            {
                OutData("Bracket sequence must have even count of elements.");
                return false;
            }

            string messageOfValidity = BracketSequenceUtil.IsCorrect(inputSequence, PermisChars.Substring(0, PermisChars.Length / 2),
                new string(PermisChars.Substring(PermisChars.Length / 2).Reverse().ToArray())) ? "valid" : "invalid";

            OutData($"Bracket sequence is { messageOfValidity }");

            return false;
        }

        protected override void OutHelpInfo()
        {
            OutData($"Enter bracket sequence with words from \"{ PermisChars }\" or \"{ _quitKey }\" for exit:");
        }

        private bool IsValidInputSequence(string sequence, string permisChars)
        {
            foreach (var c in sequence)
                if (!permisChars.Contains(c))
                    return false;

            return true;
        }
    }
}
