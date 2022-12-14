namespace SemaAndCo.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uploadButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.downloadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.renameTextBox = new System.Windows.Forms.TextBox();
            this.localRadioButton = new System.Windows.Forms.RadioButton();
            this.serverRadioButton = new System.Windows.Forms.RadioButton();
            this.connectionCheckLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.referenceButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.Yellow;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Location = new System.Drawing.Point(14, 14);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(5);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(117, 45);
            this.uploadButton.TabIndex = 1;
            this.uploadButton.Text = "Загрузить ↑";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.BackColor = System.Drawing.SystemColors.Window;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(-2, 73);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1210, 534);
            this.listView.TabIndex = 9;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.Yellow;
            this.downloadButton.Enabled = false;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Location = new System.Drawing.Point(141, 14);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(5);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(117, 45);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Скачать ↓";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteButton.Enabled = false;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(398, 14);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 45);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.renameButton.Enabled = false;
            this.renameButton.FlatAppearance.BorderSize = 0;
            this.renameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.renameButton.Location = new System.Drawing.Point(268, 14);
            this.renameButton.Margin = new System.Windows.Forms.Padding(5);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(120, 45);
            this.renameButton.TabIndex = 3;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = false;
            this.renameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.infoButton.Enabled = false;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoButton.Location = new System.Drawing.Point(499, 14);
            this.infoButton.Margin = new System.Windows.Forms.Padding(5);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(114, 45);
            this.infoButton.TabIndex = 5;
            this.infoButton.Text = "Информация";
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "word.png");
            this.imageList.Images.SetKeyName(1, "pictures.png");
            this.imageList.Images.SetKeyName(2, "exe.png");
            this.imageList.Images.SetKeyName(3, "text.png");
            this.imageList.Images.SetKeyName(4, "Excel.png");
            this.imageList.Images.SetKeyName(5, "Archive.png");
            this.imageList.Images.SetKeyName(6, "File.png");
            this.imageList.Images.SetKeyName(7, "pdf.png");
            // 
            // renameTextBox
            // 
            this.renameTextBox.Location = new System.Drawing.Point(42, 371);
            this.renameTextBox.MaxLength = 64;
            this.renameTextBox.Name = "renameTextBox";
            this.renameTextBox.Size = new System.Drawing.Size(100, 31);
            this.renameTextBox.TabIndex = 0;
            this.renameTextBox.Visible = false;
            this.renameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenameTextBox_KeyDown);
            // 
            // localRadioButton
            // 
            this.localRadioButton.AutoSize = true;
            this.localRadioButton.Checked = true;
            this.localRadioButton.Location = new System.Drawing.Point(630, 12);
            this.localRadioButton.Name = "localRadioButton";
            this.localRadioButton.Size = new System.Drawing.Size(210, 27);
            this.localRadioButton.TabIndex = 6;
            this.localRadioButton.TabStop = true;
            this.localRadioButton.Text = "Локальное хранилище";
            this.localRadioButton.UseVisualStyleBackColor = true;
            this.localRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // serverRadioButton
            // 
            this.serverRadioButton.AutoSize = true;
            this.serverRadioButton.Location = new System.Drawing.Point(630, 35);
            this.serverRadioButton.Name = "serverRadioButton";
            this.serverRadioButton.Size = new System.Drawing.Size(208, 27);
            this.serverRadioButton.TabIndex = 7;
            this.serverRadioButton.Text = "Серверное хранилище";
            this.serverRadioButton.UseVisualStyleBackColor = true;
            this.serverRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // connectionCheckLabel
            // 
            this.connectionCheckLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionCheckLabel.AutoSize = true;
            this.connectionCheckLabel.BackColor = System.Drawing.Color.White;
            this.connectionCheckLabel.ForeColor = System.Drawing.Color.Lime;
            this.connectionCheckLabel.Location = new System.Drawing.Point(1096, 562);
            this.connectionCheckLabel.Name = "connectionCheckLabel";
            this.connectionCheckLabel.Size = new System.Drawing.Size(99, 23);
            this.connectionCheckLabel.TabIndex = 11;
            this.connectionCheckLabel.Text = "Соединено";
            this.connectionCheckLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // referenceButton
            // 
            this.referenceButton.BackColor = System.Drawing.Color.Transparent;
            this.referenceButton.FlatAppearance.BorderSize = 0;
            this.referenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.referenceButton.Image = global::SemaAndCo.Properties.Resources.reference;
            this.referenceButton.Location = new System.Drawing.Point(1100, 19);
            this.referenceButton.Margin = new System.Windows.Forms.Padding(5);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(26, 33);
            this.referenceButton.TabIndex = 12;
            this.referenceButton.UseVisualStyleBackColor = false;
            this.referenceButton.Click += new System.EventHandler(this.ReferenceButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Image = global::SemaAndCo.Properties.Resources.icons8_logout_40ы1;
            this.exitButton.Location = new System.Drawing.Point(1148, 14);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 45);
            this.exitButton.TabIndex = 8;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = global::SemaAndCo.Properties.Resources.video__1_;
            this.pictureBox.Location = new System.Drawing.Point(339, 87);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(416, 450);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 605);
            this.Controls.Add(this.referenceButton);
            this.Controls.Add(this.connectionCheckLabel);
            this.Controls.Add(this.serverRadioButton);
            this.Controls.Add(this.localRadioButton);
            this.Controls.Add(this.renameTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.uploadButton);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MinimumSize = new System.Drawing.Size(930, 260);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox renameTextBox;
        private System.Windows.Forms.RadioButton localRadioButton;
        private System.Windows.Forms.RadioButton serverRadioButton;
        private System.Windows.Forms.Label connectionCheckLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button referenceButton;
    }
}