using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class ChainofResponsibility
    {
        public ChainofResponsibility()
        {
            PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
            PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
            PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

            Approver manager = new Manager("LearningHard");
            Approver Vp = new VicePresident("Tony");
            Approver Pre = new President("BossTom");

            // 设置责任链
            manager.NextApprover = Vp;
            Vp.NextApprover = Pre;

            // 处理请求
            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            manager.ProcessRequest(requestComputers);
            Console.ReadLine();
        }
    }
    // 采购请求
    public class PurchaseRequest
    {
        // 金额
        public double Amount { get; set; }
        // 产品名字
        public string ProductName { get; set; }
        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }
    }
    // 审批人,Handler
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }
        public Approver(string name)
        {
            Name = name;
        }

        public abstract void ProcessRequest(PurchaseRequest request);
    }
    // ConcreteHandler
    public class Manager : Approver
    {
        public Manager(string name) : base(name)
        { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 1000.00)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
    // ConcreteHandler,副总
    public class VicePresident : Approver
    {
        public VicePresident(string name) : base(name)
        {

        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 25000.00)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
    // ConcreteHandler,副总
    public class President : Approver
    {
        public President(string name) : base(name)
        { }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000.00)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                Console.WriteLine("Request需要组织一个会议讨论");
            }
        }
    }


}
