using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace патерн
{
    class StockInfo
    {
        public int молоко { get; set; }
        public int Хлебушек { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Magz Magz = new Magz("Из франции", stock);
            Broker broker = new Broker("Дмитрий Сергеевич", stock);
            stock.Market();
            broker.StopTrade();
            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo sInfo; 

        List<IObserver> observers;
        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            sInfo.Хлебушек= rnd.Next(0,1);
            sInfo.молоко = rnd.Next(0,1);
            NotifyObservers();
        }
    }
}
