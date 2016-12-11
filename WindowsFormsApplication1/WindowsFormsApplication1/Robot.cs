using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Robot
    {
        
        public int i_type = 2; //己方类型默认为2
        public int enemy_type = 1; //敌方类型默认为1
        public List<string> i_Information = new List<string>(); //存放己方日记
        public List<string> enemy_Information = new List<string>(); //存放敌方日记
        private int[,] Temporary_Digital = new int[Form1.Horizontal + 1, Form1.vertical + 1]; //创建临时数字棋谱
        string Temporary_chessman = ""; //临时存放棋子的连数情况 如01110
        public bool Temporary_outcome = false; //得知游戏是否结束
        public int chessman_point_x = 1; //无日记可下时 存放的棋子临时坐标x
        public int chessman_point_y = 1; //无日记可下时 存放的棋子临时坐标y
        public void first() //无日记可下时 寻找敌方的位置 并在附近下子
        {
            for (int i = 2; i < Form1.Horizontal; i++)
            {
                for (int j = 2; j < Form1.vertical; j++)  //循环每个位置
                {
                    if (Form1.Digital_Goban[i, j] == enemy_type) //找到敌方棋子
                    {
                        if (Form1.Digital_Goban[i + 1, j] == 0) //其上方可下时,落子其上方
                        {
                            chessman_point_x = i + 1; //坐标存入临时坐标
                            chessman_point_y = j;    //坐标存入临时坐标
                            break;
                        }
                        else if (Form1.Digital_Goban[i - 1, j] == 0)//其下方可下时,落子其下方
                        {
                            chessman_point_x = i - 1;//坐标存入临时坐标
                            chessman_point_y = j;//坐标存入临时坐标
                            break;
                        }
                        if (Form1.Digital_Goban[i, j + 1] == 0)//其右方可下时,落子其右方
                        {
                            chessman_point_x = i;//坐标存入临时坐标
                            chessman_point_y = j + 1;//坐标存入临时坐标
                            break;
                        }
                        else if (Form1.Digital_Goban[i, j - 1] == 0)//其左方可下时,落子其左方
                        {
                            chessman_point_x = i;//坐标存入临时坐标
                            chessman_point_y = j - 1;//坐标存入临时坐标
                            break;
                        }
                    }
                }
            }
        }
        public void Testing_DANGER(int type, List<string> Information) //循环每个空位 并设想填入敌方棋子的类型 找出危险 存入日记
        {
            for (int i = 1; i <= Form1.Horizontal; i++)
            {
                for (int j = 1; j <= Form1.vertical; j++) //循环每个位置
                {
                    for (int i2 = 1; i2 <= Form1.Horizontal; i2++)
                    {
                        for (int j2 = 1; j2 <= Form1.vertical; j2++)
                        {
                            Temporary_Digital[i2, j2] = Form1.Digital_Goban[i2, j2]; //循环获取真实数字棋谱放入临时棋谱内
                        }
                    }
                    if (Temporary_Digital[i, j] == 0) //如果有空位
                    {
                        Temporary_Digital[i, j] = type; //设想填入棋子
                        Temporary_chessman = Temporary_Digital[i, j].ToString(); //填入棋子类型
                        for (int z = 1; z <= 5; z++)
                        {
                            if (j - z > 0)
                            {
                                Temporary_chessman = Temporary_Digital[i, j - z] + Temporary_chessman; //往左历遍并添加棋子类型
                                if (Temporary_Digital[i, j - z] != type) //遇到非己方棋子时退出
                                    break;
                            }
                        }
                        for (int z = 1; z <= 5; z++)
                        {
                            if (j + z <= Form1.Horizontal)
                            {
                                Temporary_chessman = Temporary_chessman + Temporary_Digital[i, j + z];//往右历遍并添加棋子类型
                                if (Temporary_Digital[i, j + z] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }

                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + "0") != -1) //如果下一步棋子连数变量为:01110时 横
                            Information.Add("横三连两边空x:" + i + ",y:" + j + ".Level:1");//写入日记
                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + type.ToString() + "0") != -1)//如果下一步棋子连数变量为:011110时 横
                            Information.Add("横四缺一x:" + i + ",y:" + j + ".Level:2");//写入日记

                        Temporary_chessman = Temporary_Digital[i, j].ToString();//填入棋子类型
                        for (int z = 1; z <= 4; z++)
                        {
                            if (i - z > 0)
                            {
                                Temporary_chessman = Temporary_Digital[i - z, j] + Temporary_chessman;//往下历遍并添加棋子类型
                                if (Temporary_Digital[i - z, j] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        for (int z = 1; z <= 4; z++)
                        {
                            if (i + z <= Form1.vertical)
                            {
                                Temporary_chessman = Temporary_chessman + Temporary_Digital[i + z, j];//往上历遍并添加棋子类型
                                if (Temporary_Digital[i + z, j] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + "0") != -1)//如果下一步棋子连数变量为:01110时 列
                            Information.Add("列三连两边空x:" + i + ",y:" + j + ".Level:1");//写入日记
                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + type.ToString() + "0") != -1)//如果下一步棋子连数变量为:011110时 列
                            Information.Add("列四缺一x:" + i + ",y:" + j + ".Level:2");//写入日记

                        Temporary_chessman = Temporary_Digital[i, j].ToString();//填入棋子类型
                        for (int z = 1; z <= 4; z++)
                        {
                            if (j - z > 0 && i + z <=Form1.vertical)
                            {
                                Temporary_chessman = Temporary_Digital[i + z, j - z] + Temporary_chessman;//往左下历遍并添加棋子类型
                                if (Temporary_Digital[i + z, j - z] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        for (int z = 1; z <= 4; z++)
                        {
                            if (j + z <= Form1.Horizontal && i - z >0)
                            {
                                Temporary_chessman = Temporary_chessman + Temporary_Digital[i - z, j + z];//往右上历遍并添加棋子类型
                                if (Temporary_Digital[i - z, j + z] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + "0") != -1)//如果下一步棋子连数变量为:01110时 /
                            Information.Add("/三连两边空x:" + i + ",y:" + j + ".Level:1");//写入日记
                        if (Temporary_chessman.IndexOf(type.ToString() + type.ToString() + type.ToString() + type.ToString()) != -1)//如果下一步棋子连数变量为:011110时 /
                            Information.Add("/四缺一x:" + i + ",y:" + j + ".Level:2");//写入日记

                        Temporary_chessman = Temporary_Digital[i, j].ToString();//填入棋子类型
                        for (int z = 1; z <= 4; z++)
                        {
                            if (j + z <= Form1.Horizontal && i + z <= Form1.vertical)
                            {
                                Temporary_chessman = Temporary_Digital[i + z, j + z] + Temporary_chessman;//往右下历遍并添加棋子类型
                                if (Temporary_Digital[i + z, j + z] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        for (int z = 1; z <= 4; z++)
                        {
                            if (j - z > 0 && i - z > 0)
                            {
                                Temporary_chessman = Temporary_chessman + Temporary_Digital[i - z, j - z];//往走下历遍并添加棋子类型
                                if (Temporary_Digital[i - z, j - z] != type)//遇到非己方棋子时退出
                                    break;
                            }
                        }
                        if (Temporary_chessman.IndexOf("0" + type.ToString() + type.ToString() + type.ToString() + "0") != -1)//如果下一步棋子连数变量为:01110时 丶
                            Information.Add("丶三连两边空x:" + i + ",y:" + j + ".Level:1");//写入日记
                        if (Temporary_chessman.IndexOf(type.ToString() + type.ToString() + type.ToString() + type.ToString()) != -1)//如果下一步棋子连数变量为:011110时 丶
                            Information.Add("丶四缺一x:" + i + ",y:" + j + ".Level:2");//写入日记


                        if (outcome(Temporary_Digital, type)) //判断下一步是否可以赢棋 如果可以
                            Information.Add("赢x:" + i + ",y:" + j + ".Level:3");//写入日记
                        #region 没用
                        /*
                        for (int i1 = 1; i1 <= Form1.Horizontal; i1++)  //循环每行
                        {
                            for (int j1 = 1; j1 <= Form1.vertical - 4; j1++) //循环每行的一列
                            {
                                if (Temporary_Digital[i1, j1] == 0  //判断是否有01110情况
                                    && Temporary_Digital[i1, j1 + 1] == type
                                    && Temporary_Digital[i1, j1 + 1] == Temporary_Digital[i1, j1 + 2]
                                    && Temporary_Digital[i1, j1 + 1] == Temporary_Digital[i1, j1 + 3]
                                    && Temporary_Digital[i1, j1 + 4] == 0)
                                {
                                    if(Information.IndexOf("横三连两边空x:" + i + ",y:" + j) == -1)
                                        Information.Add("横三连两边空x:" + i + ",y:" + j); //放入详细信息
                                }
                                if ((Temporary_Digital[i1, j1] == 0  //判断是否有01111情况
                                    && Temporary_Digital[i1, j1 + 1] == type
                                    && Temporary_Digital[i1, j1 + 1] == Temporary_Digital[i1, j1 + 2]
                                    && Temporary_Digital[i1, j1 + 1] == Temporary_Digital[i1, j1 + 3]
                                    && Temporary_Digital[i1, j1 + 1] == Temporary_Digital[i1, j1 + 4])
                                    || (Temporary_Digital[i1, j1] == type  //判断是否有11110情况
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1, j1 + 1]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1, j1 + 2]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1, j1 + 3]
                                    && Temporary_Digital[i1, j1 + 4] == 0))
                                {
                                    if (Information.IndexOf("横四缺一x:" + i + ",y:" + j) == -1)
                                        Information.Add("横四缺一x:" + i + ",y:" + j); //放入详细信息
                                }
                            }
                        }
                        for (int i1 = 1; i1 <= Form1.vertical; i1++)//循环每列
                        {
                            for (int j1 = 1; j1 <= Form1.Horizontal - 4; j1++)//循环每行的一行
                            {
                                if (Temporary_Digital[j1, i1] == 0//判断是否有01110情况(列)
                                    && Temporary_Digital[j1 + 1, i1] == type
                                    && Temporary_Digital[j1 + 1, i1] == Temporary_Digital[j1 + 2, i1]
                                    && Temporary_Digital[j1 + 1, i1] == Temporary_Digital[j1 + 3, i1]
                                    && Temporary_Digital[j1 + 4, i1] == 0)
                                {
                                    if (Information.IndexOf("列三连两边空x:" + i + ",y:" + j) == -1)
                                        Information.Add("列三连两边空x:" + i + ",y:" + j); //放入详细信息
                                }

                                if ((Temporary_Digital[j1, i1] == 0//判断是否有01111情况(列)
                                    && Temporary_Digital[j1 + 1, i1] == type
                                    && Temporary_Digital[j1 + 1, i1] == Temporary_Digital[j1 + 2, i1]
                                    && Temporary_Digital[j1 + 1, i1] == Temporary_Digital[j1 + 3, i1]
                                    && Temporary_Digital[j1 + 1, i1] == Temporary_Digital[j1 + 4, i1])
                                    || (Temporary_Digital[j1, i1] == type//判断是否有11110情况(列)
                                    && Temporary_Digital[j1, i1] == Temporary_Digital[j1 + 1, i1]
                                    && Temporary_Digital[j1, i1] == Temporary_Digital[j1 + 2, i1]
                                    && Temporary_Digital[j1, i1] == Temporary_Digital[j1 + 3, i1]
                                    && Temporary_Digital[j1 + 4, i1] == 0))
                                {
                                    if (Information.IndexOf("列四缺一x:" + i + ",y:" + j) == -1)
                                        Information.Add("列四缺一x:" + i + ",y:" + j); //放入详细信息
                                }
                            }
                        }
                        for (int i1 = 1; i1 <= Form1.Horizontal - 4; i1++)  //循环每行
                        {
                            for (int j1 = 5; j1 <= Form1.vertical; j1++) //循环每行的一列
                            {
                                if (Temporary_Digital[i1, j1] == 0  //判断是否有01110(/形状)
                                    && Temporary_Digital[i1 + 1, j1 - 1] == type
                                    && Temporary_Digital[i1 + 1, j1 - 1] == Temporary_Digital[i1 + 2, j1 - 2]
                                    && Temporary_Digital[i1 + 1, j1 - 1] == Temporary_Digital[i1 + 3, j1 - 3]
                                    && Temporary_Digital[i1 + 4, j1 - 4] == 0)
                                {
                                    if (Information.IndexOf("/三连两边空x:" + i + ",y:" + j) == -1)
                                        Information.Add("/三连两边空x:" + i + ",y:" + j); //放入详细信息
                                }
                                if ((Temporary_Digital[i1, j1] == 0  //判断是否有01111(/形状)
                                    && Temporary_Digital[i1 + 1, j1 - 1] == type
                                    && Temporary_Digital[i1 + 1, j1 - 1] == Temporary_Digital[i1 + 2, j1 - 2]
                                    && Temporary_Digital[i1 + 1, j1 - 1] == Temporary_Digital[i1 + 3, j1 - 3]
                                    && Temporary_Digital[i1 + 1, j1 - 1] == Temporary_Digital[i1 + 4, j1 - 4])
                                    || (Temporary_Digital[i1, j1] == type  //判断是否有11110(/形状)
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 1, j1 - 1]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 2, j1 - 2]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 3, j1 - 3]
                                    && Temporary_Digital[i1 + 4, j1 - 4] == 0))
                                {
                                    if (Information.IndexOf("/四缺一x:" + i + ",y:" + j) == -1)
                                        Information.Add("/四缺一x:" + i + ",y:" + j); //放入详细信息
                                }
                            }
                        }
                        for (int i1 = 1; i1 <= Form1.Horizontal - 4; i1++)  //循环每行
                        {
                            for (int j1 = 1; j1 <= Form1.vertical - 4; j1++) //循环每行的一列
                            {
                                if (Temporary_Digital[i1, j1] == 0  //判断是否有01110(\形状)
                                    && Temporary_Digital[i1 + 1, j1 + 1] == type
                                    && Temporary_Digital[i1 + 1, j1 + 1] == Temporary_Digital[i1 + 2, j1 + 2]
                                    && Temporary_Digital[i1 + 1, j1 + 1] == Temporary_Digital[i1 + 3, j1 + 3]
                                    && Temporary_Digital[i1 + 4, j1 + 4] == 0)
                                {
                                    if (Information.IndexOf("丶三连两边空x:" + i + ",y:" + j) == -1)
                                        Information.Add("丶三连两边空x:" + i + ",y:" + j); //放入详细信息
                                }
                                if ((Temporary_Digital[i1, j1] == 0  //判断是否有01111(\形状)
                                    && Temporary_Digital[i1 + 1, j1 + 1] == type
                                    && Temporary_Digital[i1 + 1, j1 + 1] == Temporary_Digital[i1 + 2, j1 + 2]
                                    && Temporary_Digital[i1 + 1, j1 + 1] == Temporary_Digital[i1 + 3, j1 + 3]
                                    && Temporary_Digital[i1 + 1, j1 + 1] == Temporary_Digital[i1 + 4, j1 + 4])
                                    || (Temporary_Digital[i1, j1] == type  //判断是否有11110(\形状)
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 1, j1 + 1]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 2, j1 + 2]
                                    && Temporary_Digital[i1, j1] == Temporary_Digital[i1 + 3, j1 + 3]
                                    && Temporary_Digital[i1 + 4, j1 + 4] == 0))
                                {
                                    if (Information.IndexOf("丶四缺一x:" + i + ",y:" + j) == -1)
                                        Information.Add("丶四缺一x:" + i + ",y:" + j); //放入详细信息
                                }
                            }
                        }
                        for (int i1 = 1; i1 <= Form1.Horizontal - 2; i1++)  //循环每行
                        {
                            for (int j1 = 1; j1 <= Form1.vertical - 2; j1++) //循环每行的一列
                            {
                                if (Temporary_Digital[i1, j1] == type  //判断是否有  11(形状)
                                    && Temporary_Digital[i1 + 1, j1 + 1] == type//11
                                    && Temporary_Digital[i1 + 1, j1] == type
                                    && Temporary_Digital[i1 , j1 + 1] == type)
                                {
                                    if (Information.IndexOf("双层一样x:" + i + ",y:" + j) == -1)
                                        Information.Add("双层一样x:" + i + ",y:" + j); //放入详细信息
                                }
                            }
                        }*/ 
                        #endregion
                    }
                }
            }
        }
        private bool outcome(int[,] Temporary_Array, int chessman_type) //通过棋子类型判断是否获胜
        {

            for (int i = 1; i <= Form1.Horizontal; i++)  //循环每行
            {
                for (int j = 1; j <= Form1.vertical - 4; j++) //循环每行的一列
                {
                    if (Temporary_Array[i, j] == chessman_type  //判断是否有5子相连(横)
                        && Temporary_Array[i, j] == Temporary_Array[i, j + 1]
                        && Temporary_Array[i, j] == Temporary_Array[i, j + 2]
                        && Temporary_Array[i, j] == Temporary_Array[i, j + 3]
                        && Temporary_Array[i, j] == Temporary_Array[i, j + 4])
                    { return true; }

                }
            }
            for (int i = 1; i <= Form1.vertical; i++)//循环每列
            {
                for (int j = 1; j <= Form1.Horizontal - 4; j++)//循环每行的一行
                {
                    if (Temporary_Array[j, i] == chessman_type//判断是否有5子相连(列)
                        && Temporary_Array[j, i] == Temporary_Array[j + 1, i]
                        && Temporary_Array[j, i] == Temporary_Array[j + 2, i]
                        && Temporary_Array[j, i] == Temporary_Array[j + 3, i]
                        && Temporary_Array[j, i] == Temporary_Array[j + 4, i])
                    { return true; }
                }
            }
            for (int i = 1; i <= Form1.Horizontal - 4; i++)  //循环每行
            {
                for (int j = 5; j <= Form1.vertical; j++) //循环每行的一列
                {
                    if (Temporary_Array[i, j] == chessman_type  //判断是否有5子相连(/形状)
                        && Temporary_Array[i, j] == Temporary_Array[i + 1, j - 1]
                        && Temporary_Array[i, j] == Temporary_Array[i + 2, j - 2]
                        && Temporary_Array[i, j] == Temporary_Array[i + 3, j - 3]
                        && Temporary_Array[i, j] == Temporary_Array[i + 4, j - 4])
                    { return true; }
                }
            }
            for (int i = 1; i <= Form1.Horizontal - 4; i++)  //循环每行
            {
                for (int j = 1; j <= Form1.vertical - 4; j++) //循环每行的一列
                {
                    if (Temporary_Array[i, j] == chessman_type  //判断是否有5子相连(\形状)
                        && Temporary_Array[i, j] == Temporary_Array[i + 1, j + 1]
                        && Temporary_Array[i, j] == Temporary_Array[i + 2, j + 2]
                        && Temporary_Array[i, j] == Temporary_Array[i + 3, j + 3]
                        && Temporary_Array[i, j] == Temporary_Array[i + 4, j + 4])
                    { return true; }
                }
            }
            return false;
        }
    }
}
