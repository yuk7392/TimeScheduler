using System;
using System.IO;
using System.Text;

namespace TimeScheduler
{
    public class cLogWriter
    {
        #region WriteLog : 로그를 작성한다.
        /// <summary>
        /// 로그를 작성한다.
        /// </summary>
        public static void WriteLog(Exception pException, string pCmmt = "")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(cConstraint.LOG_LOCATION);
            StringBuilder sb = new StringBuilder();
            Exception ex = pException;
            string logFileName = "log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string fullPath = cConstraint.LOG_LOCATION + @"/" + logFileName;

            if (!dirInfo.Exists)
                dirInfo.Create();

            sb.Append("예외 발생 프로그램/개체 : " + ex.Source + Environment.NewLine);
            sb.Append("발생한 예외 : " + ex.Message + Environment.NewLine);
            sb.Append("예외가 발생한 메서드 : " + ex.TargetSite + Environment.NewLine);

            if (!string.IsNullOrEmpty(pCmmt))
                sb.Append("CMMT : " + pCmmt + Environment.NewLine);

            sb.Append("StackTrace =>" + Environment.NewLine);
            sb.Append(ex.StackTrace);

            if (File.Exists(fullPath))
                File.AppendAllText(fullPath, Environment.NewLine);

            File.AppendAllText(fullPath, sb.ToString());
        }
        #endregion
    }
}
