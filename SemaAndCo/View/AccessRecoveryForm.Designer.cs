namespace SemaAndCo.View
{
    partial class AccessRecoveryForm
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
            this.components = new System.ComponentModel.Container();
            this.enterButton = new System.Windows.Forms.Button();
            this.recoveryCodeTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.enterMailPage = new System.Windows.Forms.TabPage();
            this.referenceButton1 = new System.Windows.Forms.Button();
            this.enterCodePage = new System.Windows.Forms.TabPage();
            this.referenceButton2 = new System.Windows.Forms.Button();
            this.introPictureBox = new System.Windows.Forms.PictureBox();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.saveNewPasswordButton = new System.Windows.Forms.Button();
            this.passwordHeaderLabel = new System.Windows.Forms.Label();
            this.regErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl.SuspendLayout();
            this.enterMailPage.SuspendLayout();
            this.enterCodePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.introPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.Yellow;
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterButton.Location = new System.Drawing.Point(91, 157);
            this.enterButton.Margin = new System.Windows.Forms.Padding(5);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(292, 71);
            this.enterButton.TabIndex = 1;
            this.enterButton.Text = "Проверить";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // recoveryCodeTextBox
            // 
            this.recoveryCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recoveryCodeTextBox.Location = new System.Drawing.Point(42, 107);
            this.recoveryCodeTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.recoveryCodeTextBox.MaxLength = 30;
            this.recoveryCodeTextBox.Name = "recoveryCodeTextBox";
            this.recoveryCodeTextBox.Size = new System.Drawing.Size(402, 35);
            this.recoveryCodeTextBox.TabIndex = 0;
            this.recoveryCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecoveryCodeTextBox_KeyDown);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(37, 73);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(254, 29);
            this.descriptionLabel.TabIndex = 75;
            this.descriptionLabel.Text = "Код восстановления";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(69, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(358, 39);
            this.label7.TabIndex = 74;
            this.label7.Text = "Заполните информацию";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.enterMailPage);
            this.tabControl.Controls.Add(this.enterCodePage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(499, 274);
            this.tabControl.TabIndex = 77;
            // 
            // enterMailPage
            // 
            this.enterMailPage.BackColor = System.Drawing.Color.SeaShell;
            this.enterMailPage.Controls.Add(this.referenceButton1);
            this.enterMailPage.Controls.Add(this.recoveryCodeTextBox);
            this.enterMailPage.Controls.Add(this.enterButton);
            this.enterMailPage.Controls.Add(this.label7);
            this.enterMailPage.Controls.Add(this.descriptionLabel);
            this.enterMailPage.Location = new System.Drawing.Point(4, 32);
            this.enterMailPage.Margin = new System.Windows.Forms.Padding(5);
            this.enterMailPage.Name = "enterMailPage";
            this.enterMailPage.Padding = new System.Windows.Forms.Padding(5);
            this.enterMailPage.Size = new System.Drawing.Size(491, 238);
            this.enterMailPage.TabIndex = 0;
            this.enterMailPage.Text = "Отправка кода";
            // 
            // referenceButton1
            // 
            this.referenceButton1.BackColor = System.Drawing.Color.Transparent;
            this.referenceButton1.FlatAppearance.BorderSize = 0;
            this.referenceButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.referenceButton1.Image = global::SemaAndCo.Properties.Resources.reference;
            this.referenceButton1.Location = new System.Drawing.Point(465, 0);
            this.referenceButton1.Margin = new System.Windows.Forms.Padding(5);
            this.referenceButton1.Name = "referenceButton1";
            this.referenceButton1.Size = new System.Drawing.Size(26, 33);
            this.referenceButton1.TabIndex = 76;
            this.referenceButton1.UseVisualStyleBackColor = false;
            this.referenceButton1.Click += new System.EventHandler(this.ReferenceButton1_Click);
            // 
            // enterCodePage
            // 
            this.enterCodePage.BackColor = System.Drawing.Color.SeaShell;
            this.enterCodePage.Controls.Add(this.referenceButton2);
            this.enterCodePage.Controls.Add(this.introPictureBox);
            this.enterCodePage.Controls.Add(this.viewCheckBox);
            this.enterCodePage.Controls.Add(this.passwordTextBox);
            this.enterCodePage.Controls.Add(this.saveNewPasswordButton);
            this.enterCodePage.Controls.Add(this.passwordHeaderLabel);
            this.enterCodePage.Location = new System.Drawing.Point(4, 32);
            this.enterCodePage.Margin = new System.Windows.Forms.Padding(5);
            this.enterCodePage.Name = "enterCodePage";
            this.enterCodePage.Padding = new System.Windows.Forms.Padding(5);
            this.enterCodePage.Size = new System.Drawing.Size(491, 238);
            this.enterCodePage.TabIndex = 1;
            this.enterCodePage.Text = "Ввод пароля";
            // 
            // referenceButton2
            // 
            this.referenceButton2.BackColor = System.Drawing.Color.Transparent;
            this.referenceButton2.FlatAppearance.BorderSize = 0;
            this.referenceButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.referenceButton2.Image = global::SemaAndCo.Properties.Resources.reference;
            this.referenceButton2.Location = new System.Drawing.Point(460, 0);
            this.referenceButton2.Margin = new System.Windows.Forms.Padding(5);
            this.referenceButton2.Name = "referenceButton2";
            this.referenceButton2.Size = new System.Drawing.Size(26, 33);
            this.referenceButton2.TabIndex = 78;
            this.referenceButton2.UseVisualStyleBackColor = false;
            this.referenceButton2.Click += new System.EventHandler(this.ReferenceButton2_Click);
            // 
            // introPictureBox
            // 
            this.introPictureBox.Enabled = false;
            this.introPictureBox.Image = global::SemaAndCo.Properties.Resources.video__1_;
            this.introPictureBox.Location = new System.Drawing.Point(441, 185);
            this.introPictureBox.Name = "introPictureBox";
            this.introPictureBox.Size = new System.Drawing.Size(47, 50);
            this.introPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.introPictureBox.TabIndex = 82;
            this.introPictureBox.TabStop = false;
            this.introPictureBox.Visible = false;
            // 
            // viewCheckBox
            // 
            this.viewCheckBox.AutoSize = true;
            this.viewCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewCheckBox.Location = new System.Drawing.Point(41, 115);
            this.viewCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.viewCheckBox.Name = "viewCheckBox";
            this.viewCheckBox.Size = new System.Drawing.Size(160, 24);
            this.viewCheckBox.TabIndex = 1;
            this.viewCheckBox.Text = "Показать пароль";
            this.viewCheckBox.UseVisualStyleBackColor = true;
            this.viewCheckBox.CheckedChanged += new System.EventHandler(this.ViewCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.Location = new System.Drawing.Point(41, 70);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTextBox.MaxLength = 30;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(404, 35);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyDown);
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            // 
            // saveNewPasswordButton
            // 
            this.saveNewPasswordButton.BackColor = System.Drawing.Color.Yellow;
            this.saveNewPasswordButton.FlatAppearance.BorderSize = 0;
            this.saveNewPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewPasswordButton.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveNewPasswordButton.Location = new System.Drawing.Point(92, 157);
            this.saveNewPasswordButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveNewPasswordButton.Name = "saveNewPasswordButton";
            this.saveNewPasswordButton.Size = new System.Drawing.Size(292, 71);
            this.saveNewPasswordButton.TabIndex = 2;
            this.saveNewPasswordButton.Text = "Сохранить";
            this.saveNewPasswordButton.UseVisualStyleBackColor = false;
            this.saveNewPasswordButton.Click += new System.EventHandler(this.SaveNewPasswordTextBox_Click);
            // 
            // passwordHeaderLabel
            // 
            this.passwordHeaderLabel.AutoSize = true;
            this.passwordHeaderLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordHeaderLabel.Location = new System.Drawing.Point(131, 15);
            this.passwordHeaderLabel.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.passwordHeaderLabel.Name = "passwordHeaderLabel";
            this.passwordHeaderLabel.Size = new System.Drawing.Size(217, 39);
            this.passwordHeaderLabel.TabIndex = 78;
            this.passwordHeaderLabel.Text = "Новый пароль";
            // 
            // regErrorProvider
            // 
            this.regErrorProvider.ContainerControl = this;
            // 
            // AccessRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(499, 274);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 313);
            this.MinimumSize = new System.Drawing.Size(515, 313);
            this.Name = "AccessRecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восстановление доступа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccessRecoveryForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.enterMailPage.ResumeLayout(false);
            this.enterMailPage.PerformLayout();
            this.enterCodePage.ResumeLayout(false);
            this.enterCodePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.introPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox recoveryCodeTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage enterMailPage;
        private System.Windows.Forms.TabPage enterCodePage;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button saveNewPasswordButton;
        private System.Windows.Forms.Label passwordHeaderLabel;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.ErrorProvider regErrorProvider;
        private System.Windows.Forms.PictureBox introPictureBox;
        private System.Windows.Forms.Button referenceButton1;
        private System.Windows.Forms.Button referenceButton2;
    }
}