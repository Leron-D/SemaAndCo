﻿using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Threading;
using System.IO;
using System.Reflection;
using SemaAndCo.Model;

namespace SemaAndCo.View
{
    public partial class AccessRecoveryForm : TemplateForm
    {
        Core context = new Core(Core.StrConnection());
        List<FtpUser.semaandcouser> users;
        public AccessRecoveryForm()
        {
            InitializeComponent();
            if (Core.goAdministration)
            {
                tabControl.SelectedTab = enterCodePage;
                this.Text = "Доступ к администрированию";
                passwordHeaderLabel.Text = "Пароль администратора";
                passwordHeaderLabel.Location = new Point(80, 15);
                saveNewPasswordTextBox.Text = "Проверить";
            }
            else
            {
                this.Text = "Восстановление доступа";
                passwordHeaderLabel.Text = "Новый пароль";
                passwordHeaderLabel.Location = new Point(137, 15);
                saveNewPasswordTextBox.Text = "Сохранить";
                if (!Core.CheckMailVariability())
                {
                    Text = "Проверка почты";
                    descriptionLabel.Text = "Код подтверждения";
                }
            }

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            EnterButtonMethod();
        }

        private void EnterButtonMethod()
        {
            try
            {
                if (Convert.ToInt32(recoveryCodeTextBox.Text) == Properties.Settings.Default.code)
                {
                    if (Core.CheckMailVariability())
                    {
                        tabControl.SelectedTab = enterCodePage;
                    }
                    else
                    {
                        RegistrationData.Registrate();
                        MessageBox.Show("Вы успешно зарегистрированы", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void recoveryCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(recoveryCodeTextBox.Text) == Properties.Settings.Default.code)
                    {
                        if (Core.CheckMailVariability())
                        {
                            tabControl.SelectedTab = enterCodePage;
                        }
                        else
                        {
                            RegistrationData.Registrate();
                            MessageBox.Show("Вы успешно зарегистрированы", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    else
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private async void SaveNewPasswordTextBox_Click(object sender, EventArgs e)
        {
            SaveNewPassword();
        }

        private void SaveNewPassword()
        {
            try
            {
                if (!Core.goAdministration)
                {
                    var user = context.semaandcouser.FirstOrDefault(u => u.userid == Properties.Settings.Default.login || u.email == Properties.Settings.Default.login);
                    user.passwd = passwordTextBox.Text.EncryptString();
                    context.SaveChanges();
                    MessageBox.Show("Пароль успешно изменен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    if (passwordTextBox.Text == Properties.Settings.Default.adminPassword)
                    {
                        AdministrationForm form = new AdministrationForm();
                        form.FormClosed += Form_FormClosed;
                        introPictureBox.Dock = DockStyle.Fill;
                        introPictureBox.Enabled = true;
                        introPictureBox.Visible = true;
                        if (!UsersLoad())
                        {
                            MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Core.access = true;
                            MessageBox.Show("Вы зашли как администратор", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Hide();
                            form.ShowDialog();
                        }
                        introPictureBox.Dock = DockStyle.None;
                        introPictureBox.Visible = false;
                        introPictureBox.Enabled = false;
                    }
                    else
                    {
                        Core.access = false;
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        public bool UsersLoad()
        {
            try
            {
                users = context.semaandcouser.AsNoTracking().ToList();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void AccessRecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            Core.goAdministration = false;
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            Close();
        }

        private void viewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viewCheckBox.Checked)
                passwordTextBox.UseSystemPasswordChar = false;
            else
                passwordTextBox.UseSystemPasswordChar = true;
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                regErrorProvider.SetError(passwordTextBox, "Не введен пароль!");
            }
            else if (passwordTextBox.Text.Length < 5 || passwordTextBox.Text.Length > 30)
            {
                regErrorProvider.SetError(passwordTextBox, "Пароль должен быть длиной от 5 до 30 символов");
            }
            else
            {
                regErrorProvider.Clear();
            }
        }
    }
}
