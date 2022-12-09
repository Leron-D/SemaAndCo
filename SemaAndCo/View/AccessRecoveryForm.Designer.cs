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
            this.enterCodePage = new System.Windows.Forms.TabPage();
            this.introPictureBox = new System.Windows.Forms.PictureBox();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.saveNewPasswordTextBox = new System.Windows.Forms.Button();
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
            this.enterButton.Location = new System.Drawing.Point(92, 152);
            this.enterButton.Margin = new System.Windows.Forms.Padding(5);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(292, 71);
            this.enterButton.TabIndex = 76;
            this.enterButton.Text = "Проверить";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // recoveryCodeTextBox
            // 
            this.recoveryCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recoveryCodeTextBox.Location = new System.Drawing.Point(42, 107);
            this.recoveryCodeTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.recoveryCodeTextBox.MaxLength = 30;
            this.recoveryCodeTextBox.Name = "recoveryCodeTextBox";
            this.recoveryCodeTextBox.Size = new System.Drawing.Size(402, 35);
            this.recoveryCodeTextBox.TabIndex = 73;
            this.recoveryCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.recoveryCodeTextBox_KeyDown);
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
            // enterCodePage
            // 
            this.enterCodePage.BackColor = System.Drawing.Color.SeaShell;
            this.enterCodePage.Controls.Add(this.introPictureBox);
            this.enterCodePage.Controls.Add(this.viewCheckBox);
            this.enterCodePage.Controls.Add(this.passwordTextBox);
            this.enterCodePage.Controls.Add(this.saveNewPasswordTextBox);
            this.enterCodePage.Controls.Add(this.passwordHeaderLabel);
            this.enterCodePage.Location = new System.Drawing.Point(4, 32);
            this.enterCodePage.Margin = new System.Windows.Forms.Padding(5);
            this.enterCodePage.Name = "enterCodePage";
            this.enterCodePage.Padding = new System.Windows.Forms.Padding(5);
            this.enterCodePage.Size = new System.Drawing.Size(491, 238);
            this.enterCodePage.TabIndex = 1;
            this.enterCodePage.Text = "Ввод кода";
            // 
            // introPictureBox
            // 
            this.introPictureBox.Enabled = false;
            this.introPictureBox.Image = global::SemaAndCo.Properties.Resources.video__1_;
            this.introPictureBox.Location = new System.Drawing.Point(427, 4);
            this.introPictureBox.Name = "introPictureBox";
            this.introPictureBox.Size = new System.Drawing.Size(61, 50);
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
            this.viewCheckBox.TabIndex = 81;
            this.viewCheckBox.Text = "Показать пароль";
            this.viewCheckBox.UseVisualStyleBackColor = true;
            this.viewCheckBox.CheckedChanged += new System.EventHandler(this.viewCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.Location = new System.Drawing.Point(41, 70);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTextBox.MaxLength = 30;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(404, 35);
            this.passwordTextBox.TabIndex = 77;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // saveNewPasswordTextBox
            // 
            this.saveNewPasswordTextBox.BackColor = System.Drawing.Color.Yellow;
            this.saveNewPasswordTextBox.FlatAppearance.BorderSize = 0;
            this.saveNewPasswordTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewPasswordTextBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveNewPasswordTextBox.Location = new System.Drawing.Point(98, 149);
            this.saveNewPasswordTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.saveNewPasswordTextBox.Name = "saveNewPasswordTextBox";
            this.saveNewPasswordTextBox.Size = new System.Drawing.Size(292, 71);
            this.saveNewPasswordTextBox.TabIndex = 80;
            this.saveNewPasswordTextBox.Text = "Сохранить";
            this.saveNewPasswordTextBox.UseVisualStyleBackColor = false;
            this.saveNewPasswordTextBox.Click += new System.EventHandler(this.SaveNewPasswordTextBox_Click);
            // 
            // passwordHeaderLabel
            // 
            this.passwordHeaderLabel.AutoSize = true;
            this.passwordHeaderLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordHeaderLabel.Location = new System.Drawing.Point(137, 15);
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
        private System.Windows.Forms.Button saveNewPasswordTextBox;
        private System.Windows.Forms.Label passwordHeaderLabel;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.ErrorProvider regErrorProvider;
        private System.Windows.Forms.PictureBox introPictureBox;
    }
}