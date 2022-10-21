using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int cWaitTime = 5000;

        public event ValueTransfer cValueTransfer;

        public frm_CM_Main()
        {
            InitializeComponent();

            cWorker.WorkerSupportsCancellation = true;
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
                            if (dow.Equals(dayOfWeek) && s.TIME.Equals(time) && s.MINUTE.Equals(min))
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
            cCommon.LoadData(dgvList);
            tbWaitLatency.Text = cWaitTime.ToString();

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

            tbScheduleName.Text = selSchedule.NAME;
            tbScheduleDate.Text = selSchedule.DATE;

            if (selSchedule.CYCLE.Equals(ScheduleCycleType.Once))
                rbSchedule_Once.Checked = true;
            else
                rbSchedule_Every.Checked = true;

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
        }

        private void frm_CM_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            cCommon.SaveData(dgvList);

            MessageBox.Show("저장되었습니다.");
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
                dgvList.Rows.Add(tbScheduleName.Text, rbSchedule_Once.Checked ? "Once" : "Every", tbScheduleDate.Text, cCommon.CheckBoxToDayOfWeek(cbSchedule_Sun, cbSchedule_Mon, cbSchedule_Tue, cbSchedule_Wed, cbSchedule_Thu, cbSchedule_Fri, cbSchedule_Sat),
                                 lblSchedule_Time.Text, lblSchedule_Minute.Text, cbSchedule_Completed.Checked);
            else
                MessageBox.Show("중복된 이름이 존재합니다 : " + tbScheduleName.Text);
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
                    cWaitTime = 5000;

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

            MessageBox.Show(pContext, "알림");
        }
    }
}
