using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CSharpDesignPatternDemo.FactoryMethodPatternClass;

namespace CSharpDesignPatternDemo
{
    public class FactoryMethodPattern
    {
        FactoryMethodPattern()
        {
            // 初始化做菜的两个工厂（）
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoodFactory();
            tomatoScrambleEggs.Print();

            //开始做土豆肉丝
            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoodFactory();
            shreddedPorkWithPotatoes.Print();

            // 如果客户又想点肉末茄子了
            // 再另外初始化一个肉末茄子工厂
            Creator minceMeatEggplantFactor = new MincedMeatEggplantFactory();

            // 利用肉末茄子工厂来创建肉末茄子这道菜
            Food minceMeatEggplant = minceMeatEggplantFactor.CreateFoodFactory();
            minceMeatEggplant.Print();

            Console.Read();
        }
    }

    public class FactoryMethodPatternClass
    {
        public abstract class Food
        {
            public abstract void Print();
        }

        /// <summary>
        /// 西红柿炒鸡蛋这道菜
        /// </summary>
        public class TomatoScrambledEggs : Food
        {
            public override void Print()
            {
                Console.WriteLine("西红柿炒蛋好了！");
            }
        }

        /// <summary>
        /// 土豆肉丝这道菜
        /// </summary>
        public class ShreddedPorkWithPotatoes : Food
        {
            public override void Print()
            {
                Console.WriteLine("土豆肉丝好了");
            }
        }

        /// <summary>
        /// 抽象工厂类
        /// </summary>
        public abstract class Creator
        {
            // 工厂方法
            public abstract Food CreateFoodFactory();
        }

        /// <summary>
        /// 西红柿炒蛋工厂类
        /// </summary>
        public class TomatoScrambledEggsFactory : Creator
        {
            /// <summary>
            /// 负责创建西红柿炒蛋这道菜
            /// </summary>
            /// <returns></returns>
            public override Food CreateFoodFactory()
            {
                return new TomatoScrambledEggs();
            }
        }

        /// <summary>
        /// 肉末茄子这道菜
        /// </summary>
        public class MincedMeatEggplant : Food
        {
            /// <summary>
            /// 重写抽象类中的方法
            /// </summary>
            public override void Print()
            {
                Console.WriteLine("肉末茄子好了");
            }
        }
        /// <summary>
        /// 肉末茄子工厂类，负责创建肉末茄子这道菜
        /// </summary>
        public class MincedMeatEggplantFactory : Creator
        {
            /// <summary>
            /// 负责创建肉末茄子这道菜
            /// </summary>
            /// <returns></returns>
            public override Food CreateFoodFactory()
            {
                return new MincedMeatEggplant();
            }
        }

        /// <summary>
        /// 土豆肉丝工厂类
        /// </summary>
        public class ShreddedPorkWithPotatoesFactory : Creator
        {
            /// <summary>
            /// 负责创建土豆肉丝这道菜
            /// </summary>
            /// <returns></returns>
            public override Food CreateFoodFactory()
            {
                return new ShreddedPorkWithPotatoes();
            }
        }
    }


}
