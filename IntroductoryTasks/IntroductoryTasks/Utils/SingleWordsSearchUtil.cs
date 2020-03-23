using System.Collections.Generic;
using System.Linq;

namespace IntroductoryTasks.Utils
{
    public static class SingleWordsSearchUtil
    {
        public static ICollection<string> GetSingleWords(string str, IEnumerable<char> separators)
        {
            HashSet<char> separatorsSet = new HashSet<char>(separators);
            Dictionary<string, int> wordToWordsCountMap = new Dictionary<string, int>();

            int startIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (separators.Contains(str[i]))
                {
                    if (i != startIndex)
                        AddWordToMap(str, wordToWordsCountMap, startIndex, i);

                    startIndex = i + 1;
                }
            }
            AddWordToMap(str, wordToWordsCountMap, startIndex, str.Length);

            return (from kvp in wordToWordsCountMap
                    where kvp.Value == 1
                    select kvp.Key).ToList();
        }

        private static void AddWordToMap(string str, Dictionary<string, int> wordToWordsCountMap, int startIndex, int endIndex)
        {
            string word = str.Substring(startIndex, endIndex - startIndex);
            if (wordToWordsCountMap.ContainsKey(word))
                wordToWordsCountMap[word]++;
            else
                wordToWordsCountMap.Add(word, 1);
        }
    }
}
