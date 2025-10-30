using System;
using System.Collections.Generic;

namespace TextProcessing.Legacy
{
    public class TextProcessor
    {
        private TextAnalyzer analyzer = new TextAnalyzer();
        private TextFormatter formatter = new TextFormatter();

        public void ProcessCompleteText(string text)
        {
            Console.WriteLine("=== TEXT ANALYSIS ===");
            var analysis = analyzer.AnalyzeEverything(text);
            Console.WriteLine($"Words: {analysis["word_count"]}");
            Console.WriteLine($"Longest word length: {analysis["longest_word_length"]}");

            Console.WriteLine("\n=== CHARACTER FREQUENCY ===");
            analyzer.CharacterFrequencyAnalysis(text);

            Console.WriteLine("\n=== FORMATTED TEXT ===");
            string cleaned = formatter.RemoveExtraSpaces(text);
            string formatted = formatter.AlignText(cleaned, 40);
            Console.WriteLine(formatted);
        }

        public string GetProcessedFirstWord(string text)
        {
            if (text != null && text.Length > 0 && text.Split(' ').Length > 0)
            {
                return formatter.ChangeTextCase(text.Split(' ')[0], 1);
            }
            return "";
        }

        public Dictionary<string, object> FullTextAnalysis(string text)
        {
            var result = new Dictionary<string, object>();

            var analysis = analyzer.AnalyzeEverything(text);
            var formatted = formatter.FormatEverything(text, 1);
            var longest = analyzer.FindLongestWord(text);

            result.Add("analysis", analysis);
            result.Add("formatted", formatted);
            result.Add("longest_word", longest);

            return result;
        }
    }
}