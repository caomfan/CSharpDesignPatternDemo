using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class DecoratorPattern
    {
        public DecoratorPattern()
        {
            // 我买了个苹果手机
            Phone phone = new ApplePhone();

            // 现在想贴膜了
            Decorator applePhoneWithSticker = new Sticker(phone);
            // 扩展贴膜行为
            applePhoneWithSticker.Print();
            Console.WriteLine("----------------------\n");

            // 现在我想有挂件了
            Decorator applePhoneWithAccessories = new Accessories(phone);
            // 扩展手机挂件行为
            applePhoneWithAccessories.Print();
            Console.WriteLine("----------------------\n");

            // 现在我同时有贴膜和手机挂件了
            Sticker sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();
            Console.ReadLine();
        }
    }

    public abstract class Phone
    {
        public abstract void Print();
    }

    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }

    public abstract class Decorator:Phone
    {
        private Phone phone;
        public Decorator(Phone p)
        {
            this.phone = p;
        }
        public override void Print()
        {
            if(phone!=null)
            {
                phone.Print();
            }
        }
    }
    /// <summary>
    /// 贴膜，即具体装饰者
    /// </summary>
    public class Sticker:Decorator
    {
        public Sticker(Phone p):base(p)
        {

        }

        public override void Print()
        {
            base.Print();
            //添加新行为
            AddSticker();
        }

        private void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }
    /// <summary>
    /// 手机挂机
    /// </summary>
    public class Accessories:Decorator
    {
        public Accessories(Phone p):base(p)
        {

        }
        public override void Print()
        {
            base.Print();
            //添加新的行为
            AddAccessories();
        }
        //新的行为方法
        private void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }
}
