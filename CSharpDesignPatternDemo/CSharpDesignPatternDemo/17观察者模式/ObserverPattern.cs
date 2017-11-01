using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class ObserverPattern
    {
        ObserverPattern()
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");

            // 添加订阅者
            tenXun.AddObserver(new Subscriber("Learning Hard"));
            tenXun.AddObserver(new Subscriber("Tom"));

            tenXun.Update();

            Console.ReadLine();
        }
    }
    // 订阅号抽象类
    public abstract class TenXun
    {
        // 保存订阅者列表
        private List<IObserver> observers = new List<IObserver>();

        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        #region 新增对订阅号列表的维护操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        #endregion

        public void Update()
        {
            // 遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }

    // 具体订阅号类
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    // 订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    // 具体的订阅者类
    public class Subscriber : IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }

}
