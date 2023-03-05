namespace task2
{
    internal class Program
    {
        // Словарь для добавления слов и количества совпадений
        public static Dictionary<string, int> myTopWords = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string path = "D:\\Разработка\\skillfactory\\task_13\\cdev_Text.txt";
             
            using (StreamReader reader = new StreamReader(path))    // Читаем наш файл
            {
                string text = reader.ReadToEnd();
                
                // Убираем из текста пунктуацию и числа
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c) && !char.IsDigit(c)).ToArray());

                // Добавляем все каждое слово в массив, убираем пробелы, табуляцию, пустые строки
                string?[] words = noPunctuationText.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                
                Console.WriteLine("Пожалуйста подождите...");

                // Сравниваем каждое слово, считаем количество совпадений
                // Добавляем слова и количество совпадений в список
                // Посчитанным значениям присваиваем null, при следующем проходе они пропускаются
                for (int i = 0; i < words.Length; i++)
                {
                    
                    if (words[i] == null) continue;
                    int number = 1;

                    for (int k = i + 1; k < words.Length; k++)
                    {
                        if (string.Compare(words[i], words[k], StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            number++;
                            words[k] = null;
                        }
                    }
                    
                    myTopWords.Add(words[i], number);
                    words[i] = null;
         
                }

                Console.Clear();

                Console.WriteLine("Слова, чаще встречаемые в тексте:\n");
                Console.WriteLine("Слово\tКоличество совпадений");
                Console.WriteLine("____________________________");
                
                // Сортировка списка по значению
                myTopWords = myTopWords.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                int sortNumber = 1;

                // Переворачиваем сортированный список, чтобы большие значения были вначале, выводим 10 наибольших значений
                foreach (var n in myTopWords.Reverse()) 
                {
                    if (sortNumber > 10) return;
                    Console.WriteLine($"{n.Key}\t{n.Value}");
                    sortNumber++;
                }

            }
        }
    }
}