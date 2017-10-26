using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpDesignPatternDemo
{
    /// <summary>
    /// Singleton.xaml 的交互逻辑
    /// </summary>
    public partial class Singleton : Window
    {
        public Singleton()
        {
            InitializeComponent();
        }

        #region 单线程处理，单例模式
        /// <summary>
        /// 定义一个静态变量来保存类的实例
        /// </summary>
        private static Singleton uniqueInstance;
        /// <summary>
        /// 定义公有方法提供一个全局的访问点，同时你也可以定义公有属性变量来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Singleton();
            }
            return uniqueInstance;
        }
        #endregion


        #region 多线程处理，单例模式，推荐使用
        /// <summary>
        /// 定义一个静态变量来保存类的实例
        /// </summary>
        private static Singleton uniqueInstance2;
        /// <summary>
        /// 定义一个标识确保线程同步
        /// </summary>
        private static readonly object locker = new object();
        /// <summary>
        /// 定义公有方法提供一个全局的访问点，同时你也可以定义公有属性变量来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance2()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance2==null)
            {
                lock(locker)
                {
                    if (uniqueInstance2 == null)
                    {
                        uniqueInstance2 = new Singleton();
                    }
                }
            }
            return uniqueInstance2;
        }
        #endregion
    }
}
