using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace TimeScheduler
{
    public partial class frm_CM_Download : Form
    {
        private List<eDownloadFile> cDownloadList;
        private ManualResetEvent cReset = new ManualResetEvent(true);
        private BackgroundWorker cWorker = new BackgroundWorker();

        public frm_CM_Download(List<eDownloadFile> pList)
        {
            try
            {
                InitializeComponent();
                cDownloadList = pList;

                cCommon.SetSecurityProtocol();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void cWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                cCommon.SetSecurityProtocol();

                int skipCnt = 0;
                WebClient webClient = new WebClient();

                pgBar.BeginInvoke(new MethodInvoker(delegate { pgBar.Step = 100 / cDownloadList.Count; }));

                AppendText("다운로드 항목 : " + cDownloadList.Count);
                AppendText("다운로드를 시작합니다.");
                AppendText(string.Empty);

                foreach (eDownloadFile file in cDownloadList)
                {
                    if (string.IsNullOrEmpty(file.SAVEPATH) || string.IsNullOrEmpty(file.URL))
                    {
                        skipCnt++;
                        pgBar.BeginInvoke(new MethodInvoker(delegate { pgBar.PerformStep(); }));
                        continue;
                    }

                    AppendText("다운로드 중 : " + Path.GetFileName(file.SAVEPATH) + " ", false);

                    if (File.Exists(file.SAVEPATH))
                        File.Delete(file.SAVEPATH);

                    webClient.DownloadFile(new Uri(file.URL), file.SAVEPATH);
                    AppendText("[완료]");
                    pgBar.BeginInvoke(new MethodInvoker(delegate { pgBar.PerformStep(); }));
                }

                AppendText(string.Empty);

                if (skipCnt > 0)
                    AppendText(cDownloadList.Count + "개의 항목 중 " + skipCnt + "개의 항목을 건너뛰었습니다.");

                pgBar.BeginInvoke(new MethodInvoker(delegate { pgBar.PerformStep(); }));

                AppendText("프로그램을 종료합니다.", false);
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void cWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void cWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                cWorker_SubEvent(false);
                this.BeginInvoke(new MethodInvoker(delegate { this.DialogResult = DialogResult.OK; this.Close(); }));
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void AppendText(string pString, bool pChngLine = true)
        {
            try
            {
                tb.BeginInvoke(new MethodInvoker(delegate { tb.AppendText("[" + DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE) + "] " + pString + (pChngLine ? Environment.NewLine : string.Empty)); }));
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void cWorker_SubEvent(bool pSubFlag)
        {
            try
            {
                if (pSubFlag)
                {
                    cWorker.DoWork += cWorker_DoWork;
                    cWorker.ProgressChanged += cWorker_ProgressChanged;
                    cWorker.RunWorkerCompleted += cWorker_RunWorkerCompleted;
                }
                else
                {
                    cWorker.DoWork -= cWorker_DoWork;
                    cWorker.ProgressChanged -= cWorker_ProgressChanged;
                    cWorker.RunWorkerCompleted -= cWorker_RunWorkerCompleted;
                }
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tb.ScrollToCaret();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void frm_CM_Download_Load(object sender, EventArgs e)
        {
            try
            {
                cWorker.WorkerSupportsCancellation = true;

                cWorker_SubEvent(true);

                if (cDownloadList.Count == 0)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    cWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }
    }
}
