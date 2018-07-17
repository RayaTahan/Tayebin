namespace FreeControls
{
    #region Using Directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using Regex = System.Text.RegularExpressions.Regex;
    #endregion

    [Serializable]
    public struct  PersianDate : IComparable,
                                      IComparable<PersianDate>,
                                      IComparer,
                                      IComparer<PersianDate>,
                                      ICloneable
    {
        #region Fields
        private static readonly PersianCalendar calendar = new PersianCalendar();

        public static readonly PersianDate MinValue = new PersianDate(1,1,1  );
        public static readonly PersianDate MaxValue = new PersianDate(1500,12,29,11,59,59);

        private string[] weekArray ;
        private string[] monthsArray ;// 

        private int year;
        private int month;
        private int day;

        private int hour;
        private int minute;
        private int second;


        private DayOfWeek dayOfWeek;
        #endregion

        #region Ctor

        //public PersianDate(DateTime date)
        //{
        //    PersianDate persianDate = PersianDate.Parse(date);
        //   // Assign(persianDate);

        //    this.year = persianDate.Year;
        //    this.month = persianDate.Month;
        //    this.day = persianDate.Day;

        //    this.hour = persianDate.Hour;
        //    this.minute = persianDate.Minute;
        //    this.second = persianDate.Second;

        //    this.dayOfWeek = persianDate.DayOfWeek;

            
        //}

        public PersianDate(int year, int month, int day, int hour, int minute, int second)
        {

            if (!PersianDate.ValidDate(year, month, day, hour, minute, second))
                throw new ArgumentException("Date time is not valid");

            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            weekArray = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
            monthsArray = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

           var dt=calendar.ToDateTime(year, month, day, hour, minute, second,0);

            this.dayOfWeek = calendar.GetDayOfWeek(dt );
        }

        public PersianDate(int year, int month, int day) : this(year , month<=0?1:month , day<=0?1:day,0,0,0) { } 
        #endregion

        #region Props
        public int Year
        {
            get { return year; }
            //set
            //{
            //    if (!PersianDate.ValidDate(value, month, day, hour, minute, second))
            //        throw new ArgumentException("Year is out of range");
            //    year = value;
            //}
        }

        public int Month
        {
            get { return month; }
            //set
            //{
            //    if (!PersianDate.ValidDate(year, value, day, hour, minute, second))
            //        throw new ArgumentException("Month is out of range");
            //    month = value;
            //}
        }

        public int Day
        {
            get { return day; }
            //set
            //{
            //    if (!PersianDate.ValidDate(year, month, value, hour, minute, second))
            //        throw new ArgumentException("Day is out of range");
            //    day = value;
            //}
        }

        public int Hour
        {
            get { return hour; }
            //set
            //{
            //    if (!PersianDate.ValidDate(year, month, day, value, minute, second))
            //        throw new ArgumentException("Day is out of range");
            //    hour = value;
            //}
        }

        public int Minute
        {
            get { return minute; }
            //set
            //{
            //    if (!PersianDate.ValidDate(year, month, day, hour, value, second))
            //        throw new ArgumentException("Day is out of range");
            //    minute = value;
            //}
        }

        public int Second
        {
            get { return second; }
            //set
            //{
            //    if (!PersianDate.ValidDate(year, month, day, hour, minute, value))
            //        throw new ArgumentException("Day is out of range");
            //    hour = value;
            //}
        }

        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeek; }
        }

        public static PersianDate Now
        {
            get
            {
                return Parse(DateTime.Now);
            }
        }
        #endregion

        #region Methods

        #region Static Methods

        public static bool ValidDate(int year, int month, int day, int hour, int minute, int second)
        {
            bool result = true;
            try
            {
                calendar.ToDateTime(year, month, day, hour, minute, second, 0);
            }
            catch (ArgumentException) { result = false; }
            return result;
        }

        [Obsolete("please use valid date method ValidDate(1388,05,06,04,10,20) ")]
        public static bool ValidDate(int year, int month, int day)
        {
            bool result = true;
            try
            {
                calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (ArgumentException) { result = false; }
            return result;
        }

        public static bool ValidDate(PersianDate persianDate)
        {
            return PersianDate.ValidDate(persianDate.Year, persianDate.Month, persianDate.Day, persianDate.Hour, persianDate.Minute, persianDate.Second);
        }

        public static int Compare2Date(PersianDate persianDate1, PersianDate persianDate2)
        {
            //if (persianDate1 == null || (persianDate2 == null))
            //    throw new ApplicationException("Invalid PersianDate comparer.");

            if (persianDate1.year > persianDate2.Year) return 1;
            else if (persianDate1.year < persianDate2.Year) return -1;

            if (persianDate1.month > persianDate2.Month) return 1;
            else if (persianDate1.month < persianDate2.Month) return -1;

            if (persianDate1.day > persianDate2.Day) return 1;
            else if (persianDate1.day < persianDate2.Day) return -1;

            if (persianDate1.hour > persianDate2.hour) return 1;
            else if (persianDate1.hour < persianDate2.hour) return -1;

            if (persianDate1.minute > persianDate2.Minute) return 1;
            else if (persianDate1.minute < persianDate2.Minute) return -1;

            if (persianDate1.second > persianDate2.Second) return 1;
            else if (persianDate1.second < persianDate2.Second) return -1;

            return 0;
        }

        public static PersianDate Parse(DateTime date)
        {
            PersianDate pd = new PersianDate(
                calendar.GetYear(date),
                calendar.GetMonth(date),
                calendar.GetDayOfMonth(date),
                calendar.GetHour(date),
                calendar.GetMinute(date),
                calendar.GetSecond(date));
            pd.dayOfWeek = calendar.GetDayOfWeek(date);
            return pd;
           // return PersianDate.MinValue;
        }

        public static PersianDate Parse(string dateString)
        {
            return PersianDate.MinValue ;    
            
            // return PersianDate.MinValue;
        }
        #endregion

        #region Public Methods
        public PersianDate AddHours(int value)
        {
            try
            {
                return (PersianDate)(((DateTime)this).AddHours(value));
            }
            catch (Exception ex) { throw ex; }
        }
     
        public PersianDate AddMinutes(int value)
        {
            try
            {
                return (PersianDate)(((DateTime)this).AddMinutes(value));
            }
            catch (Exception ex) { throw ex; }
        }

        public PersianDate AddSeconds(int value)
        {
            try
            {
                return (PersianDate)(((DateTime)this).AddSeconds(value));
            }
            catch (Exception ex) { throw ex; }
        }

        public PersianDate AddDays(int value)
        {
            try
            {
                return (PersianDate)(((DateTime)this).AddDays(value));
            }
            catch (Exception ex) { throw ex; }
        }

        public PersianDate AddMonths(int value)
        {
            try
            {
                return (PersianDate)(((DateTime)this).AddMonths(value));
            }
            catch (Exception ex) { throw ex; }
        }

        public PersianDate AddYears(int value)
        {
            try
            {
                return (PersianDate)(((DateTime )this).AddYears(value));
            }
            catch (Exception ex) { throw ex; }
        }

        public int GetDaysInMonth()
        {
            return calendar.GetDaysInMonth(year, month);
        }
        public int GetDaysInYear()
        {
            return calendar.GetDaysInYear(year);
        }

        #endregion

        #region internal Method(s)
        internal PersianDate GetLastSaturday()
        {
            PersianDate date = AddDays(-(day + 1));
            return date.AddDays(-(GetWeekNo(date.dayOfWeek) - 1));
        }
        #endregion

        #region Private Method(s)
        private int GetWeekNo(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Saturday:
                    return 1;
                case DayOfWeek.Sunday:
                    return 2;
                case DayOfWeek.Monday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 4;
                case DayOfWeek.Wednesday:
                    return 5;
                case DayOfWeek.Thursday:
                    return 6;
                case DayOfWeek.Friday:
                    return 7;
            }
            return -1;
        }
        #endregion

        #region Override Methods

        /// <summary>
        /// for example ToString(yyyy-MM-dd hh:mm:ss);
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            
            format = Regex.Replace(format, "dd", day.ToString("00"));
            format = Regex.Replace(format, "MM", month.ToString("00"));
            format = Regex.Replace(format, "yyyy", year.ToString("0000"), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            format = Regex.Replace(format, "DD", weekArray[GetWeekNo(calendar.GetDayOfWeek((DateTime)this)) - 1]);
            format = Regex.Replace(format, "ND", weekArray[GetWeekNo(dayOfWeek) - 1]);
            format = Regex.Replace(format, "NM", monthsArray[month - 1]);

            format = Regex.Replace(format, "hh", hour.ToString("00"));
            format = Regex.Replace(format, "mm", minute.ToString("00"));
            format = Regex.Replace(format, "ss", second.ToString("00"));

            return format;
        }

        public override string ToString()
        {
            return string.Format("{0:D4}/{1:D2}/{2:D2} {3:D2}:{4:D2}:{5:D2}", year, month, day, hour, minute, second);
        }

        public override bool Equals(object obj)
        {
            if (obj is PersianDate)
                return ((PersianDate)obj) == this;
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion

        #endregion

        #region Operators
        public static bool operator ==(PersianDate persianDate1, PersianDate persianDate2)
        {

            //if (!(persianDate1 is PersianDate) || !(persianDate2 is PersianDate))
            //{
            //    if (!(persianDate2 is PersianDate) && !(persianDate1 is PersianDate))
            //        return true;
            //    return false;
            //}
            return (
                persianDate1.Second == persianDate2.Second &&
               (persianDate1.Minute == persianDate2.Minute) &&
               (persianDate1.Hour == persianDate2.Hour) &&
                   (persianDate1.Day == persianDate2.Day) &&
                    (persianDate1.Month == persianDate2.Month) &&
                    (persianDate1.Year == persianDate2.Year)

                   );



        }

        public static bool operator !=(PersianDate persianDate1, PersianDate persianDate2)
        {
            //if (!(persianDate1 is PersianDate) || !(persianDate2 is PersianDate))
            //{
            //    if (!(persianDate2 is PersianDate))
            //        return false;
            //    return true;
            //}

            return !(
                                persianDate1.Second == persianDate2.Second &&
               (persianDate1.Minute == persianDate2.Minute) &&
               (persianDate1.Hour == persianDate2.Hour) &&
                    (persianDate1.Day == persianDate2.Day) &&
                    (persianDate1.Month == persianDate2.Month) &&
                    (persianDate1.Year == persianDate2.Year)
                   );
        }

        public static bool operator >(PersianDate persianDate1, PersianDate persianDate2)
        {
            return PersianDate.Compare2Date(persianDate1, persianDate2) == 1;
        }

        public static bool operator <(PersianDate persianDate1, PersianDate persianDate2)
        {
            return PersianDate.Compare2Date(persianDate1, persianDate2) == -1;
        }

        public static bool operator >=(PersianDate persianDate1, PersianDate persianDate2)
        {
            int res = PersianDate.Compare2Date(persianDate1, persianDate2);
            return res == 1 || res == 0;
        }

        public static bool operator <=(PersianDate persianDate1, PersianDate persianDate2)
        {
            int res = PersianDate.Compare2Date(persianDate1, persianDate2);
            return res == -1 || res == 0;
        }
        #endregion

        #region Implicit Casting

        public static implicit operator DateTime(PersianDate persianDate)
        {
            if (PersianDate.ValidDate(persianDate))
                return calendar.ToDateTime(persianDate.Year, persianDate.Month, persianDate.Day, persianDate.Hour  , persianDate.Minute  ,persianDate.Second , 0);
            return DateTime.MinValue;
        }

        public static implicit operator PersianDate(DateTime date)
        {
            if (date.Equals(DateTime.MinValue))
                return MinValue;
            return Parse(date);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (!(obj is PersianDate))
                new ArgumentException("obj is not PersianDate");

            return CompareTo((PersianDate)obj);
        }

        #endregion

        #region IComparable<PersianDate> Members

        public int CompareTo(PersianDate other)
        {
            return PersianDate.Compare2Date(this, other);
        }

        #endregion

        #region IComparer Members

        public int Compare(object x, object y)
        {
            if (!(x is PersianDate))
                throw new ArgumentException("x is not PersianDate");
            if (!(y is PersianDate))
                throw new ArgumentException("y is not PersianDate");

            return PersianDate.Compare2Date((PersianDate)x, (PersianDate)y);
        }

        #endregion

        #region IComparer<PersianDate> Members

        public int Compare(PersianDate x, PersianDate y)
        {
            return PersianDate.Compare2Date(x, y);
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return (PersianDate)this.MemberwiseClone();
        }

        #endregion

    }//end class
}//end namespace
