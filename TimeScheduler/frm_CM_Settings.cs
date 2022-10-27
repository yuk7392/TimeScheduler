using System;
using System.Windows.Forms;

namespace TimeScheduler
{
    public partial class frm_CM_Settings : Form
    {
        public frm_CM_Settings()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                int temp = 0;

                if (!Int32.TryParse(tbCycleTime.Text, out temp))
                {
                    MessageBox.Show("숫자만 입력 하실 수 있습니다.");
                }
                else
                {
                    cSetting.SetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME, tbCycleTime.Text);
                    cSetting.SetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START, rbAutoRun_True.Checked ? "true" : "false");
                    cSetting.SetValue(cConstraint.SETTINGS_LAST_UPDATED_DATE, DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE));
                    cSetting.SetValue(cConstraint.SETTINGS_ASK_ON_CLOSE, rbAskOnClose_True.Checked ? "true" : "false");
                    cSetting.SetValue(cConstraint.SETTINGS_SAVE_ON_DATA_CHANGED, rbSaveOnDataChange_True.Checked ? "true" : "false");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;

                this.Close();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MessageBox.Show("정말 초기화 하시겠습니까? 설정한 값은 모두 초기값으로 변경됩니다.", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                // remove all
                cSetting.RemoveAllValue();
                cSetting.SetDefaultValueIfNotExists();
                LoadSetting();

                MessageBox.Show("초기화 되었습니다.");
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void LoadSetting()
        {
            try
            {
                cSetting.SetDefaultValueIfNotExists();

                tbCycleTime.Text = cSetting.GetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME);
                rbAutoRun_False.Checked = cSetting.GetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START).ToUpper().Equals("FALSE") ? true : false;
                rbAutoRun_True.Checked = !rbAutoRun_False.Checked;
                rbAskOnClose_False.Checked = cSetting.GetValue(cConstraint.SETTINGS_ASK_ON_CLOSE).ToUpper().Equals("FALSE") ? true : false;
                rbAskOnClose_True.Checked = !rbAskOnClose_False.Checked;
                rbSaveOnDataChange_False.Checked = cSetting.GetValue(cConstraint.SETTINGS_SAVE_ON_DATA_CHANGED).ToUpper().Equals("FALSE") ? true : false;
                rbSaveOnDataChange_True.Checked = !rbSaveOnDataChange_False.Checked;
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void frm_CM_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSetting();
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }

        private void tbCycleTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = 0;

                if (!int.TryParse(tbCycleTime.Text, out temp))
                    lblCycleTime.Text = "-";
                else
                    lblCycleTime.Text = ((double)temp / 1000) + "초";
            }
            catch (Exception ex)
            {
                cLogWriter.WriteLog(ex);
            }
        }
    }
}
