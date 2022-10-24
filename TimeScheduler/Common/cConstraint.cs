namespace TimeScheduler
{
    public class cConstraint
    {
        public static string CSV_LOCATION = @"C:\TimeScheduler";
        public static string CSV_NAME = @"TimeScheduler.csv";
        public static string CSV_ABSOLUTE_LOCATION = CSV_LOCATION + @"\" + CSV_NAME;

        public static string REG_PROGRAM_PATH = @"SOFTWARE\TimeSchedule";

        public static string SETTINGS_DOWORK_CYCLE_TIME = "DOWORK_CYCLE_TIME";
        public static string SETTINGS_RUN_ON_PROGRAM_START = "RUN_ON_PROGRAM_START";
        public static string SETTINGS_LAST_UPDATED_DATE = "LAST_UPDATED_DATE";
        public static string FORMAT_LAST_UPDATED_DATE = "yyyy-MM-dd HH:mm:ss";
    }
}
