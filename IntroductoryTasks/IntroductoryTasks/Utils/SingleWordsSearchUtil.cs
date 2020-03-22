using System.Collections.Generic;
using System.Linq;

namespace IntroductoryTasks.Utils
{
    public static class SingleWordsSearchUtil
    {
        public static ICollection<string> GetSingleWords(string str, IEnumerable<char> separators)
        {
            HashSet<char> separatorsSet = new HashSet<char>(separators);
            Dictionary<string, int> wordToWordCountMap = new Dictionary<string, int>();

            int startIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (separators.Contains(str[i]))
                {
                    if (i != startIndex)
                        AddWordToMap(str, wordToWordCountMap, startIndex, i);

                    startIndex = i + 1;
                }
            }
            AddWordToMap(str, wordToWordCountMap, startIndex, str.Length);

            return (from kvp in wordToWordCountMap
                    where kvp.Value == 1
                    select kvp.Key).ToList();
        }

        private static void AddWordToMap(string str, Dictionary<string, int> wordToWordCountMap, int startIndex, int endIndex)
        {
            string word = str.Substring(startIndex, endIndex - startIndex);
            if (wordToWordCountMap.ContainsKey(word))
                wordToWordCountMap[word]++;
            else
                wordToWordCountMap.Add(word, 1);
        }
    }
}
