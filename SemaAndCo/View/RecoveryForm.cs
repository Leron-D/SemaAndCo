using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using SemaAndCo.Presenter;
using System.Data.Entity.Core.Metadata.Edm;
using SemaAndCo.Supporting;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Configuration.Install;
using System.Diagnostics;
using System.Drawing.Text;

namespace SemaAndCo.View
{
    public partial class RecoveryForm : Form, IRecoveryView
    {
        RecoveryPresenter presenter;
        SendMail sendMail;
        ReferenceForm referenceForm = new ReferenceForm();
        public RecoveryForm()
        {
            IntroForm form = new IntroForm(533);
            form.ShowDialog();
            InitializeComponent();
            presenter = new RecoveryPresenter(this);
            sendMail = new SendMail();
            captcha.Renew();
        }

        private void LoginOrEmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(loginOrEmailTextBox.Text))
            {
                recErrorProvider.SetError(loginOrEmailTextBox, "Введите логин или email!");
            }
            else
            {
                recErrorProvider.Clear();
            }
                
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnteringMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnteringMethod()
        {
            try
            {
                if (captcha.CheckText(captchaTextBox.Text))
                {
                    if (sendMail.SendMessageWithConfirmOnMail(loginOrEmailTextBox.Text, true))
                    {
                        presenter.GetLoginOrEmail(loginOrEmailTextBox.Text);
                        Hide();
                        AccessRecoveryForm form = new AccessRecoveryForm();
                        form.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Код из капчи не соответствует введенному", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    captcha.Renew();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EnteringMethod();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            referenceForm.Close();
            Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog();
            Close();
        }

        private void RenewButton_Click(object sender, EventArgs e)
        {
            captcha.Renew();
        }

        private void CaptchaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            referenceButton.Enabled = enterButton.Enabled = false;
            referenceForm.FormClosed += ReferenceForm_Closed;
            referenceForm.Show();
        }
        private void ReferenceForm_Closed(object sender, FormClosedEventArgs e)
        {
            referenceButton.Enabled = enterButton.Enabled = true;
        }
    }
}
