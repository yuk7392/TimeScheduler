using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TimeScheduler
{

    public delegate void ValueTransfer(bool pHoursFlag, string pValue);

    public partial class frm_CM_Main : Form
    {

        List<Control> cInformControls = new List<Control>();
        List<Control> cRunConfigControls = new List<Control>();
        List<CheckBox> cDayOfWeekCheckBoxes = new List<CheckBox>();
        BackgroundWorker cWorker = new BackgroundWorker();
        ManualResetEvent cReset = new ManualResetEvent(true);

        public int cWaitTime = 1000;
        public bool cAutoExecute = false;
        public bool cAskOnClose = true;
        public bool cSaveOnDataChange = true;

        public event ValueTransfer cValueTransfer;

        public frm_CM_Main()
        {
            InitializeComponent();

            cWorker.WorkerSupportsCancellation = true;
            this.Text = "Time Scheduler (" + cConstraint.APPLICATION_CURRENT_VERSION + ")";

            cCommon.RemoveUpdateFile();

            if (cCommon.IsAlreadyRunning())
            {
                MessageBox.Show("프로그램이 이미 실행중입니다. 프로그램을 종료합니다.");
                Environment.Exit(0);
            }
        }

        public void LoadSetting()
        {
            cSetting.SetDefaultValueIfNotExists();

            // Cycle Time
            cWaitTime = Int32.Parse(String.IsNullOrEmpty(cSetting.GetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME)) ? "1000" : cSetting.GetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME));
            tbWaitLatency.Text = cWaitTime.ToString();
            //

            // 
            cAutoExecute = cSetting.GetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START).ToUpper().Equals("TRUE") ? true : false;
            //

            //
            cAskOnClose = cSetting.GetValue(cConstraint.SETTINGS_ASK_ON_CLOSE).ToUpper().Equals("TRUE") ? true : false;
            //

            //
            cSaveOnDataChange = cSetting.GetValue(cConstraint.SETTINGS_SAVE_ON_DATA_CHANGED).ToUpper().Equals("TRUE") ? true : false;
            //
        }

        private void cWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            cReset.WaitOne(cWaitTime);
            cReset.Reset();

            List<eSchedule> schedules = new List<eSchedule>();

            lblWorkDate.BeginInvoke(new MethodInvoker(delegate { lblWorkDate.Text = DateTime.Now.ToString(); }));
            lblRecogCnt.BeginInvoke(new MethodInvoker(delegate { lblRecogCnt.Text = schedules.Count.ToString(); }));

            foreach (DataGridViewRow row in dgvList.Rows)
            {
                schedules.Add(cCommon.ConvertToEntity(row));
            }

            // Start Here
            foreach (eSchedule s in schedules)
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string time = DateTime.Now.ToString("HH");
                string min = DateTime.Now.ToString("mm");
                DayOfWeek dayOfWeek = cCommon.GetDayOfWeekOfDate(date);


                switch (s.CYCLE)
                {
                    case ScheduleCycleType.Once:

                        if (s.DATE.Equals(date) && s.TIME.Equals(time) && s.MINUTE.Equals(min))
                        {
                            if (s.COMPLETED)
                            {
                                break;
                            }
                            else
                            {
                                ShowMessages(s.NAME);
                                s.COMPLETED = true;
                            }
                        }

                        break;

                    case ScheduleCycleType.Every:

                        foreach (DayOfWeek dow in s.DAYOFWEEK)
                        {
                            if (dow.Equals(dayOfWeek))
                            {
                                if (s.TIME.Equals(time) && s.MINUTE.Equals(min))
                                {
                                    if (s.COMPLETED)
                                        break;

                                    ShowMessages(s.NAME);
                                    s.COMPLETED = true;
                                }
                                else
                                {
                                    s.COMPLETED = false;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        break;

                    default:
                        break;
                }

                // 변경사항 반영
                UpdateRowInfo(s);
            }
        }

        private void cWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void cWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cWorker.RunWorkerAsync();
        }

        public void SendValue(bool pHoursFlag, string pValue)
        {
            if (cValueTransfer != null)
                cValueTransfer(pHoursFlag, pValue);
        }

        private void frm_CM_Main_Load(object sender, EventArgs e)
        {
            LoadSetting();

            cCommon.LoadData(dgvList);

            CheckUpdate();

            if (cAutoExecute)
                btnToggleDaemon.PerformClick();

            // Inform
            cInformControls.Add(tbScheduleName);
            cInformControls.Add(tbScheduleDate);
            cInformControls.Add(rbSchedule_Once);
            cInformControls.Add(rbSchedule_Every);
            cInformControls.Add(cbSchedule_Sun);
            cInformControls.Add(cbSchedule_Mon);
            cInformControls.Add(cbSchedule_Tue);
            cInformControls.Add(cbSchedule_Wed);
            cInformControls.Add(cbSchedule_Thu);
            cInformControls.Add(cbSchedule_Fri);
            cInformControls.Add(cbSchedule_Sat);
            cInformControls.Add(lblSchedule_Time);
            cInformControls.Add(lblSchedule_Minute);
            cInformControls.Add(cbSchedule_Completed);
            //

            // Run Config
            cRunConfigControls.Add(tbWaitLatency);
            cRunConfigControls.Add(lblRecogCnt);
            cRunConfigControls.Add(lblWorkDate);
            cRunConfigControls.Add(lblStatus);
            //

            // DayOfWeek CheckBoxes
            cDayOfWeekCheckBoxes.Add(cbSchedule_Sun);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Mon);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Tue);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Wed);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Thu);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Fri);
            cDayOfWeekCheckBoxes.Add(cbSchedule_Sat);

            ChngDayOfWeekChecked();
            //
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                gbInform.Text = "정보";
                return;
            }

            gbInform.Text = "정보(" + (e.RowIndex + 1) + "번)";

            SetInfo(dgvList.Rows[e.RowIndex]);
        }

        private void SetInfo(DataGridViewRow pRow)
        {
            eSchedule selSchedule = cCommon.ConvertToEntity(pRow);

            if (selSchedule.CYCLE.Equals(ScheduleCycleType.Once))
                rbSchedule_Once.Checked = true;
            else
                rbSchedule_Every.Checked = true;

            tbScheduleName.Text = selSchedule.NAME;
            tbScheduleDate.Text = selSchedule.DATE;

            foreach (CheckBox c in cDayOfWeekCheckBoxes)
                c.Checked = false;

            cCommon.SetDayOfWeekCheckBox(selSchedule.DAYOFWEEK, cbSchedule_Sun, cbSchedule_Mon, cbSchedule_Tue, cbSchedule_Wed, cbSchedule_Thu, cbSchedule_Fri, cbSchedule_Sat);

            lblSchedule_Time.Text = selSchedule.TIME;
            lblSchedule_Minute.Text = selSchedule.MINUTE;

            cbSchedule_Completed.Checked = selSchedule.COMPLETED;
        }

        private void UpdateRowInfo(DataGridViewRow pRow)
        {
            pRow.Cells["ScheduleName"].Value = tbScheduleName.Text;
            pRow.Cells["ScheduleDate"].Value = tbScheduleDate.Text;
            pRow.Cells["ScheduleCycle"].Value = rbSchedule_Once.Checked ? "Once" : "Every";
            pRow.Cells["ScheduleDayOfWeek"].Value = cCommon.CheckBoxToDayOfWeek(cbSchedule_Sun, cbSchedule_Mon, cbSchedule_Tue, cbSchedule_Wed, cbSchedule_Thu, cbSchedule_Fri, cbSchedule_Sat);
            pRow.Cells["ScheduleTime"].Value = lblSchedule_Time.Text;
            pRow.Cells["ScheduleMinute"].Value = lblSchedule_Minute.Text;
            pRow.Cells["ScheduleCompleted"].Value = cbSchedule_Completed.Checked;
        }

        private void UpdateRowInfo(eSchedule pSchedule)
        {
            int idx = -1;

            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells["ScheduleName"].Value.ToString().NtoE().Equals(pSchedule.NAME))
                    idx = row.Index;
            }

            if (idx == -1)
                return;

            dgvList.Rows[idx].Cells["ScheduleName"].Value = pSchedule.NAME;
            dgvList.Rows[idx].Cells["ScheduleDate"].Value = pSchedule.DATE;
            dgvList.Rows[idx].Cells["ScheduleCycle"].Value = pSchedule.CYCLE.Equals(ScheduleCycleType.Once) ? "Once" : "Every";
            dgvList.Rows[idx].Cells["ScheduleDayOfWeek"].Value = cCommon.ConvertDayOfWeekEnumListToString(pSchedule.DAYOFWEEK);
            dgvList.Rows[idx].Cells["ScheduleTime"].Value = pSchedule.TIME;
            dgvList.Rows[idx].Cells["ScheduleMinute"].Value = pSchedule.MINUTE;
            dgvList.Rows[idx].Cells["ScheduleCompleted"].Value = pSchedule.COMPLETED;

        }


        public void CallHMPicker(bool pHoursFlag, Label pLabel)
        {
            frm_CM_HMPicker picker = new frm_CM_HMPicker();
            cValueTransfer += picker.ValueRecv;
            SendValue(pHoursFlag, pLabel.Text);

            picker.ShowDialog();

            if (picker.DialogResult == DialogResult.OK)
                pLabel.Text = picker.cValue;
        }

        private void lblHours_Chng_Click(object sender, EventArgs e)
        {
            CallHMPicker(true, lblSchedule_Time);
        }

        private void lblMinutes_Chng_Click(object sender, EventArgs e)
        {
            CallHMPicker(false, lblSchedule_Minute);
        }

        private void ClearInformControls()
        {
            foreach (Control ctrl in cInformControls)
            {
                switch (ctrl.GetType().ToString().ToUpper())
                {
                    case "SYSTEM.WINDOWS.FORMS.TEXTBOX":
                        TextBox tb = (TextBox)ctrl;
                        tb.Text = string.Empty;
                        break;

                    case "SYSTEM.WINDOWS.FORMS.RADIOBUTTON":
                        RadioButton rb = (RadioButton)ctrl;
                        rb.Checked = false;
                        break;

                    case "SYSTEM.WINDOWS.FORMS.CHECKBOX":
                        CheckBox cb = (CheckBox)ctrl;
                        cb.Checked = false;
                        break;

                    case "SYSTEM.WINDOWS.FORMS.LABEL":
                        Label lbl = (Label)ctrl;
                        lbl.Text = string.Empty;
                        break;

                    default:
                        break;
                }
            }

            rbSchedule_Once.Checked = true;
        }

        private void ClearRunConfigControls()
        {
            foreach (Control ctrl in cRunConfigControls)
            {
                switch (ctrl.GetType().ToString().ToUpper())
                {
                    case "SYSTEM.WINDOWS.FORMS.TEXTBOX":
                        TextBox tb = (TextBox)ctrl;
                        tb.Text = string.Empty;
                        break;

                    case "SYSTEM.WINDOWS.FORMS.LABEL":
                        Label lbl = (Label)ctrl;
                        lbl.Text = string.Empty;
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gbInform.Text = "정보";
            ClearInformControls();
            dgvList.ClearSelection();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                return;

            if (!Validation())
                return;

            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            UpdateRowInfo(dgvList.SelectedRows[0]);
            ClearInformControls();
            dgvList.ClearSelection();

            if (cSaveOnDataChange)
            {
                cCommon.SaveData(dgvList);
                MessageBox.Show("저장되었습니다.");
            }
        }

        private void frm_CM_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cAskOnClose)
            {

                if (MessageBox.Show("내용을 저장하시겠습니까?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;

                cCommon.SaveData(dgvList);
                MessageBox.Show("저장되었습니다.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;

            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            if (!cCommon.IsDupName(dgvList, tbScheduleName.Text))
            {

                dgvList.Rows.Add(tbScheduleName.Text, rbSchedule_Once.Checked ? "Once" : "Every", tbScheduleDate.Text, cCommon.CheckBoxToDayOfWeek(cbSchedule_Sun, cbSchedule_Mon, cbSchedule_Tue, cbSchedule_Wed, cbSchedule_Thu, cbSchedule_Fri, cbSchedule_Sat),
                                 lblSchedule_Time.Text, lblSchedule_Minute.Text, cbSchedule_Completed.Checked);

                ClearInformControls();
                dgvList.ClearSelection();

                if (cSaveOnDataChange)
                {
                    cCommon.SaveData(dgvList);
                    MessageBox.Show("저장되었습니다.");
                }
            }
            else
            {

                MessageBox.Show("중복된 이름이 존재합니다 : " + tbScheduleName.Text);
            }
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(tbScheduleName.Text))
            {
                MessageBox.Show("이름은 빈칸일 수 없습니다.");
                return false;
            }

            if (string.IsNullOrEmpty(tbScheduleDate.Text) && rbSchedule_Once.Checked)
            {
                MessageBox.Show("날짜는 빈칸일 수 없습니다.");
                return false;
            }

            if (!cCommon.IsDate(tbScheduleDate.Text) && rbSchedule_Once.Checked)
            {
                MessageBox.Show("올바른 날짜 형식이 아닙니다. (" + DateTime.Today.ToString("yyyyMMdd") + " 형식으로 작성해주세요.)");
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                return;

            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            dgvList.Rows.Remove(dgvList.SelectedRows[0]);
            ClearInformControls();
            dgvList.ClearSelection();

            if (cSaveOnDataChange)
            {
                cCommon.SaveData(dgvList);
                MessageBox.Show("저장되었습니다.");
            }
        }

        private void rbSchedule_Every_CheckedChanged(object sender, EventArgs e)
        {
            tbScheduleDate.Text = String.Empty;
            tbScheduleDate.ReadOnly = rbSchedule_Every.Checked;
        }

        private void btnToggleDaemon_Click(object sender, EventArgs e)
        {
            if (btnToggleDaemon.Text.Equals("실행"))
            {
                this.WindowState = FormWindowState.Minimized;

                tbWaitLatency.ReadOnly = true;

                btnToggleDaemon.Text = "중지";
                lblStatus.Text = "실행 중";

                cWorker.DoWork += cWorker_DoWork;
                cWorker.ProgressChanged += cWorker_ProgressChanged;
                cWorker.RunWorkerCompleted += cWorker_RunWorkerCompleted;

                cWorker.RunWorkerAsync();

                int latency = 0;

                if (Int32.TryParse(tbWaitLatency.Text, out latency))
                    cWaitTime = latency;
                else
                    cWaitTime = Int32.Parse(cSetting.GetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME));

                tbWaitLatency.Text = cWaitTime.ToString();

            }
            else
            {
                if (cWorker.IsBusy)
                {
                    cWorker.CancelAsync();
                    lblStatus.Text = "중지 중";
                    btnToggleDaemon.Enabled = false;
                }

                cWorker.DoWork -= cWorker_DoWork;
                cWorker.ProgressChanged -= cWorker_ProgressChanged;
                cWorker.RunWorkerCompleted -= cWorker_RunWorkerCompleted;

                while (cWorker.IsBusy)
                    Application.DoEvents();

                btnToggleDaemon.Enabled = true;
                tbWaitLatency.ReadOnly = false;

                ClearRunConfigControls();

                tbWaitLatency.Text = cWaitTime.ToString();

                lblStatus.Text = "중지";
                btnToggleDaemon.Text = "실행";
            }
        }

        private void rbSchedule_Once_CheckedChanged(object sender, EventArgs e)
        {
            ChngDayOfWeekChecked();
        }

        public void ChngDayOfWeekChecked()
        {
            foreach (CheckBox cb in cDayOfWeekCheckBoxes)
            {

                if (rbSchedule_Once.Checked)
                {

                    cb.Checked = false;
                    cb.Enabled = false;
                }
                else
                {
                    cb.Enabled = true;
                }

            }
        }

        public void ShowMessages(string pContext)
        {

            this.BeginInvoke(new MethodInvoker(delegate { this.Show(); this.WindowState = FormWindowState.Normal; }));

            MessageBox.Show(pContext, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private void btnDeleteCompleted_Click(object sender, EventArgs e)
        {
            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            if (MessageBox.Show("완료항목들을 삭제하시겠습니까?" + Environment.NewLine + "(주기가 Every인 항목은 삭제되지 않습니다.)", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            MessageBox.Show(cCommon.RemoveCompletedRow(dgvList) + "개의 항목이 삭제되었습니다.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            if (MessageBox.Show("모든항목들을 저장하시겠습니까?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            cCommon.SaveData(dgvList);

            MessageBox.Show("저장되었습니다.");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            if (MessageBox.Show("모든항목들을 불러오시겠습니까?" + Environment.NewLine + "(저장하지 않은 항목은 모두 삭제됩니다.)", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            dgvList.Rows.Clear();
            cCommon.LoadData(dgvList);

            MessageBox.Show("저장된 데이터를 불러왔습니다.");
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            if (MessageBox.Show("모든항목들을 삭제하시겠습니까?" + Environment.NewLine + "(화면에 표시된 데이터 또한 삭제됩니다.)", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            cCommon.ResetCsv();
            dgvList.Rows.Clear();
            cCommon.LoadData(dgvList);
            ClearInformControls();
            ClearRunConfigControls();

            MessageBox.Show("삭제되었습니다.");
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            // 실행 중, 중지 중, 중지

            Color color = Color.Black;

            switch (lblStatus.Text)
            {
                case "실행 중":
                    color = Color.Green;
                    break;

                case "중지 중":
                    color = Color.Yellow;
                    break;

                case "중지":
                    color = Color.Red;
                    break;

                default:
                    color = Color.Black;
                    break;
            }

            lblStatus.ForeColor = color;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (cWorker.IsBusy)
            {
                MessageBox.Show("실행중에는 해당기능을 사용하실 수 없습니다.");
                return;
            }

            frm_CM_Settings frm = new frm_CM_Settings();
            frm.ShowDialog();

            LoadSetting();

        }

        private void dgvList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                gbInform.Text = "정보";
        }

        private void CheckUpdate()
        {
            if (!cCommon.InternetConnected())
                return;

            string dateToday = DateTime.Now.ToString("yyyyMMdd");
            string updateFilePath = cConstraint.UPDATE_APPLICATION_DIR_PATH + "/" + "Update_" + dateToday + ".exe";

            List<eDownloadFile> fileList = new List<eDownloadFile>();
            fileList.Add(new eDownloadFile(updateFilePath, cConstraint.UPDATE_SERVER_EXE_URL));

            frm_CM_Download frm = new frm_CM_Download(fileList);
            frm.ShowDialog();

            switch (cCommon.CompareVersion(cConstraint.APPLICATION_CURRENT_VERSION, cCommon.GetFileAssemblyVersion(updateFilePath)))
            {
                // 동일
                case 0:
                    if (File.Exists(updateFilePath))
                        File.Delete(updateFilePath);
                    return;

                // 업데이트 존재
                case 1:
                case -1:
                    if (MessageBox.Show("업데이트가 존재합니다. 신규버전을 설치하시겠습니까?", string.Empty, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        if (File.Exists(updateFilePath))
                            File.Delete(updateFilePath);

                        return;
                    }

                    File.Move(cConstraint.UPDATE_APPLICATION_LOCATION, cConstraint.UPDATE_APPLICATION_LOCATION + cConstraint.OLD_FILE_EXTENSION);
                    File.Move(updateFilePath, cConstraint.UPDATE_APPLICATION_LOCATION);

                    MessageBox.Show("업데이트 적용을 위해 프로그램이 종료됩니다.");
                    break;

                default:
                    MessageBox.Show("알 수 없는 코드입니다.");
                    return;
            }

            Process.Start(cConstraint.UPDATE_APPLICATION_LOCATION);
            Environment.Exit(0);
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            frm_CM_ChangeLog frm = new frm_CM_ChangeLog();
            frm.ShowDialog();
        }
    }
}
