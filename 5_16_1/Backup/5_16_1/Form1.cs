using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace _5_16_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread MyListenThread;
        //声明网络监听对象
        private bool host = false;
        private bool start = false;
        private TcpListener MyTcpListener;
        private int i=0;
        private int xx = -1;
        private int yy = -1;
        private int name=0;
        private int[,] map=new int [14,14];
        private bool black=false;
        private bool flag = false;
        private bool prime;
        public PictureBox[] Plate = new PictureBox[400];
        private void xiazi(int y1,int x1,int a)
        {
            Plate[i] = new PictureBox();
            pictureBox1.Controls.Add(Plate[i]);
            Plate[i].Left = x1 * 30 - 10;
            Plate[i].Top = y1 * 30 - 10;
            Plate[i].Width = 23;
            Plate[i].Height = 23;
            Plate[i].Tag = i;
            if (black == false)
            {
                if (a == 1)
                {
                    map[y1 - 1, x1 - 1] = 0;
                    Plate[i].Image = Properties.Resources.白子;
                }
                else if (a == 2)
                {
                    map[y1 - 1, x1 - 1] = 1;
                    Plate[i].Image = Properties.Resources.黑子;
                }
            }
            else if (black == true)
            {
                if (a == 1)
                {
                    map[y1 - 1, x1 - 1] = 1;
                    Plate[i].Image = Properties.Resources.黑子;
                }
                else if (a == 2)
                {
                    map[y1 - 1, x1 - 1] = 0;
                    Plate[i].Image = Properties.Resources.白子;
                }
            }
            Plate[i].SizeMode = PictureBoxSizeMode.StretchImage;//将图像调整为控件大小
            //Plate[i].Parent = pictureBox1;
            i++;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x3 = e.X;
            int y3 = e.Y;
            int x1 = x3 / 30;
            int y1 = y3 / 30;
            int x2 = x3 - x1 * 30;
            int y2 = y3 - y1 * 30;
            if (x2 >= 15)
            {
                x1 = x1 + 1;
            }
            if (y2 >= 15)
            {
                y1 = y1 + 1;
            }
            if (x1 >= 1 && y1 >= 1&&map[y1 - 1, x1 - 1]==-1)
            {
                if (flag == true)
                {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            try
                            {
                                int m=y1 * 100 + x1;
                                string MyMessage = Convert.ToString(m);
                                //根据目标计算机地址建立连接
                                TcpClient MyTcpClient = new TcpClient(this.textBox1.Text, 8885);
                                //获得用于网络访问的数据流
                                NetworkStream MyTcpStream = MyTcpClient.GetStream();
                                StreamWriter MyStream = new StreamWriter(MyTcpStream);
                                //将字符串写入流
                                MyStream.Write(MyMessage);
                                //将缓冲数据写入基础流  
                                MyStream.Flush();
                                //关闭网络流
                                MyStream.Close();
                                MyTcpClient.Close();
                            }
                            catch (Exception Err)
                            {
                                MessageBox.Show(Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            xiazi(y1, x1,1);
                        }
                        flag = false;
                        label5.Text = "对手下棋！";
                        label6.Text = "";
                    prime = judge(y1 - 1, x1 - 1);
                    if (prime == true)
                    {
                            flag = false;
                            label3.Text = "恭喜你获胜了！！！";
                            string MyMessage = "win";
                            button1.Enabled = true;
                            host = true;
                            xx = -1;
                            yy = -1;
                            //根据目标计算机地址建立连接
                            TcpClient MyTcpClient = new TcpClient(this.textBox1.Text, 8885);
                            //获得用于网络访问的数据流
                            NetworkStream MyTcpStream = MyTcpClient.GetStream();
                            StreamWriter MyStream = new StreamWriter(MyTcpStream);
                            //将字符串写入流
                            MyStream.Write(MyMessage);
                            //将缓冲数据写入基础流  
                            MyStream.Flush();
                            //关闭网络流
                            MyStream.Close();
                            MyTcpClient.Close();
                    }
                }
            }
        }

        private  bool judge(int a, int b)
        {
            if (i < 9) return false;
            int num = 1;
            int x = a;
            while (x>0)
            {
                x=x-1;
                if (map[x,b] == -1 || map[x,b] != map[a,b])
                     break;
                 else
                    num++;
            }
            x = a;
            while (x < 12)
            {
                x=x+1;
                if (map[x,b] == -1 || map[x,b] != map[a,b])
                  break;
                else
                    num++;
            }
            if (num >= 5) return true;
            num = 1;
            int y = b;
            while (y>0)
            {
                y = y - 1;
                if (map[a,y] == -1 || map[a,y] != map[a,b])
                     break;
                else
                   num++;
            }
            y = b;
            while (y < 12)
            {
                y = y + 1;
                    if (map[a,y] == -1 || map[a,y] != map[a,b])
                        break;
                    else
                        num++;
            }
            if (num >= 5) return true;
            num = 1;
            x = a; y = b;
            while (x > 0 && y > 0)
            {
                y=y-1;
                x=x-1;
                    if (map[x,y] == -1 || map[x,y] != map[a,b])
                        break;
                    else num++;
            }
            x = a; y = b;
            while (x < 12 && y < 12)
            {
                y++;
                x++;
                    if (map[x,y] == -1 || map[x,y] != map[a,b])
                        break;
                    else num++;
            }
            if (num >= 5) return true;

            num = 1;
            x = a; y = b;
            while (x < 12 && y > 0)
            {
                x++;
                y--;
                    if (map[x,y] == -1 || map[x,y] != map[a,b])
                        break;
                    else num++;
            }
            x = a; y = b;
            while (x > 0 && y < 12)
            {
                x--;
                y++;
                    if (map[x,y] == -1 || map[x,y] != map[a,b])
                        break;
                    else num++;
            }
            if (num >= 5) return true;
            else return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "联机PK")
            {
                if (textBox1.Text.Length < 1)
                    return;
                try
                {
                    string MyMessage = "PK";
                    TcpClient MyTcpClient = new TcpClient(this.textBox1.Text, 8885);
                    NetworkStream MyTcpStream = MyTcpClient.GetStream();
                    StreamWriter MyStream = new StreamWriter(MyTcpStream);
                    //将字符串写入流
                    MyStream.Write(MyMessage);
                    //将缓冲数据写入基础流  
                    MyStream.Flush();
                    //关闭网络流
                    MyStream.Close();
                    MyTcpClient.Close();
                    button1.Text = "开始游戏";
                    host = true;
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(button1.Text=="开始游戏")
            {
                pictureBox1.Controls.Clear();
                int j, k;
                for (j = 0; j < 13; j++)
                {
                    for (k = 0; k < 13; k++)
                    {
                        map[j, k] = -1;
                    }
                }
                //flag = true;
                button1.Enabled = false;
                label3.Text = "";
                if (host == true)
                {
                    //start = true;
                    Random brr = new Random();
                    int arr = brr.Next(1, 100);
                    if (arr % 2 == 0)
                    {
                        pictureBox4.Image = Properties.Resources.白子1;
                        name = 1;
                        pictureBox5.Image = Properties.Resources.黑子1;
                        label5.Text = "请下棋！";
                        label6.Text = "";
                        black = false;
                        flag = true;
                        try
                        {
                            string MyMessage = "1";
                            TcpClient MyTcpClient = new TcpClient(this.textBox1.Text, 8885);
                            NetworkStream MyTcpStream = MyTcpClient.GetStream();
                            StreamWriter MyStream = new StreamWriter(MyTcpStream);
                            //将字符串写入流
                            MyStream.Write(MyMessage);
                            //将缓冲数据写入基础流  
                            MyStream.Flush();
                            //关闭网络流
                            MyStream.Close();
                            MyTcpClient.Close();
                        }
                        catch (Exception Err)
                        {
                            MessageBox.Show(Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        pictureBox4.Image = Properties.Resources.黑子1;
                        name = 2;
                        pictureBox5.Image = Properties.Resources.白子1;
                        label5.Text = "对手下棋！";
                        label6.Text = "";
                        black = true;
                        try
                        {
                            string MyMessage = "2";
                            TcpClient MyTcpClient = new TcpClient(this.textBox1.Text, 8885);
                            NetworkStream MyTcpStream = MyTcpClient.GetStream();
                            StreamWriter MyStream = new StreamWriter(MyTcpStream);
                            //将字符串写入流
                            MyStream.Write(MyMessage);
                            //将缓冲数据写入基础流  
                            MyStream.Flush();
                            //关闭网络流
                            MyStream.Close();
                            MyTcpClient.Close();
                        }
                        catch (Exception Err)
                        {
                            MessageBox.Show(Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    start = true;
                }
                else
                {
                    start = true;
                    label3.Text = "";
                }
            }

        }

        private void StartListen()
        {
            MyTcpListener = new TcpListener(8885);
            //开始监听
            MyTcpListener.Start();
            while (true)
            {
                TcpClient MyTcpClient = MyTcpListener.AcceptTcpClient();
                NetworkStream MyStream = MyTcpClient.GetStream();
                byte[] MyBytes = new byte[1024];
                int MyBytesRead = MyStream.Read(MyBytes, 0, MyBytes.Length);
                string MyMessage = System.Text.Encoding.Default.GetString(MyBytes, 0, MyBytesRead);
                if (MyMessage == "PK")
                    button1.Text = "开始游戏";
                else if (MyMessage == "win")
                {
                    flag = false;
                    label3.Text = "很遗憾你输了！！！";
                    xx = -1;
                    yy = -1;
                    host = false;
                    start = false;
                }
                else
                {
                    if (start == false)
                    {

                        if (MyMessage == "1")
                        {
                            pictureBox4.Image = Properties.Resources.黑子1;
                            name = 1;
                            pictureBox5.Image = Properties.Resources.白子1;
                            label5.Text = "对手下棋！";
                            label6.Text = "";
                            button1.Enabled = true;
                            flag = false;
                            black = true;
                        }
                        else if (MyMessage == "2")
                        {
                            pictureBox4.Image = Properties.Resources.白子1;
                            name = 1;
                            pictureBox5.Image = Properties.Resources.黑子1;
                            label5.Text = "请下棋！";
                            label6.Text = "";
                            button1.Enabled = true;
                            flag = true;
                            black = false;
                        }
                    }
                    if (start == true)
                    {
                        int m = Convert.ToInt32(MyMessage);
                        int x = m % 100;
                        int y = m / 100;
                        xx = x; 
                        yy = y;
                       // xiazi(y, x);
                        flag = true;
                        label5.Text = "请下棋！";
                        label6.Text = "";
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 500; 
            this.MyListenThread = new Thread(new ThreadStart(StartListen));
            //启动线程
            this.MyListenThread.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (xx != -1 && yy != -1)
            {
                xiazi(yy, xx,2);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {//关闭SOCKET
			try
			{
				if (this.MyTcpListener!=null)
				{//关闭监听器
					this.MyTcpListener.Stop();
				}
				if (this.MyListenThread!=null)
				{	//如果线程还处于运行状态就关闭它
					if (this.MyListenThread.ThreadState==ThreadState.Running)
					{
						this.MyListenThread.Abort();
					}
				}
			}
			catch(Exception Err)
			{
				  MessageBox.Show(Err.Message,"信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
        }
    }
}
