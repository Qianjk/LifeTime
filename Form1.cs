using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LifeTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int is_leap_year(int year) //判断闰年的函数 
        {
            int leap;
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) leap = 1; //leap=1 是闰年
            else leap = 0;
            return leap;
        }


        /* 函数 len_of_month(int year,int mo nth) 的返回值为某年year的某月month的天数 */
        public int len_of_month(int year, int month)
        {
            int month_days;
            if (month == 2) //二月份的天数要判断闰年 调用函数
                if (is_leap_year(year) == 1) month_days = 29;
                else month_days = 28;
            else if (month == 4 || month == 6 || month == 9 || month == 11) month_days = 30;
            else month_days = 31;
            return month_days;
        }


        /*函数len_of_days()的返回值为该日期date是该年year的第几天 */
        public int len_of_days(int year, int month, int date)
        {
            int total_days, n;
            for (n = 1, total_days = 0; n < month; n++)
                total_days += len_of_month(year, n); // 调用len_of_month(year,n)函数， n是变化着的month
            total_days += date;
            return total_days;
        }
      
        public void run()
        {
            DateTime DT = System.DateTime.Now;

            int year1, year2, month1, month2, date1, date2, days1, days2, days3, days, t, i;

            year1 = DT.Year;
            month1 = DT.Month;
            date1 = DT.Day;

            year2 = Int32.Parse(textBox1.Text);
            month2 = Int32.Parse(textBox2.Text);
            date2 = Int32.Parse(textBox3.Text);

            days1 = len_of_days(year1, month1, date1); //调用len_of_days函数今天是今年的第几天
            days2 = len_of_days(year2, month2, date2); //生日是当年的第几天

            for (i = year2 + 1, t = 0; i < year1; i++)
                if (is_leap_year(i) == 1) t = t + 1;// 中间几年有多少个闰年

            days3 = (year1 - year2 - 1) * 365 + t; // 中间几年有多少天

            if (is_leap_year(year2) == 1) days = days1 + (366 - days2 + 1) + days3;
            else days = days1 + (365 - days2 + 1) + days3; //days 是总计活了多少天

            days = days - 1;
            long seconds1 = DT.Hour * 3600 + DT.Minute * 60 + DT.Second;
            long seconds = 86400 * days + seconds1;


            double ages1, ages2;
            ages1 = 366 - days1;
            ages2 = 366 - days2;
            double age;

            if (days1 > days2) age = (year1 - year2 + ((double)days1 - (double)days2) / 366);
            else age = year1 - year2 + (ages2 + days1) / 366 - 1;

            int year = year1 - year2;
            int month = (year1 - year2) * 12 + month1 - month2 + 1;
            label4.Text = Convert.ToString("你已经活了" + age + "岁;\n\n" + "已经活了" + year + "年/" + month + "月/" + days + "天;\n\n" + "已经活了" + seconds + "秒。");

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                run();
            }
            catch
            { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                run();
            }
            catch
            { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                run();
            }
            catch
            { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }    
}

