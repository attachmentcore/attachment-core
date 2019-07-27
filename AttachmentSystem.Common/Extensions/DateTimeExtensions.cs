using System;
using System.Globalization;

namespace AttachmentSystem.Common.Extensions
{
    public static class DateTimeExtensions
    {
        #region PersianDateTime
        private class PersianDateTime
        {
            #region Variables
            private DateTime dateTime = new DateTime();
            #endregion

            #region Constructors
            public PersianDateTime(DateTime dateTime)
            {
                this.dateTime = dateTime;
            }
            public PersianDateTime(string persianDateTime) : this(persianDateTime, '/', ':') { }
            public PersianDateTime(string persianDateTime, char dateSeparator) : this(persianDateTime, dateSeparator, ':') { }
            public PersianDateTime(string persianDateTime, char dateSeparator, char timeSeparator)
            {
                string datePart = persianDateTime.Substring(0, 10);
                var dateParts = datePart.Split(dateSeparator);

                string[] timeParts = new string[0];
                if (persianDateTime.Length > 10)
                {
                    string timePart = persianDateTime.Substring(10);
                    timeParts = timePart.Split(timeSeparator);
                }
                PersianCalendar persianCalendar = new PersianCalendar();
                int persianYear = int.Parse(dateParts[0]);
                int persianMonth = int.Parse(dateParts[1]);
                int persianDay = int.Parse(dateParts[2]);

                int hour = 0;
                if (timeParts.Length > 0)
                    hour = int.Parse(timeParts[0]);

                int minute = 0;
                if (timeParts.Length > 1)
                    minute = int.Parse(timeParts[1]);

                int second = 0;
                if (timeParts.Length > 2)
                    second = int.Parse(timeParts[2]);

                int millisecond = 0;
                if (timeParts.Length > 3)
                    millisecond = int.Parse(timeParts[3]);

                this.dateTime = persianCalendar.ToDateTime(persianYear, persianMonth, persianDay, hour, minute, second, millisecond);
            }

            #endregion

            #region Methods
            public DateTime ToDateTime()
            {
                return this.dateTime;
            }
            #endregion

            #region Properties
            public string DateSparator { get; set; }
            public string PersianDateTimeString
            {
                get
                {
                    try
                    {
                        PersianCalendar persianCalender = new PersianCalendar();
                        return string.Format
                        (
                            "{0} {1:00}:{2:00}:{3:00}",
                            this.PersianDateString,
                            persianCalender.GetHour(dateTime),
                            persianCalender.GetMinute(dateTime),
                            persianCalender.GetSecond(dateTime)
                        );
                    }
                    catch
                    {
                        return "";
                    }
                }
            }
            public string PersianDateString
            {
                get
                {
                    try
                    {
                        PersianCalendar persianCalender = new PersianCalendar();
                        return string.Format
                        (
                            "{0:0000}{3}{1:00}{3}{2:00}",
                            persianCalender.GetYear(dateTime),
                            persianCalender.GetMonth(dateTime),
                            persianCalender.GetDayOfMonth(dateTime),
                            this.DateSparator
                        );
                    }
                    catch
                    {
                        return "";
                    }
                }
            }
            #endregion
        }
        #endregion
        public static string ToPersianDateTime(this DateTime dateTime, string separator = "/")
        {
            PersianDateTime persianDateTime = new PersianDateTime(dateTime);
            persianDateTime.DateSparator = separator;
            return persianDateTime.PersianDateTimeString;
        }
        public static string ToPersianDate(this DateTime dateTime, string separator = "/")
        {
            PersianDateTime persianDateTime = new PersianDateTime(dateTime);
            persianDateTime.DateSparator = separator;
            return persianDateTime.PersianDateString;
        }

        public static bool HasValue(this DateTime? value)
        {
            return value.HasValue;
        }

        public static bool EqualsWith(this DateTime date1, DateTime date2)
        {
            return date1 == date2;
        }
        public static bool EqualsWith(this DateTime date1, DateTime? date2)
        {
            if (!date2.HasValue())
            {
                return false;
            }
            return date1 == date2;
        }

        public static bool EqualsWith(this DateTime? date1, DateTime? date2)
        {
            if (!date2.HasValue() && !date1.HasValue())
            {
                return true;
            }
            else if(!date2.HasValue() || !date1.HasValue())
            {
                return false;
            }
            return date1 == date2;
        }

    }
}
