using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class CompositePattern2
    {
        CompositePattern2()
        {
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);

            // 显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            // 移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.Read();
        }
    }

    /// <summary>
    /// 图形抽象类
    /// </summary>
    public abstract class Graphics2
    {
        public string Name { get; set; }
        public Graphics2(string name)
        {
            this.Name = name;
        }

        public abstract void Draw();
       
    }

    public class Line2 : Graphics2
    {
        public Line2(string name) : base(name)
        {

        }
        //重写父类抽象方法
        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }

    }

    public class Circle2 : Graphics2
    {
        public Circle2(string name) : base(name)
        {

        }

        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }

    }
    /// <summary>
    /// 复杂图形，由一些简单图形组成,这里假设该复杂图形由一个圆两条线组成的复杂图形
    /// </summary>
    public class ComplexGraphics2 : Graphics2
    {
        private List<Graphics2> complexGraphicsList = new List<Graphics2>();

        public ComplexGraphics2(string name) : base(name)
        { }

        /// <summary>
        /// 复杂图形的画法
        /// </summary>  
        public override void Draw()
        {
            foreach (Graphics2 g in complexGraphicsList)
            {

                g.Draw();
            }
        }

        public  void Add(Graphics2 g)
        {
            complexGraphicsList.Add(g);
        }

        public  void Remove(Graphics2 g)
        {
            complexGraphicsList.Remove(g);
        }
    }
}
