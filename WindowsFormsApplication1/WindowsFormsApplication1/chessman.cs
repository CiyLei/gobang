using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class chessman
    {
        Goban_Figure gf = new Goban_Figure();
        public string name = "白方"; //代表棋子的名字 默认白色
        public int type = 1; //表示棋子的类型 1代表一方,2代表一方
        public Brush color = Brushes.White; //棋子的颜色
        public int size = 14;  //棋子的大小(半径)
        public void show(Graphics dc, int x, int y)
        {
            Form1.Digital_Goban[y, x] = type; //填写数字棋谱
            dc.FillEllipse(color, gf.Lattice * x - size, gf.Lattice * y + 25 - size, size * 2, size * 2); //根据棋子在数字棋谱的位置在窗体画下棋子
        }
    }
}
