using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT1
{
    public class Livestock
    {
        public string Name { get; private set; }
        public int MilkYield { get; protected set; } // Amount of milk produced per session

        public Livestock(string name, int milkYield)
        {
            Name = name;
            MilkYield = milkYield;
        }

        public virtual string MakeSound()
        {
            return "";
        }

        public string Feed()
        {
            return $"{Name} is making noise asking for food!";
        }

        public virtual int GiveMilk()
        {
            return MilkYield;
        }

    }

    public class Cow : Livestock
    {
        public Cow() : base("Cow", 10) { } // Assuming cow gives 10 liters of milk each time

        public override string MakeSound()
        {
            return "Cow says: Moo!";
        }
        public override int GiveMilk()
        {
            MilkYield = new Random().Next(0, 21); // Random milk yield between 0 and 20 liters
            return MilkYield;
        }
    }

    public class Sheep : Livestock
    {
        public Sheep() : base("Sheep", 5) { } // Assuming sheep gives 5 liters of milk each time

        public override string MakeSound()
        {
            return "Sheep says: Baa!";
        }
        public override int GiveMilk()
        {
            MilkYield = new Random().Next(0, 6); // Random milk yield between 0 and 5 liters
            return MilkYield;
        }
    }

    public class Goat : Livestock
    {
        public Goat() : base("Goat", 8) { } // Assuming goat gives 8 liters of milk each time

        public override string MakeSound()
        {
            return "Goat says: Mee!";
        }
        public override int GiveMilk()
        {
            MilkYield = new Random().Next(0, 11); // Random milk yield between 0 and 10 liters
            return MilkYield;
        }
    }

    public class Farm
    {
        private List<Cow> cows = new List<Cow>();
        private List<Sheep> sheep = new List<Sheep>();
        private List<Goat> goats = new List<Goat>();
        public Farm()
        {

        }
        public Farm(int numberOfCows, int numberOfSheeps, int numberOfGoats)
        {
            AddLivestock("cow", numberOfCows);
            AddLivestock("sheep", numberOfSheeps);
            AddLivestock("goat", numberOfGoats);
        }

        public void AddLivestock(string animalType, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                switch (animalType.ToLower())
                {
                    case "cow":
                        cows.Add(new Cow());
                        break;
                    case "sheep":
                        sheep.Add(new Sheep());
                        break;
                    case "goat":
                        goats.Add(new Goat());
                        break;
                    default:
                        Console.WriteLine("Invalid livestock type.");
                        break;
                }
            }
        }

        public int TotalMilkYield()
        {
            int totalMilk = 0;
            foreach (var cow in cows)
            {
                totalMilk += cow.GiveMilk();
            }
            foreach (var sheep in sheep)
            {
                totalMilk += sheep.GiveMilk();
            }
            foreach (var goat in goats)
            {
                totalMilk += goat.GiveMilk();
            }
            return totalMilk;
        }


        public void LivestockCount()
        {
            Console.WriteLine($"Livestock counts:");
            Console.WriteLine($"Cows: {cows.Count}");
            Console.WriteLine($"Sheep: {sheep.Count}");
            Console.WriteLine($"Goats: {goats.Count}");
        }
        public string AnimalSounds()
        {
            List<string> sounds = new List<string>();
            sounds.Add(cows[0].MakeSound());
            sounds.Add(sheep[0].MakeSound());
            sounds.Add(goats[0].MakeSound());
            return string.Join(", ", sounds);
        }
    }
}
