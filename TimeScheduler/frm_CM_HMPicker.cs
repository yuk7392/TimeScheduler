using System;
using System.Windows.Forms;

namespace TimeScheduler
{
    public partial class frm_CM_HMPicker : Form
    {

        public string cValue = string.Empty;
        private bool cHoursFlag = false;

        public frm_CM_HMPicker()
        {
            InitializeComponent();
        }

        public void ValueRecv(bool pHoursFlag, string pValue)
        {
            if (!string.IsNullOrEmpty(pValue))
                lblValue.Text = pValue;

            cHoursFlag = pHoursFlag;
        }

        private void frm_CM_HourPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cValue = lblValue.Text;
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int nextVal = (ConvertLabelToInt() + 1);

            if (cHoursFlag)
            {
                if (nextVal > 23)
                    nextVal = 0;

                if (nextVal > 12)
                    btnClose.Text = "적용" + Environment.NewLine + "(" + (+nextVal - 12) + "시)";
                else
                    btnClose.Text = "적용";
            }
            else
            {
                if (nextVal > 59)
                    nextVal = 0;
            }

            lblValue.Text = nextVal.ToString().PadLeft(2, '0');
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int nextVal = (ConvertLabelToInt() - 1);

            if (cHoursFlag)
            {
                if (nextVal < 0)
                    nextVal = 23;

                if (nextVal > 12)
                    btnClose.Text = "적용" + Environment.NewLine + "(" + (+nextVal - 12) + "시)";
                else
                    btnClose.Text = "적용";
            }
            else
            {
                if (nextVal < 0)
                    nextVal = 59;
            }

            lblValue.Text = nextVal.ToString().PadLeft(2, '0');
        }

        private int ConvertLabelToInt()
        {
            return Int32.Parse(lblValue.Text);
        }

        private void lblApply_Click(object sender, EventArgs e)
        {
            int newVal;

            if (Int32.TryParse(tbValue.Text, out newVal))
            {
                if (newVal < 0)
                {
                    MessageBox.Show("0보다 작을 수 없습니다.");
                    return;
                }

                if (cHoursFlag)
                {
                    if (newVal > 23)
                    {
                        MessageBox.Show("23시보다 클 수 없습니다.");
                        return;
                    }

                    if (newVal > 12)
                        btnClose.Text = "적용" + Environment.NewLine + "(" + (+newVal - 12) + "시)";
                    else
                        btnClose.Text = "적용";

                }
                else
                {
                    if (newVal > 59)
                    {
                        MessageBox.Show("59분보다 클 수 없습니다.");
                        return;
                    }
                }

                lblValue.Text = newVal.ToString().PadLeft(2, '0');
                tbValue.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("올바르지 않은 입력입니다.");
                return;
            }
        }
    }
}
