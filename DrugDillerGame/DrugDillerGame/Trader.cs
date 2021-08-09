using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugDiller
{
    class Trader//просто хранитель наркоты
    {
        public Product[] ProductInventory { get; set; }
        public Trader()
        {
            ProductInventory = new Product[14];
        }
       
        }

}
