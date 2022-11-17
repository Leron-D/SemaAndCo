namespace SemaAndCo
{
    partial class AuthorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.toRegistrationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autoButton = new System.Windows.Forms.Button();
            this.savingPathButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rememberCheckBox.Location = new System.Drawing.Point(10, 291);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(143, 23);
            this.rememberCheckBox.TabIndex = 18;
            this.rememberCheckBox.Text = "Запомнить меня";
            this.rememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotPasswordLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forgotPasswordLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.forgotPasswordLabel.Location = new System.Drawing.Point(223, 291);
            this.forgotPasswordLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(142, 23);
            this.forgotPasswordLabel.TabIndex = 13;
            this.forgotPasswordLabel.Text = "Забыли пароль?";
            this.forgotPasswordLabel.Click += new System.EventHandler(this.ForgotPasswordLabel_Click);
            // 
            // toRegistrationButton
            // 
            this.toRegistrationButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toRegistrationButton.FlatAppearance.BorderSize = 0;
            this.toRegistrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toRegistrationButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toRegistrationButton.Location = new System.Drawing.Point(86, 458);
            this.toRegistrationButton.Name = "toRegistrationButton";
            this.toRegistrationButton.Size = new System.Drawing.Size(200, 39);
            this.toRegistrationButton.TabIndex = 16;
            this.toRegistrationButton.Text = "Зарегистрироваться";
            this.toRegistrationButton.UseVisualStyleBackColor = false;
            this.toRegistrationButton.Click += new System.EventHandler(this.ToRegistrationButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(72, 432);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ещё не зарегистрированы?";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Yellow;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.Location = new System.Drawing.Point(86, 369);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 47);
            this.loginButton.TabIndex = 15;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.Location = new System.Drawing.Point(10, 238);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(355, 47);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextBox.Location = new System.Drawing.Point(10, 140);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(355, 47);
            this.loginTextBox.TabIndex = 10;
            this.loginTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 39);
            this.label3.TabIndex = 14;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 39);
            this.label2.TabIndex = 12;
            this.label2.Text = "Логин";
            // 
            // autoButton
            // 
            this.autoButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.autoButton.FlatAppearance.BorderSize = 0;
            this.autoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.autoButton.Location = new System.Drawing.Point(10, 317);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(149, 26);
            this.autoButton.TabIndex = 21;
            this.autoButton.Text = "Работать автономно";
            this.autoButton.UseVisualStyleBackColor = false;
            // 
            // savingPathButton
            // 
            this.savingPathButton.BackColor = System.Drawing.Color.Transparent;
            this.savingPathButton.FlatAppearance.BorderSize = 0;
            this.savingPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savingPathButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.savingPathButton.Image = global::SemaAndCo.Properties.Resources.icons8_папка_архив_321;
            this.savingPathButton.Location = new System.Drawing.Point(10, 3);
            this.savingPathButton.Name = "savingPathButton";
            this.savingPathButton.Size = new System.Drawing.Size(31, 27);
            this.savingPathButton.TabIndex = 22;
            this.savingPathButton.UseVisualStyleBackColor = false;
            this.savingPathButton.Click += new System.EventHandler(this.SavingPathButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = global::SemaAndCo.Properties.Resources.Bezymyanny_1_Vosstanovlen;
            this.pictureBox.Location = new System.Drawing.Point(129, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(117, 101);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 20;
            this.pictureBox.TabStop = false;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(387, 522);
            this.Controls.Add(this.savingPathButton);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.rememberCheckBox);
            this.Controls.Add(this.forgotPasswordLabel);
            this.Controls.Add(this.toRegistrationButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox rememberCheckBox;
        private System.Windows.Forms.Label forgotPasswordLabel;
        private System.Windows.Forms.Button toRegistrationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.Button savingPathButton;
    }
}