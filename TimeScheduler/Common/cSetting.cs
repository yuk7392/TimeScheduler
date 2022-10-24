using Microsoft.Win32;
using System;

namespace TimeScheduler
{
    public class cSetting
    {
        private static RegistryKey cRegKey = Registry.CurrentUser.CreateSubKey(cConstraint.REG_PROGRAM_PATH + @"\Setting");

        public static string GetValue(string pName)
        {
            if (cRegKey.GetValue(pName) == null)
                return String.Empty;
            else
                return cRegKey.GetValue(pName).ToString().NtoE();
        }

        public static void SetValue(string pName, string pValue)
        {
            cRegKey.SetValue(pName, pValue);
        }

        public static void RemoveValue(string pName)
        {
            if (cRegKey.GetValue(pName) == null)
                return;

            cRegKey.DeleteValue(pName);
        }

        public static void SetDefaultValue()
        {
            SetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME, "1000");
            SetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START, "false");
            SetValue(cConstraint.SETTINGS_LAST_UPDATED_DATE, DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE));
        }

        public static bool IsSettingExists()
        {
            if (cRegKey.GetValue(cConstraint.SETTINGS_LAST_UPDATED_DATE) == null)
                return false;
            else
                return true;
        }
    }
}
