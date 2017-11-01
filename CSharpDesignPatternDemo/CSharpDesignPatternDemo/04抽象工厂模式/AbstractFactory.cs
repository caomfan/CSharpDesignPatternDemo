using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CSharpDesignPatternDemo.AbstractFactoryClass;

namespace CSharpDesignPatternDemo
{
    class AbstractFactoryCilent
    {
        public AbstractFactoryCilent()
        {
            AbstractFactory nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYabo();
            nanChangYabo.Print();
            YaJia nanChangYajia = nanChangFactory.CreateYaJia();
            nanChangYajia.Print();

            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            YaBo shangHaiYabo = shangHaiFactory.CreateYabo();
            shangHaiYabo.Print();
            YaJia shangHaiYajia = shangHaiFactory.CreateYaJia();
            shangHaiYajia.Print();

            //新增湖南
            AbstractFactory huNanFactory = new HuNanFactory();
            YaBo huNanYabo = huNanFactory.CreateYabo();
            huNanYabo.Print();
            YaJia huNanYajia = huNanFactory.CreateYaJia();
            huNanYajia.Print();
        }
       
    }

    public  class AbstractFactoryClass
    {
        public abstract class AbstractFactory
        {
            public abstract YaBo CreateYabo();
            public abstract YaJia CreateYaJia();
        } 

        public abstract class YaBo
        {
            public abstract void Print();
        }

        public abstract class YaJia
        {
            public abstract void Print();
        }

        public class NanChangFactory:AbstractFactory
        {
            public override YaBo CreateYabo()
            {
                return new NanChangYaBo();
            }

            public override YaJia CreateYaJia()
            {
                return new NanChangYaJia();
            }
        }

        public class ShangHaiFactory : AbstractFactory
        {
            public override YaBo CreateYabo()
            {
                return new ShangHaiYaBo();
            }

            public override YaJia CreateYaJia()
            {
                return new ShangHaiYaJia();
            }
        }
        //新增湖南
        public class HuNanFactory:AbstractFactory
        {
            public override YaBo CreateYabo()
            {
                return new HuNanYaBo();
            }

            public override YaJia CreateYaJia()
            {
                return new HuNanYaJia();
            }
        }

        public class NanChangYaBo : YaBo
        {
            public override void Print()
            {
                Console.WriteLine("南昌的鸭脖");
            }
        }
       
        public class NanChangYaJia:YaJia
        {
            public override void Print()
            {
                Console.WriteLine("南昌的鸭架子");
            }
        }
        public class ShangHaiYaBo : YaBo
        {
            public override void Print()
            {
                Console.WriteLine("上海的鸭脖");
            }
        }
        //新增湖南
        public class ShangHaiYaJia : YaJia
        {
            public override void Print()
            {
                Console.WriteLine("上海的鸭架子");
            }
        }
       
        public class HuNanYaBo : YaBo
        {
            public override void Print()
            {
                Console.WriteLine("湖南的鸭脖");
            }
        }

        public class HuNanYaJia : YaJia
        {
            public override void Print()
            {
                Console.WriteLine("湖南的鸭架子");
            }
        }
    }

}
