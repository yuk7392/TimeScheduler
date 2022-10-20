﻿using System;
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

            if (!cHoursFlag)
                lblValue.Text = nextVal.ToString().PadLeft(2, '0');
            else
                lblValue.Text = nextVal.ToString();                
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

            if (!cHoursFlag)
                lblValue.Text = nextVal.ToString().PadLeft(2, '0');
            else
                lblValue.Text = nextVal.ToString();
        }

        private int ConvertLabelToInt()
        {
            return Int32.Parse(lblValue.Text);
        }
    }
}
