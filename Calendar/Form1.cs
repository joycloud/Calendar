using Calendar.dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        DateTime life_time = DateTime.Parse("2022/04/15 12:00:00");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //變更文字顏色
            this.BackColor = Color.FromArgb(82, 82, 82);
            title01.ForeColor = Color.FromArgb(250, 250, 250);
            remark01.ForeColor = Color.FromArgb(255, 255, 194);
            timeLeft01.ForeColor = Color.FromArgb(255, 133, 182);
            nextItem.ForeColor = Color.FromArgb(139, 229, 206);
            lifeTime.ForeColor = Color.FromArgb(255, 71, 71);
        }

        #region timer1_Tick
        /// <summary>
        /// timer1_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //抓Json檔路徑
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"Web\";
            StreamReader r = new StreamReader(path + "data.json");

            //解析Json檔
            string jsonString = r.ReadToEnd();
            JObject jObj = JObject.Parse(jsonString);
            JArray jArray = JArray.Parse(jObj["items"].ToString());
            //Read關閉，不然會咬住檔案
            r.Close();

            //整理成List
            var items = new List<dtoItems>();
            for (int i = 0; i < jArray.Count(); i++)
            {
                JObject tempo = JObject.Parse(jArray[i].ToString());
                string aa = tempo["open"].ToString();

                items.Add(new dtoItems
                {
                    no = Convert.ToInt32(tempo["no"]),
                    title = tempo["title"].ToString(),
                    remark = tempo["remark"].ToString(),
                    sdate = tempo["sdate"].ToString(),
                    edate = tempo["edate"].ToString(),
                    open = tempo["open"].ToString() == "True" ? true : false
                });
            }

            //取出現在時間內且有開啟的資料
            string nowTime = DateTime.Now.ToString("yyyy/MM/dd");
            if (nowTime.Substring(0, 1) != "2")
                nowTime = (Convert.ToInt32(nowTime.Substring(0, 3)) + 1911).ToString() + nowTime.Substring(3, 6);
            //取下一筆目標資料
            var nextItemList = new List<dtoItems>();
            nextItemList = items.Where(x => x.open == true && Convert.ToDateTime(x.sdate) > Convert.ToDateTime(nowTime)).OrderBy(x => x.sdate).ToList();

            if (nextItemList.Count() > 0)
            {
                dtoItems next_item = nextItemList.FirstOrDefault();
                nextItem.Text = "下個目標：" + next_item.title + "  " + next_item.sdate + " - " + next_item.edate;
            }
            else
            {
                nextItem.Text = "";
            }

            items = items.Where(x => x.open == true &&
                    Convert.ToDateTime(x.sdate) <= Convert.ToDateTime(nowTime) &&
                    Convert.ToDateTime(x.edate) >= Convert.ToDateTime(nowTime)).ToList();

            //加入時分秒做計算
            nowTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            //life time
            TimeSpan t1 = new TimeSpan(Convert.ToDateTime(nowTime).Ticks);
            TimeSpan t2 = new TimeSpan(life_time.Ticks);
            TimeSpan t = t1.Subtract(t2).Duration();
            string lifeString = t.Days.ToString() + "天  " + t.Hours.ToString() + "小時  " + t.Minutes.ToString() + "分  " + t.Seconds.ToString() + "秒";
            lifeTime.Text = "Life Countdown：" + lifeString;

            if (nowTime.Substring(0, 1) != "2")
                nowTime = (Convert.ToInt32(nowTime.Substring(0, 3)) + 1911).ToString() + nowTime.Substring(3, 15);
            if (items.Count() > 0)
            {
                //推測現在跟End Date剩餘時間
                DateTime endDate = Convert.ToDateTime(Convert.ToDateTime(items[0].edate).ToString("yyyy/MM/dd hh:mm:ss"));
                string dateDiff = null;
                TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(nowTime).Ticks);
                TimeSpan ts2 = new TimeSpan(endDate.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString() + "天  " + ts.Hours.ToString() + "小時  " + ts.Minutes.ToString() + "分  " + ts.Seconds.ToString() + "秒";
                title01.Text = "目標：" + items[0].title;
                remark01.Text = "備註：" + items[0].remark;
                timeLeft01.Text = "剩餘時間：" + dateDiff;
            }
            else
            {
                title01.Text = "暫無目標";
                remark01.Text = "";
                timeLeft01.Text = "";
            }
        }
        #endregion

        #region 雙擊工具列右下角圖示顯示視窗
        /// <summary>
        /// 雙擊工具列右下角圖示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        /// <summary>
        /// 顯示視窗
        /// </summary>
        private void ShowForm()
        {
            //如果是最小化就打開顯示
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            // Activate the form.
            this.Activate();
            this.Focus();
        }
        #endregion


    }
}
