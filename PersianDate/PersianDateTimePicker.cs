namespace FreeControls
{
    #region Using Directives
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using PopupControl;
    #endregion

    [ToolboxBitmap(typeof(System.Windows.Forms.DateTimePicker))]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    public partial class PersianDateTimePicker : Control
    {
        #region Delegate & Events
        public delegate void onValueChanged(object sender, PersianMonthCalendarEventArgs e);
        public event onValueChanged ValueChanged;
        #endregion

        #region Fields

        private Pen borderPen = new Pen(Brushes.RoyalBlue, 1.25F);
        private SolidBrush selectedBrush = new SolidBrush(Color.RoyalBlue);
        private StringFormat sf = StringFormat.GenericDefault;

        private RectangleF rectYear, rectMonth, rectDay, rectSep1, rectSep2;
        private RectangleF rectFillYear, rectFillMonth, rectFillDay;

        private RectangleF rectHour, rectMinute, rectSepHour;
        private RectangleF rectFillHour, rectFillMinute;

        private Rectangle rectComboButton;

        private PersianDate persianValue = PersianDate.MinValue;

        private DatePartTypes selectedCommand = DatePartTypes.None;

        //private Form popup;
        private Popup popup;
        private PersianMonthCalendar persianMonthCalendar;

        private bool keepFocus = false;
        private bool sizeChanging = false;
        protected bool IsOpen = false;

        private bool showTime = false;
        private bool isInitFirst = false;
        private Font font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        #endregion

        #region Ctor
        public PersianDateTimePicker()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.StandardClick, true);
            this.SetStyle(ControlStyles.FixedWidth, true);

            persianMonthCalendar = new PersianMonthCalendar();
            persianMonthCalendar.ValueChanged += new PersianMonthCalendar.onValueChanged(persianMonthCalendar_ValueChanged);
            persianMonthCalendar.PopupClosed += new EventHandler(persianMonthCalendar_PopupClosed);

            popup = new Popup(persianMonthCalendar);
            if (SystemInformation.IsComboBoxAnimationEnabled)
            {
                popup.ShowingAnimation = PopupAnimations.Slide | PopupAnimations.TopToBottom;
                popup.HidingAnimation = PopupAnimations.Slide | PopupAnimations.BottomToTop;
            }
            else
            {
                popup.ShowingAnimation = popup.HidingAnimation = PopupAnimations.None;
            }
            //{
            //FormBorderStyle = FormBorderStyle.None,
            //Size = persianMonthCalendar.Size,
            //ShowInTaskbar = false,
            //StartPosition = FormStartPosition.Manual

            //};
            //popup.Controls.Add(persianMonthCalendar);

            //popup.Deactivate += delegate(object sender, EventArgs e)
            //{
            //    isOpen = false;
            //    popup.Hide();
            //    this.FindForm().Activate();
            //};


            sf.Alignment = StringAlignment.Near;
            sf.Trimming |= StringTrimming.Word;



            //  UpdateRectangle(persianValue);
        }

        ~PersianDateTimePicker()
        {
            try {
                popup = null;
                this.Graphic.Dispose();
                sf.Dispose();
                persianMonthCalendar = null;
            }
            catch { }
            
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


                    if (!this.DesignMode)
                    {
                        if (value == PersianDate.MinValue && !isInitFirst)
                        {
                            value = PersianDate.Now;
                            isInitFirst = true;
                        }

                    }
                    PersianDate tmpDate = persianValue;

                    if (value != tmpDate)
                    {
                        persianValue = value;
                        OnValueChanged(value, tmpDate);
                    }
                }
                catch (ArgumentException) { }
            }
        }

        [Description("set show display time ")]
        [Category("Behavior")]

        public bool ShowTime
        {
            get { return showTime; }
            set
            {
                showTime = value;
                DrawDate(this.Graphic);

            }
        }

        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                base.Font = value;
            }
        }

        private Graphics graphic;
        protected Graphics Graphic
        {
            get
            {
                if (graphic == null && this.IsHandleCreated)
                    graphic = CreateGraphics();
                return graphic;

            }
        }


        #endregion

        #region Methods

        #region Override Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            if (rectComboButton == Rectangle.Empty)
                UpdateRectangle(Value);

            //draw Border
            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(borderPen, rect);

            DrawComboButton(e.Graphics, ButtonState.Normal);

            DrawDate(e.Graphics);
            e.Graphics.DrawString("/", this.Font, Brushes.Black, rectSep1, sf);
            e.Graphics.DrawString("/", this.Font, Brushes.Black, rectSep2, sf);
            if (showTime)
                e.Graphics.DrawString(":", this.Font, Brushes.Black, rectSepHour, sf);


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.Focus();
            if (rectFillYear.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Year;
                DrawDate(this.Graphic);
            }
            else if (rectMonth.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Month;
                DrawDate(this.Graphic);
            }
            else if (rectComboButton.Contains(e.Location))
            {
                DrawComboButton(this.Graphic, ButtonState.Pushed);
                ShowCalendar();
            }
            else if (rectDay.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Day;
                DrawDate(this.Graphic);
            }
            else if (rectHour.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Hour;
                DrawDate(this.Graphic);
            }
            else if (rectMinute.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Minute;
                DrawDate(this.Graphic);
            }
            else
            {
                if (showTime)
                {
                    selectedCommand = DatePartTypes.Minute;
                    DrawDate(this.Graphic);
                }
                else
                {
                    selectedCommand = DatePartTypes.Day;
                    DrawDate(this.Graphic);
                }
            }


        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            DrawComboButton(this.Graphic, ButtonState.Normal);
            base.OnMouseUp(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (keepFocus)
            {
               // this.Focus();

                keepFocus = false;

              //  return;
            }
            SetDateTimeByKeyboardBuffer();
            selectedCommand = DatePartTypes.None;
            this.Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
                OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Down));
            else
                OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Up));
            base.OnMouseWheel(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (!keepFocus)
            {
                selectedCommand = DatePartTypes.Day;
                DrawDate(this.Graphic);
            }
            base.OnGotFocus(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
                return false;

           
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            try
            {
                
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    SetDateTimeByKeyboardBuffer();
                    
                }

                switch (e.KeyCode)
                {
                    case Keys.Left:
                        {
                            if (selectedCommand == DatePartTypes.None) return;

                            keepFocus = true;
                            switch (selectedCommand)
                            {
                                case DatePartTypes.Minute:
                                    selectedCommand = DatePartTypes.Hour;
                                    break;
                                case DatePartTypes.Hour:
                                    selectedCommand = DatePartTypes.Day;
                                    break;
                                case DatePartTypes.Day:
                                    selectedCommand = DatePartTypes.Month;
                                    break;
                                case DatePartTypes.Month:
                                    selectedCommand = DatePartTypes.Year;
                                    break;
                                case DatePartTypes.Year:
                                    if (!showTime)
                                        selectedCommand = DatePartTypes.Day;
                                    else
                                        selectedCommand = DatePartTypes.Minute;
                                    break;
                            }
                            DrawDate(this.Graphic);

                        }
                        break;
                    case Keys.Right:
                        {
                            if (selectedCommand == DatePartTypes.None) return;

                            keepFocus = true;
                            switch (selectedCommand)
                            {
                                case DatePartTypes.Minute:
                                    selectedCommand = DatePartTypes.Year;
                                    break;
                                case DatePartTypes.Hour:
                                    selectedCommand = DatePartTypes.Minute;
                                    break;
                                case DatePartTypes.Day:
                                    if (!showTime)
                                        selectedCommand = DatePartTypes.Year;
                                    else
                                        selectedCommand = DatePartTypes.Hour;
                                    break;
                                case DatePartTypes.Month:
                                    selectedCommand = DatePartTypes.Day;
                                    break;
                                case DatePartTypes.Year:
                                    selectedCommand = DatePartTypes.Month;
                                    break;
                            }
                            DrawDate(this.Graphic);

                        }
                        break;
                    case Keys.Up:
                        {
                            if (selectedCommand == DatePartTypes.None) return;

                            keepFocus = true;
                            switch (selectedCommand)
                            {
                                case DatePartTypes.Minute:
                                    {
                                        if (this.persianValue.Minute != 59)
                                            this.Value = this.Value.AddMinutes(1);
                                        else
                                            this.Value =new PersianDate(persianValue.Year,persianValue.Month,persianValue.Day,persianValue.Hour,0,persianValue.Second   );
                                    }
                                    break;
                                case DatePartTypes.Hour:
                                    {
                                        if (this.persianValue.Hour != 23)
                                            this.Value = this.Value.AddHours(1);
                                        else
                                            this.Value=new PersianDate(persianValue.Year,persianValue.Month,persianValue.Day,0,persianValue.Minute ,persianValue.Second   );
                                    }
                                    break;
                                case DatePartTypes.Day:
                                    {
                                        int iCount = -1;
                                        if ((iCount = this.persianValue.GetDaysInMonth()) != this.persianValue.Day)
                                            this.Value = this.Value.AddDays(1);
                                        else
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month, 1, persianValue.Hour  , persianValue.Minute, persianValue.Second); 
                                    }
                                    break;
                                case DatePartTypes.Month:
                                    {
                                        if (this.persianValue.Month != 12)
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month+1, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); 
                                        else
                                            this.Value = new PersianDate(persianValue.Year, 1, persianValue.Day , persianValue.Hour, persianValue.Minute, persianValue.Second); 
                                    }
                                    break;
                                case DatePartTypes.Year:
                                    {
                                        if (this.persianValue.Year != 1500)
                                            this.Value = new PersianDate(persianValue.Year+1, persianValue.Month , persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second);
                                        else
                                            this.Value = new PersianDate(1300, persianValue.Month, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); 
                                    }
                                    break;
                            }
                        }
                        break;
                    case Keys.Down:
                        {
                            if (selectedCommand == DatePartTypes.None) return;


                            keepFocus = true;
                            switch (selectedCommand)
                            {
                                case DatePartTypes.Minute:
                                    {
                                        if (this.persianValue.Minute != 0)
                                            this.Value = this.Value.AddMinutes(-1);
                                        else
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month, persianValue.Day, persianValue.Hour, 59, persianValue.Second);
                                    }
                                    break;
                                case DatePartTypes.Hour:
                                    {
                                        if (this.persianValue.Hour != 0)
                                            this.Value = this.Value.AddHours(-1);
                                        else
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month, persianValue.Day, 23, persianValue.Minute, persianValue.Second);
                                    }
                                    break;
                                case DatePartTypes.Day:
                                    {
                                        int iCount = (iCount = this.persianValue.GetDaysInMonth()) ;
                                        if (1!= this.persianValue.Day)
                                            this.Value = this.Value.AddDays(-1);
                                        else
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month, iCount , persianValue.Hour, persianValue.Minute, persianValue.Second);
                                    }
                                    break;
                                case DatePartTypes.Month:
                                    {
                                        if (this.persianValue.Month != 1)
                                            this.Value = new PersianDate(persianValue.Year, persianValue.Month - 1, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second);
                                        else
                                            this.Value = new PersianDate(persianValue.Year, 12, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); 
                                    }
                                    break;
                                case DatePartTypes.Year:
                                    {

                                        if (this.persianValue.Year != 1300)
                                            this.Value = new PersianDate(persianValue.Year-1, persianValue.Month, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second);
                                        else
                                            this.Value = new PersianDate(1500, persianValue.Month, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); 
                                    }
                                    break;
                            }

                        }
                        break;
                    case Keys.Enter:
                        {
                            if (e.Control)
                                ShowCalendar();
                        }
                        break;

                }
                int keyCode = (int)e.KeyCode;
                int key = -1;

                if (keyCode >= 48 && keyCode <= 57) key = (keyCode - 48);
                if (keyCode >= 96 && keyCode <= 105) key = (keyCode - 96);
                if (key != -1)
                {
                    DrawDigit(this.Graphic, key);
                }
            }
            catch(ArgumentException ) { } 

            base.OnPreviewKeyDown(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            UpdateRectangle(this.Value);

            base.OnFontChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!this.sizeChanging)
                UpdateRectangle(Value);
        }

        #endregion

        #region Painting Method
        private void DrawDate(Graphics gr)
        {
            if (gr == null) return;

            //if (rectComboButton == Rectangle.Empty)
            UpdateRectangle(Value);

            //UpdateRectangle(Value);

            gr.FillRectangle(Brushes.White, rectFillMonth);
            gr.FillRectangle(Brushes.White, rectFillDay);
            gr.FillRectangle(Brushes.White, rectFillYear);

            if (showTime)
            {
                gr.FillRectangle(Brushes.White, rectFillMinute);
                gr.FillRectangle(Brushes.White, rectFillHour);

            }
            ////draw Persian Value

            Brush brDay, brMonth, brYear, brHour, brMinute;
            brHour = brMinute = brDay = brMonth = brYear = Brushes.Black;
            switch (selectedCommand)
            {
                case DatePartTypes.Day:
                    gr.FillRectangle(selectedBrush, rectFillDay);
                    brDay = Brushes.White;
                    break;
                case DatePartTypes.Month:
                    gr.FillRectangle(selectedBrush, rectFillMonth);
                    brMonth = Brushes.White;
                    break;
                case DatePartTypes.Year:
                    gr.FillRectangle(selectedBrush, rectFillYear);
                    brYear = Brushes.White;
                    break;
                case DatePartTypes.Hour:
                    gr.FillRectangle(selectedBrush, rectFillHour);
                    brHour = Brushes.White;
                    break;
                case DatePartTypes.Minute:
                    gr.FillRectangle(selectedBrush, rectFillMinute);
                    brMinute = Brushes.White;
                    break;
            }

            gr.DrawString(Value.Year.ToString("0000"), font, brYear, rectYear, sf);
            gr.DrawString(Value.Month.ToString("00"), font, brMonth, rectMonth, sf);
            gr.DrawString(Value.Day.ToString("00"), font, brDay, rectDay, sf);
            if (showTime)
            {
                gr.DrawString(Value.Hour.ToString("00"), font, brHour, rectHour, sf);
                gr.DrawString(Value.Minute.ToString("00"), font, brMinute, rectMinute, sf);
            }

        }

        private void DrawComboButton(Graphics gr, ButtonState state)
        {
            ControlPaint.DrawComboButton(gr, rectComboButton, state);
        }

        private string _digit = "";
        private void DrawDigit(Graphics gr, int digit)
        {
            if (gr == null) return;

            if (rectComboButton == Rectangle.Empty)
                UpdateRectangle(Value);
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment |= StringAlignment.Far;
            string temp = "";
            //UpdateRectangle(Value);
            switch (selectedCommand)
            {
                case DatePartTypes.Day:
                    gr.FillRectangle(selectedBrush, rectFillDay);

                    temp = _digit;
                    temp += digit;
                    if (Convert.ToInt32(temp) <= persianValue.GetDaysInMonth())
                        _digit = temp;
                    else
                        _digit = digit.ToString();

                    gr.DrawString(_digit, font, Brushes.White, rectDay, sFormat);
                    break;
                case DatePartTypes.Month:
                    temp = _digit;
                    temp += digit;
                    if (Convert.ToInt32(temp) <= 12)
                        _digit = temp;
                    else
                        _digit = digit.ToString();

                    gr.FillRectangle(selectedBrush, rectFillMonth);
                    gr.DrawString(_digit, font, Brushes.White, rectMonth, sFormat);

                    break;
                case DatePartTypes.Year:
                    if (_digit.Length < 4)
                    {
                        temp = _digit;
                        temp += digit;
                        if (Convert.ToInt32(temp) <= 1500)
                            _digit = temp;
                        else
                            _digit = digit.ToString();
                        gr.FillRectangle(selectedBrush, rectFillYear);
                        gr.DrawString(_digit, font, Brushes.White, rectYear, sFormat);
                        ;
                    }
                    else
                    {
                        _digit =
                            "";
                    }
                    break;
                case DatePartTypes.Hour:
                    temp = _digit;
                    temp += digit;
                    if (Convert.ToInt32(temp) <= 24)
                        _digit = temp;
                    else
                        _digit = digit.ToString();
                    gr.FillRectangle(selectedBrush, rectFillHour);
                    gr.DrawString(_digit, font, Brushes.White, rectHour, sFormat);

                    break;
                case DatePartTypes.Minute:
                    temp = _digit;
                    temp += digit;
                    if (Convert.ToInt32(temp) <= 59)
                        _digit = temp;
                    else
                        _digit = digit.ToString();
                    gr.FillRectangle(selectedBrush, rectFillMinute);
                    gr.DrawString(_digit, font, Brushes.White, rectMinute, sFormat);

                    break;
            }
        }
        #endregion

        #region Private Methods
        private int GetTop(Control ct, int topTotal)
        {
            if (ct != null)
                topTotal += GetTop(ct.Parent, ct.Location.Y);
            return topTotal;
        }

        private int GetLeft(Control ct, int leftTotal)
        {
            if (ct != null)
                leftTotal += GetLeft(ct.Parent, ct.Location.X);
            return leftTotal;
        }

        private void SetDateTimeByKeyboardBuffer()
        {
            if (_digit.Length > 0)
            {

                int digit = Convert.ToInt32(_digit);
                _digit = "";
                //PersianDate date = new PersianDate();
                //date.Assign(persianValue);
                switch (selectedCommand)
                {
                    case DatePartTypes.Day:
                        Value = new PersianDate(persianValue.Year, persianValue.Month,digit , persianValue.Hour, persianValue.Minute, persianValue.Second); ;
                        break;
                    case DatePartTypes.Month:
                        Value = new PersianDate(persianValue.Year, digit , persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); ;
                        break;
                    case DatePartTypes.Year:
                        if (digit < 100)
                            digit += 1300;
                        Value = new PersianDate(digit, persianValue.Month, persianValue.Day, persianValue.Hour, persianValue.Minute, persianValue.Second); ;
                        break;
                    case DatePartTypes.Hour:
                        Value = new PersianDate(persianValue.Year , persianValue.Month, persianValue.Day, digit ,persianValue.Minute  , persianValue.Second); ;
                        break;
                    case DatePartTypes.Minute:
                        Value = new PersianDate(persianValue.Year, persianValue.Month, persianValue.Day, persianValue.Hour, digit, persianValue.Second); ;
                        break;
                }
                //OnValueChanged(Value, date);
            }
        }

        private void ShowCalendar()
        {

            if (IsOpen)
            {
                popup.Hide();
                IsOpen = false; return;
            }
            IsOpen = true;
            //Point p = new Point(GetLeft(this, 0), GetTop(this, 0));
            //Form f;
            //if ((f = this.FindForm()) != null)
            //{
            //    p.X -= f.Left;
            //    p.Y -= f.Top; 
            //    p = f.PointToScreen(p);
            //    p.Y += this.Height;
            //}
            //else
            //{
            //    p.X += 3;
            //    p.Y += this.Height * 2 + this.Height / 2;
            //}
            //popup.Location = p;
            persianMonthCalendar.Value = this.Value;

            popup.Show(this);
        }

        private void UpdateRectangle(PersianDate curDate)
        {
            if (curDate == null) return;

            this.sizeChanging = true;
            Graphics gr = this.Graphic;
            if (gr == null) return;

            SizeF textSize = gr.MeasureString(curDate.Year.ToString("0000"), font, 0, sf);
            this.Height = ((int)textSize.Height) + 4;
            float fY = ((((float)this.Height) / 2) - (textSize.Height / 2));
            //rectYear = new RectangleF(0, (int)((this.Height / 2) - (textSize.Height / 2)), textSize.Width, textSize.Height);
            rectYear = new RectangleF(2, fY, textSize.Width, textSize.Height);

            textSize = gr.MeasureString("/", font, 0, sf);
            rectSep1 = new RectangleF(rectYear.Right -( textSize.Width / 3.5F)+2, fY, textSize.Width, textSize.Height);

            textSize = gr.MeasureString(curDate.Month.ToString("00"), font, 0, sf);
            rectMonth = new RectangleF(rectSep1.Right - rectSep1.Width / 3.5F, fY, textSize.Width, textSize.Height);


            rectSep2 = new RectangleF(rectMonth.Right - rectSep1.Width / 4F+2, fY, rectSep1.Width, rectSep1.Height);

            textSize = gr.MeasureString(curDate.Day.ToString("00"), font, 0, sf);
            rectDay = new RectangleF(rectSep2.Right - rectSep1.Width / 3.7F, fY, textSize.Width, textSize.Height);

            textSize = gr.MeasureString(curDate.Hour.ToString("00"), font, 0, sf);
            rectHour = new RectangleF(rectDay.Right + gr.MeasureString("  ", font).Width, fY, textSize.Width, textSize.Height);

            textSize = gr.MeasureString(":", font, 0, sf);
            rectSepHour = new RectangleF(rectHour.Right - textSize.Width / 3.5F, fY, textSize.Width, textSize.Height);

            textSize = gr.MeasureString(curDate.Minute.ToString("00"), font, 0, sf);
            rectMinute = new RectangleF(rectSepHour.Right - rectSepHour.Width / 3.5F, fY, textSize.Width, textSize.Height);




            this.rectFillYear = this.rectYear;
            this.rectFillYear.Height -= 1;

            this.rectFillMonth = this.rectMonth;
            this.rectFillMonth.Height -= 1;

            this.rectFillDay = this.rectDay;
            this.rectFillDay.Height -= 1;

            this.rectFillHour = this.rectHour;
            this.rectFillHour.Height -= 1;

            this.rectFillMinute = this.rectMinute;
            //this.rectFillMinute.Width += 6; 
            this.rectFillMinute.Height -= 1;


            rectComboButton = new Rectangle(this.Width - 21, (int)rectYear.Y, 20, this.Height - 1);

            //  gr.Dispose();
            this.sizeChanging = false;
        }

        #endregion

        #region Virtual Methods
        protected virtual void OnValueChanged(PersianDate curDate, PersianDate oldDate)
        {
            if (curDate == oldDate) return;
            if (!PersianDate.ValidDate(curDate))
                curDate = oldDate;
            //UpdateRectangle(curDate);
            DrawDate(this.Graphic);
            if (ValueChanged != null)
                ValueChanged(this, new PersianMonthCalendarEventArgs { CurrentValue = curDate, OldValue = oldDate });
        }
        #endregion

        #endregion

        #region Method of events
        private void persianMonthCalendar_PopupClosed(object sender, EventArgs e)
        {
            IsOpen = false;
            popup.Hide();
            selectedCommand = DatePartTypes.Day;
            this.Value = persianMonthCalendar.Value;
            //this.FindForm().Activate();

        }

        private void persianMonthCalendar_ValueChanged(object sender, PersianMonthCalendarEventArgs e)
        {
            //UpdateRectangle(e.CurrentValue);
            selectedCommand = DatePartTypes.Day;
            this.Value = e.CurrentValue;
        }
        #endregion

        #region Enums
        private enum DatePartTypes
        {
            None = 0,
            Day = 1,
            Month = 2,
            Year = 3,
            Hour = 4,
            Minute = 5,
            Second = 6

        }
        #endregion
    }
}
