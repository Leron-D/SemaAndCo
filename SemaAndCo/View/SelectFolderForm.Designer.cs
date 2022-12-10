﻿namespace SemaAndCo.View
{
    partial class SelectFolderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.choosePathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderTextBox
            // 
            this.folderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.folderTextBox.Location = new System.Drawing.Point(14, 52);
            this.folderTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.folderTextBox.MaxLength = 30;
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(454, 35);
            this.folderTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 29);
            this.label2.TabIndex = 73;
            this.label2.Text = "Путь сохранения";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Yellow;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(128, 97);
            this.saveButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(273, 58);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // choosePathButton
            // 
            this.choosePathButton.BackColor = System.Drawing.Color.Transparent;
            this.choosePathButton.FlatAppearance.BorderSize = 0;
            this.choosePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosePathButton.Image = global::SemaAndCo.Properties.Resources.icons8_папка_архив_481;
            this.choosePathButton.Location = new System.Drawing.Point(472, 49);
            this.choosePathButton.Name = "choosePathButton";
            this.choosePathButton.Size = new System.Drawing.Size(46, 39);
            this.choosePathButton.TabIndex = 2;
            this.choosePathButton.UseVisualStyleBackColor = false;
            this.choosePathButton.Click += new System.EventHandler(this.ChoosePathButton_Click);
            // 
            // SelectFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(525, 171);
            this.Controls.Add(this.choosePathButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "SelectFolderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор пути сохранения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectFolderForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button choosePathButton;
    }
}