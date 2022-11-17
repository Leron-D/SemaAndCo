﻿using System;
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

namespace SemaAndCo.View
{
    public partial class RecoveryForm : Form, IRecoveryView
    {
        RecoveryPresenter presenter;
        SendMail sendMail;
        public RecoveryForm()
        {
            IntroForm form = new IntroForm();
            form.ShowDialog();
            InitializeComponent();
            presenter = new RecoveryPresenter(this);
            sendMail = new SendMail();
            captcha.Renew();
        }

        public void Splash()
        {
            Application.Run(new IntroForm());
        }

        private void loginOrEmailTextBox_Validating(object sender, CancelEventArgs e)
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

        private void enterButton_Click(object sender, EventArgs e)
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
            if (captcha.CheckText(captchaTextBox.Text))
            {
                if(sendMail.SendOnMail(loginOrEmailTextBox.Text))
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
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void RecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog();
            Close();
        }

        private void renewButton_Click(object sender, EventArgs e)
        {
            captcha.Renew();
        }

        private void captchaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
