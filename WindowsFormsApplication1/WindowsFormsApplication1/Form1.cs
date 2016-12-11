using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Goban_Figure gf = new Goban_Figure();
        chessman cm1 = new chessman(); //实例化棋子1
        chessman cm2 = new chessman(); //实例化棋子2
        public static int Horizontal = 19; //棋谱的横数
        public static int vertical = 19;   //棋谱的列数
        public static int[,] Digital_Goban = new int[Horizontal + 1, vertical + 1]; //创建数字棋谱
        bool cm1_bool = true;  //true为现在该棋子1下
        bool cm2_bool = false; //true为现在该棋子2下
        bool Start = false;  //true为游戏开始,false为游戏结束.游戏默认结束
        Robot robot = new Robot();//实例化机器人
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            开始ToolStripMenuItem.Text = "重新开始";
            //gf.bgcolor = Brushes.DodgerBlue; //设置棋谱背景
            gf.bgcolor = Brushes.Goldenrod; //设置棋谱背景
            gf.form_height = this.Height;  
            gf.form_width = this.Width;
            gf.Line_size = 2;  //设置棋谱线条大小
            gf.Line_color = Color.Black; //设置棋谱线条颜色
            gf.show(this.CreateGraphics());
            Start = true; //游戏开始
            this.label1.Text = " ";
            Digital_Goban = new int[Horizontal + 1, vertical + 1]; //数字棋谱初始化
            robot.enemy_Information = new List<string>(); //初始化机器人的敌方的日记
            robot.i_Information = new List<string>();  //初始化机器人的己方的日记
            robot.chessman_point_x = 1;//初始化机器方无法落子情况下的落子起始位置
            robot.chessman_point_y = 1;//初始化机器方无法落子情况下的落子起始位置
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
        private void Robot_chessman()
        {
            Thread.Sleep(500); //延迟半秒 更人性化
            int robot_chessman_x;  //存放临时日记的x坐标
            int robot_chessman_y;  //存放临时日记的y坐标
            string Detailed_information_enemy = ""; //创建 从敌方日记里读出要执行的临时日记
            string Detailed_information_i = "";     //创建 从己方日记里读出要执行的临时日记
            robot.Testing_DANGER(robot.enemy_type, robot.enemy_Information); //传递敌方类型,敌方日记 ,记录下所有危险日记
            if (robot.enemy_Information.Count != 0)  //在敌方有威胁到己方时
            {
                Detailed_information_enemy = robot.enemy_Information[robot.enemy_Information.Count - 1]; //读出最后一条存入临时日记
                for (int i = 0; i < robot.enemy_Information.Count; i++)
                {
                    if (robot.enemy_Information[i].IndexOf("Level:2") != -1)
                        Detailed_information_enemy = robot.enemy_Information[i];  //循环读出敌方日记中危险程度为2的日记写入临时日记
                }
                for (int i = 0; i < robot.enemy_Information.Count; i++)
                {
                    if (robot.enemy_Information[i].IndexOf("Level:3") != -1)
                        Detailed_information_enemy = robot.enemy_Information[i]; //循环读出敌方日记中危险程度为3的日记写入临时日记
                }
            }
            robot.Testing_DANGER(robot.i_type, robot.i_Information);//传递己方类型,己方日记 ,记录下所有危险日记
            if (robot.i_Information.Count != 0)//在己方有 有利位置下的时候
            {
                Detailed_information_i = robot.i_Information[robot.i_Information.Count - 1]; //读出最后一条存入临时日记
                for (int i = 0; i < robot.i_Information.Count; i++)
                {
                    if (robot.i_Information[i].IndexOf("Level:2") != -1)
                        Detailed_information_i = robot.i_Information[i];  //循环读出己方日记中有利程度为2的日记写入临时日记
                }
                for (int i = 0; i < robot.i_Information.Count; i++)
                {
                    if (robot.i_Information[i].IndexOf("Level:3") != -1)
                        Detailed_information_i = robot.i_Information[i]; //循环读出己方日记中有利程度为3的日记写入临时日记
                }
            }
            if (robot.enemy_Information.Count != 0 && robot.i_Information.Count != 0) //在有己方日记和敌方日记的情况下
            {
                if (int.Parse(Detailed_information_i.Substring(Detailed_information_i.Length - 1)) >= int.Parse(Detailed_information_enemy.Substring(Detailed_information_enemy.Length - 1))) //判断己方的有利程度是否大于敌方的危险程度 如果大于
                    Detailed_information_enemy = Detailed_information_i; //将己方临时日记写入敌方临时日记
            }
            if (Detailed_information_enemy.Length > 0) //在临时日记有记录的情况下
            {
                robot_chessman_x = int.Parse(Detailed_information_enemy.Substring(Detailed_information_enemy.IndexOf("x:") + 2, Detailed_information_enemy.IndexOf("y:") - Detailed_information_enemy.IndexOf("x:") - 3)); //读出临时日记中x坐标
                robot_chessman_y = int.Parse(Detailed_information_enemy.Substring(Detailed_information_enemy.IndexOf("y:") + 2, Detailed_information_enemy.IndexOf(".") - Detailed_information_enemy.IndexOf("y:") - 2));  //读出临时日记中y坐标
                cm2.name = "黑方"; //设置棋子2的名字
                cm2.type = 2;      //设置棋子2的类型
                cm2.color = Brushes.Black; //设置棋子2的颜色
                cm2.show(this.CreateGraphics(), robot_chessman_y, robot_chessman_x);//传递棋子在数字棋谱的位置,并画出
            }
            else //在临时日记没记录的情况下
            {
                robot.first(); //寻找敌方的位置 并在附近下子
                cm2.name = "黑方";//设置棋子2的名字
                cm2.type = 2;     //设置棋子2的类型
                cm2.color = Brushes.Black; //设置棋子2的颜色
                cm2.show(this.CreateGraphics(), robot.chessman_point_y, robot.chessman_point_x);//传递棋子在数字棋谱的位置,并画出
                robot.chessman_point_y++; //在无记录且下方无法下时,起始位置变化
            }
            robot.enemy_Information = new List<string>(); //下完子后初始化敌方日记
            robot.i_Information = new List<string>();     //下完子后初始化己方日记
            cm1_bool = !cm1_bool;  //判断现在是谁下 cm1_bool等于true则现在该棋子1落子
            cm2_bool = !cm2_bool;  //判断现在是谁下 cm2_bool等于true则现在该棋子2落子
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Start)//游戏开始
            {
                int chessman_x = (e.X + gf.Lattice / 2) / gf.Lattice;         //通过鼠标位置确定下子位置
                int chessman_y = (e.Y - 25 + gf.Lattice / 2) / gf.Lattice;    //通过鼠标位置确定下子位置(25为头的高)
                if (chessman_x > 0 && chessman_y > 0 && chessman_x <= Form1.vertical && chessman_y <= Form1.Horizontal && Digital_Goban[chessman_y, chessman_x] == 0)
                {//判断是否落子在棋谱内,同时判断此处是否有棋子
                    if (cm1_bool)
                    {
                        cm1.show(this.CreateGraphics(), chessman_x, chessman_y); //传递棋子在数字棋谱的位置
                        Robot_chessman();
                    }

                    if (outcome(cm1.type)) //传递棋子类型,通过outcome函数判断是否获胜
                    {
                        this.label1.Text = "恭喜" + cm1.name + "获胜";
                        Start = false; //游戏结束
                    }
                    else if (outcome(cm2.type))//传递棋子类型,通过outcome函数判断是否获胜
                    {
                        this.label1.Text = "恭喜" + cm2.name + "获胜";
                        Start = false; //游戏结束
                    }

                    cm1_bool = !cm1_bool;//判断现在是谁下 cm1_bool等于true则现在该棋子1落子
                    cm2_bool = !cm2_bool;//判断现在是谁下 cm2_bool等于true则现在该棋子2落子
                }
            }
        }
        private bool outcome(int chessman_type) //通过棋子类型判断是否获胜
        {
            
            for (int i = 1; i <= Form1.Horizontal; i++)  //循环每行
            {
                for (int j = 1; j <= Form1.vertical - 4; j++) //循环每行的一列
                {
                    if (Digital_Goban[i, j] ==chessman_type  //判断是否有5子相连(横)
                        && Digital_Goban[i, j] == Digital_Goban[i, j + 1]
                        && Digital_Goban[i, j] == Digital_Goban[i, j + 2]
                        && Digital_Goban[i, j] == Digital_Goban[i, j + 3]
                        && Digital_Goban[i, j] == Digital_Goban[i, j + 4])
                    { return true; }
                        
                }
            }
            for (int i = 1; i <= Form1.vertical; i++)//循环每列
            {
                for (int j = 1; j <= Form1.Horizontal - 4; j++)//循环每行的一行
                {
                    if (Digital_Goban[j, i] == chessman_type//判断是否有5子相连(列)
                        && Digital_Goban[j, i] == Digital_Goban[j + 1, i]
                        && Digital_Goban[j, i] == Digital_Goban[j + 2, i]
                        && Digital_Goban[j, i] == Digital_Goban[j + 3, i]
                        && Digital_Goban[j, i] == Digital_Goban[j + 4, i])
                    { return true; }
                }
            }
            for (int i = 1; i <= Form1.Horizontal - 4; i++)  //循环每行
            {
                for (int j = 5; j <= Form1.vertical; j++) //循环每行的一列
                {
                    if (Digital_Goban[i, j] == chessman_type  //判断是否有5子相连(/形状)
                        && Digital_Goban[i, j] == Digital_Goban[i + 1, j - 1]
                        && Digital_Goban[i, j] == Digital_Goban[i + 2, j - 2]
                        && Digital_Goban[i, j] == Digital_Goban[i + 3, j - 3]
                        && Digital_Goban[i, j] == Digital_Goban[i + 4, j - 4])
                    { return true; }
                }
            }
            for (int i = 1; i <= Form1.Horizontal - 4; i++)  //循环每行
            {
                for (int j = 1; j <= Form1.vertical - 4; j++) //循环每行的一列
                {
                    if (Digital_Goban[i, j] == chessman_type  //判断是否有5子相连(\形状)
                        && Digital_Goban[i, j] == Digital_Goban[i + 1, j + 1]
                        && Digital_Goban[i, j] == Digital_Goban[i + 2, j + 2]
                        && Digital_Goban[i, j] == Digital_Goban[i + 3, j + 3]
                        && Digital_Goban[i, j] == Digital_Goban[i + 4, j + 4])
                    { return true; }
                }
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)  //在窗体需要重新绘制时,根据数字棋谱重新绘制
        {
            if (开始ToolStripMenuItem.Text=="重新开始")//在游戏开始过的情况下
            {
                gf.show(this.CreateGraphics()); //绘制棋谱
                for (int i = 1; i <= Form1.Horizontal; i++)
                {
                    for (int j = 1; j <= Form1.vertical; j++) //循环每个位置
                    {
                        if(Form1.Digital_Goban[i,j]==cm1.type) //如果找到棋子1的类型,绘制棋子1
                            cm1.show(this.CreateGraphics(), j, i);
                        if (Form1.Digital_Goban[i, j] == cm2.type)//如果找到棋子2的类型,绘制棋子2
                            cm2.show(this.CreateGraphics(), j, i);
                    }
                }
            }
        }
    }
}
