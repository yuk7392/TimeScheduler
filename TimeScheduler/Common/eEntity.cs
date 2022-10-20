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
}
