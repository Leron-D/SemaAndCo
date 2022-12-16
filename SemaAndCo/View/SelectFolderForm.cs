using SemaAndCo.Model;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SemaAndCo.View
{
    public partial class SelectFolderForm : TemplateForm
    {
        string path;
        ReferenceForm referenceForm = new ReferenceForm();
        public SelectFolderForm()
        {
            IntroForm form = new IntroForm(533);
            form.ShowDialog();
            InitializeComponent();
            folderTextBox.Text = Properties.Settings.Default.savingPath;
            path = Properties.Settings.Default.savingPath;
            System.Windows.Forms.ToolTip tool = new System.Windows.Forms.ToolTip();
            tool.SetToolTip(referenceButton, "О программе");
        }

        private void SelectFolderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            referenceForm.Close();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
        }

        void ChooseFolder()
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderTextBox.Text = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFolder();
        }

        private void SaveFolder()
        {
            try
            {
                string oldPath = Properties.Settings.Default.savingPath;
                if (!String.IsNullOrEmpty(oldPath))
                {
                    if (Directory.Exists(folderTextBox.Text))
                    {
                        Properties.Settings.Default.savingPath = folderTextBox.Text;
                        Properties.Settings.Default.Save();
                        foreach (var file in Directory.GetFiles(oldPath))
                        {
                            if(file.Split('.').Last() == "zip")
                                File.Move(file, $@"{Properties.Settings.Default.savingPath}\{Path.GetFileName(file)}");
                        }
                        OpenAuthorizationFormMethod();
                    }
                    else
                    {
                        MessageBox.Show("Данной папки не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Properties.Settings.Default.savingPath = folderTextBox.Text;
                    Properties.Settings.Default.Save();
                    OpenAuthorizationFormMethod();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAuthorizationFormMethod()
        {
            MessageBox.Show("Путь успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void ChoosePathButton_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            referenceButton.Enabled = saveButton.Enabled = false;
            referenceForm.FormClosed += ReferenceForm_FormClosed;
            referenceForm.ShowDialog();
        }

        private void ReferenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            referenceButton.Enabled = saveButton.Enabled = true;
        }

        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(folderTextBox.Text, folderTextBox.Font);
            folderTextBox.Width = size.Width;
            choosePathButton.Left = folderTextBox.Location.X + folderTextBox.Width + 5;
            Width = folderTextBox.Location.X + folderTextBox.Width + 85;
        }

        private void SelectFolderForm_SizeChanged(object sender, EventArgs e)
        {
            choosePathButton.Left = folderTextBox.Location.X + folderTextBox.Width + 5;
            saveButton.Left = (ClientSize.Width - saveButton.Width) / 2;
        }
    }
}
