using System.Windows.Forms;

namespace TimeScheduler
{
    public class cMessageBox
    {
        public static DialogResult Show(string pContext,
                                        string pTitle,
                                        MessageBoxButtons pMsgBoxBtn,
                                        MessageBoxIcon pMsgBoxIcon,
                                        MessageBoxDefaultButton pMsgBoxDefBtn,
                                        MessageBoxOptions pMsgBoxOpt)
        {
            return MessageBox.Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon, pMsgBoxDefBtn, pMsgBoxOpt);
        }

        public static DialogResult Show(string pContext,
                                string pTitle,
                                MessageBoxButtons pMsgBoxBtn,
                                MessageBoxIcon pMsgBoxIcon)
        {
            return MessageBox.Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon);
        }

        public static DialogResult Inform(string pContext,
                                          string pTitle = "알림",
                                          MessageBoxButtons pMsgBoxBtn = MessageBoxButtons.OK,
                                          MessageBoxIcon pMsgBoxIcon = MessageBoxIcon.Asterisk)
        {
            return Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon);
        }

        public static DialogResult Warn(string pContext,
                                        string pTitle = "경고",
                                        MessageBoxButtons pMsgBoxBtn = MessageBoxButtons.OK,
                                        MessageBoxIcon pMsgBoxIcon = MessageBoxIcon.Warning)
        {
            return Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon);
        }

        public static DialogResult Error(string pContext,
                                         string pTitle = "오류",
                                         MessageBoxButtons pMsgBoxBtn = MessageBoxButtons.OK,
                                         MessageBoxIcon pMsgBoxIcon = MessageBoxIcon.Error)
        {
            return Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon);
        }

        public static DialogResult Question(string pContext,
                                            string pTitle = "알림",
                                            MessageBoxButtons pMsgBoxBtn = MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon pMsgBoxIcon = MessageBoxIcon.Question)
        {
            return Show(pContext, pTitle, pMsgBoxBtn, pMsgBoxIcon);
        }
    }
}
