using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TimeScheduler
{
    public class cCommon
    {
        #region GetDayOfWeekDate : 입력받은 요일에 해당하는 가장 가까운 날짜를 반환한다.
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
        #endregion

        #region GetDayOfWeekOfDate : 입력받은 날짜(yyyyMMDD)의 요일을 반환한다.
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
        #endregion

        #region IsDupName : 중복된 이름이 있는지 확인한다.
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
        #endregion

        #region SaveData : DataGridView의 정보를 프로그램 폴더에 CSV형태로 저장한다.
        /// <summary>
        /// DataGridView의 정보를 프로그램 폴더에 CSV형태로 저장한다.
        /// </summary>
        /// <param name="pDataGridView"></param>
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
        #endregion

        #region LoadData : 저장된 CSV파일을 읽어서 DataGridView의 Row로 변환한다.
        /// <summary>
        /// 저장된 CSV파일을 읽어서 DataGridView의 Row로 변환한다.
        /// </summary>
        /// <param name="pDataGridView"></param>
        public static void LoadData(DataGridView pDataGridView)
        {

            if (!File.Exists(cConstraint.CSV_ABSOLUTE_LOCATION))
                return;

            string data = File.ReadAllText(cConstraint.CSV_ABSOLUTE_LOCATION).TrimEnd();

            string[] dataLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string s in dataLines)
            {
                string[] rowData = s.Split(new string[] { "," }, StringSplitOptions.None);

                if (rowData.Length != 7)
                    continue;

                pDataGridView.Rows.Add(rowData[0], rowData[1], rowData[2], ConvertIntToDayOfWeek(rowData[3].ToString().NtoE()), rowData[4], rowData[5], rowData[6].ToString().NtoE().ToUpper().Equals("TRUE") ? true : false);
            }
        }
        #endregion

        #region ResetCsv : CSV 파일을 초기화한다.
        /// <summary>
        /// CSV 파일을 초기화한다.
        /// </summary>
        public static void ResetCsv()
        {
            if (File.Exists(cConstraint.CSV_ABSOLUTE_LOCATION))
                File.Delete(cConstraint.CSV_ABSOLUTE_LOCATION);

            using (File.Create(cConstraint.CSV_ABSOLUTE_LOCATION))
            {

            }
        }
        #endregion

        #region ConvertToEntity : DataGridViewRow의 정보를 eSchedule로 변환한다.
        /// <summary>
        /// DataGridViewRow의 정보를 eSchedule로 변환한다.
        /// </summary>
        /// <param name="pRow"></param>
        /// <returns></returns>
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
        #endregion

        #region ConvertDayOfWeekToInt : 요일을 Int형식으로 변환한다.
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
        #endregion

        #region SetDayOfWeekCheckBox : 요일 리스트에 들어있는 요소들과 매칭하여 체크박스를 체크한다.
        /// <summary>
        /// 요일 리스트에 들어있는 요소들과 매칭하여 체크박스를 체크한다.
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="pCb1"></param>
        /// <param name="pCb2"></param>
        /// <param name="pCb3"></param>
        /// <param name="pCb4"></param>
        /// <param name="pCb5"></param>
        /// <param name="pCb6"></param>
        /// <param name="pCb7"></param>
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
        #endregion

        #region CheckBoxToDayOfWeek : 요일 체크박스의 체크여부를 요일로 변환한다.
        /// <summary>
        /// 요일 체크박스의 체크여부를 요일로 변환한다.
        /// </summary>
        /// <param name="pCb1"></param>
        /// <param name="pCb2"></param>
        /// <param name="pCb3"></param>
        /// <param name="pCb4"></param>
        /// <param name="pCb5"></param>
        /// <param name="pCb6"></param>
        /// <param name="pCb7"></param>
        /// <returns></returns>
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
        #endregion

        #region ConvertDayOfWeekToEnum : 요일을 DayOfWeek(Enum)으로 변환한다.
        /// <summary>
        /// 요일을 DayOfWeek(Enum)으로 변환한다.
        /// </summary>
        /// <param name="pDayOfWeek"></param>
        /// <returns></returns>
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
        #endregion

        #region ConvertIntToDayOfWeek : int형식을 요일로 변환한다.
        /// <summary>
        /// int형식을 요일로 변환한다.
        /// </summary>
        /// <param name="pInt"></param>
        /// <returns></returns>
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
        #endregion

        #region IsDate : yyyyMMdd 형식의 날짜인지 확인한다.
        /// <summary>
        /// yyyyMMdd 형식의 날짜인지 확인한다.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public static bool IsDate(string pString)
        {
            DateTime dateTime;

            return DateTime.TryParseExact(pString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
        }
        #endregion

        #region ConvertDayOfWeekEnumListToString : DayOfWeek(Enum) 리스트를 string으로 변환한다.
        /// <summary>
        /// DayOfWeek(Enum) 리스트를 string으로 변환한다.
        /// </summary>
        /// <param name="pDayOfWeekList"></param>
        /// <returns></returns>
        public static string ConvertDayOfWeekEnumListToString(List<DayOfWeek> pDayOfWeekList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DayOfWeek d in pDayOfWeekList)
            {
                if (d.Equals(DayOfWeek.Sunday))
                    sb.Append("일");

                if (d.Equals(DayOfWeek.Monday))
                    sb.Append("월");

                if (d.Equals(DayOfWeek.Tuesday))
                    sb.Append("화");

                if (d.Equals(DayOfWeek.Wednesday))
                    sb.Append("수");

                if (d.Equals(DayOfWeek.Thursday))
                    sb.Append("목");

                if (d.Equals(DayOfWeek.Friday))
                    sb.Append("금");

                if (d.Equals(DayOfWeek.Saturday))
                    sb.Append("토");
            }

            return sb.ToString();
        }
        #endregion

        #region RemoveCompletedRow : 완료된 Row를 제거한다, Cycle이 Every인 항목은 제외한다.
        /// <summary>
        /// 완료된 Row를 제거한다, Cycle이 Every인 항목은 제외한다.
        /// </summary>
        /// <param name="pDataGridView"></param>
        /// <returns></returns>
        public static int RemoveCompletedRow(DataGridView pDataGridView)
        {
            int cnt = 0;

            foreach (DataGridViewRow row in pDataGridView.Rows)
            {
                if (row.Cells["ScheduleCompleted"].Value.Equals(true))
                {
                    if (row.Cells["ScheduleCycle"].Value.ToString().ToUpper().NtoE().Equals("EVERY"))
                        continue;

                    pDataGridView.Rows.Remove(row);
                    cnt++;
                }
            }

            return cnt;
        }
        #endregion

        #region CompareVersion : 두 버전을 비교한다, 동일버전이면 0, 구버전이면 -1, 신버전이거나 null이면 1을 반환한다.
        /// <summary>
        /// 두 버전을 비교한다, 동일버전이면 0, 구버전이면 -1, 신버전이거나 null이면 1을 반환한다.
        /// </summary>
        /// <param name="pVersion1"></param>
        /// <param name="pVersion2"></param>
        /// <returns></returns>
        public static int CompareVersion(string pVersion1, string pVersion2)
        {
            Version v1 = new Version(pVersion1);
            Version v2 = new Version(pVersion2);

            int val = v1.CompareTo(v2);

            return val == 0 ? 0 : val > 0 ? 1 : -1;
        }
        #endregion

        #region GetExecutionFileVersion : 실행파일의 Assembly Version을 반환한다.
        /// <summary>
        /// 실행파일의 Assembly Version을 반환한다.
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public static string GetFileAssemblyVersion(string pPath)
        {
            if (!File.Exists(pPath))
                return string.Empty;

            return AssemblyName.GetAssemblyName(pPath).Version.ToString();
        }

        #endregion
    }

    public static class cCommonExtension
    {
        #region NtoE : null 이거나 비어있는 문자를 string.Empty로 치환한다.
        /// <summary>
        /// null 이거나 비어있는 문자를 string.Empty로 치환한다.
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public static string NtoE(this string pString)
        {
            if (string.IsNullOrEmpty(pString))
                pString = string.Empty;

            return pString;
        }
        #endregion
    }
}
