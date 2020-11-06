using System;
using System.Collections.Generic;

namespace lab3
{
    public class Race
    {
        private List<Transport> AllTransport = new List<Transport>();
        private string type;
        public Race(string type)
        {
            this.type = type;
        }
        public void AddTransport(Transport transport)
        {
            if (type == "Any" || type == transport.GetTypeOfTransport())
            {
                AllTransport.Add(transport);
            } else throw new Exception("Wrong type of transport");
        }
        public void RaceWinner(double distance)
        {
            Dictionary<string,double> AllRaceTransport = new Dictionary<string, double>();
            double TransportTime = 0;
            double WinnerTime = -1;
            string WinnerName = null;
            foreach (Transport tr in AllTransport)
            {
                TransportTime = tr.RaceTime(distance);
                AllRaceTransport.Add(tr.GetTransportName(),TransportTime);
            }

            foreach (var TransportName in AllRaceTransport.Keys)
            {
                if (WinnerTime == -1)
                {
                    WinnerTime = AllRaceTransport[TransportName];
                    WinnerName = TransportName;
                } else if (WinnerTime > AllRaceTransport[TransportName])
                {
                    WinnerTime = AllRaceTransport[TransportName];
                    WinnerName = TransportName;
                }
            }
            Console.WriteLine("Winner is " + WinnerName + " with time = " + WinnerTime);
        }
    }
}