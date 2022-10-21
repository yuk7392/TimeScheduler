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
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {

        }
    }
}
