namespace IntroductoryTasks.InputHandlers
{
    public class ModeHandler : InputHandler
    {
        private const string _sortKey = "sort";
        private const string _binarySearchKey = "bs";
        private const string _singleWordsSearchKey = "splitdist";
        private const string _factorialKey = "fact";
        private const string _bracketSequenceKey = "validbs";

        public override bool RequestHandle()
        {
            for (; ; )
            {
                base.RequestHandle();

                InputHandler inputHandler;
                switch (Input)
                {
                    case _sortKey:
                        inputHandler = new SortHandler();
                        break;
                    case _binarySearchKey:
                        inputHandler = new BinarySearchHandler();
                        break;
                    case _singleWordsSearchKey:
                        inputHandler = new SingleWordsSearchHandler();
                        break;
                    case _factorialKey:
                        inputHandler = new FactorialHandler();
                        break;
                    case _bracketSequenceKey:
                        inputHandler = new BracketSequenceHandler();
                        break;
                    case _quitKey:
                        return true;
                    default:
                        OutData("Unknown command.");
                        continue;
                }

                for (; ; )             
                    if (inputHandler.RequestHandle())
                        break;
            }
        }

        protected override void OutHelpInfo()
        {
            OutData("Choose work mode. Use this commands:");
            OutData("");
            OutData($"\"{ _sortKey }\" for sorting some integer array;");
            OutData($"\"{ _binarySearchKey }\" for get index of element in sorted array;");
            OutData($"\"{ _singleWordsSearchKey }\" for get single words from string;");
            OutData($"\"{ _factorialKey }\" for get factorial of integer;");
            OutData($"\"{ _bracketSequenceKey }\" for check validity of bracket sequence;");
            OutData($"\"{ _quitKey }\" for exit;");
            OutData("");
            OutData("Enter command:");
        }
    }
}
