using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            BactrianCamel bactrianCamel = new BactrianCamel();
            SpeedboatCamel speedboatCamel = new SpeedboatCamel();
            Centaur centaur = new Centaur();
            AllTerrainBoots allTerrainBoots = new AllTerrainBoots();
            Broom broom = new Broom();
            AirCarpet airCarpet = new AirCarpet();
            Stupa stupa = new Stupa();

            Race AirRace = new Race("Air");
            AirRace.AddTransport(airCarpet);
            AirRace.AddTransport(stupa);
            AirRace.AddTransport(broom);
            AirRace.RaceWinner(1000);
            
            Race LandRace = new Race("Land");
            LandRace.AddTransport(bactrianCamel);
            LandRace.AddTransport(speedboatCamel);
            LandRace.AddTransport(centaur);
            LandRace.AddTransport(allTerrainBoots);
            LandRace.RaceWinner(1000);
            
            Race AnyRace = new Race("Any");
            AnyRace.AddTransport(stupa);
            AnyRace.AddTransport(bactrianCamel);
            AnyRace.AddTransport(allTerrainBoots);
            AnyRace.AddTransport(airCarpet);
            AnyRace.RaceWinner(1000);
            
        }
    }
}