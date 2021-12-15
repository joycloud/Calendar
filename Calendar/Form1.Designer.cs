
namespace Calendar
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.title01 = new System.Windows.Forms.Label();
            this.timeLeft01 = new System.Windows.Forms.Label();
            this.remark01 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.nextItem = new System.Windows.Forms.Label();
            this.lifeTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // title01
            // 
            this.title01.AutoSize = true;
            this.title01.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title01.ForeColor = System.Drawing.Color.Black;
            this.title01.Location = new System.Drawing.Point(12, 21);
            this.title01.Name = "title01";
            this.title01.Size = new System.Drawing.Size(29, 35);
            this.title01.TabIndex = 0;
            this.title01.Text = "  ";
            // 
            // timeLeft01
            // 
            this.timeLeft01.AutoSize = true;
            this.timeLeft01.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.timeLeft01.ForeColor = System.Drawing.Color.Black;
            this.timeLeft01.Location = new System.Drawing.Point(13, 122);
            this.timeLeft01.Name = "timeLeft01";
            this.timeLeft01.Size = new System.Drawing.Size(25, 30);
            this.timeLeft01.TabIndex = 1;
            this.timeLeft01.Text = "  ";
            // 
            // remark01
            // 
            this.remark01.AutoSize = true;
            this.remark01.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.remark01.ForeColor = System.Drawing.Color.Black;
            this.remark01.Location = new System.Drawing.Point(13, 72);
            this.remark01.Name = "remark01";
            this.remark01.Size = new System.Drawing.Size(25, 30);
            this.remark01.TabIndex = 2;
            this.remark01.Text = "  ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Calendar";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // nextItem
            // 
            this.nextItem.AutoSize = true;
            this.nextItem.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nextItem.ForeColor = System.Drawing.Color.Black;
            this.nextItem.Location = new System.Drawing.Point(13, 174);
            this.nextItem.Name = "nextItem";
            this.nextItem.Size = new System.Drawing.Size(20, 24);
            this.nextItem.TabIndex = 3;
            this.nextItem.Text = "  ";
            // 
            // lifeTime
            // 
            this.lifeTime.AutoSize = true;
            this.lifeTime.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lifeTime.ForeColor = System.Drawing.Color.Black;
            this.lifeTime.Location = new System.Drawing.Point(12, 226);
            this.lifeTime.Name = "lifeTime";
            this.lifeTime.Size = new System.Drawing.Size(33, 38);
            this.lifeTime.TabIndex = 4;
            this.lifeTime.Text = "  ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 290);
            this.Controls.Add(this.lifeTime);
            this.Controls.Add(this.nextItem);
            this.Controls.Add(this.remark01);
            this.Controls.Add(this.timeLeft01);
            this.Controls.Add(this.title01);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "倒數行事曆";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label title01;
        private System.Windows.Forms.Label timeLeft01;
        private System.Windows.Forms.Label remark01;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label nextItem;
        private System.Windows.Forms.Label lifeTime;
    }
}

