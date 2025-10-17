using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Casino
{

    public static class Report
    {
        private static ConcurrentBag<string> reportLines = new ConcurrentBag<string>();

        public static void SubscribeAll(Casino casino)
        {
            casino.PlayerSeated += player =>
            {
                string msg = $"{player.Name} сел за стол. Старт: {player.StartMoney}";
                Console.WriteLine(msg);
                reportLines.Add(msg); 
            };

            casino.PlayerBet += (player, bet, result) =>
            {
                string msg = $"{player.Name} поставил {bet}, результат: {(result > 0 ? "+" + result : result.ToString())}";
                Console.WriteLine(msg);
                reportLines.Add(msg);
            };

            casino.PlayerLeft += player =>
            {
                string msg = $"{player.Name} покинул стол. Итог: {player.CurrentMoney}";
                Console.WriteLine(msg);
                reportLines.Add(msg);
            };

            casino.DayEnded += () =>
            {
                File.WriteAllLines("CasinoReport.txt", reportLines);
                Console.WriteLine("День завершен. Отчет записан в CasinoReport.txt");
            };
        }

    }
}

