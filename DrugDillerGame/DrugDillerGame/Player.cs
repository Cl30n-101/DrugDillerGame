using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugDiller
{
    class Player
    {
        public int Money { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public Product[] ProductInventory { get; set; }
        public Player(string name)
        {
            Money = 500;
            ProductInventory = new Product[14];
            Health = 100;
            Name = name;
        }
        public Player(string name, int money)
        {
            Money = money;
            ProductInventory = new Product[14];
            Health = 100;
            Name = name;
        }
        public void Eat() 
        {
            Money -= 50;
        }
        
        
    }
}
