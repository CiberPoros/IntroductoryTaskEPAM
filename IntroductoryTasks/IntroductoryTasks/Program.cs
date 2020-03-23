using IntroductoryTasks.InputHandlers;
using System;
using System.Collections.Generic;
using IntroductoryTasks.Utils;

namespace IntroductoryTasks
{
    class Program
    {
        static void Main()
        {
            ModeHandler modeHandler = new ModeHandler();
            modeHandler.RequestHandle();
        }
    }
}
