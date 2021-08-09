using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace DrugDiller
{
    class LowProduct : Product
    {
        public override void NewPrice()
        {
            Random rs = new Random();
            Thread.Sleep(100);
            this.Price = Math.Max(this.Price + rs.Next(-50, 40), 10 + rs.Next(-5, 10));
        }
        public override void NewAmount()
        {
            Random r = new Random();
            Thread.Sleep(100);
            this.Amount = Math.Max(this.Amount + r.Next(-10, 20), 0);
        }
    }
}
