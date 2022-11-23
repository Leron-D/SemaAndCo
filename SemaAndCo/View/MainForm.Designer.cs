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
            this.localListView = new System.Windows.Forms.ListView();
            this.downloadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.administrationButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.renameTextBox = new System.Windows.Forms.TextBox();
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
            // localListView
            // 
            this.localListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localListView.BackColor = System.Drawing.SystemColors.Window;
            this.localListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.localListView.HideSelection = false;
            this.localListView.Location = new System.Drawing.Point(-2, 73);
            this.localListView.Name = "localListView";
            this.localListView.Size = new System.Drawing.Size(1087, 534);
            this.localListView.TabIndex = 3;
            this.localListView.UseCompatibleStateImageBehavior = false;
            this.localListView.View = System.Windows.Forms.View.List;
            this.localListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
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
            this.downloadButton.TabIndex = 4;
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
            this.deleteButton.TabIndex = 5;
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
            this.renameButton.TabIndex = 6;
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
            this.infoButton.TabIndex = 9;
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
            // 
            // administrationButton
            // 
            this.administrationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.administrationButton.BackColor = System.Drawing.Color.Transparent;
            this.administrationButton.FlatAppearance.BorderSize = 0;
            this.administrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.administrationButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.administrationButton.Image = global::SemaAndCo.Properties.Resources.icons8_administration_40;
            this.administrationButton.Location = new System.Drawing.Point(974, 14);
            this.administrationButton.Margin = new System.Windows.Forms.Padding(5);
            this.administrationButton.Name = "administrationButton";
            this.administrationButton.Size = new System.Drawing.Size(41, 45);
            this.administrationButton.TabIndex = 12;
            this.administrationButton.UseVisualStyleBackColor = false;
            this.administrationButton.Click += new System.EventHandler(this.AdministrationButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Image = global::SemaAndCo.Properties.Resources.icons8_logout_40ы;
            this.exitButton.Location = new System.Drawing.Point(1025, 14);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 45);
            this.exitButton.TabIndex = 11;
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
            // renameTextBox
            // 
            this.renameTextBox.Location = new System.Drawing.Point(42, 371);
            this.renameTextBox.MaxLength = 64;
            this.renameTextBox.Name = "renameTextBox";
            this.renameTextBox.Size = new System.Drawing.Size(100, 31);
            this.renameTextBox.TabIndex = 13;
            this.renameTextBox.Visible = false;
            this.renameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenameTextBox_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 605);
            this.Controls.Add(this.renameTextBox);
            this.Controls.Add(this.administrationButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.localListView);
            this.Controls.Add(this.uploadButton);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MinimumSize = new System.Drawing.Size(770, 260);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ListView localListView;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button administrationButton;
        private System.Windows.Forms.TextBox renameTextBox;
    }
}