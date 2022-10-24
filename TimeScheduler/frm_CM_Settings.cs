using System;
using System.Windows.Forms;

namespace TimeScheduler
{
    public partial class frm_CM_Settings : Form
    {
        public frm_CM_Settings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            int temp = 0;

            if (!Int32.TryParse(tbCycleTime.Text, out temp))
            {
                MessageBox.Show("숫자만 입력 하실 수 있습니다.");
                return;
            }

            cSetting.SetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME, tbCycleTime.Text);
            cSetting.SetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START, rbAutoRun_True.Checked ? "true" : "false");
            cSetting.SetValue(cConstraint.SETTINGS_LAST_UPDATED_DATE, DateTime.Now.ToString(cConstraint.FORMAT_LAST_UPDATED_DATE));

            this.Close();

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("정말 초기화 하시겠습니까? 설정한 값은 모두 초기값으로 변경됩니다.", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            cSetting.SetDefaultValue();
            LoadSetting();

            MessageBox.Show("초기화 되었습니다.");
        }

        private void LoadSetting()
        {
            if (!cSetting.IsSettingExists())
                cSetting.SetDefaultValue();

            tbCycleTime.Text = cSetting.GetValue(cConstraint.SETTINGS_DOWORK_CYCLE_TIME);
            rbAutoRun_False.Checked = cSetting.GetValue(cConstraint.SETTINGS_RUN_ON_PROGRAM_START).ToUpper().Equals("FALSE") ? true : false;
            rbAutoRun_True.Checked = !rbAutoRun_False.Checked;
        }

        private void frm_CM_Settings_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }
    }
}
