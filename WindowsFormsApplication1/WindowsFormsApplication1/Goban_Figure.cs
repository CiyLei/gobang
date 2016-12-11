using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Goban_Figure
    {
        public int Lattice = 30;  //格子的大小
        public Brush bgcolor = Brushes.Red;  //棋谱的背景颜色
        public int form_width;  //存放窗体的宽
        public int form_height; //存放窗体的高
        public int Line_size =1;//设置棋谱线的大小
        public Color Line_color = Color.Black; //设置棋谱线的颜色
        public void show(Graphics dc) //显示棋谱的函数
        {
            Rectangle rect = new Rectangle(0, 0, form_width, form_height);  //画窗体大小的矩形
            dc.FillRectangle(bgcolor, rect);  //矩形填充

            Pen pen = new Pen(Line_color, Line_size); //传递画笔的颜色和大小
            for (int i = 1; i <= Form1.Horizontal; i++)
                dc.DrawLine(pen, Lattice, i * Lattice + 25, Form1.Horizontal * Lattice, i * Lattice + 25); //循环添加棋谱线 横
            for (int i = 1; i <= Form1.vertical; i++)
                dc.DrawLine(pen, i * Lattice, Lattice + 25, i * Lattice, Form1.vertical * Lattice + 25);   //循环添加棋谱线 列


        }
    }
}
