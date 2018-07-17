namespace FreeControls
{
    partial class PersianMonthCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.prevMonthButton = new System.Windows.Forms.PictureBox();
            this.nextMonthButton = new System.Windows.Forms.PictureBox();
            this.bodyPanel = new System.Windows.Forms.PictureBox();
            this.headerPanel = new System.Windows.Forms.PictureBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.lblSeprator = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.gotoTodayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gotoTodayMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevMonthButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextMonthButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.gotoTodayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearNumericUpDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.yearNumericUpDown.ForeColor = System.Drawing.Color.Black;
            this.yearNumericUpDown.Location = new System.Drawing.Point(129, 4);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            1290,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(64, 23);
            this.yearNumericUpDown.TabIndex = 2;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            1386,
            0,
            0,
            0});
            this.yearNumericUpDown.Visible = false;
            this.yearNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.yearNumericUpDown_Validating);
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Image = global::PersianDate.Properties.Resources.left;
            this.prevMonthButton.Location = new System.Drawing.Point(15, 9);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new System.Drawing.Size(23, 15);
            this.prevMonthButton.TabIndex = 7;
            this.prevMonthButton.TabStop = false;
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);
            this.prevMonthButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prevMonthButton_MouseDown);
            this.prevMonthButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.prevMonthButton_MouseUp);
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Image = global::PersianDate.Properties.Resources.right;
            this.nextMonthButton.Location = new System.Drawing.Point(284, 9);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new System.Drawing.Size(21, 15);
            this.nextMonthButton.TabIndex = 6;
            this.nextMonthButton.TabStop = false;
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);
            this.nextMonthButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nextMonthButton_MouseDown);
            this.nextMonthButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nextMonthButton_MouseUp);
            // 
            // bodyPanel
            // 
            this.bodyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 30);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(325, 142);
            this.bodyPanel.TabIndex = 5;
            this.bodyPanel.TabStop = false;
            this.bodyPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bodyPanel_MouseDown);
            this.bodyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bodyPanel_Paint);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel.Controls.Add(this.monthLabel);
            this.headerPanel.Controls.Add(this.lblSeprator);
            this.headerPanel.Controls.Add(this.yearLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(325, 30);
            this.headerPanel.TabIndex = 2;
            this.headerPanel.TabStop = false;
            this.headerPanel.Click += new System.EventHandler(this.headerPanel_Click);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.BackColor = System.Drawing.Color.Transparent;
            this.monthLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.monthLabel.ForeColor = System.Drawing.Color.White;
            this.monthLabel.Location = new System.Drawing.Point(170, 7);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(23, 14);
            this.monthLabel.TabIndex = 1;
            this.monthLabel.Text = "08";
            this.monthLabel.Click += new System.EventHandler(this.monthLabel_Click);
            // 
            // lblSeprator
            // 
            this.lblSeprator.AutoSize = true;
            this.lblSeprator.BackColor = System.Drawing.Color.Transparent;
            this.lblSeprator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSeprator.ForeColor = System.Drawing.Color.White;
            this.lblSeprator.Location = new System.Drawing.Point(161, 6);
            this.lblSeprator.Name = "lblSeprator";
            this.lblSeprator.Size = new System.Drawing.Size(13, 16);
            this.lblSeprator.TabIndex = 5;
            this.lblSeprator.Text = "/";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.yearLabel.ForeColor = System.Drawing.Color.White;
            this.yearLabel.Location = new System.Drawing.Point(127, 7);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(39, 14);
            this.yearLabel.TabIndex = 3;
            this.yearLabel.Text = "1386";
            this.yearLabel.Click += new System.EventHandler(this.yearLabel_Click);
            // 
            // gotoTodayMenuStrip
            // 
            this.gotoTodayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoTodayMitem});
            this.gotoTodayMenuStrip.Name = "monthMenuStrip";
            this.gotoTodayMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.gotoTodayMenuStrip.Size = new System.Drawing.Size(131, 26);
            // 
            // gotoTodayMitem
            // 
            this.gotoTodayMitem.Name = "gotoTodayMitem";
            this.gotoTodayMitem.Size = new System.Drawing.Size(130, 22);
            this.gotoTodayMitem.Tag = "12";
            this.gotoTodayMitem.Text = "برو به امروز";
            this.gotoTodayMitem.Click += new System.EventHandler(this.gotoTodayMitem_Click);
            // 
            // todayLink
            // 
            this.todayLink.AutoSize = true;
            this.todayLink.CausesValidation = false;
            this.todayLink.Location = new System.Drawing.Point(12, 150);
            this.todayLink.Name = "todayLink";
            this.todayLink.Size = new System.Drawing.Size(0, 13);
            this.todayLink.TabIndex = 8;
            this.todayLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.todayLink_LinkClicked);
            // 
            // PersianMonthCalendar
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.todayLink);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.nextMonthButton);
            this.Controls.Add(this.prevMonthButton);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximumSize = new System.Drawing.Size(325, 172);
            this.MinimumSize = new System.Drawing.Size(325, 172);
            this.Size = new System.Drawing.Size(325, 172);
            this.LostFocus += new System.EventHandler(this.PersianMonthCalendar_LostFocus);
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevMonthButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextMonthButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.gotoTodayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox headerPanel;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label lblSeprator;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.PictureBox bodyPanel;
        private System.Windows.Forms.PictureBox nextMonthButton;
        private System.Windows.Forms.PictureBox prevMonthButton;
        private System.Windows.Forms.ContextMenuStrip gotoTodayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gotoTodayMitem;
        private System.Windows.Forms.LinkLabel todayLink;
    }
}
