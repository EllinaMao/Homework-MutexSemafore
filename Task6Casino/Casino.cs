using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Casino
{
    public class Casino
    {
        private static Random rand_ = new Random();
        private SemaphoreSlim tableSemaphore;
        private readonly object lockObj = new object();
        private CasinoSettings settings;


        public event Action<Player> PlayerSeated;
        public event Action<Player, int, int> PlayerBet; // игрок, ставка, выигрыш/проигрыш
        public event Action<Player> PlayerLeft;
        public event Action DayEnded;

        public List<Player> allPlayers = new List<Player>();

        public Casino(CasinoSettings casinoSettings)
        {
            settings = casinoSettings;
            tableSemaphore = new SemaphoreSlim(settings.MaxTableSeats);
        }

        public void StartDay()
        {


            int totalPlayers = rand_.Next(settings.MinPlayers, settings.MaxPlayers + 1);
            Queue<Player> waitingPlayers = new Queue<Player>();

            for (int i = 1; i <= totalPlayers; i++)
            {
                int money = rand_.Next(settings.MinStartMoney, settings.MaxStartMoney + 1);
                waitingPlayers.Enqueue(new Player($"Игрок{i}", money));
            }
            List<Task> runningTasks = new List<Task>();

            while (waitingPlayers.Count > 0)
            {
                Player player = waitingPlayers.Dequeue();
                tableSemaphore.Wait();

                Task t = Task.Run(() =>
                {
                    PlayerSeated?.Invoke(player);
                    Play(player);
                    PlayerLeft?.Invoke(player);
                    tableSemaphore.Release();
                });

                runningTasks.Add(t);
            }

            Task.WaitAll(runningTasks.ToArray());
            DayEnded?.Invoke();


        }
        private void Play(Player player)
        {
            while (player.CurrentMoney > 0)
            {
                int betNumber = rand_.Next(settings.RouletteMinNumber, settings.RouletteMaxNumber + 1);
                int maxBetAmount = Math.Min(player.CurrentMoney, settings.MaxBet);
                int betAmount = rand_.Next(settings.MinBet, maxBetAmount + 1);
                int winningNumber = rand_.Next(settings.RouletteMinNumber, settings.RouletteMaxNumber + 1);

                if (winningNumber == betNumber)
                {
                    player.CurrentMoney += betAmount;
                }
                else
                {
                    player.CurrentMoney -= betAmount;
                }

                PlayerBet?.Invoke(player, betAmount, winningNumber == betNumber ? betAmount : -betAmount);

                Thread.Sleep(rand_.Next(settings.MinSleepMs, settings.MaxSleepMs + 1));

                if (player.CurrentMoney <= 0)
                    break;
            }


        }
    }
}
