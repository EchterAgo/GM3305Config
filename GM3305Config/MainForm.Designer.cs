namespace GM3305Config
{
    partial class MainForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.checkBoxLEDEnabled = new System.Windows.Forms.CheckBox();
            this.groupBoxLED = new System.Windows.Forms.GroupBox();
            this.comboBoxLEDBlinkSpeed = new System.Windows.Forms.ComboBox();
            this.labelLEDBlinkSpeed = new System.Windows.Forms.Label();
            this.comboBoxLEDStrength = new System.Windows.Forms.ComboBox();
            this.labelLEDStrength = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDPI = new System.Windows.Forms.ComboBox();
            this.comboBoxHz = new System.Windows.Forms.ComboBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxLED.SuspendLayout();
            this.trayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxLEDEnabled
            // 
            this.checkBoxLEDEnabled.AutoSize = true;
            this.checkBoxLEDEnabled.Checked = true;
            this.checkBoxLEDEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLEDEnabled.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLEDEnabled.Name = "checkBoxLEDEnabled";
            this.checkBoxLEDEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxLEDEnabled.TabIndex = 2;
            this.checkBoxLEDEnabled.Text = "&Enabled";
            this.checkBoxLEDEnabled.UseVisualStyleBackColor = true;
            this.checkBoxLEDEnabled.CheckedChanged += new System.EventHandler(this.checkBoxLEDEnabled_CheckedChanged);
            // 
            // groupBoxLED
            // 
            this.groupBoxLED.Controls.Add(this.comboBoxLEDBlinkSpeed);
            this.groupBoxLED.Controls.Add(this.labelLEDBlinkSpeed);
            this.groupBoxLED.Controls.Add(this.comboBoxLEDStrength);
            this.groupBoxLED.Controls.Add(this.checkBoxLEDEnabled);
            this.groupBoxLED.Controls.Add(this.labelLEDStrength);
            this.groupBoxLED.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLED.Name = "groupBoxLED";
            this.groupBoxLED.Size = new System.Drawing.Size(252, 98);
            this.groupBoxLED.TabIndex = 3;
            this.groupBoxLED.TabStop = false;
            this.groupBoxLED.Text = "&LED";
            // 
            // comboBoxLEDBlinkSpeed
            // 
            this.comboBoxLEDBlinkSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLEDBlinkSpeed.FormattingEnabled = true;
            this.comboBoxLEDBlinkSpeed.Items.AddRange(new object[] {
            "Off",
            "Slow",
            "Middle",
            "Fast"});
            this.comboBoxLEDBlinkSpeed.Location = new System.Drawing.Point(108, 63);
            this.comboBoxLEDBlinkSpeed.Name = "comboBoxLEDBlinkSpeed";
            this.comboBoxLEDBlinkSpeed.Size = new System.Drawing.Size(126, 21);
            this.comboBoxLEDBlinkSpeed.TabIndex = 9;
            // 
            // labelLEDBlinkSpeed
            // 
            this.labelLEDBlinkSpeed.AutoSize = true;
            this.labelLEDBlinkSpeed.Location = new System.Drawing.Point(6, 66);
            this.labelLEDBlinkSpeed.Name = "labelLEDBlinkSpeed";
            this.labelLEDBlinkSpeed.Size = new System.Drawing.Size(85, 13);
            this.labelLEDBlinkSpeed.TabIndex = 8;
            this.labelLEDBlinkSpeed.Text = "LED blink speed";
            // 
            // comboBoxLEDStrength
            // 
            this.comboBoxLEDStrength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLEDStrength.FormattingEnabled = true;
            this.comboBoxLEDStrength.Items.AddRange(new object[] {
            "Low",
            "Middle",
            "High"});
            this.comboBoxLEDStrength.Location = new System.Drawing.Point(108, 36);
            this.comboBoxLEDStrength.Name = "comboBoxLEDStrength";
            this.comboBoxLEDStrength.Size = new System.Drawing.Size(126, 21);
            this.comboBoxLEDStrength.TabIndex = 7;
            // 
            // labelLEDStrength
            // 
            this.labelLEDStrength.AutoSize = true;
            this.labelLEDStrength.Location = new System.Drawing.Point(6, 39);
            this.labelLEDStrength.Name = "labelLEDStrength";
            this.labelLEDStrength.Size = new System.Drawing.Size(69, 13);
            this.labelLEDStrength.TabIndex = 6;
            this.labelLEDStrength.Text = "LED strength";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(171, 170);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "DPI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hz";
            // 
            // comboBoxDPI
            // 
            this.comboBoxDPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDPI.FormattingEnabled = true;
            this.comboBoxDPI.Items.AddRange(new object[] {
            "400",
            "800",
            "1600",
            "3200"});
            this.comboBoxDPI.Location = new System.Drawing.Point(120, 116);
            this.comboBoxDPI.Name = "comboBoxDPI";
            this.comboBoxDPI.Size = new System.Drawing.Size(126, 21);
            this.comboBoxDPI.TabIndex = 9;
            // 
            // comboBoxHz
            // 
            this.comboBoxHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHz.FormattingEnabled = true;
            this.comboBoxHz.Items.AddRange(new object[] {
            "125",
            "250",
            "500",
            "1000"});
            this.comboBoxHz.Location = new System.Drawing.Point(120, 143);
            this.comboBoxHz.Name = "comboBoxHz";
            this.comboBoxHz.Size = new System.Drawing.Size(126, 21);
            this.comboBoxHz.TabIndex = 9;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "GM3305 Config";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 208);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxLED);
            this.Controls.Add(this.comboBoxDPI);
            this.Controls.Add(this.comboBoxHz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 247);
            this.MinimumSize = new System.Drawing.Size(288, 247);
            this.Name = "MainForm";
            this.Text = "GM3305 Config";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBoxLED.ResumeLayout(false);
            this.groupBoxLED.PerformLayout();
            this.trayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxLEDEnabled;
        private System.Windows.Forms.GroupBox groupBoxLED;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelLEDStrength;
        private System.Windows.Forms.Label labelLEDBlinkSpeed;
        private System.Windows.Forms.ComboBox comboBoxLEDBlinkSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDPI;
        private System.Windows.Forms.ComboBox comboBoxHz;
        private System.Windows.Forms.ComboBox comboBoxLEDStrength;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

