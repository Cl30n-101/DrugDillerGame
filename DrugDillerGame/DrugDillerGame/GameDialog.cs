using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugDiller
{
    class GameDialog
    {
        private Random rnd = new Random();
        public bool GameState { get; set; }
        private Player player;
        private Enemy enemy;
        private Trader trader;
        public GameDialog(Player p, Trader t,Enemy e)
        {
            enemy = e;
            player = p;
            trader = t;
        }

        public void PlayerBuy(int punct, int amont)
        {
            if (player.Money >= amont * trader.ProductInventory[punct].Price && trader.ProductInventory[punct].Amount >= amont)
            {
                Console.WriteLine("куплено {0} пакетов за {1} рублей", amont, amont * trader.ProductInventory[punct].Price);
                trader.ProductInventory[punct].Amount -= amont;
                player.ProductInventory[punct].Amount += amont;
                player.Money -= amont * trader.ProductInventory[punct].Price;
            }
            else if (trader.ProductInventory[punct].Amount < amont)
            {
                Console.WriteLine("На рынке нет столько товара");
            }
            else
            {
                Console.WriteLine("Вам нехватает {0} рублей для совершения покупки", trader.ProductInventory[punct].Amount * trader.ProductInventory[punct].Price - player.Money);
        }
    }
        public void PlayerSold(int punct, int amont)
        {
            if (player.ProductInventory[punct].Amount >= amont)
            {
                Console.WriteLine("продано {0} пакетов за {1} рублей", amont, amont * trader.ProductInventory[punct].Price);
                player.ProductInventory[punct].Amount -= amont;
                trader.ProductInventory[punct].Amount += amont;
                player.Money += amont * trader.ProductInventory[punct].Price;
            }

           
            else
            
            { Console.WriteLine("у вас нет столько товара"); }
        
        }
        public void MenuOfChange()
        {
            try
            {
                if (player.Health > 0)
                {
                    if (player.Money < 0)
                    {
                        Console.WriteLine("Вы умерли от голода");
                        Console.ReadKey();
                    }
                    else
                    {
                        string enterr;
                        Console.WriteLine("Что хотите сделать?\n 1 - купить товар\n 2 - продать товар\n 3 - состояние игрока\n 4 - товар на рынке\n 5 - следующий день\n 6 - увеличить здоровье\n exit - выход");
                        enterr = Console.ReadLine();
                        switch (enterr)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("у Вас {0} рублей", player.Money);
                                GetTraderInventory();

                                Console.WriteLine("введите номер товара");
                                int price = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("введите количество");
                                int pricee = Convert.ToInt32(Console.ReadLine());
                                PlayerBuy(price, pricee);
                                MenuOfChange();
                                break;
                            case "2":
                                Console.Clear();
                                GetPlayerInventory();
                                Console.WriteLine("введите номер товара");
                                int a = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("введите количество");
                                int b = Convert.ToInt32(Console.ReadLine());
                                PlayerSold(a, b);
                                MenuOfChange();
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine($"Здоровье [{player.Health}]");
                                GetPlayerInventory();
                                MenuOfChange();
                                break;
                            case "4":
                                Console.Clear();
                                GetTraderInventory();
                                MenuOfChange();
                                break;
                            case "5":
                                Console.Clear();
                                for (int o = 0; o < 5; o++)
                                {

                                    trader.ProductInventory[o].NewPrice();
                                    trader.ProductInventory[o].NewAmount();
                                    trader.ProductInventory[o].RandomEvent();

                                }
                                for (int o = 5; o < 11; o++)
                                {

                                    trader.ProductInventory[o].NewPrice();
                                    trader.ProductInventory[o].NewAmount();
                                    trader.ProductInventory[o].RandomEvent();

                                }
                                for (int o = 11; o < 14; o++)
                                {

                                    trader.ProductInventory[o].NewPrice();
                                    trader.ProductInventory[o].NewAmount();
                                    trader.ProductInventory[o].RandomEvent();

                                }
                               
                                Console.WriteLine("Новый день");
                                enemy = new Enemy(enemy.Names);
                                player.Eat();
                                if (rnd.Next(1, 500)%100 > 25)
                                {
                                    Console.WriteLine($"на вас напал {enemy.Name}");
                                    enemy.Battle(player);
                                }
                                MenuOfChange();
                                break;

                            case "6":
                                player.Health += Math.Min(10,100 - player.Health);
                                player.Money -= 100;
                                Console.Clear();
                                Console.WriteLine($"Вы потратили 100 рублей на таблетки. Ваше здоровье: {player.Health}");
                                MenuOfChange();
                                break;
                            case "exit":
                                Console.WriteLine("конец игры");
                                this.GameState = false;
                                break;
                        }
                        if (enterr != "exit") { Console.Clear(); MenuOfChange(); }
                    }

                }
            }

            catch { Console.Clear(); MenuOfChange(); }
            
        }
                void GetTraderInventory()
                {
                 for (int o = 0; o < 5; o++)
                {

                    Console.WriteLine("{0}){1} [пакетов:{2}] [{3} рублей за пакет]", o, trader.ProductInventory[o].Name, trader.ProductInventory[o].Amount, trader.ProductInventory[o].Price);

                }
                for (int o = 5; o < 11; o++)
                {

                    Console.WriteLine("{0}){1} [пакетов:{2}] [{3} рублей за пакет]", o, trader.ProductInventory[o].Name, trader.ProductInventory[o].Amount, trader.ProductInventory[o].Price);

                }
                for (int o = 11; o < 14; o++)
                {


                    Console.WriteLine("{0}){1} [пакетов:{2}] [{3} рублей за пакет]", o, trader.ProductInventory[o].Name, trader.ProductInventory[o].Amount, trader.ProductInventory[o].Price);
                }
            
                }
                void GetPlayerInventory()
                {
                    Console.WriteLine("У вас {0} рублей в кошельке", player.Money);
                    for (int o = 0; o < 5; o++)
                    {

                        Console.WriteLine("{0}){1} [пакетов:{2}]", o, player.ProductInventory[o].Name, player.ProductInventory[o].Amount, player.ProductInventory[o].Price);

                    }
                    for (int o = 5; o < 11; o++)
                    {

                        Console.WriteLine("{0}){1} [пакетов:{2}]", o, player.ProductInventory[o].Name, player.ProductInventory[o].Amount, player.ProductInventory[o].Price);

                    }
                    for (int o = 11; o < 14; o++)
                    {


                        Console.WriteLine("{0}){1} [пакетов:{2}]", o, player.ProductInventory[o].Name, player.ProductInventory[o].Amount, player.ProductInventory[o].Price);
                    }

                }
        
    
        }
    }

