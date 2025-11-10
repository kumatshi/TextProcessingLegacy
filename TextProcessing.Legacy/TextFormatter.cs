using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessing.Legacy
{
    public class TextFormatter
    {
        // ========== МОДУЛЬ 2: ФОРМАТИРОВЩИК ТЕКСТА ==========

        // Нарушение: Два метода с одинаковой функциональностью
        public string RemoveExtraSpaces(string inputText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool previousWasSpace = false;

            for (int index = 0; index < inputText.Length; index++)
            {
                if (inputText[index] == ' ')
                {
                    if (!previousWasSpace)
                    {
                        stringBuilder.Append(inputText[index]);
                        previousWasSpace = true;
                    }
                }
                else
                {
                    stringBuilder.Append(inputText[index]);
                    previousWasSpace = false;
                }
            }
            return stringBuilder.ToString().Trim();
        }

        // Дублирование: тот же функционал, но другой алгоритм
        public string NormalizeSpaces(string text)
        {
            return string.Join(" ", text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries));
        }

        // Нарушение: Магические числа (0, 1, 2), плохие имена параметров
        public string ChangeTextCase(string input, int caseType)
        {
            switch (caseType)
            {
                case 0:
                    return input.ToLower();
                case 1:
                    return input.ToUpper();
                case 2:
                    return "Feature not implemented yet";
                default:
                    return input;
            }
        }

        // Нарушение: Слишком длинный метод, сложная логика
        public string AlignText(string input, int lineWidth)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
                return string.Empty;

            StringBuilder finalResult = new StringBuilder();
            StringBuilder currentLine = new StringBuilder();
            int lineLength = 0;

            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                string currentWord = words[wordIndex];
                int spaceNeeded = (lineLength > 0) ? 1 : 0;

                if (lineLength + currentWord.Length + spaceNeeded <= lineWidth)
                {
                    if (lineLength > 0)
                    {
                        currentLine.Append(' ');
                        lineLength++;
                    }
                    currentLine.Append(currentWord);
                    lineLength += currentWord.Length;
                }
                else
                {
                    if (currentLine.Length > 0)
                    {
                        // БАГ 2: Бесконечный цикл - условие никогда не выполнится
                        while (currentLine.Length > lineWidth)
                        {
                            currentLine.Append(' ');
                        }
                        finalResult.AppendLine(currentLine.ToString());
                    }
                    currentLine.Clear();
                    currentLine.Append(currentWord);
                    lineLength = currentWord.Length;
                }
            }

            if (currentLine.Length > 0)
            {
                finalResult.Append(currentLine);
            }

            return finalResult.ToString();
        }

        // "Божественная функция" - делает всё форматирование
        public string FormatEverything(string text, int formatType)
        {
            string result = text;

            // Магические числа вместо enum
            if (formatType == 1)
                result = RemoveExtraSpaces(text);
            else if (formatType == 2)
                result = ChangeTextCase(text, 0);
            else if (formatType == 3)
                result = ChangeTextCase(text, 1);
            else if (formatType == 4)
                result = AlignText(text, 50);

            return result;
        }

        // Нарушение: Жестко закодированные значения
        public string FormatToDefaultWidth(string text)
        {
            return AlignText(text, 80); // Магическое число
        }
    }
}
