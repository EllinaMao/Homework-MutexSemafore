using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task4
{
    /*    Задание 5
    Добавьте к четвертому заданию четвертый поток, который подготовит и выведет отчет о полученных файлах в итоговый файл отчёта. 
    Пример отчёта:
    количество чисел в каждом файле;
    размер каждого файла в байтах;
    содержимое каждого из файлов.*/
    public class Task5Report
    {
        private readonly List<string> reportLines = new List<string>();

        public void AddFileReport(string fileName)
        {
            if (!File.Exists(fileName))
            {
                reportLines.Add($"Файл {fileName} не найден.");
                return;
            }

            var numbers = File.ReadAllLines(fileName).Select(int.Parse).ToList();
            FileInfo fi = new FileInfo(fileName);

            reportLines.Add($"Файл: {fileName}");
            reportLines.Add($"Количество чисел: {numbers.Count}");
            reportLines.Add($"Размер файла: {fi.Length} байт");
            reportLines.Add("Содержимое:");
            reportLines.Add(string.Join(", ", numbers));
            reportLines.Add("");
        }


        public void SaveReport(string reportFileName = "report.txt")
        {
            File.WriteAllLines(reportFileName, reportLines);
            Console.WriteLine($"Отчёт сохранён в {reportFileName}");
        }

    }
}

