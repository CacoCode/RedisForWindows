namespace RedisForWindow.Generator
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.installMsysBtn = new MaterialSkin2DotNet.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin2DotNet.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin2DotNet.Controls.MaterialLabel();
            this.button2 = new MaterialSkin2DotNet.Controls.MaterialButton();
            this.textBox2 = new MaterialSkin2DotNet.Controls.MaterialMaskedTextBox();
            this.textBox1 = new MaterialSkin2DotNet.Controls.MaterialMaskedTextBox();
            this.button1 = new MaterialSkin2DotNet.Controls.MaterialButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // installMsysBtn
            // 
            this.installMsysBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.installMsysBtn.BackColor = System.Drawing.SystemColors.Control;
            this.installMsysBtn.CharacterCasing = MaterialSkin2DotNet.Controls.MaterialButton.CharacterCasingEnum.Title;
            this.installMsysBtn.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.installMsysBtn.Depth = 0;
            this.installMsysBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.installMsysBtn.HighEmphasis = true;
            this.installMsysBtn.Icon = null;
            this.installMsysBtn.Location = new System.Drawing.Point(3, 64);
            this.installMsysBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.installMsysBtn.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            this.installMsysBtn.Name = "installMsysBtn";
            this.installMsysBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.installMsysBtn.Size = new System.Drawing.Size(457, 36);
            this.installMsysBtn.TabIndex = 8;
            this.installMsysBtn.Text = "请点击安装Msys，再进行以下操作";
            this.installMsysBtn.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            this.installMsysBtn.UseAccentColor = true;
            this.installMsysBtn.UseVisualStyleBackColor = false;
            this.installMsysBtn.Click += new System.EventHandler(this.installMsysBtn_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 128);
            this.materialLabel1.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "生成目录：";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(12, 189);
            this.materialLabel2.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 19);
            this.materialLabel2.TabIndex = 11;
            this.materialLabel2.Text = "Redis 版本：";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button2.Depth = 0;
            this.button2.HighEmphasis = true;
            this.button2.Icon = null;
            this.button2.Location = new System.Drawing.Point(386, 118);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button2.Size = new System.Drawing.Size(65, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "选择...";
            this.button2.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button2.UseAccentColor = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.AllowPromptAsInput = true;
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.AnimateReadOnly = false;
            this.textBox2.AsciiOnly = false;
            this.textBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox2.BeepOnError = false;
            this.textBox2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBox2.Depth = 0;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.HidePromptOnLeave = false;
            this.textBox2.HideSelection = true;
            this.textBox2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.textBox2.LeadingIcon = null;
            this.textBox2.Location = new System.Drawing.Point(110, 111);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 32767;
            this.textBox2.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PrefixSuffixText = null;
            this.textBox2.PromptChar = '_';
            this.textBox2.ReadOnly = false;
            this.textBox2.RejectInputOnFirstFailure = false;
            this.textBox2.ResetOnPrompt = true;
            this.textBox2.ResetOnSpace = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(252, 48);
            this.textBox2.SkipLiterals = true;
            this.textBox2.TabIndex = 14;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBox2.TrailingIcon = null;
            this.textBox2.UseSystemPasswordChar = false;
            this.textBox2.ValidatingType = null;
            // 
            // textBox1
            // 
            this.textBox1.AllowPromptAsInput = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AnimateReadOnly = false;
            this.textBox1.AsciiOnly = false;
            this.textBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox1.BeepOnError = false;
            this.textBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.HidePromptOnLeave = false;
            this.textBox1.HideSelection = true;
            this.textBox1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.textBox1.LeadingIcon = null;
            this.textBox1.Location = new System.Drawing.Point(110, 174);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 32767;
            this.textBox1.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PrefixSuffixText = null;
            this.textBox1.PromptChar = '_';
            this.textBox1.ReadOnly = false;
            this.textBox1.RejectInputOnFirstFailure = false;
            this.textBox1.ResetOnPrompt = true;
            this.textBox1.ResetOnSpace = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(252, 48);
            this.textBox1.SkipLiterals = true;
            this.textBox1.TabIndex = 15;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.textBox1.TrailingIcon = null;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.ValidatingType = null;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(387, 179);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(64, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "生成";
            this.button1.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(12, 282);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(439, 242);
            this.listBox1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Redis 版本为";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(87, 243);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 17);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github Redis";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tags 名称，本程序会进行网络通讯，请确保网络畅通";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.installMsysBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Index";
            this.Text = "Redis For Window生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin2DotNet.Controls.MaterialButton installMsysBtn;
        private MaterialSkin2DotNet.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2DotNet.Controls.MaterialLabel materialLabel2;
        private MaterialSkin2DotNet.Controls.MaterialButton button2;
        private MaterialSkin2DotNet.Controls.MaterialMaskedTextBox textBox2;
        private MaterialSkin2DotNet.Controls.MaterialMaskedTextBox textBox1;
        private MaterialSkin2DotNet.Controls.MaterialButton button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
    }
}
