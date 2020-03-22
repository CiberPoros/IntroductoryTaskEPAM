using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductoryTasks
{
    public static class BracketSequenceUtil
    {
        public static bool IsCorrect(string s) => IsCorrect(s, new List<char> { '{', '(', '[' }, new List<char> { '}', ')', ']' });

        public static bool IsCorrect(string s, IList<char> openBracketChars, IList<char> closeBracketChars)
        {
            if (openBracketChars.Count != closeBracketChars.Count)
                throw new ArgumentException("Each opening bracket must have closing pair");

            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (openBracketChars.Contains(c))
                    stack.Push(c);
                else 
                {
                    int closeIndex = closeBracketChars.IndexOf(c);
                    if (closeIndex == -1)
                        throw new ArgumentException("Unknown char in bracket sequence");

                    if (openBracketChars.IndexOf(stack.Pop()) != closeIndex)
                        return false;
                }     
            }

            return stack.Count == 0;
        }
    }
}
