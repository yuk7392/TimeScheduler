using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TimeScheduler
{
    public class cCommon
    {
        /// <summary>
        /// 입력받은 요일에 해당하는 가장 가까운 날짜를 반환한다.
        /// </summary>
        /// <param name="pDayOfWeek">DayOfWeek</param>
        /// <returns>DateTime</returns>
        public static DateTime GetDayOfWeekDate(DayOfWeek pDayOfWeek)
        {
            DateTime dateTime = DateTime.Today;
            bool loop = true;

            while (loop)
            {
                if (dateTime.DayOfWeek == pDayOfWeek)
                    loop = false;
                else
                    dateTime = dateTime.AddDays(1);
            }

            return dateTime;
        }

        /// <summary>
        /// 입력받은 날짜(yyyyMMDD)의 요일을 반환한다.
        /// </summary>
        /// <returns></returns>
        public static DayOfWeek GetDayOfWeekOfDate(string pDate)
        {
            int year = Int32.Parse(pDate.Substring(0, 4));
            int month = Int32.Parse(pDate.Substring(4, 2));
            int day = Int32.Parse(pDate.Substring(6, 2));

            DateTime dateTime = new DateTime(year, month, day);

            return dateTime.DayOfWeek;
        }

        /// <summary>
        /// 중복된 이름이 있는지 확인한다.
        /// </summary>
        /// <param name="pDataGridView"></param>
        /// <returns></returns>
        public static bool IsDupName(DataGridView pDataGridView, string pName)
        {
            foreach (DataGridViewRow row in pDataGridView.Rows)
            {
                if (row.Cells["ScheduleName"].Value.ToString().ToUpper().Equals(pName.ToUpper()))
                    return true;
            }

            return false;
        }

        public static void SaveData(DataGridView pDataGridView)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(cConstraint.CSV_LOCATION);

            if (!dirInfo.Exists)
                dirInfo.Create();


            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow row in pDataGridView.Rows)
            {
                sb.Append(row.Cells["ScheduleName"].Value.ToString().NtoE() + ",");
                sb.Append(row.Cells["ScheduleCycle"].Value.ToString().NtoE() + ",");
                sb.Append(row.Cells["ScheduleDate"].Value.ToString().NtoE() + ",");
                sb.Append(ConvertDayOfWeekToInt(row.Cells["ScheduleDayOfWeek"].Value.ToString()).NtoE() + ",");
                sb.Append(row.Cells["ScheduleTime"].Value.ToString().NtoE() + ",");
                sb.Append(row.Cells["ScheduleMinute"].Value.ToString().NtoE() + ",");
                sb.Append(row.Cells["ScheduleCompleted"].Value.ToString().NtoE() + Environment.NewLine);

            }

            File.WriteAllText(cConstraint.CSV_ABSOLUTE_LOCATION, sb.ToString());
        }

        public static void LoadData(DataGridView pDataGridView)
        {

            if (!File.Exists(cConstraint.CSV_ABSOLUTE_LOCATION))
                return;

            string data = File.ReadAllText(cConstraint.CSV_ABSOLUTE_LOCATION).TrimEnd();

            string[] dataLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string s in dataLines)
            {
                string[] rowData = s.Split(new string[] { "," }, StringSplitOptions.None);
                pDataGridView.Rows.Add(rowData[0], rowData[1], rowData[2], ConvertIntToDayOfWeek(rowData[3].ToString().NtoE()), rowData[4], rowData[5], rowData[6].ToString().NtoE().ToUpper().Equals("TRUE") ? true : false);
            }
        }

        public static eSchedule ConvertToEntity(DataGridViewRow pRow)
        {
            eSchedule eSchedule = new eSchedule();

            eSchedule.NAME = pRow.Cells["ScheduleName"].Value.ToString().NtoE();
            eSchedule.CYCLE = pRow.Cells["ScheduleCycle"].Value.ToString().NtoE().ToUpper().Equals("ONCE") ? ScheduleCycleType.Once : ScheduleCycleType.Every;
            eSchedule.DATE = pRow.Cells["ScheduleDate"].Value.ToString().NtoE();
            eSchedule.DAYOFWEEK = ConvertDayOfWeekToEnum(pRow.Cells["ScheduleDayOfWeek"].Value.ToString().NtoE());
            eSchedule.TIME = pRow.Cells["ScheduleTime"].Value.ToString().NtoE();
            eSchedule.MINUTE = pRow.Cells["ScheduleMinute"].Value.ToString().NtoE();
            eSchedule.COMPLETED = pRow.Cells["ScheduleCompleted"].Value.ToString().NtoE().ToUpper().Equals("TRUE") ? true : false;

            return eSchedule;
        }

        public static string ConvertDayOfWeekToInt(string pDayOfWeek)
        {
            StringBuilder sb = new StringBuilder();

            if (pDayOfWeek.Contains("일"))
                sb.Append("0");

            if (pDayOfWeek.Contains("월"))
                sb.Append("1");

            if (pDayOfWeek.Contains("화"))
                sb.Append("2");

            if (pDayOfWeek.Contains("수"))
                sb.Append("3");

            if (pDayOfWeek.Contains("목"))
                sb.Append("4");

            if (pDayOfWeek.Contains("금"))
                sb.Append("5");

            if (pDayOfWeek.Contains("토"))
                sb.Append("6");

            return sb.ToString();
        }

        public static void SetDayOfWeekCheckBox(List<DayOfWeek> pList, CheckBox pCb1, CheckBox pCb2, CheckBox pCb3, CheckBox pCb4, CheckBox pCb5, CheckBox pCb6, CheckBox pCb7)
        {
            foreach (DayOfWeek day in pList)
            {
                switch (day)
                {
                    case DayOfWeek.Sunday:
                        pCb1.Checked = true;
                        break;

                    case DayOfWeek.Monday:
                        pCb2.Checked = true;
                        break;

                    case DayOfWeek.Tuesday:
                        pCb3.Checked = true;
                        break;

                    case DayOfWeek.Wednesday:
                        pCb4.Checked = true;
                        break;

                    case DayOfWeek.Thursday:
                        pCb5.Checked = true;
                        break;

                    case DayOfWeek.Friday:
                        pCb6.Checked = true;
                        break;

                    case DayOfWeek.Saturday:
                        pCb7.Checked = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public static string CheckBoxToDayOfWeek(CheckBox pCb1, CheckBox pCb2, CheckBox pCb3, CheckBox pCb4, CheckBox pCb5, CheckBox pCb6, CheckBox pCb7)
        {
            StringBuilder sb = new StringBuilder();

            if (pCb1.Checked)
                sb.Append("일");

            if (pCb2.Checked)
                sb.Append("월");

            if (pCb3.Checked)
                sb.Append("화");

            if (pCb4.Checked)
                sb.Append("수");

            if (pCb5.Checked)
                sb.Append("목");

            if (pCb6.Checked)
                sb.Append("금");

            if (pCb7.Checked)
                sb.Append("토");

            return sb.ToString();
        }

        public static List<DayOfWeek> ConvertDayOfWeekToEnum(string pDayOfWeek)
        {

            List<DayOfWeek> dayOfWeek = new List<DayOfWeek>();

            if (pDayOfWeek.Contains("일"))
                dayOfWeek.Add(DayOfWeek.Sunday);

            if (pDayOfWeek.Contains("월"))
                dayOfWeek.Add(DayOfWeek.Monday);

            if (pDayOfWeek.Contains("화"))
                dayOfWeek.Add(DayOfWeek.Tuesday);

            if (pDayOfWeek.Contains("수"))
                dayOfWeek.Add(DayOfWeek.Wednesday);

            if (pDayOfWeek.Contains("목"))
                dayOfWeek.Add(DayOfWeek.Thursday);

            if (pDayOfWeek.Contains("금"))
                dayOfWeek.Add(DayOfWeek.Friday);

            if (pDayOfWeek.Contains("토"))
                dayOfWeek.Add(DayOfWeek.Saturday);

            return dayOfWeek;
        }

        public static string ConvertIntToDayOfWeek(string pInt)
        {
            StringBuilder sb = new StringBuilder();

            if (pInt.Contains("0"))
                sb.Append("일");

            if (pInt.Contains("1"))
                sb.Append("월");

            if (pInt.Contains("2"))
                sb.Append("화");

            if (pInt.Contains("3"))
                sb.Append("수");

            if (pInt.Contains("4"))
                sb.Append("목");

            if (pInt.Contains("5"))
                sb.Append("금");

            if (pInt.Contains("6"))
                sb.Append("토");

            return sb.ToString();
        }
    }

    public static class cCommonExtension
    {
        public static string NtoE(this string pString)
        {
            if (string.IsNullOrEmpty(pString))
                pString = string.Empty;

            return pString;
        }
    }
}
