using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class MediatorPattern
    {
        MediatorPattern()
        {
            AbstractCardPartner A = new ParterA();
            AbstractCardPartner B = new ParterB();
            // 初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;

            AbstractMediator mediator = new MediatorPater(A, B);

            // A赢了
            A.ChangeCount(5, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B 赢了
            B.ChangeCount(10, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
            Console.Read();
        }
    }
    // 抽象牌友类
    public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }
        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }
        public abstract void ChangeCount(int Count, AbstractMediator mediator);
    }
    // 牌友A类
    public class ParterA : AbstractCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.AWin(Count);
        }
    }
    // 牌友B类
    public class ParterB : AbstractCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.BWin(Count);
        }
    }
    // 抽象中介者类
    public abstract class AbstractMediator
    {
        protected AbstractCardPartner A;
        protected AbstractCardPartner B;
        public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
        {
            A = a;
            B = b;
        }
        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }
    // 具体中介者类
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(AbstractCardPartner a, AbstractCardPartner b) : base(a, b)
        { }
        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }

        public override void BWin(int count)
        {
            B.MoneyCount += count;
            A.MoneyCount -= count;
        }
    }
}
