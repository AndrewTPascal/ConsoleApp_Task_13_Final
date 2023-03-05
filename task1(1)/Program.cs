using System.Diagnostics;

namespace task1_1_
{
    internal class Program
    {
        // Создаем пустой LinkedList
        public static LinkedList<string> myList = new LinkedList<string>();
        static void Main(string[] args)
        {
            string path = "D:\\Разработка\\skillfactory\\task_13\\cdev_Text.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();

                // Заносим каждое слово в массив 
                string[] words = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var stopWatch = Stopwatch.StartNew();   // Запускаем тест производительности

                // Добавляем в наш LinkedList все элементы массива и выводим результат
                foreach (string word in words) myList.AddLast(word);

                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}