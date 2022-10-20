using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeScheduler
{

    public delegate void ValueTransfer(bool pHoursFlag, string pValue);

    public partial class frm_CM_Main : Form
    {

        List<Control> cInformControls = new List<Control>();

        public event ValueTransfer cValueTransfer;

        public frm_CM_Main()
        {
            InitializeComponent();
        }

        public void SendValue(bool pHoursFlag, string pValue)
        {
            if (cValueTransfer != null)
                cValueTransfer(pHoursFlag, pValue);
        }

        private void frm_CM_Main_Load(object sender, EventArgs e)
        {
            cCommon.LoadData(dgvList);

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
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                gbInform.Text = "정보";
                return;
            }

            gbInform.Text = "정보("+(e.RowIndex + 1)+"번)";

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
                rbSchedule_Every.Checked = false;

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

            UpdateRowInfo(dgvList.SelectedRows[0]);
            ClearInformControls();
        }

        private void frm_CM_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            cCommon.SaveData(dgvList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Add(tbScheduleName.Text, tbScheduleDate.Text, rbSchedule_Once.Checked ? "Once" : "Every", cCommon.CheckBoxToDayOfWeek(cbSchedule_Sun, cbSchedule_Mon, cbSchedule_Tue, cbSchedule_Wed, cbSchedule_Thu, cbSchedule_Fri, cbSchedule_Sat),
                             lblSchedule_Time.Text, lblSchedule_Minute.Text, cbSchedule_Completed.Checked);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                return;

            dgvList.Rows.Remove(dgvList.SelectedRows[0]);
        }

        private void rbSchedule_Every_CheckedChanged(object sender, EventArgs e)
        {
            tbScheduleDate.Text = String.Empty;
            tbScheduleDate.ReadOnly = rbSchedule_Every.Checked;
        }
    }
}
