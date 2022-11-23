﻿using SemaAndCo.Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SemaAndCo.View
{
    public partial class SelectFolderForm : TemplateForm
    {
        string path;
        public SelectFolderForm()
        {
            IntroForm form = new IntroForm(533);
            form.ShowDialog();
            InitializeComponent();
            folderTextBox.Text = Properties.Settings.Default.savingPath;
            path = Properties.Settings.Default.savingPath;
        }

        private void SelectFolderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            Close();
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
                if (Directory.Exists(folderTextBox.Text))
                {
                    Properties.Settings.Default.savingPath = folderTextBox.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Путь успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    AuthorizationForm form = new AuthorizationForm();
                    form.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Данной папки несуществует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ChoosePathButton_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }
    }
}