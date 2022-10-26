using System.IO;
using System.Reflection;

namespace TimeScheduler
{
    public class cConstraint
    {
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
        /// <summary>
        /// Registry 기본 경로
        /// </summary>
        public static string REG_PROGRAM_PATH = @"SOFTWARE\TimeSchedule";
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
        /// <summary>
        /// 최종수정일의 Value Format
        /// </summary>
        public static string FORMAT_LAST_UPDATED_DATE = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// Github에 등록된 최신 Release exe 파일
        /// </summary>
        public static string UPDATE_SERVER_EXE_URL = "https://github.com/yuk7392/TimeScheduler/raw/master/TimeScheduler/bin/Release/TimeScheduler.exe";
        /// <summary>
        /// 실행중인 exe 파일의 절대경로
        /// </summary>
        public static string UPDATE_APPLICATION_LOCATION = Assembly.GetCallingAssembly().Location;
        /// <summary>
        /// 실행중인 exe 파일이 존재하는 폴더 경로
        /// </summary>
        public static string UPDATE_APPLICATION_DIR_PATH = Path.GetDirectoryName(UPDATE_APPLICATION_LOCATION);
        /// <summary>
        /// 실행중인 exe 이름
        /// </summary>
        public static string UPDATE_APPLICATION_EXE_NAME = Path.GetFileName(UPDATE_APPLICATION_LOCATION);
        public static string OLD_FILE_EXTENSION = ".TSOLD";
    }
}
