namespace TimeScheduler
{
    public class cConstraint
    {
        #region CSV
        /// <summary>
        /// CSV 저장장소
        /// </summary>
        public static string CSV_LOCATION = @"C:\TimeScheduler";
        /// <summary>
        /// CSV 파일이름
        /// </summary>
        public static string CSV_NAME = @"TimeScheduler.csv";
        /// <summary>
        /// CSV 저장장소 + CSV 파일이름
        /// </summary>
        public static string CSV_ABSOLUTE_LOCATION = CSV_LOCATION + @"\" + CSV_NAME;
        #endregion

        #region Registry
        /// <summary>
        /// Registry 기본 경로
        /// </summary>
        public static string REG_PROGRAM_PATH = @"SOFTWARE\TimeSchedule";
        #endregion

        #region Setting
        /// <summary>
        /// 조회주기 KeyName
        /// </summary>
        public static string SETTINGS_DOWORK_CYCLE_TIME = "DOWORK_CYCLE_TIME";
        /// <summary>
        /// 프로그램 실행시 자동 실행여부 KeyName
        /// </summary>
        public static string SETTINGS_RUN_ON_PROGRAM_START = "RUN_ON_PROGRAM_START";
        /// <summary>
        /// 프로그램 종료시 저장여부 묻기 KeyName
        /// </summary>
        public static string SETTINGS_ASK_ON_CLOSE = "ASK_ON_CLOSE";
        /// <summary>
        /// 데이터 수정시 자동저장 여부 KeyName
        /// </summary>
        public static string SETTINGS_SAVE_ON_DATA_CHANGED = "SAVE_ON_DATA_CHANGED";
        /// <summary>
        /// 최종수정일 KeyName
        /// </summary>
        public static string SETTINGS_LAST_UPDATED_DATE = "LAST_UPDATED_DATE";
        #endregion

        #region Format
        /// <summary>
        /// 최종수정일의 Value Format
        /// </summary>
        /// 
        public static string FORMAT_LAST_UPDATED_DATE = "yyyy-MM-dd HH:mm:ss";
        #endregion
    }
}
