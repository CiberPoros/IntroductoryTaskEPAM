using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductoryTasks
{
    public static class SingleWordsSearchUtil
    {
        public static ICollection<string> GetSingleWords(string s) => GetSingleWords(s, new HashSet<char> { ' ', ',', '.', '?', '!', ':', ';' });

        public static ICollection<string> GetSingleWords(string s, HashSet<char> separators)
        {
            HashSet<string> result = new HashSet<string>();

            int startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (separators.Contains(s[i]))
                {
                    if (i != startIndex)
                        result.Add(s.Substring(startIndex, i - startIndex));

                    startIndex = i + 1;
                }
            }

            return result;
        }
    }
}
