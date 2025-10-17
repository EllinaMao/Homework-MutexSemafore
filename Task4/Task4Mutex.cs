namespace Task4
{

    /*Задание 4
    Создайте приложение, использующее механизм мьютексов. Создайте в коде приложения несколько потоков. Первый поток генерирует набор случайных чисел и записывает их в файл. 

    Второй поток ожидает, когда первый закончит своё исполнение, после чего анализирует содержимое файла и создаёт новый файл, в котором должны быть собраны только простые числа из первого файла. 

    Третий поток ожидает, когда закончится второй поток, после чего создаёт новый файл, в котором должны быть собраны все простые числа из второго файла у которых последняя цифра равна 7. 
    Выбор типа приложения (консольное или оконное, остаётся за вами)


    
     */
    public static class Task4Mutex
    {
        private static Mutex AppMutex = new Mutex();
        public static readonly string FileNumbers = "fileGenerate";
        public static readonly string FileSimple = "fileGenerateSimple";
        public static readonly string FileSimple7 = "fileGenerateSimple7";
        private static readonly Random rnd_ = new Random();

        public static List<int> GenerateNumbers(int count, int min = 0, int max = 1000)
        {
            AppMutex.WaitOne();
            try
            {
                var numbers = Enumerable.Range(0, count)
                    .Select(n => rnd_.Next(min, max))
                    .ToList();
                return numbers;
            }
            finally
            {
                AppMutex.ReleaseMutex();
            }

        }
        public static string WriteInFile(string name, List<int> numbers)
        {
            AppMutex.WaitOne();
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
                string fileName = $"{name}_{timestamp}.txt"; File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
                Console.WriteLine($"Сохранено {numbers.Count} чисел в {fileName}");
                return fileName;
            }
            finally
            {
                AppMutex.ReleaseMutex();
            }

        }
        public static List<int> ReadFromFile(string fileName)
        {
            AppMutex.WaitOne();
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException(fileName);
                }
                var numbers = File.ReadAllLines(fileName).Select(int.Parse).ToList();
                Console.WriteLine($"Прочитано {numbers.Count} чисел из {fileName}");
                return numbers;
            }
            finally
            {
                AppMutex.ReleaseMutex();
            }
        }
        /*    Второй поток ожидает, когда первый закончит своё исполнение, после чего анализирует содержимое файла и создаёт новый файл, в котором должны быть собраны только простые числа из первого файла. */

        public static List<int> IsWhat(List<int> nums, int count, Func<int, bool> pred)
        {
            AppMutex.WaitOne();
            try
            {
                var numbers = nums.Where(pred).ToList();
                return numbers;
            }
            finally
            {
                AppMutex.ReleaseMutex();
            }
        }
        /*    Третий поток ожидает, когда закончится второй поток, после чего создаёт новый файл, в котором должны быть собраны все простые числа из второго файла у которых последняя цифра равна 7. 
    Выбор типа приложения (консольное или оконное, остаётся за вами)*/
        public static bool IsEnd7(int n)
        {
            return n % 10 == 7;
        }

        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)
                if (n % i == 0) return false;

            return true;
        }



    }
}
