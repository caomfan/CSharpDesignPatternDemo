using CSharpDesignPatternDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CSharpDesignPatternDemo.FoodSimpleFactoryClass;

namespace CSharpDesignPatternDemo
{
    public class FoodSimpleFactory
    {
        FoodSimpleFactory()
        {
            //客户想吃西红柿炒鸡蛋
            Food food1 = FoodSimpleFactoryClassMethod.CreateFood("西红柿炒鸡蛋");
            food1.Print();

            //客户想再点一个土豆肉丝
            Food food2 = FoodSimpleFactoryClassMethod.CreateFood("土豆肉丝");
            food2.Print();

            Console.Read();
        }
    }

    public class FoodSimpleFactoryClass
    {
        /// <summary>
        /// 菜抽象类
        /// </summary>
        public abstract class Food
        {
            //输出点了什么菜
            public abstract void Print();
        }

        /// <summary>
        /// 西红柿炒鸡蛋这道菜
        /// </summary>
        public class TomatoScrambleEggs : Food
        {
            public override void Print()
            {
                Console.WriteLine("一份西红柿炒鸡蛋！");
            }
        }

        /// <summary>
        /// 土豆肉丝这道菜
        /// </summary>
        public class ShreddedPorkWithPotatoes : Food
        {
            public override void Print()
            {
                Console.WriteLine("一份土豆肉丝！");
            }
        }
    }

    /// <summary>
    /// 简单工厂类，负责 炒菜
    /// </summary>
    public class FoodSimpleFactoryClassMethod
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type == "土豆肉丝")
            {
                food = new ShreddedPorkWithPotatoes();
            }
            else if (type == "西红柿炒鸡蛋")
            {
                food = new TomatoScrambleEggs();
            }

            return food;
        }


    }

}
