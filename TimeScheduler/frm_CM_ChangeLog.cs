using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
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

        private bool GetChangeLog(out List<eChangeLog> pList)
        {
            pList = new List<eChangeLog>();

            if (!cCommon.InternetConnected())
                return false;

            WebClient webClient = new WebClient();

            string logStr = webClient.DownloadString(new Uri(cConstraint.CHANGELOG_SERVER_URL));

            string[] logStr_split = logStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string s in logStr_split)
            {
                eChangeLog log = new eChangeLog();
                bool inForm = false;
                StringBuilder sb = new StringBuilder();

                // Beginning Point
                if (s.Trim().StartsWith("#") && s.Trim().Length > 1)
                {
                    inForm = true;
                    log.VERSION = s.Replace("#", string.Empty).Trim();
                }

                if (s.Trim().StartsWith("$") && inForm)
                    log.UPDDATE = s.Replace("$", string.Empty).Trim();

                if (inForm)
                    sb.Append(s + Environment.NewLine);

                if (s.Trim().StartsWith("#") && s.Trim().Length == 1)
                {
                    inForm = false;
                    pList.Add(log);
                    log.Clear();
                    sb.Clear();
                }
            }

            return true;

        }

        private void frm_CM_ChangeLog_Load(object sender, EventArgs e)
        {
            if (!GetChangeLog(out cChangeLogList))
            {
                AppendLog("인터넷에 연결되어 있지 않습니다.");
            }
            else
            {
                AppendLog(cChangeLogList.Count+"개의 변경사항을 불러왔습니다 : ");

                lbVersion.Items.Clear();

                foreach (eChangeLog l in cChangeLogList)
                {
                    lbVersion.Items.Add(l.VERSION);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
