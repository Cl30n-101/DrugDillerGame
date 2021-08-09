using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugDiller
{
    class Enemy
    {
        public static int Fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        public int FindLevel(int level,int fact)
        {
            for (; fact % level !=0; level--) ;
            
            return level-1;
        }
        public string[] Names { get; set; }
        private Random rnd = new Random();
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public Enemy(string[] names)
        {
            Names = names;
            Level = Math.Max(FindLevel(names.Length,rnd.Next(1, Fact((names.Length)))), 1);
            Name = names[Level];
            Health = (5 * Level);
        }
        public void Battle(Player player)
        {
            bool i = true;
          
            
            if (this.Health < 0) { int tt = rnd.Next((Level + 1) * 10, (Level+1) * 25); player.Money += tt; Console.WriteLine($"Вы победили. Получено {tt} рублей"); i = false; } else {
                

            if (rnd.Next(0, 300) % 100 <= Level * 5 && Health > 0)
            {
                player.Health -= rnd.Next(1, Level+1 * 5);
                Console.WriteLine($"{this.Name} попал. У Вас {player.Health} здоровья.");
            }
            else
            {
                Console.WriteLine($"{this.Name} промахнулся");
            }
                if (player.Health < 0)
                {
                    Console.WriteLine("Вы умерли");
                    Console.ReadKey();
                }
                else
                {
                        for (; i;)
                        {
                            Console.WriteLine("Ваше действие:\n 1 - Ударить \n 2 - Убежать");
                            string enter = Console.ReadLine();
                            switch (enter)
                            {
                                case "1":
                                    if (rnd.Next(0, 300) % 100 >= 25)
                                    {
                                        Console.Clear();
                                        this.Health -= rnd.Next(1, 15);
                                        Console.WriteLine($"Вы попали. У {this.Name} {Math.Max(0, this.Health)} здоровья.");
                                        i = false;

                                        Battle(player);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Вы промахнулись");
                                        i = false;
                                        Battle(player);
                                    }
                                    break;
                                case "2":
                                    player.Health -= rnd.Next(1, Level * 5);
                                    Console.WriteLine($"Вы сбежали. У Вас {player.Health} здоровья.");
                                i = false;
                                    break;
                                    
                            
                        }
                    }
                }
            }
        }
        
    }
}
