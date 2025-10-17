using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Casino
{
    public class Player
    {
        public string Name { get; set; }
        public int StartMoney { get; set; }
        public int CurrentMoney { get; set; }

        public Player(string name, int money)
        {
            Name = name;
            StartMoney = money;
            CurrentMoney = money;
        }
    }
}
