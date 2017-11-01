
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class StatePattern
    {
        StatePattern()
        {
            // 开一个新的账户
            Account account = new Account("Learning Hard");

            // 进行交易
            // 存钱
            account.Deposit(1000.0);
            account.Deposit(200.0);
            account.Deposit(600.0);

            // 付利息
            account.PayInterest();

            // 取钱
            account.Withdraw(2000.00);
            account.Withdraw(500.00);

            // 等待用户输入
            Console.ReadKey();
        }
    }

    public class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }
        public Account(string owner)
        {
            this.Owner = owner;
            this.State = new SliverState(0.0, this);

        }

        public double Balance { get { return State.Balance; } }//余额
        //存钱
        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine("存款金额为 {0:C}——", amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }
        //取钱
        public void Withdraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }

        // 获得利息
        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }
    }
    
    public abstract class State
    {
        public Account Account { get; set; }
        public double Balance { get; set; }//余额
        public double Interest { get; set; }//利率
        public double LowerLimit { get; set; }//下限
        public double UpperLimit { get; set; }//上限
        public abstract void Deposit(double amount);//存款
        public abstract void Withdraw(double amount);//取钱
        public abstract void PayInterest();//获得的利息
    }

    public class RedState:State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.00;
            LowerLimit = -100.00;
            UpperLimit = 0.00;
        }
        //存钱
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }
        //取钱
        public override void Withdraw(double amount)
        {
            Console.WriteLine("没有钱可以取了！");
        }

        public override void PayInterest()
        {
            //没有利息
        }
        private void StateChangeCheck()
        {
            if(Balance>UpperLimit)
            {
                Account.State = new SliverState(this);
            }
        }
    }

    public class SliverState:State
    {
        public SliverState(State state):this(state.Balance,state.Account)
        {

        }

        public SliverState(double balance,Account account)
        {
            this.Balance = balance;
            this.Account = account;
            Interest = 0.00;
            LowerLimit = 0.00;
            UpperLimit = 1000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            if(Balance<LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if(Balance>UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }
    }

    public class GoldState:State
    {
        public GoldState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 1000000.00;
        }

        public override void Deposit(double amount)
        {
            Balance+=amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if(Balance<0.0)
            {
                Account.State = new RedState(this);
            }
            else if(Balance<LowerLimit)
            {
                Account.State = new SliverState(this);
            }
        }

    }
}
