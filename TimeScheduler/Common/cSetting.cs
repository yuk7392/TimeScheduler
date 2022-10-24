using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace TimeScheduler
{
    public class cSetting
    {
        /// <summary>
        /// 설정 경로
        /// </summary>
        private static RegistryKey cRegKey = Registry.CurrentUser.CreateSubKey(cConstraint.REG_PROGRAM_PATH + @"\Setting");

        #region GetValue : Key값을 통하여 값을 가져온다.
        /// <summary>
        /// Key값을 통하여 값을 가져온다.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static string GetValue(string pName)
        {
            if (cRegKey.GetValue(pName) == null)
                return String.Empty;
            else
                return cRegKey.GetValue(pName).ToString().NtoE();
        }
        #endregion

        #region SetValue : Key와 Value를 매칭하여 저장한다.
        /// <summary>
        /// Key와 Value를 매칭하여 저장한다.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public static void SetValue(string pName, string pValue)
        {
            cRegKey.SetValue(pName, pValue);
        }
        #endregion

        #region RemoveValue : Key값을 통하여 값을 삭제한다.
        /// <summary>
        /// Key값을 통하여 값을 삭제한다.
        /// </summary>
        /// <param name="pName"></param>
        public static void RemoveValue(string pName)
        {
            if (cRegKey.GetValue(pName) == null)
                return;

            cRegKey.DeleteValue(pName);
        }
        #endregion

        #region RemoveAllValue : 모든값을 삭제한다.
        /// <summary>
        /// 모든값을 삭제한다.
        /// </summary>
        public static void RemoveAllValue()
        {
            List<string> list = GetSettingNameList();

            foreach (string s in list)
                RemoveValue(s);
        }
        #endregion

        #region GetSettingNameList : 설정에 사용된 Key이름 리스트을 불러온다.
        /// <summary>
        /// 설정에 사용된 Key이름 리스트을 불러온다.
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region SetDefaultValueIfNotExists : 설정 항목이 존재하지 않으면 기본값으로 항목을 생성한다.
        /// <summary>
        /// 설정 항목이 존재하지 않으면 기본값으로 항목을 생성한다.
        /// </summary>
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
        #endregion
    }
}
