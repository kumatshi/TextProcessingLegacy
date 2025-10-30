using System;
using System.Collections.Generic;
using System.Linq;

namespace TextProcessing.Legacy
{
    public class TextAnalyzer
    {
        // ========== МОДУЛЬ 1: АНАЛИЗАТОР ТЕКСТА ==========

        // Нарушение: "Божественная функция" - делает весь анализ в одном методе
        public Dictionary<string, int> AnalyzeEverything(string inputText)
        {
            var resultDict = new Dictionary<string, int>();

            // Подсчет количества слов (примитивный, без учета пунктуации)
            string[] wordsArray = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            resultDict.Add("word_count", wordsArray.Length);

            // Поиск самого длинного слова
            string longestWordFound = "";
            for (int i = 0; i < wordsArray.Length; i++)
            {
                if (wordsArray[i].Length > longestWordFound.Length)
                {
                    longestWordFound = wordsArray[i];
                }
            }
            resultDict.Add("longest_word_length", longestWordFound.Length);

            // Частота использования символов (неполная реализация)
            var charFrequency = new Dictionary<char, int>();
            foreach (char character in inputText.ToLower())
            {
                if (char.IsWhiteSpace(character)) continue;
                if (charFrequency.ContainsKey(character))
                    charFrequency[character]++;
                else
                    charFrequency.Add(character, 1);
            }
            // Нарушение: charFrequency вычислен, но не используется!

            return resultDict;
        }

        // Нарушение: Дублирование функциональности
        public int CountWords(string text)
        {
            return text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Нарушение: Метод делает слишком много - и считает и выводит
        public void CharacterFrequencyAnalysis(string inputString)
        {
            var frequencyMap = new Dictionary<char, int>();

            foreach (char c in inputString.ToLower())
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (frequencyMap.ContainsKey(c))
                        frequencyMap[c]++;
                    else
                        frequencyMap.Add(c, 1);
                }
            }

            // Нарушение: Вывод в консоль в библиотечном методе!
            Console.WriteLine("Character Frequency:");
            foreach (var pair in frequencyMap)
            {
                Console.WriteLine($"'{pair.Key}': {pair.Value}");
            }
        }

        public string FindLongestWord(string text)
        {
            string[] words = text.Split(' ');
            string longest = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longest.Length && words[i].Length > 0)
                {
                    longest = words[i];
                }
            }
            return longest;
        }

        // Нарушение: Магические числа
        public Dictionary<char, int> GetCharFrequency(string text, int mode)
        {
            var result = new Dictionary<char, int>();

            foreach (char c in text)
            {
                bool includeChar = false;

                // Магические числа вместо enum
                if (mode == 0) includeChar = char.IsLetterOrDigit(c);
                else if (mode == 1) includeChar = true;
                else if (mode == 2) includeChar = char.IsLetter(c);

                if (includeChar)
                {
                    char key = (mode == 3) ? c : char.ToLower(c); // Еще одно магическое число
                    if (result.ContainsKey(key))
                        result[key]++;
                    else
                        result.Add(key, 1);
                }
            }

            return result;
        }
    }
}