using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TimeScheduler
{
    public partial class frm_CM_ChangeLog : Form
    {
        List<eChangeLog> cChangeLogList;

        public frm_CM_ChangeLog()
        {
            InitializeComponent();
        }

        private void AppendLog(string pText, bool pNewLineFlag = true)
        {
            tbLog.AppendText("[" + DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE) + "] " + pText + (pNewLineFlag ? Environment.NewLine : string.Empty));
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            tbLog.ScrollToCaret();
        }

        private bool GetChangeLog()
        {
            cChangeLogList = new List<eChangeLog>();

            if (!cCommon.InternetConnected())
                return false;

            cCommon.SetSecurityProtocol();

            WebClient webClient = new WebClient();

            string logStr = Regex.Replace(webClient.DownloadString(new Uri(cConstraint.CHANGELOG_SERVER_URL)), @"\r\n?|\n", Environment.NewLine);

            string[] logStr_split = logStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            eChangeLog log = new eChangeLog();
            bool inForm = false;
            StringBuilder sb = new StringBuilder();

            foreach (string s in logStr_split)
            {
                if (s.Trim().StartsWith("#") && s.Trim().Length == 1)
                {
                    log.CHANGELOG = sb.ToString();

                    inForm = false;
                    cChangeLogList.Add(log);
                    log = new eChangeLog();
                    sb.Clear();
                }

                if (!s.Trim().StartsWith("$") && inForm)
                    sb.Append(s + Environment.NewLine);

                // Beginning Point
                if (s.Trim().StartsWith("#") && s.Trim().Length > 1)
                {
                    inForm = true;
                    log.VERSION = s.Replace("#", string.Empty).Trim();
                }

                if (s.Trim().StartsWith("$") && inForm)
                    log.UPDDATE = s.Replace("$", string.Empty).Trim();
            }

            return true;

        }

        private void frm_CM_ChangeLog_Load(object sender, EventArgs e)
        {
            if (!GetChangeLog())
            {
                AppendLog("인터넷에 연결되어 있지 않습니다.");
            }
            else
            {
                AppendLog(cChangeLogList.Count + "개의 변경사항을 불러왔습니다.");

                cChangeLogList.Reverse();

                lbVersion.Items.Clear();

                foreach (eChangeLog l in cChangeLogList)
                {
                    lbVersion.Items.Add(l.VERSION);

                    if (l.VERSION.Equals(cConstraint.APPLICATION_CURRENT_VERSION))
                        lbVersion.SetSelected(lbVersion.Items.IndexOf(l.VERSION), true);
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVersion.SelectedIndex == -1)
                return;

            foreach (eChangeLog l in cChangeLogList)
            {
                if (l.VERSION.Equals(lbVersion.Items[lbVersion.SelectedIndex].ToString()))
                {
                    tbVersion.Text = l.VERSION;
                    tbUpdDate.Text = l.UPDDATE;
                    tbChangeLog.Text = l.CHANGELOG;
                }
            }
        }

        private void cbSort_CheckedChanged(object sender, EventArgs e)
        {
            cbSort.Text = cbSort.Checked ? "오름차순" : "내림차순";

            ReverseListBox();
        }

        private void ReverseListBox()
        {
            cChangeLogList.Reverse();
            lbVersion.Items.Clear();

            foreach (eChangeLog l in cChangeLogList)
                lbVersion.Items.Add(l.VERSION);
        }
    }
}
