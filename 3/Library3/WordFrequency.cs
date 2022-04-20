namespace _3.Library3
{
    /// <summary>
    /// Класс содержит метод для подсчета частоты слов в каком-либо тексте.
    /// </summary>
    public static class WordsFrequency
    {
        /// <summary>
        /// Метод возвращает строку с результатами подсчета частоты слов в переданном тексте.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string CalculateWordsFrequency(string text)
        {
            if ((text == null) || (text == ""))
            {
                throw new ArgumentException("Вы не ввели строку или строка пустая", nameof(text));
            }
            var wordFrequency = 0;
            var result = "";
            text.Trim();
            text = text.Replace(". ", " ");
            string[] wordsInText = text.Split(' ', '.');
            for (var i = 0; i < wordsInText.Length; i++)
            {
                wordsInText[i] = wordsInText[i].ToLower();
            }
            var uniqueWords = new List<string>();
            foreach (var word in wordsInText)
            {
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }
            }
            for (var i = 0; i < uniqueWords.Count; i++)
            {
                foreach (var word in wordsInText)
                {
                    if (uniqueWords[i] == word)
                    {
                        wordFrequency++;
                    }
                }
                result += $"{uniqueWords[i]} - {wordFrequency}\n";
                wordFrequency = 0;
            }
            return result;
        }
        /// <summary>
        /// Вывод в консоль результата подсчета частоты слов.
        /// </summary>
        /// <param name="text"></param>
        public static void PrintCalculatedFrequency(string text)
        {
            var result = CalculateWordsFrequency(text);
            Console.WriteLine(result);
        }
    }
}
