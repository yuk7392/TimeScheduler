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
        public bool SKIP { get; set; }

        public eSchedule()
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public eSchedule(string pName, ScheduleCycleType pCycle, string pDate, List<DayOfWeek> pDayOfWeek, string pTime, string pMinute, bool pCompleted = false, bool pSkip = false)
        {
            try
            {
                NAME = pName.ToUpper();
                CYCLE = pCycle;
                DATE = pDate;
                DAYOFWEEK = pDayOfWeek;
                TIME = pTime;
                MINUTE = pMinute;
                COMPLETED = pCompleted;
                SKIP = pSkip;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public void Clear()
        {
            try
            {
                NAME = TIME = MINUTE = DATE = string.Empty;
                CYCLE = ScheduleCycleType.None;
                DAYOFWEEK.Clear();
                COMPLETED = SKIP = false;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
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
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public eDownloadFile(string pSavePath, string pUrl)
        {
            try
            {
                SAVEPATH = pSavePath;
                URL = pUrl;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public void Clear()
        {
            try
            {
                SAVEPATH = string.Empty;
                URL = string.Empty;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }
    }
    #endregion

    #region eChangeLog
    public class eChangeLog
    {
        public string VERSION { get; set; }
        public string UPDDATE { get; set; }
        public string CHANGELOG { get; set; }

        public eChangeLog()
        {
            try
            {

            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public eChangeLog(string pVersion, string pUpdDate, string pChangeLog)
        {
            try
            {
                VERSION = pVersion;
                UPDDATE = pUpdDate;
                CHANGELOG = pChangeLog;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        public void Clear()
        {
            try
            {
                VERSION = string.Empty;
                UPDDATE = string.Empty;
                CHANGELOG = string.Empty;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }
    }
    #endregion
}
