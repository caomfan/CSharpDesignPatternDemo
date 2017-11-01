using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class StrategyPattern
    {
        StrategyPattern()
        {
            //个人所得税方式
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));
            // 企业所得税
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));
            Console.Read();
        }
    }
    // 所得税计算策略
    public interface ITaxStrategy
    {
        double CalculateTax(double income);
    }

    public class PersonalTaxStrategy:ITaxStrategy
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }

    public class EnterpriseTaxStrategy : ITaxStrategy
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.45 : 0.0;
        }
    }

    public class InterestOperation
    {
        private ITaxStrategy m_strategy;
        public InterestOperation(ITaxStrategy strategy)
        {
            this.m_strategy = strategy;
        }
        public double GetTax(double income)
        {
            return m_strategy.CalculateTax(income);
        }
    }
    
}
