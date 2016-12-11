using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wuziqi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] weizhi=new int[18,13];
        bool yin = false;
        bool weixian_3 = false;
        int weixian_3_weizhix;
        int weixian_3_weizhiy;
        bool weixian_3_hen = false;
        bool weixian_3_shu = false;
        bool weixian_3_xia = false;
        bool weixian_3_shang = false;
        bool weixian_4 = false;
        int weixian_4_weizhix;
        int weixian_4_weizhiy;
        bool weixian_4_hen = false;
        bool weixian_4_shu = false;
        bool weixian_4_xia = false;
        bool weixian_4_shang = false;
        Random rad = new Random();
        int x;
        int y;
        bool diyici = false;
        int sj1 = 1;
        int sj2 = 1;
        int sj3 = 1;
        int sj4 = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            x = rad.Next(10) + 1;
            y = rad.Next(10) + 1;
        }
        private void huaqitu()
        {
            label4.Text = "";
            weizhi = new int[18, 13];
            yin = false;
            weixian_3 = false;
            weixian_3_weizhix = 0;
            weixian_3_weizhiy = 0;
            weixian_3_hen = false;
            weixian_3_shu = false;
            weixian_3_xia = false;
            weixian_3_shang = false;
            weixian_4 = false;
            weixian_4_weizhix = 0;
            weixian_4_weizhiy = 0;
            weixian_4_hen = false;
            weixian_4_shu = false;
            weixian_4_xia = false;
            weixian_4_shang = false;
            rad = new Random();
            diyici = false;
            sj1 = 1;
            sj2 = 1;
            sj3 = 1;
            sj4 = 1;
            Graphics gr = panel2.CreateGraphics();
            gr.Clear(Color.Khaki);
            Pen pen = new Pen(Color.Black, 2);
            gr.DrawLine(pen, 15, 15, 496, 15);
            gr.DrawLine(pen, 15, 45, 496, 45);
            gr.DrawLine(pen, 15, 75, 496, 75);
            gr.DrawLine(pen, 15, 105, 496, 105);
            gr.DrawLine(pen, 15, 135, 496, 135);
            gr.DrawLine(pen, 15, 165, 496, 165);
            gr.DrawLine(pen, 15, 195, 496, 195);
            gr.DrawLine(pen, 15, 225, 496, 225);
            gr.DrawLine(pen, 15, 255, 496, 255);
            gr.DrawLine(pen, 15, 285, 496, 285);
            gr.DrawLine(pen, 15, 315, 496, 315);
            gr.DrawLine(pen, 15, 345, 496, 345);

            gr.DrawLine(pen, 15, 15, 15, 346);
            gr.DrawLine(pen, 45, 15, 45, 346);
            gr.DrawLine(pen, 75, 15, 75, 346);
            gr.DrawLine(pen, 105, 15, 105, 346);
            gr.DrawLine(pen, 135, 15, 135, 346);
            gr.DrawLine(pen, 165, 15, 165, 346);
            gr.DrawLine(pen, 195, 15, 195, 346);
            gr.DrawLine(pen, 225, 15, 225, 346);
            gr.DrawLine(pen, 255, 15, 255, 346);
            gr.DrawLine(pen, 285, 15, 285, 346);
            gr.DrawLine(pen, 315, 15, 315, 346);
            gr.DrawLine(pen, 345, 15, 345, 346);
            gr.DrawLine(pen, 375, 15, 375, 346);
            gr.DrawLine(pen, 405, 15, 405, 346);
            gr.DrawLine(pen, 435, 15, 435, 346);
            gr.DrawLine(pen, 465, 15, 465, 346);
            gr.DrawLine(pen, 495, 15, 495, 346);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始")
            {
                huaqitu();
                button1.Text = "重新开始";
                label3.Visible = true;
            }
            else
                huaqitu();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void pdhs(int yanse)//yanse 1为黑  2为白
        {
            if (yin == false)
            {
                int lianshu = 1;//横赢
                for (int j = 1; j <= 12; j++)
                {
                    for (int i = 1; i < 17; i++)
                    {
                        if (weizhi[i, j] == yanse && weizhi[i + 1, j] == yanse)
                        {
                            lianshu++;
                            if (yanse == 1 && lianshu == 3)
                            {
                                try
                                {
                                    if (weizhi[i - 2, j] == 0 && weizhi[i + 2, j] == 0)
                                    {
                                        weixian_3 = true;
                                        weixian_3_hen = true;
                                        weixian_3_weizhix = i - 2;
                                        weixian_3_weizhiy = j;
                                    }
                                }
                                catch { }
                            }
                            if (yanse == 1 && lianshu == 4)
                            {
                                try
                                {
                                    if (weizhi[i - 3, j] == 0 || weizhi[i + 2, j] == 0)
                                    {
                                        weixian_4 = true;
                                        weixian_4_hen = true;
                                        weixian_4_weizhix = i - 3;
                                        weixian_4_weizhiy = j;
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                            lianshu = 1;
                        if (lianshu == 5)
                        {
                            if(yanse==1)
                                label4.Text="黑棋获胜了";
                            else if(yanse==2)
                                label4.Text = "白棋获胜了"; 
                            yin = true;
                            break;
                        }
                    }
                    if (lianshu == 5)
                        break;
                }
            }
            if (yin == false)
            {
                int lianshu1 = 1;//竖赢
                for (int i = 1; i <= 17; i++)
                {
                    for (int j = 1; j < 12; j++)
                    {
                        if (weizhi[i, j] == yanse && weizhi[i, j + 1] == yanse)
                        {
                            lianshu1++;
                            if (yanse == 1 && lianshu1 == 3)
                            {
                                try
                                {
                                    if (weizhi[i, j - 2] == 0 && weizhi[i, j + 2] == 0)
                                    {
                                        weixian_3 = true;
                                        weixian_3_shu = true;
                                        weixian_3_weizhix = i;
                                        weixian_3_weizhiy = j-2;
                                    }
                                }
                                catch { }
                            }
                            if (yanse == 1 && lianshu1 == 4)
                            {
                                try
                                {
                                    if (weizhi[i, j - 3] == 0 || weizhi[i, j + 2] == 0)
                                    {
                                        weixian_4 = true;
                                        weixian_4_shu = true;
                                        weixian_4_weizhix = i;
                                        weixian_4_weizhiy = j - 3;
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                            lianshu1 = 1;
                        if (lianshu1 == 5)
                        {
                            if (yanse == 1)
                                label4.Text = "黑棋获胜了";
                            else if (yanse == 2)
                                label4.Text = "白棋获胜了"; 
                            yin = true;
                            break;
                        }
                    }
                    if (lianshu1 == 5)
                        break;
                }
            }
            if (yin == false)
            {//斜赢
                for (int j = 1; j < 9; j++)
                {
                    for (int i = 1; i < 14; i++)
                    {
                        if (weizhi[i, j] == yanse && weizhi[i + 1, j + 1] == yanse
                            && weizhi[i + 2, j + 2] == yanse)
                        {
                            if (yanse == 1)
                            {
                                try
                                {
                                    if (weizhi[i-1, j-1] == 0 && weizhi[i + 3, j + 3] == 0)
                                    {
                                        weixian_3 = true;
                                        weixian_3_xia = true;
                                        weixian_3_weizhix = i - 1;
                                        weixian_3_weizhiy = j - 1;
                                    }
                                }
                                catch { }
                            }
                            if (weizhi[i + 3, j + 3] == yanse)
                            {
                                try
                                {
                                    if (weizhi[i - 1, j - 1] == 0 || weizhi[i + 4, j + 4] == 0)
                                    {
                                        weixian_4 = true;
                                        weixian_4_xia = true;
                                        weixian_4_weizhix = i - 1;
                                        weixian_4_weizhiy = j - 1;
                                    }
                                }
                                catch { }
                                if (weizhi[i + 4, j + 4] == yanse)
                                {
                                    if (yanse == 1)
                                        label4.Text = "黑棋获胜了";
                                    else if (yanse == 2)
                                        label4.Text = "白棋获胜了"; 
                                    yin = true;
                                    break;
                                }
                            }
                        }
                        if (yin)
                            break;
                    }
                }
            }
            if (yin == false)
            {//斜赢
                for (int i = 1; i < 14; i++)
                {
                    for (int j = 12; j > 1; j--)
                    {
                        if (weizhi[i, j] == yanse && weizhi[i + 1, j - 1] == yanse
                            && weizhi[i + 2, j - 2] == yanse)
                           {
                            if (yanse == 1)
                            {
                                try
                                {
                                    if (weizhi[i -1, j + 1] == 0 && weizhi[i +3, j - 3] == 0)
                                    {
                                        weixian_3 = true;
                                        weixian_3_shang = true;
                                        weixian_3_weizhix = i - 1;
                                        weixian_3_weizhiy = j + 1;
                                    }
                                }
                                catch { }
                            }
                            if (weizhi[i + 3, j - 3] == yanse)
                            {
                                try
                                {
                                    if (weizhi[i - 1, j + 1] == 0 || weizhi[i + 4, j - 4] == 0)
                                    {
                                        weixian_4 = true;
                                        weixian_4_shang = true;
                                        weixian_4_weizhix = i - 1;
                                        weixian_4_weizhiy = j + 1;
                                    }
                                }
                                catch { }
                                if (weizhi[i + 4, j - 4] == yanse)
                                {
                                    if (yanse == 1)
                                        label4.Text = "黑棋获胜了";
                                    else if (yanse == 2)
                                        label4.Text = "白棋获胜了"; 
                                    yin = true;
                                    break;
                                }
                            }
                        }
                        if (yin)
                            break;
                    }
                }
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (button1.Text == "重新开始")
            {
                if (yin)
                    MessageBox.Show("这盘已结束,请重新开始");
                else
                {
                    double shu = ((float)e.X + 15) / (float)30;
                    int zhengshu = (int)shu;
                    float yu = (float)shu - (float)zhengshu;
                    if (yu >= 0.5)
                        zhengshu += 1;
                    double shu1 = ((float)e.Y + 15) / (float)30;
                    int zhengshu1 = (int)shu1;
                    float yu1 = (float)shu1 - (float)zhengshu1;
                    if (yu1 >= 0.5)
                        zhengshu1 += 1;
                    label2.Text = zhengshu.ToString() + "  " + zhengshu1.ToString();
                    Graphics gr = panel2.CreateGraphics();
                    if (label3.Text == "现在是黑棋下")
                    {
                        if (weizhi[zhengshu, zhengshu1] == 0)
                        {
                            Brush brush = Brushes.Black;
                            gr.FillEllipse(brush, zhengshu * 30 - 30, zhengshu1 * 30 - 30, 30, 30);
                            weizhi[zhengshu, zhengshu1] = 1;
                            pdhs(1);
                            label3.Text = "现在是白棋下";
                            timer1.Enabled = true;
                        }
                        else
                            MessageBox.Show("请下别处,此处已有棋子");
                    }
                    //else if (label3.Text == "现在是白棋下")
                    //{
                        //if (weizhi[zhengshu, zhengshu1] == 0)
                        //{
                        //    Brush brush = Brushes.White;
                        //    gr.FillEllipse(brush, zhengshu * 30 - 30, zhengshu1 * 30 - 30, 30, 30);
                        //    weizhi[zhengshu, zhengshu1] = 2;
                        //    pdhs(2);
                        //    label3.Text = "现在是黑棋下";
                        //}
                        //else
                        //    MessageBox.Show("请下别处,此处已有棋子");
                    //}
                }
            }
            else
                MessageBox.Show("请先开始");
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + "  " + e.Y.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool bai = true;
            if (weixian_3 || weixian_4)
            {
                if (bai)
                {
                    if (weixian_4_hen)
                    {
                        if (weixian_4_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                            weizhi[weixian_4_weizhix + 5, weixian_4_weizhiy] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_4_weizhix, weixian_4_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix, weixian_4_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix + 5, weixian_4_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_4_hen = false;
                    }
                    else if (weixian_3_hen)
                    {
                        if (weixian_3_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                            weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_3_weizhix, weixian_3_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix, weixian_3_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_3_hen = false;
                    }
                }
                if (bai)
                {
                    if (weixian_4_shu)
                    {
                        if (weixian_4_weizhiy == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, (weixian_4_weizhiy + 5) * 30 - 30, 30, 30);
                            weizhi[weixian_4_weizhix, weixian_4_weizhiy + 5] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_4_weizhix, weixian_4_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix, weixian_4_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, (weixian_4_weizhiy + 5) * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix, weixian_4_weizhiy + 5] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_4_shu = false;
                    }
                    else if (weixian_3_shu)
                    {
                        if (weixian_3_weizhiy == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, (weixian_3_weizhiy + 4) * 30 - 30, 30, 30);
                            weizhi[weixian_3_weizhix, weixian_3_weizhiy + 4] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_3_weizhix, weixian_3_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix, weixian_3_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, (weixian_3_weizhiy + 4) * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix, weixian_3_weizhiy + 4] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_3_shu = false;
                    }
                }
                if (bai)
                {
                    if (weixian_4_xia)
                    {
                        if (weixian_4_weizhiy == 0 || weixian_4_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, (weixian_4_weizhiy + 5) * 30 - 30, 30, 30);
                            weizhi[weixian_4_weizhix + 5, weixian_4_weizhiy + 5] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_4_weizhix, weixian_4_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix, weixian_4_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, (weixian_4_weizhiy + 5) * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix + 5, weixian_4_weizhiy + 5] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_4_xia = false;
                    }
                    else if (weixian_3_xia)
                    {
                        if (weixian_3_weizhiy == 0 || weixian_3_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, (weixian_3_weizhiy + 4) * 30 - 30, 30, 30);
                            weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy + 4] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_3_weizhix, weixian_3_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix, weixian_3_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, (weixian_3_weizhiy + 4) * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy + 4] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_3_xia = false;
                    }
                }
                if (bai)
                {
                    if (weixian_4_shang)
                    {
                        if (weixian_4_weizhiy == 0 || weixian_4_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, (weixian_4_weizhiy - 5) * 30 - 30, 30, 30);
                            weizhi[weixian_4_weizhix + 4, weixian_4_weizhiy - 4] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_4_weizhix, weixian_4_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_4_weizhix * 30 - 30, weixian_4_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix, weixian_4_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_4_weizhix + 5) * 30 - 30, (weixian_4_weizhiy - 5) * 30 - 30, 30, 30);
                                weizhi[weixian_4_weizhix + 5, weixian_4_weizhiy - 5] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_4_shang = false;
                    }
                    else if (weixian_3_shang)
                    {
                        if (weixian_3_weizhiy == 0 || weixian_3_weizhix == 0)
                        {
                            Graphics gr = panel2.CreateGraphics();
                            Brush brush = Brushes.White;
                            gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, (weixian_3_weizhiy - 4) * 30 - 30, 30, 30);
                            weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy - 4] = 2;
                            pdhs(2);
                            label3.Text = "现在是黑棋下";
                            bai = false;
                        }
                        else
                        {
                            if (weizhi[weixian_3_weizhix, weixian_3_weizhiy] == 0)
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, weixian_3_weizhix * 30 - 30, weixian_3_weizhiy * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix, weixian_3_weizhiy] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                            else
                            {
                                Graphics gr = panel2.CreateGraphics();
                                Brush brush = Brushes.White;
                                gr.FillEllipse(brush, (weixian_3_weizhix + 4) * 30 - 30, (weixian_3_weizhiy - 4) * 30 - 30, 30, 30);
                                weizhi[weixian_3_weizhix + 4, weixian_3_weizhiy - 4] = 2;
                                pdhs(2);
                                label3.Text = "现在是黑棋下";
                                bai = false;
                            }
                        }
                        weixian_3_shang = false;
                    }
                }
                weixian_4 = false;
                weixian_3 = false;
            }
            else
            {
                if (weizhi[x, y] == 0 && diyici==false)
                {
                    Graphics gr = panel2.CreateGraphics();
                    Brush brush = Brushes.White;
                    gr.FillEllipse(brush, x * 30 - 30, y * 30 - 30, 30, 30);
                    weizhi[x, y] = 2;
                    pdhs(2);
                    label3.Text = "现在是黑棋下";
                    diyici = true;
                }
                else
                {
                    if (diyici == false)
                    {
                        x += 1;
                        y += 1;
                        Graphics gr = panel2.CreateGraphics();
                        Brush brush = Brushes.White;
                        gr.FillEllipse(brush, x * 30 - 30, y * 30 - 30, 30, 30);
                        weizhi[x, y] = 2;
                        pdhs(2);
                        label3.Text = "现在是黑棋下";
                        diyici = true;
                    }
                    else
                    {
                        xiaqi();
                    }
                }
            }
            timer1.Enabled = false;
            label3.Text = "现在是黑棋下";
        }
        private void xiaqi()
        {
            try
            {
                if (weizhi[x + sj1, y] == 0)
                {
                    Graphics gr = panel2.CreateGraphics();
                    Brush brush = Brushes.White;
                    gr.FillEllipse(brush, (x + sj1) * 30 - 30, y * 30 - 30, 30, 30);
                    weizhi[x + sj1, y] = 2;
                    pdhs(2);
                    label3.Text = "现在是黑棋下";
                    diyici = true;
                    sj1++;
                }
                else if (weizhi[x - sj2, y] == 0)
                {
                    Graphics gr = panel2.CreateGraphics();
                    Brush brush = Brushes.White;
                    gr.FillEllipse(brush, (x - sj2) * 30 - 30, y * 30 - 30, 30, 30);
                    weizhi[x - sj2, y] = 2;
                    pdhs(2);
                    label3.Text = "现在是黑棋下";
                    diyici = true;
                    sj2++;
                }
                else if (weizhi[x, y + sj3] == 0)
                {
                    Graphics gr = panel2.CreateGraphics();
                    Brush brush = Brushes.White;
                    gr.FillEllipse(brush, x * 30 - 30, (y + sj3) * 30 - 30, 30, 30);
                    weizhi[x, y + sj3] = 2;
                    pdhs(2);
                    label3.Text = "现在是黑棋下";
                    diyici = true;
                    sj3++;
                }
                else if (weizhi[x, y - sj4] == 0)
                {
                    Graphics gr = panel2.CreateGraphics();
                    Brush brush = Brushes.White;
                    gr.FillEllipse(brush, x * 30 - 30, (y - sj4) * 30 - 30, 30, 30);
                    weizhi[x, y - sj4] = 2;
                    pdhs(2);
                    label3.Text = "现在是黑棋下";
                    diyici = true;
                    sj4++;
                }
                else
                {
                    x = rad.Next(10) + 1;
                    y = rad.Next(10) + 1;
                    sj1 = 1;
                    sj2 = 1;
                    sj3 = 1;
                    sj4 = 1;
                    xiaqi();
                }
            }
            catch
            {
                x = rad.Next(10) + 1;
                y = rad.Next(10) + 1;
                sj1 = 1;
                sj2 = 1;
                sj3 = 1;
                sj4 = 1;
                xiaqi();
            }
        }
    }
}
