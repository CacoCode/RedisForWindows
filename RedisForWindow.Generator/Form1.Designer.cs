namespace RedisForWindow.Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.installMsysBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // installMsysBtn
            // 
            this.installMsysBtn.Location = new System.Drawing.Point(56, 30);
            this.installMsysBtn.Name = "installMsysBtn";
            this.installMsysBtn.Size = new System.Drawing.Size(75, 23);
            this.installMsysBtn.TabIndex = 0;
            this.installMsysBtn.Text = "安装Msys";
            this.installMsysBtn.UseVisualStyleBackColor = true;
            this.installMsysBtn.Click += new System.EventHandler(this.installMsysBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(12, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(506, 276);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 340);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.installMsysBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button installMsysBtn;
        private System.Windows.Forms.ListBox listBox1;
    }
}
