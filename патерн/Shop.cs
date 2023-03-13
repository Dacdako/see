using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace патерн
{
    class Magz : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Magz(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Хлебушек == 1)
                Console.WriteLine("Магазин оповещает о продукте;  хлебушек есть!", this.Name);
            else
                Console.WriteLine("Магазин ничего не сообщает;");
        }
    }
}
