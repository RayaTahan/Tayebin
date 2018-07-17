namespace FreeControls
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Globalization;
    using System.Windows.Forms;
    using PopupControl;
    #endregion

    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [ToolboxBitmap(typeof(System.Windows.Forms.MonthCalendar))]
    public partial class PersianMonthCalendar : Control
    {
        #region Delegate & Events
        public delegate void onValueChanged(object sender, PersianMonthCalendarEventArgs e);
        public event onValueChanged ValueChanged;
        public event EventHandler TitleBackColorChanged;
        public event EventHandler TitleForeColorChanged;
        internal event EventHandler PopupClosed;
        #endregion

        #region Fields
        private string[] monthsArray = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        private string[] weekArray = { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };

        private Pen blackPen = new Pen(Brushes.Black, 1.25F);
        private Pen whitePen = new Pen(Brushes.White, 1.5F);

        private Color titleBackColor = SystemColors.ActiveCaption;
        private Color titleForeColor = Color.White;
        private Color markColor = Color.Green;

        private SolidBrush brush = new SolidBrush(SystemColors.ActiveCaption);
        private SolidBrush markBrush = new SolidBrush(Color.Green);
        private StringFormat sf = StringFormat.GenericDefault;

        private PersianDate persianValue;

        private Font weekFont = new Font("Times New Roman", 9F, FontStyle.Bold);

        private CellInfo[] cells = null;
        private CellInfo selectedCell = null;
        private CellInfo oldSelectedCell = null;

        private List<PersianDate> markDateList;

        private int iSelectedCellIndex = -1;

        private bool showToday = true;
        private bool isMarkListSorted = false;
        private bool keepFocus = false;
        #endregion

        #region Ctor
        // Summary:
        //     Initializes a new instance of the H128Controls.PersianMonthCalendar class.
        public PersianMonthCalendar()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, true);

            sf.Alignment = StringAlignment.Center;
            persianValue = PersianDate.Now;
            todayLink.Text = persianValue.ToString("امروز: DD dd NM yyyy");
            todayLink.Tag = persianValue;

            markDateList = new List<PersianDate>();

            FillCells(persianValue);
        }
        #endregion

        #region Props
        [TypeConverter(typeof(PersianDateConverter))]
        [Description("The value of control")]
        [Category("Behavior")]
        [Bindable(true)]
        public PersianDate Value
        {
            get { return persianValue; }
            set
            {
                try
                {
                    //if (value != persianValue)
                    if (!this.DesignMode)
                    {
                        if (value == PersianDate.MinValue)
                        {
                            value = PersianDate.Now;
                        }
                    }
                    OnValueChanged( value, persianValue);
                    persianValue = value;

                }
                catch (ArgumentException) { }
            }
        }

        [Description("The ShowToday of control")]
        [Category("Behavior")]
        [Bindable(true)]
        public bool ShowToday
        {
            get { return showToday; }
            set { showToday = value; }
        }

        [Description("The ShowToday of control")]
        [Category("Behavior")]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<PersianDate> MarkDates
        {
            get { return markDateList; }
        }



        [Description("The TitleBackColor of control in color")]
        [Category("Apperance")]
        [DefaultValue("SystemColors.ActiveCaption")]
        [Bindable(true)]
        public Color TitleBackColor
        {
            get { return titleBackColor; }
            set
            {
                if (value != titleBackColor)
                {
                    titleBackColor = value;
                    brush = new SolidBrush(value);
                    headerPanel.BackColor = value;
                    Invalidate();
                    if (TitleBackColorChanged != null)
                        TitleBackColorChanged(this, EventArgs.Empty);
                }
            }
        }

        [Description("The TitleForeColor of control in color")]
        [Category("Apperance")]
        [DefaultValue("Color.Black")]
        [Bindable(true)]
        public Color TitleForeColor
        {
            get { return titleForeColor; }
            set
            {
                if (value != titleForeColor)
                {
                    titleForeColor = value;
                    yearLabel.ForeColor = monthLabel.ForeColor = value;
                    if (TitleForeColorChanged != null)
                        TitleForeColorChanged(this, EventArgs.Empty);
                }
            }
        }

        [Description("The TitleForeColor of control in color")]
        [Category("Apperance")]
        [DefaultValue("Color.Green")]
        [Bindable(true)]
        public Color MarkColor
        {
            get { return markColor; }
            set
            {
                markColor = value;
                markBrush = new SolidBrush(value);
            }
        }
        #endregion

        #region Methods

        #region Painting Methods
        private void DarwWithArrangment(Graphics gr)
        {
            if (gr == null) gr = Graphics.FromHwnd(bodyPanel.Handle);

            SizeF textsize;
            int iLeft = bodyPanel.Width;
            int iWidth = bodyPanel.Width / 7;

            //SmoothingMode =antialias
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            //draw week array
            foreach (string stDay in weekArray)
            {
                iLeft -= 46;
                gr.DrawString(stDay, weekFont, Brushes.RoyalBlue, new Rectangle(iLeft, 2, iWidth, 16), sf);
            }
            // draw sep line
            gr.DrawLine(this.blackPen, new Point(4, 17), new Point(bodyPanel.Width - 8, 17));

            int iCounter = 0;
            foreach (CellInfo ci in cells) // Draw days
            {
                textsize = gr.MeasureString(ci.Value.Day.ToString(), this.Font);

                if (ci.Value.Day == Value.Day && (ci.Value.Month == Value.Month))
                {
                    gr.FillRectangle(brush, ci.Rectangle);
                    gr.DrawString(ci.Value.Day.ToString("00"), this.Font, Brushes.White, ci.Rectangle, sf);

                    selectedCell = ci;
                    iSelectedCellIndex = iCounter;
                }
                else if (ci.Value.Month != Value.Month)
                    gr.DrawString(ci.Value.Day.ToString("00"), this.Font, Brushes.Gray, ci.Rectangle, sf);
                else
                    gr.DrawString(ci.Value.Day.ToString("00"), this.Font, Brushes.Black, ci.Rectangle, sf);

                if (ci.Value == (PersianDate)todayLink.Tag)
                    gr.DrawRectangle(blackPen, ci.Rectangle);

                if (IsMarkDate(ci.Value))
                    gr.DrawRectangle(new Pen(markBrush, 1.25F), ci.Rectangle);

                iCounter++;
            }

        }

        private void DrawChangeDayInMonth(Graphics gr, CellInfo oldSelected, PersianDate curDate)
        {
            if (gr == null) gr = Graphics.FromHwnd(bodyPanel.Handle);

            //SmoothingMode =antialias
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF textsize = gr.MeasureString(selectedCell.Value.Day.ToString("00"), this.Font);
            gr.FillRectangle(brush, selectedCell.Rectangle);
            gr.DrawString(selectedCell.Value.Day.ToString("00"), this.Font, Brushes.White, selectedCell.Rectangle, sf);

            if (oldSelected == null) return;
            textsize = gr.MeasureString(oldSelected.Value.Day.ToString("00"), this.Font);
            gr.FillRectangle(Brushes.White, oldSelected.Rectangle);
            if (!((PersianDate)todayLink.Tag == oldSelected.Value || (IsMarkDate(oldSelected.Value))))
                gr.DrawRectangle(whitePen, oldSelected.Rectangle);

            gr.DrawString(oldSelected.Value.Day.ToString("00"), this.Font, Brushes.Black, oldSelected.Rectangle, sf);
            DrawToday(gr, curDate);
            gr.Dispose();
        }

        private void DrawToday(Graphics gr, PersianDate curDate)
        {
            if (this.showToday)
            {
                string date = curDate.ToString("DD dd NM yyyy");
                SizeF textSize = gr.MeasureString(date, this.Font);
                RectangleF rect = new RectangleF(bodyPanel.Width - (textSize.Width + 8), bodyPanel.Height - textSize.Height - 7, textSize.Width + 5, textSize.Height);
                RectangleF emptyRect = rect;
                emptyRect.X -= 150;
                emptyRect.Width += 150;
                gr.FillRectangle(Brushes.White, emptyRect);
                gr.DrawString(date, this.Font, brush, rect, sf);
            }
        }

        #endregion

        #region Private Methods
        private void FillCells(PersianDate date)
        {
            PersianDate tempDate = PersianDate.MinValue;

            if (date == PersianDate.MinValue) return;

            if (markDateList.Count > 0 && !(isMarkListSorted))
            {
                markDateList.Sort();
                isMarkListSorted = true;
            }
            cells = new CellInfo[42];
            int i, j, iCounter = 0;
            int iWidth = 43, iHeight = 13;
            int iLeft = bodyPanel.Width, iTop = 20;
            //PersianDate tempDate = date.AddDays(date.GetDaysInMonth()-date.Day);
            tempDate = date.GetLastSaturday();

            for (i = 0; i < 6; i++)
            {
                iLeft = bodyPanel.Width;
                for (j = 0; j < 7; j++)
                {
                    iLeft -= 46;

                    cells[iCounter] = new CellInfo();
                    cells[iCounter].Value = tempDate;
                    cells[iCounter].Rectangle = new Rectangle(iLeft, iTop, iWidth, iHeight);

                    iCounter++;


                    tempDate = tempDate.AddDays(1);

                }
                iTop += 17;
            }
        }

        private void ChangeValueByPoint(Point point)
        {
            int iCounter = 0;
            foreach (CellInfo ci in cells)
            {
                if (ci.Value == selectedCell.Value)
                {
                    iCounter++;
                    continue;
                }
                if (ci.Rectangle.Contains(point))
                {
                    this.oldSelectedCell = this.selectedCell;
                    this.selectedCell = ci;
                    this.iSelectedCellIndex = iCounter;
                    this.Value = ci.Value;

                    break;
                }
                iCounter++;
            }
        }

        private bool IsMarkDate(PersianDate date)
        {
            int iIndex = markDateList.BinarySearch(date);
            return iIndex > -1;
        }
        #endregion

        #region Virtual Method(s)
        public void Active()
        {
            todayLink.Focus();

        }

        public virtual void GotoToday()
        {
            try
            {
                this.Value = (PersianDate)todayLink.Tag;
            }
            catch (Exception) { }
        }

        protected virtual void OnValueChanged(PersianDate curDate, PersianDate oldDate)
        {
            if (ValueChanged != null)
                ValueChanged(this, new PersianMonthCalendarEventArgs { CurrentValue = curDate, OldValue = oldDate });


            //if change month raise change arrangment
            if (
                selectedCell == null ||
                (curDate.Month != oldDate.Month) ||
                (curDate.Year != oldDate.Year) ||
                (curDate == PersianDate.Now)
               )
            {
                FillCells(curDate);//change arrangment 

                bodyPanel.Invalidate(); //Raise paint method
            }
            else
            {
                DrawChangeDayInMonth(null, this.oldSelectedCell, curDate);

            }
        }

        #endregion

        #region Override Methods
        protected override void OnGotFocus(EventArgs e)
        {
            todayLink.Focus();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    {
                        keepFocus = true;
                        if (iSelectedCellIndex < 41)
                        {
                            this.oldSelectedCell = this.selectedCell;
                            this.selectedCell = cells[++iSelectedCellIndex];
                            //iSelectedCellIndex++;
                        }
                        this.Value = this.Value.AddDays(1);
                    }
                    return true;
                case Keys.Right:
                    {
                        keepFocus = true;
                        if (iSelectedCellIndex - 1 >= 0)
                        {
                            this.oldSelectedCell = this.selectedCell;
                            this.selectedCell = cells[--iSelectedCellIndex];
                            //iSelectedCellIndex--;
                        }
                        this.Value = this.Value.AddDays(-1);
                    }
                    return true;
                case Keys.Up:
                    {
                        keepFocus = true;
                        if (iSelectedCellIndex - 7 >= 0)
                        {
                            this.oldSelectedCell = this.selectedCell;
                            this.selectedCell = cells[iSelectedCellIndex - 7];
                            iSelectedCellIndex -= 7;
                        }
                        this.Value = this.Value.AddDays(-7);
                    }
                    break;
                case Keys.Down:
                    {
                        keepFocus = true;
                        if (iSelectedCellIndex + 7 < 42)
                        {

                            this.oldSelectedCell = this.selectedCell;
                            this.selectedCell = cells[iSelectedCellIndex + 7];
                            iSelectedCellIndex += +7;
                        }
                        this.Value = this.Value.AddDays(7);
                    }
                    break;
                case Keys.Enter:
                case Keys.Escape:
                    {
                        keepFocus = false;
                        if (PopupClosed != null)
                            PopupClosed(this, EventArgs.Empty);
                    }
                    return true;
                case Keys.Tab:
                    keepFocus = false;
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion


        #endregion

        #region Method of events

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Value = this.Value.AddDays(this.persianValue.GetDaysInMonth());
            }
            catch (ArgumentException) { }
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Value = this.Value.AddDays(this.persianValue.Month > 7 ? -30 : -31);
            }
            catch (ArgumentException) { }
        }

        private void gotoTodayMitem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Value = PersianDate.Now;
            }
            catch (ArgumentException) { }
        }

        private void monthMitem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Value = new PersianDate(persianValue.Year, Convert.ToInt32(((ToolStripMenuItem)sender).Tag), persianValue.Day ,persianValue.Hour,persianValue.Minute 
                    ,0);
            }
            catch (ArgumentException) { }
        }

        Popup p;
        MonthUC mo;
        private void monthLabel_Click(object sender, EventArgs e)
        {
            //monthMenuStrip.Show(monthLabel, new Point(this.Left - monthLabel.Left / 2, monthLabel.Top * 2));
            if (p == null)
            {
                mo = new MonthUC();
                mo.MonthChanged += (s, ee) => { try { this.Value = new PersianDate(persianValue.Year, int.Parse(((RadioButton)s).Tag.ToString()), persianValue.Day, persianValue.Hour, persianValue.Minute,0); } catch (ArgumentException) { } };
                p = new Popup(mo);
                if (SystemInformation.IsComboBoxAnimationEnabled)
                {
                    p.ShowingAnimation = PopupAnimations.Slide | PopupAnimations.TopToBottom;
                    p.HidingAnimation = PopupAnimations.Slide | PopupAnimations.BottomToTop;
                }
                else
                {
                    p.ShowingAnimation = p.HidingAnimation = PopupAnimations.None;
                }
            }
            p.Hide();
            mo.ActiveRadioByTagID(persianValue.Month);
            p.Show(monthLabel);
        }

        private void yearLabel_Click(object sender, EventArgs e)
        {
            yearNumericUpDown.Visible = true;
            yearNumericUpDown.Value = Value.Year;
        }

        private void headerPanel_Click(object sender, EventArgs e)
        {
            if (yearNumericUpDown.Visible)
            {
                yearNumericUpDown.Visible = false;
                try
                {
                    var p = new PersianDate(((int)yearNumericUpDown.Value), persianValue.Month, persianValue.Day,persianValue.Hour,persianValue.Minute ,0);
                    this.Value = p;
                }
                catch (ArgumentException) { }
            }
        }

        private void nextMonthButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = global::PersianDate.Properties.Resources.rightDown;
        }

        private void prevMonthButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = global::PersianDate.Properties.Resources.leftdown;
        }

        private void bodyPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeValueByPoint(e.Location);
                keepFocus = true;
                todayLink.Focus();
                if (PopupClosed != null)
                    PopupClosed(this, EventArgs.Empty);
            }
            else if (e.Button == MouseButtons.Right)
                gotoTodayMenuStrip.Show(bodyPanel, e.Location);
        }

        private void nextMonthButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = global::PersianDate.Properties.Resources.right;
        }

        private void prevMonthButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = global::PersianDate.Properties.Resources.left;
        }

        private void todayLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                GotoToday();
                if (PopupClosed != null)
                    PopupClosed(this, EventArgs.Empty);
            }
            catch (ArgumentException) { }
        }

        private void yearNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            yearNumericUpDown.Visible = false;
            try
            {
                this.Value = new PersianDate(((int)yearNumericUpDown.Value), persianValue.Month, persianValue.Day,persianValue.Hour,persianValue.Day ,0  );
            }
            catch (ArgumentException) { }
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {
            if (cells == null) return;
            sf.Alignment = StringAlignment.Center;
            DarwWithArrangment(e.Graphics);
            DrawToday(e.Graphics, Value);
            monthLabel.Text = Value.Month.ToString("00");
            yearLabel.Text = Value.Year.ToString("0000");
        }

        private void PersianMonthCalendar_LostFocus(object sender, EventArgs e)
        {
            if (keepFocus)
                bodyPanel.Focus();
            keepFocus = false;
        }
        #endregion

        #region Nested Class
        private class CellInfo
        {
            public Rectangle Rectangle;

            public PersianDate Value;
        }
        #endregion
    }//end class

    public class PersianDateConverter : ExpandableObjectConverter
    {
        #region Override Methods
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {

            if (value is string)
            {

                try
                {
                    if (value == null || (value.ToString().Length != 0))
                    {
                        string[] values = value.ToString().Split('/');

                        int iYear = Convert.ToInt32(values[0]);
                        int iMonth = Convert.ToInt32(values[1]);
                        int iDay = Convert.ToInt32(values[2]);
                        return new PersianDate(iYear, iMonth, iDay);
                    }
                    return PersianDate.MinValue;
                }
                catch (Exception ex)
                {
                    throw new FormatException(ex.Message);
                }
            }
            return base.ConvertFrom(context, culture, value);

        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is PersianDate && destinationType == typeof(string))
                return ((PersianDate)value).ToString();
            return base.ConvertTo(context, culture, value, destinationType);

        }
        #endregion
    }//end class

    public class PersianMonthCalendarEventArgs : EventArgs
    {
        #region Ctor
        public PersianMonthCalendarEventArgs() { }
        #endregion

        #region Props
        public PersianDate CurrentValue
        {
            get;
            set;
        }

        public PersianDate OldValue
        {
            get;
            set;
        }
        #endregion
    }//end class
}//end namespace
