using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugDiller
{
    class Program
    {

        static void Main(string[] args)
       {
            Console.Title = "Perekup";
            Console.WriteLine("Как вас зовут?");
            Player player = new Player(Console.ReadLine());
            Console.WriteLine("Здравствуй, {0}",player.Name);
            Console.WriteLine("Ты торговец наркотой. Ты должен покупать наркоту и продавать её по более выгодной цене. Каждый день цены на товар меняются, а ты тратишь на еду 50 рублей. Удачи!\n");
            String[] enemynamelist = {"Пёс","Бомж", "Наркоман", "Дворник", "Алкаш Виталий", "Продавщица", "Подросток", "\"Авторитет\"", "Участковый", "ВДВшник", "Полковник", "Росгвардеец"};
            String[] productlist = { "Амфетамин", "Мефедрона", "Кокаин", "Экстестези", "Марихуана", "Кактус", "Гашиш", "Кристалл", "Снюс", "Спайс", "Героин", "Морфин", "Опиум", "Кетамин" };
            Trader trader = new Trader();
            Enemy vorog = new Enemy(enemynamelist);
            GameDialog dialog = new GameDialog(player,trader, vorog);
            Setup(player, trader, productlist);
            
          
                dialog.MenuOfChange();
            
            
        }
        static void Setup(Player player, Trader trader, string[] productlist)  
        {
            for (int o = 0; o < 5; o++)
            {
                player.ProductInventory[o] = new LowProduct();
                trader.ProductInventory[o] = new LowProduct();
                player.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].NewPrice();
                trader.ProductInventory[o].NewAmount();
                
            }
            for (int o = 5; o < 11; o++)
            {
                player.ProductInventory[o] = new Product();
                trader.ProductInventory[o] = new Product();
                player.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].NewPrice();
                trader.ProductInventory[o].NewAmount();
                
            }
            for (int o = 11; o < 14; o++)
            {
                player.ProductInventory[o] = new HighProduct();
                trader.ProductInventory[o] = new HighProduct();
                player.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].Name = productlist[o];
                trader.ProductInventory[o].NewPrice();
                trader.ProductInventory[o].NewAmount();
                
            }
        }

    }
}
