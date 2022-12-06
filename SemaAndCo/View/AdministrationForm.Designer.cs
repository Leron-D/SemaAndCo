namespace SemaAndCo.View
{
    partial class AdministrationForm
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.loginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.currentPageNumeric = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.rightPageButton = new System.Windows.Forms.Button();
            this.leftPageButton = new System.Windows.Forms.Button();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.resultsAmountLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(369, 31);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersGridView.BackgroundColor = System.Drawing.Color.White;
            this.usersGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginColumn,
            this.emailColumn,
            this.nameColumn,
            this.passwordColumn,
            this.phoneColumn});
            this.usersGridView.Location = new System.Drawing.Point(12, 55);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.RowHeadersVisible = false;
            this.usersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGridView.Size = new System.Drawing.Size(1033, 347);
            this.usersGridView.TabIndex = 3;
            this.usersGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UsersGridView_CellMouseClick);
            // 
            // loginColumn
            // 
            this.loginColumn.DataPropertyName = "userid";
            this.loginColumn.HeaderText = "Логин";
            this.loginColumn.Name = "loginColumn";
            this.loginColumn.ReadOnly = true;
            // 
            // emailColumn
            // 
            this.emailColumn.DataPropertyName = "email";
            this.emailColumn.HeaderText = "E-mail";
            this.emailColumn.Name = "emailColumn";
            this.emailColumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "username";
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // passwordColumn
            // 
            this.passwordColumn.DataPropertyName = "passwd";
            this.passwordColumn.HeaderText = "Пароль";
            this.passwordColumn.Name = "passwordColumn";
            this.passwordColumn.ReadOnly = true;
            // 
            // phoneColumn
            // 
            this.phoneColumn.DataPropertyName = "phone";
            this.phoneColumn.HeaderText = "Телефон";
            this.phoneColumn.Name = "phoneColumn";
            this.phoneColumn.ReadOnly = true;
            // 
            // changeButton
            // 
            this.changeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.changeButton.FlatAppearance.BorderSize = 0;
            this.changeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.changeButton.Location = new System.Drawing.Point(609, 11);
            this.changeButton.Margin = new System.Windows.Forms.Padding(5);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(106, 31);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = false;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Yellow;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(389, 12);
            this.searchButton.Margin = new System.Windows.Forms.Padding(5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(94, 31);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // currentPageNumeric
            // 
            this.currentPageNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentPageNumeric.Font = new System.Drawing.Font("Calibri", 12F);
            this.currentPageNumeric.Location = new System.Drawing.Point(169, 410);
            this.currentPageNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentPageNumeric.Name = "currentPageNumeric";
            this.currentPageNumeric.Size = new System.Drawing.Size(56, 27);
            this.currentPageNumeric.TabIndex = 33;
            this.currentPageNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentPageNumeric.ValueChanged += new System.EventHandler(this.CurrentPageNumeric_ValueChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(88, 412);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "Страница";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 412);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 23);
            this.label13.TabIndex = 34;
            this.label13.Text = "из";
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Location = new System.Drawing.Point(254, 412);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(91, 23);
            this.totalPagesLabel.TabIndex = 37;
            this.totalPagesLabel.Text = "TotalPages";
            // 
            // lastPageButton
            // 
            this.lastPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastPageButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.lastPageButton.Location = new System.Drawing.Point(388, 410);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(32, 27);
            this.lastPageButton.TabIndex = 36;
            this.lastPageButton.Text = ">|";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.LastPageButton_Click);
            // 
            // rightPageButton
            // 
            this.rightPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rightPageButton.Location = new System.Drawing.Point(351, 410);
            this.rightPageButton.Name = "rightPageButton";
            this.rightPageButton.Size = new System.Drawing.Size(31, 27);
            this.rightPageButton.TabIndex = 35;
            this.rightPageButton.Text = ">";
            this.rightPageButton.UseVisualStyleBackColor = true;
            this.rightPageButton.Click += new System.EventHandler(this.RightPageButton_Click);
            // 
            // leftPageButton
            // 
            this.leftPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPageButton.Enabled = false;
            this.leftPageButton.Location = new System.Drawing.Point(55, 408);
            this.leftPageButton.Name = "leftPageButton";
            this.leftPageButton.Size = new System.Drawing.Size(31, 27);
            this.leftPageButton.TabIndex = 31;
            this.leftPageButton.Text = "<";
            this.leftPageButton.UseVisualStyleBackColor = true;
            this.leftPageButton.Click += new System.EventHandler(this.LeftPageButton_Click);
            // 
            // firstPageButton
            // 
            this.firstPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPageButton.Enabled = false;
            this.firstPageButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstPageButton.Location = new System.Drawing.Point(17, 408);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(32, 27);
            this.firstPageButton.TabIndex = 30;
            this.firstPageButton.Text = "|<";
            this.firstPageButton.UseVisualStyleBackColor = true;
            this.firstPageButton.Click += new System.EventHandler(this.FirstPageButton_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(426, 412);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 39;
            this.label15.Text = "Записей:";
            // 
            // resultsAmountLabel
            // 
            this.resultsAmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsAmountLabel.AutoSize = true;
            this.resultsAmountLabel.Location = new System.Drawing.Point(503, 410);
            this.resultsAmountLabel.Name = "resultsAmountLabel";
            this.resultsAmountLabel.Size = new System.Drawing.Size(20, 23);
            this.resultsAmountLabel.TabIndex = 38;
            this.resultsAmountLabel.Text = "0";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.deleteButton.Location = new System.Drawing.Point(725, 11);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(106, 31);
            this.deleteButton.TabIndex = 40;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.addButton.Location = new System.Drawing.Point(493, 11);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(106, 31);
            this.addButton.TabIndex = 41;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 444);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.resultsAmountLabel);
            this.Controls.Add(this.currentPageNumeric);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.rightPageButton);
            this.Controls.Add(this.leftPageButton);
            this.Controls.Add(this.firstPageButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.usersGridView);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MinimumSize = new System.Drawing.Size(770, 260);
            this.Name = "AdministrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование";
            this.SizeChanged += new System.EventHandler(this.AdministrationForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPageNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.NumericUpDown currentPageNumeric;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Button rightPageButton;
        private System.Windows.Forms.Button leftPageButton;
        private System.Windows.Forms.Button firstPageButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label resultsAmountLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneColumn;
    }
}