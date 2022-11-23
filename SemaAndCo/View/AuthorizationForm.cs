using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemaAndCo.Model;
using SemaAndCo.Presenter;
using SemaAndCo.Supporting;
using SemaAndCo.View;

namespace SemaAndCo
{
    public partial class AuthorizationForm : Form, ILoginView
    {
        LoginPresenter presenter;

        public AuthorizationForm()
        {
            IntroForm introForm = new IntroForm(533);
            introForm.ShowDialog();
            InitializeComponent();
            presenter = new LoginPresenter(this);
            if (Properties.Settings.Default.authLogin != "" && Properties.Settings.Default.password != "")
            {
                loginTextBox.Text = Properties.Settings.Default.authLogin;
                passwordTextBox.Text = Properties.Settings.Default.password;
                rememberCheckBox.Checked = true;
            }
        }

        public string Login
        {
            set
            {
                loginTextBox.Text = value;
            }
            get
            {
                return loginTextBox.Text;
            }
        }
        public string Password
        {
            set
            {
                passwordTextBox.Text = value;
            }
            get
            {
                return passwordTextBox.Text;
            }
        }
        public bool SaveOptions
        {
            set
            {
                rememberCheckBox.Checked = value;
            }
            get
            {
                return rememberCheckBox.Checked;
            }
        }

        private void ToRegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Close();
        }

        private void ForgotPasswordLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecoveryForm recoveryForm = new RecoveryForm();
            recoveryForm.ShowDialog();
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            presenter.LoginMethod();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                presenter.LoginMethod();
            }

        }

        private void SavingPathButton_Click(object sender, EventArgs e)
        {
            Hide();
            SelectFolderForm form = new SelectFolderForm();
            form.ShowDialog();
            Close();
        }
    }
}
