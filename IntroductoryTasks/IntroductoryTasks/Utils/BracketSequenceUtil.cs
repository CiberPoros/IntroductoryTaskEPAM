using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductoryTasks.Utils
{
    public static class BracketSequenceUtil
    {
        public static bool IsCorrect(string sequence, string openBracketChars, string closeBracketChars)
        {
            if (openBracketChars.Length != closeBracketChars.Length)
                throw new ArgumentException("Each opening bracket must have closing pair.");

            if ((openBracketChars + closeBracketChars).Distinct().Count() != openBracketChars.Length + closeBracketChars.Length)
                throw new ArgumentException("Bracket symbols can't be repeated.");

            Dictionary<char, char> closeToOpenBracketMap = new Dictionary<char, char>(openBracketChars.Length);
            for (int i = 0; i < openBracketChars.Length; i++)
                closeToOpenBracketMap.Add(closeBracketChars[i], openBracketChars[i]);

            Stack<char> stack = new Stack<char>();
            foreach (var c in sequence)
            {
                if (closeToOpenBracketMap.ContainsValue(c))
                    stack.Push(c);
                else 
                {
                    if (stack.Count <= 0)
                        return false;

                    if (closeToOpenBracketMap.ContainsKey(c))
                    {
                        if (closeToOpenBracketMap[c] != (stack.Pop()))
                            return false;
                    }
                    else
                        throw new ArgumentException("sequence", "Unknown char in bracket sequence.");
                }     
            }

            return stack.Count == 0;
        }
    }
}
