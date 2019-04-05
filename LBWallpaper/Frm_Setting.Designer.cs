namespace LBWallpaper
{
    partial class Frm_Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_ChangeInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CacheSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SpecailWallpaper = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ChangeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CacheSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "壁纸切换间隔(秒)：";
            // 
            // numericUpDown_ChangeInterval
            // 
            this.numericUpDown_ChangeInterval.Location = new System.Drawing.Point(142, 22);
            this.numericUpDown_ChangeInterval.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_ChangeInterval.Name = "numericUpDown_ChangeInterval";
            this.numericUpDown_ChangeInterval.Size = new System.Drawing.Size(76, 21);
            this.numericUpDown_ChangeInterval.TabIndex = 1;
            this.numericUpDown_ChangeInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericUpDown_CacheSize
            // 
            this.numericUpDown_CacheSize.Location = new System.Drawing.Point(142, 58);
            this.numericUpDown_CacheSize.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_CacheSize.Name = "numericUpDown_CacheSize";
            this.numericUpDown_CacheSize.Size = new System.Drawing.Size(76, 21);
            this.numericUpDown_CacheSize.TabIndex = 3;
            this.numericUpDown_CacheSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "壁纸缓存大小(MB)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "特殊壁纸：";
            // 
            // button_SpecailWallpaper
            // 
            this.button_SpecailWallpaper.Location = new System.Drawing.Point(94, 90);
            this.button_SpecailWallpaper.Name = "button_SpecailWallpaper";
            this.button_SpecailWallpaper.Size = new System.Drawing.Size(75, 23);
            this.button_SpecailWallpaper.TabIndex = 5;
            this.button_SpecailWallpaper.Text = "选择";
            this.button_SpecailWallpaper.UseVisualStyleBackColor = true;
            this.button_SpecailWallpaper.Click += new System.EventHandler(this.button_SpecailWallpaper_Click);
            // 
            // Frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 132);
            this.Controls.Add(this.button_SpecailWallpaper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_CacheSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_ChangeInterval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "壁纸设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Setting_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ChangeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CacheSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_ChangeInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_CacheSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SpecailWallpaper;
    }
}