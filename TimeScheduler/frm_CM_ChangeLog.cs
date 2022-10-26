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

        //private bool GetChangeLog(out List<eChangeLog> pDictionary)
        //{
        //    pDictionary = new List<eChangeLog>();

        //    if (!cCommon.InternetConnected())
        //    {
        //        AppendLog("인터넷에 연결되어 있지 않습니다.");
        //        return false;
        //    }

        //    WebClient webClient = new WebClient();

        //    string serverStr = webClient.DownloadString


        //}
    }
}
