using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DrugDiller
{
    class Product//определяет сущность наркотиков
    {
        public bool Deficit { get; set; }//состояние дефицита
        public bool Pereizbitok { get; set; }//состояние дефицита
        public int Price { get; set; }//у товара есть цена
        public string Name { get; set; }//название
        public int Amount { get; set; }//количество
        public Product() { this.Name = "без имени"; }
        virtual public void RandomEvent()
        {
            Random rs = new Random();
            if (rs.Next(1, 1000) % 100 > 90 && !Deficit)
            {
                if (rs.Next(1, 1000) % 100 > 50)
                {
                    Console.WriteLine($"Возник дефицит на {this.Name}");
                    this.Amount = rs.Next(0, 1);
                    this.Price *= 12;
                    this.Deficit = true;
                }
                else
                {
                    Console.WriteLine($"Возник переизбыток {this.Name}");
                    this.Amount += 6;
                    this.Price /= 5;
                    this.Pereizbitok = true;
                }
            }
            else if (Deficit)
            {
                this.Price /= 12;
                NewAmount();
                this.Deficit = false;
                this.Pereizbitok = false;
            }
            else if (Pereizbitok)
            {
                NewPrice();
                this.Deficit = false;
                this.Pereizbitok = false;

            }
        }
        virtual public void NewPrice()//каждый день определяется новая цена
        { 
        Random rs = new Random();
        Thread.Sleep(100);//из-за тупого рандомайзера, приходится делать задержку по времени
        this.Price = Math.Max(this.Price + rs.Next(-100, 100), 10 + rs.Next(-2, 5));
        }
        virtual public void NewAmount() //и новое количество в инветаре
        {
            Random r = new Random();
            Thread.Sleep(100);
            this.Amount = Math.Max(this.Amount + r.Next(-10, 10), 0);
        }
    }
}
