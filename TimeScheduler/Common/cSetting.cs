using Microsoft.Win32;
using System;
using System.Collections.Generic;

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

        public static void RemoveAllValue()
        {
            List<string> list = GetSettingNameList();

            foreach (string s in list)
                RemoveValue(s);
        }

        public static List<string> GetSettingNameList()
        {
            List<string> valNames = new List<string>();

            valNames.Add(cConstraint.SETTINGS_DOWORK_CYCLE_TIME);
            valNames.Add(cConstraint.SETTINGS_RUN_ON_PROGRAM_START);
            valNames.Add(cConstraint.SETTINGS_ASK_ON_CLOSE);
            valNames.Add(cConstraint.SETTINGS_LAST_UPDATED_DATE);
            valNames.Add(cConstraint.SETTINGS_SAVE_ON_DATA_CHANGED);

            return valNames;
        }

        public static void SetDefaultValueIfNotExists()
        {
            List<string> list = GetSettingNameList();

            foreach (string s in list)
            {
                if (cRegKey.GetValue(s) == null)
                {
                    if (s.Equals(cConstraint.SETTINGS_DOWORK_CYCLE_TIME))
                        SetValue(s, "1000");

                    if (s.Equals(cConstraint.SETTINGS_RUN_ON_PROGRAM_START))
                        SetValue(s, "false");

                    if (s.Equals(cConstraint.SETTINGS_ASK_ON_CLOSE))
                        SetValue(s, "false");

                    if (s.Equals(cConstraint.SETTINGS_LAST_UPDATED_DATE))
                        SetValue(s, DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE));

                    if (s.Equals(cConstraint.SETTINGS_SAVE_ON_DATA_CHANGED))
                        SetValue(s, "true");
                }
            }
        }
    }
}
