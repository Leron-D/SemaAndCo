namespace SemaAndCo.View
{
    partial class RecoveryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryForm));
            this.loginOrEmailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.recErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.captchaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.renewButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.captcha = new SemaAndCo.Captcha();
            ((System.ComponentModel.ISupportInitialize)(this.recErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // loginOrEmailTextBox
            // 
            this.loginOrEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginOrEmailTextBox.Location = new System.Drawing.Point(50, 111);
            this.loginOrEmailTextBox.MaxLength = 30;
            this.loginOrEmailTextBox.Name = "loginOrEmailTextBox";
            this.loginOrEmailTextBox.Size = new System.Drawing.Size(355, 35);
            this.loginOrEmailTextBox.TabIndex = 69;
            this.loginOrEmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.loginOrEmailTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.loginOrEmailTextBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 29);
            this.label2.TabIndex = 71;
            this.label2.Text = "Логин/E-mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(47, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(358, 39);
            this.label7.TabIndex = 70;
            this.label7.Text = "Заполните информацию";
            // 
            // recErrorProvider
            // 
            this.recErrorProvider.ContainerControl = this;
            // 
            // captchaTextBox
            // 
            this.captchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captchaTextBox.Location = new System.Drawing.Point(50, 398);
            this.captchaTextBox.MaxLength = 30;
            this.captchaTextBox.Name = "captchaTextBox";
            this.captchaTextBox.Size = new System.Drawing.Size(355, 35);
            this.captchaTextBox.TabIndex = 74;
            this.captchaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.captchaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.captchaTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 357);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 75;
            this.label1.Text = "Код из капчи";
            // 
            // renewButton
            // 
            this.renewButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.renewButton.FlatAppearance.BorderSize = 0;
            this.renewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.renewButton.Location = new System.Drawing.Point(280, 341);
            this.renewButton.Name = "renewButton";
            this.renewButton.Size = new System.Drawing.Size(125, 26);
            this.renewButton.TabIndex = 81;
            this.renewButton.Text = "Обновить капчу";
            this.renewButton.UseVisualStyleBackColor = false;
            this.renewButton.Click += new System.EventHandler(this.renewButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.Yellow;
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterButton.Location = new System.Drawing.Point(79, 455);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(297, 50);
            this.enterButton.TabIndex = 83;
            this.enterButton.Text = "Отправить";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // captcha
            // 
            this.captcha.Location = new System.Drawing.Point(50, 172);
            this.captcha.Name = "captcha";
            this.captcha.Size = new System.Drawing.Size(355, 163);
            this.captcha.TabIndex = 73;
            // 
            // RecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(449, 528);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.renewButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.captchaTextBox);
            this.Controls.Add(this.captcha);
            this.Controls.Add(this.loginOrEmailTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восстановление доступа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecoveryForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.recErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginOrEmailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider recErrorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox captchaTextBox;
        private Captcha captcha;
        private System.Windows.Forms.Button renewButton;
        private System.Windows.Forms.Button enterButton;
    }
}