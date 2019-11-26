namespace SECSAdapt
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
            this.label1 = new System.Windows.Forms.Label();
            this.Control_lb = new System.Windows.Forms.Label();
            this.log_rt = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control";
            // 
            // Control_lb
            // 
            this.Control_lb.AutoSize = true;
            this.Control_lb.Location = new System.Drawing.Point(75, 9);
            this.Control_lb.Name = "Control_lb";
            this.Control_lb.Size = new System.Drawing.Size(0, 12);
            this.Control_lb.TabIndex = 1;
            // 
            // log_rt
            // 
            this.log_rt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_rt.Location = new System.Drawing.Point(13, 25);
            this.log_rt.Name = "log_rt";
            this.log_rt.Size = new System.Drawing.Size(306, 315);
            this.log_rt.TabIndex = 2;
            this.log_rt.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 353);
            this.Controls.Add(this.log_rt);
            this.Controls.Add(this.Control_lb);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SECS Adapt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Control_lb;
        private System.Windows.Forms.RichTextBox log_rt;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

