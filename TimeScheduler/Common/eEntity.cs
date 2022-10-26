using System;
using System.Collections.Generic;

namespace TimeScheduler
{
    public enum ScheduleCycleType
    {
        Once,
        Every,
        None
    }

    public enum ScheduleDayOfWeekType
    {
        Sun,
        Mon,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
        None
    }

    #region eSchedule
    public class eSchedule
    {
        public string NAME { get; set; }
        public ScheduleCycleType CYCLE { get; set; }
        public string DATE { get; set; }
        public List<DayOfWeek> DAYOFWEEK = new List<DayOfWeek>();
        public string TIME { get; set; }
        public string MINUTE { get; set; }
        public bool COMPLETED { get; set; }

        public eSchedule()
        {
            Clear();
        }

        public eSchedule(string pName, ScheduleCycleType pCycle, string pDate, List<DayOfWeek> pDayOfWeek, string pTime, string pMinute, bool pCompleted = false)
        {
            NAME = pName.ToUpper();
            CYCLE = pCycle;
            DATE = pDate;
            DAYOFWEEK = pDayOfWeek;
            TIME = pTime;
            MINUTE = pMinute;
            COMPLETED = pCompleted;
        }

        public void Clear()
        {
            NAME = TIME = MINUTE = DATE = string.Empty;
            CYCLE = ScheduleCycleType.None;
            DAYOFWEEK.Clear();
            COMPLETED = false;
        }
    }
    #endregion

    #region eDownloadFile
    public class eDownloadFile
    {
        public string SAVEPATH { get; set; }
        public string URL { get; set; }

        public eDownloadFile()
        {
            Clear();
        }

        public eDownloadFile(string pSavePath, string pUrl)
        {
            SAVEPATH = pSavePath;
            URL = pUrl;
        }

        public void Clear()
        {
            SAVEPATH = string.Empty;
            URL = string.Empty;
        }
    }
    #endregion
}
