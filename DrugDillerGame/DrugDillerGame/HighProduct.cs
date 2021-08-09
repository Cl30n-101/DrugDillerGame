using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace DrugDiller
{
    class HighProduct : Product
    {
        public override void NewPrice()
        {
            Random rs = new Random();
            Thread.Sleep(100);
            this.Price = Math.Max(this.Price + rs.Next(-100, 1000), 100+rs.Next(-25, 50));
        }
    }
}
