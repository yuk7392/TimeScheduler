using Microsoft.Win32;

namespace TimeScheduler
{
    public class cRegistryUtil
    {
        public static readonly string PATH = @"SOFTWARE\TimeSchedule\Settings";
        public static RegistryKey cRegKey = null;

        public static void SetGlobalRegKey(string pPath)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(pPath);
            cRegKey = reg;
        }

        public static void WriteSetting(string pName, string pValue)
        {
            if (cRegKey == null)
                SetGlobalRegKey(PATH);

            cRegKey.SetValue(pName, pValue);
        }

        public static string GetSetting(string pName)
        {
            if (cRegKey == null)
                SetGlobalRegKey(PATH);

            return cRegKey.GetValue(pName).ToString().NtoE();
        }

        public static void DeleteSetting(string pName)
        {
            if (cRegKey == null)
                SetGlobalRegKey(PATH);

            cRegKey.DeleteValue(pName);
        }
    }
}
