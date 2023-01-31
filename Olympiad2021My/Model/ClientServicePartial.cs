using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiad2021My.Model
{
   partial class ClientService
    {
        public string TimeToStart
        {
            get
            {
                string line = (StartTime - DateTime.Now).ToString();
                string[] time = line.Split(':');
                return $"{time[0]} часов {time[1]} минут";
            }
        }
        public string Color
        {
            get
            {
                string[] time = TimeToStart.Split(' ');
                return time[0] == "00" ? "Red" : "Black";
            }
        }
    }
}
