namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();
            int count = 100;
            List<int> numbers = new List<int>();
            List<int> primes = new List<int>();
            List<int> primes7 = new List<int>();

            string? filename1 = null;
            string? filename2 = null;
            string? filename3 = null;


            try
            {
                var task1 = Task.Run(() =>
                {
                    mutex.WaitOne();
                    try
                    {
                        numbers = Task4Mutex.GenerateNumbers(count);
                        filename1 = Task4Mutex.WriteInFile(Task4Mutex.FileNumbers, numbers);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                });

                var task2 = task1.ContinueWith(t =>
                {
                    mutex.WaitOne();
                    try
                    {
                        primes = numbers.Where(Task4Mutex.IsPrime).ToList();
                        filename2 = Task4Mutex.WriteInFile(Task4Mutex.FileSimple, primes);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                });

                var task3 = task2.ContinueWith(t =>
                {
                    mutex.WaitOne();
                    try
                    {
                        primes7 = primes.Where(Task4Mutex.IsEnd7).ToList();
                        filename3 = Task4Mutex.WriteInFile(Task4Mutex.FileSimple7, primes7);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                });

                var task4 = task3.ContinueWith(t =>
                {
                    mutex.WaitOne();
                    try
                    {
                        var report = new Task5Report();
                        report.AddFileReport(filename1!);
                        report.AddFileReport(filename2!);
                        report.AddFileReport(filename3!);
                        report.SaveReport("final_report.txt");
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                });

                task4.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
