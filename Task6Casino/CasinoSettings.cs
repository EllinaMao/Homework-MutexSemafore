using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Casino
{
    public class CasinoSettings
    {
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinStartMoney { get; set; }
        public int MaxStartMoney { get; set; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }
        public int MaxTableSeats { get; set; }
        public int MinSleepMs { get; set; }
        public int MaxSleepMs { get; set; }
        public int RouletteMinNumber { get; set; }
        public int RouletteMaxNumber { get; set; }

        public static CasinoSettings LoadFromConfig()
        {
            return new CasinoSettings
            {
                MinPlayers = int.Parse(ConfigurationManager.AppSettings["MinPlayers"]!),
                MaxPlayers = int.Parse(ConfigurationManager.AppSettings["MaxPlayers"]!),
                MinStartMoney = int.Parse(ConfigurationManager.AppSettings["MinStartMoney"]!),
                MaxStartMoney = int.Parse(ConfigurationManager.AppSettings["MaxStartMoney"]!),
                MinBet = int.Parse(ConfigurationManager.AppSettings["MinBet"]!),
                MaxBet = int.Parse(ConfigurationManager.AppSettings["MaxBet"]!),
                MaxTableSeats = int.Parse(ConfigurationManager.AppSettings["MaxTableSeats"]!),
                MinSleepMs = int.Parse(ConfigurationManager.AppSettings["MinSleepMs"]!),
                MaxSleepMs = int.Parse(ConfigurationManager.AppSettings["MaxSleepMs"]!),
                RouletteMinNumber = int.Parse(ConfigurationManager.AppSettings["RouletteMinNumber"]!),
                RouletteMaxNumber = int.Parse(ConfigurationManager.AppSettings["RouletteMaxNumber"]!)
            };
        }

    }
}


