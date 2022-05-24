namespace TheWitcher
{
    partial class FormF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUcheb = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTest = new System.Windows.Forms.Panel();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.labelTestText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureText = new System.Windows.Forms.PictureBox();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUcheb
            // 
            this.labelUcheb.AutoSize = true;
            this.labelUcheb.BackColor = System.Drawing.Color.Transparent;
            this.labelUcheb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUcheb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.labelUcheb.Location = new System.Drawing.Point(686, 6);
            this.labelUcheb.Name = "labelUcheb";
            this.labelUcheb.Size = new System.Drawing.Size(152, 19);
            this.labelUcheb.TabIndex = 13;
            this.labelUcheb.Text = "Учебное пособие";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(21, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(866, 2400);
            this.button2.TabIndex = 16;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(18, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(872, 2407);
            this.button1.TabIndex = 15;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelTest
            // 
            this.panelTest.BackColor = System.Drawing.Color.Transparent;
            this.panelTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelTest.Controls.Add(this.labelTimer);
            this.panelTest.Controls.Add(this.buttonEnd);
            this.panelTest.Location = new System.Drawing.Point(12, 120);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(929, 20);
            this.panelTest.TabIndex = 18;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.ForeColor = System.Drawing.Color.White;
            this.labelTimer.Location = new System.Drawing.Point(420, 25);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(0, 25);
            this.labelTimer.TabIndex = 21;
            // 
            // buttonEnd
            // 
            this.buttonEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonEnd.Location = new System.Drawing.Point(406, 1765);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(116, 34);
            this.buttonEnd.TabIndex = 11;
            this.buttonEnd.TabStop = false;
            this.buttonEnd.Text = "Завершить";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // labelTestText
            // 
            this.labelTestText.AutoSize = true;
            this.labelTestText.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTestText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.labelTestText.Location = new System.Drawing.Point(359, 92);
            this.labelTestText.Name = "labelTestText";
            this.labelTestText.Size = new System.Drawing.Size(186, 25);
            this.labelTestText.TabIndex = 0;
            this.labelTestText.Text = "Финальный тест";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureText
            // 
            this.pictureText.BackColor = System.Drawing.Color.Transparent;
            this.pictureText.Image = global::TheWitcher.Properties.Resources.text_TheWitcher;
            this.pictureText.Location = new System.Drawing.Point(690, 26);
            this.pictureText.Name = "pictureText";
            this.pictureText.Size = new System.Drawing.Size(230, 29);
            this.pictureText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureText.TabIndex = 12;
            this.pictureText.TabStop = false;
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.Image = global::TheWitcher.Properties.Resources.witcher_logo_SuperZip;
            this.pictureLogo.Location = new System.Drawing.Point(12, 14);
            this.pictureLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(105, 85);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 11;
            this.pictureLogo.TabStop = false;
            // 
            // FormF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(960, 594);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.labelUcheb);
            this.Controls.Add(this.pictureText);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.labelTestText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormF_Load);
            this.panelTest.ResumeLayout(false);
            this.panelTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUcheb;
        private System.Windows.Forms.PictureBox pictureText;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Label labelTestText;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer1;
    }
}