using System;
using System.Collections.Generic;
using TextProcessing.Legacy;

namespace TextProcessing.Legacy.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ СИСТЕМЫ ОБРАБОТКИ ТЕКСТА ===");
            Console.WriteLine("Библиотека: TextProcessing.Legacy (Библиотека классов)");
            Console.WriteLine("Демо: TextProcessing.Legacy.Demo (Консольное приложение)");
            Console.WriteLine("=============================================");
            Console.WriteLine();
            var analyzer = new TextAnalyzer();
            var formatter = new TextFormatter();
            var processor = new TextProcessor();

            string testText = "   Привет    мир   это    тестовый     текст   ";
            Console.WriteLine("МОДУЛЬ 1: АНАЛИЗАТОР ТЕКСТА");
            Console.WriteLine("Исходный текст: '" + testText + "'");
            Console.WriteLine();

            Console.WriteLine("1. Полный анализ:");
            var analysis = analyzer.AnalyzeEverything(testText);
            Console.WriteLine($"   Количество слов: {analysis["word_count"]}");
            Console.WriteLine($"   Длина самого длинного слова: {analysis["longest_word_length"]}");
            Console.WriteLine();

            Console.WriteLine("2. Подсчет слов (альтернативный метод):");
            int wordCount = analyzer.CountWords(testText);
            Console.WriteLine($"   Количество слов: {wordCount}");
            Console.WriteLine();

            Console.WriteLine("3. Самое длинное слово:");
            string longest = analyzer.FindLongestWord(testText);
            Console.WriteLine($"   Самое длинное слово: '{longest}'");
            Console.WriteLine();

            Console.WriteLine("4. Частотность символов:");
            analyzer.CharacterFrequencyAnalysis("Привет Мир!");
            Console.WriteLine();

            Console.WriteLine("МОДУЛЬ 2: ФОРМАТИРОВЩИК ТЕКСТА");
            Console.WriteLine();

            Console.WriteLine("1. Удаление лишних пробелов:");
            string cleanText1 = formatter.RemoveExtraSpaces(testText);
            Console.WriteLine($"   Результат: '{cleanText1}'");

            string cleanText2 = formatter.NormalizeSpaces(testText);
            Console.WriteLine($"   Альтернативный метод: '{cleanText2}'");
            Console.WriteLine();

            Console.WriteLine("2. Изменение регистра:");
            string lowerCase = formatter.ChangeTextCase(testText, 0);
            string upperCase = formatter.ChangeTextCase(testText, 1);
            Console.WriteLine($"   Нижний регистр: '{lowerCase}'");
            Console.WriteLine($"   Верхний регистр: '{upperCase}'");
            Console.WriteLine();

            Console.WriteLine("3. Выравнивание текста:");
            string alignedText = formatter.AlignText(
                "Это более длинный текст который нужно выровнять по ширине для демонстрации функциональности",
                30);
            Console.WriteLine("   Выровненный текст (ширина 30):");
            Console.WriteLine(alignedText);
            Console.WriteLine();

            Console.WriteLine("4. Полная обработка текста:");
            processor.ProcessCompleteText("   Другой   пример   текста   для   обработки   ");
            Console.WriteLine();

            Console.WriteLine("5. Полный анализ через TextProcessor:");
            var fullAnalysis = processor.FullTextAnalysis(testText);
            Console.WriteLine("   Полный анализ завершен!");
            Console.WriteLine();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}