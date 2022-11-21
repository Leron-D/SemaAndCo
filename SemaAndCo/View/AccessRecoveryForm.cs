using SemaAndCo.Supporting;
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

namespace SemaAndCo.View
{
    public partial class AccessRecoveryForm : TemplateForm
    {
        public AccessRecoveryForm()
        {
            IntroForm form = new IntroForm();
            form.ShowDialog();
            InitializeComponent();
            if (Core.CheckMailVariability())
            {
                Text = "Проверка почты";
                descriptionLabel.Text = "Код подтверждения";
            }
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(recoveryCodeTextBox.Text) == Properties.Settings.Default.code)
                {
                    if (!Core.CheckMailVariability())
                    {
                        tabControl.SelectedTab = enterCodePage;
                    }
                    else
                    {
                        RegistrationData.Registrate();
                        //DotNetZipHelper.CreateZip($@"{Properties.Settings.Default.savingPath}\SemaAndCo.zip", RegistrationData.password);
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
                        tabControl.SelectedTab = enterCodePage;
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

        private void saveNewPasswordTextBox_Click(object sender, EventArgs e)
        {
            SaveNewPassword();
        }

        private void SaveNewPassword()
        {
            try
            {
                var user = Core.Context.Users.FirstOrDefault(u => u.Login == Properties.Settings.Default.login || u.Email == Properties.Settings.Default.login);
                user.Password = passwordTextBox.Text;
                Core.Context.SaveChanges();
                if (File.Exists($@"{Properties.Settings.Default.savingPath}\{user.Login}.zip"))
                {
                    DotNetZipHelper.RefreshPassword($@"{Properties.Settings.Default.savingPath}\{user.Login}.zip", passwordTextBox.Text);
                    user.Password = passwordTextBox.Text;
                    Core.Context.SaveChanges();
                }
                else
                {
                    user.Password = passwordTextBox.Text;
                    Core.Context.SaveChanges();
                }
                MessageBox.Show("Пароль успешно изменен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccessRecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
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
