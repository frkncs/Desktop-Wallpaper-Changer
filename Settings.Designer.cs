
namespace DesktopWallpaperChanger
{
    partial class Settings
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
            System.Windows.Forms.RadioButton radioBtnMinute;
            System.Windows.Forms.RadioButton radioBtnHour;
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSettingsFormOpacity = new System.Windows.Forms.Label();
            this.btnApplySettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            radioBtnMinute = new System.Windows.Forms.RadioButton();
            radioBtnHour = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // radioBtnMinute
            // 
            radioBtnMinute.AutoSize = true;
            radioBtnMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            radioBtnMinute.Font = new System.Drawing.Font("Sofia Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioBtnMinute.ForeColor = System.Drawing.Color.White;
            radioBtnMinute.Location = new System.Drawing.Point(20, 28);
            radioBtnMinute.Name = "radioBtnMinute";
            radioBtnMinute.Size = new System.Drawing.Size(122, 44);
            radioBtnMinute.TabIndex = 3;
            radioBtnMinute.Text = "Minute";
            radioBtnMinute.UseVisualStyleBackColor = true;
            radioBtnMinute.CheckedChanged += new System.EventHandler(this.radioButtonsSelect);
            // 
            // radioBtnHour
            // 
            radioBtnHour.AutoSize = true;
            radioBtnHour.Cursor = System.Windows.Forms.Cursors.Hand;
            radioBtnHour.Font = new System.Drawing.Font("Sofia Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioBtnHour.ForeColor = System.Drawing.Color.White;
            radioBtnHour.Location = new System.Drawing.Point(170, 28);
            radioBtnHour.Name = "radioBtnHour";
            radioBtnHour.Size = new System.Drawing.Size(95, 44);
            radioBtnHour.TabIndex = 4;
            radioBtnHour.Text = "Hour";
            radioBtnHour.UseVisualStyleBackColor = true;
            radioBtnHour.CheckedChanged += new System.EventHandler(this.radioButtonsSelect);
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.Location = new System.Drawing.Point(105, 387);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(500, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblSettingsFormOpacity
            // 
            this.lblSettingsFormOpacity.AutoSize = true;
            this.lblSettingsFormOpacity.Font = new System.Drawing.Font("Sofia Pro", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSettingsFormOpacity.ForeColor = System.Drawing.Color.White;
            this.lblSettingsFormOpacity.Location = new System.Drawing.Point(12, 387);
            this.lblSettingsFormOpacity.Name = "lblSettingsFormOpacity";
            this.lblSettingsFormOpacity.Size = new System.Drawing.Size(87, 44);
            this.lblSettingsFormOpacity.TabIndex = 1;
            this.lblSettingsFormOpacity.Text = "100%";
            // 
            // btnApplySettings
            // 
            this.btnApplySettings.BackColor = System.Drawing.Color.Lime;
            this.btnApplySettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplySettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplySettings.Font = new System.Drawing.Font("Sofia Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnApplySettings.Location = new System.Drawing.Point(186, 463);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(275, 60);
            this.btnApplySettings.TabIndex = 2;
            this.btnApplySettings.Text = "Apply";
            this.btnApplySettings.UseVisualStyleBackColor = false;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sofia Pro", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delay Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sofia Pro", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(273, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "Delay";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(radioBtnMinute);
            this.groupBox1.Controls.Add(radioBtnHour);
            this.groupBox1.Location = new System.Drawing.Point(180, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudDelay);
            this.groupBox2.Location = new System.Drawing.Point(253, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // nudDelay
            // 
            this.nudDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudDelay.Font = new System.Drawing.Font("Sofia Pro", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nudDelay.Location = new System.Drawing.Point(6, 22);
            this.nudDelay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(120, 51);
            this.nudDelay.TabIndex = 0;
            this.nudDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(617, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApplySettings);
            this.Controls.Add(this.lblSettingsFormOpacity);
            this.Controls.Add(this.trackBar1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSettingsFormOpacity;
        private System.Windows.Forms.Button btnApplySettings;
        private System.Windows.Forms.RadioButton radioBtnMinute;
        private System.Windows.Forms.RadioButton radioBtnHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudDelay;
    }
}