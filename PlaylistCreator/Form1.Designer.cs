using System;
using System.ComponentModel;

namespace PlaylistCreator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_bkgExport = new System.Windows.Forms.Button();
            this.btn_flowExport = new System.Windows.Forms.Button();
            this.btn_AlbumPlaylist = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel_albums = new System.Windows.Forms.Panel();
            this.lbl_selectedAlbum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_fillWithAlbums = new System.Windows.Forms.Button();
            this.btn_copyAlbum = new System.Windows.Forms.Button();
            this.devicePath = new System.Windows.Forms.TextBox();
            this.btn_skipAlbum = new System.Windows.Forms.Button();
            this.btn_CancelAnalize = new System.Windows.Forms.Button();
            this.analizer = new System.ComponentModel.BackgroundWorker();
            this.FileCopier = new System.ComponentModel.BackgroundWorker();
            this.deviceFiller = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_albums.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "D:\\Music\\";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(311, 10);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(90, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Analize";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 257);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(389, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ready";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(393, 199);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_bkgExport);
            this.tabPage1.Controls.Add(this.btn_flowExport);
            this.tabPage1.Controls.Add(this.btn_AlbumPlaylist);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(385, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate Playlists";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_bkgExport
            // 
            this.btn_bkgExport.Location = new System.Drawing.Point(6, 64);
            this.btn_bkgExport.Name = "btn_bkgExport";
            this.btn_bkgExport.Size = new System.Drawing.Size(373, 23);
            this.btn_bkgExport.TabIndex = 2;
            this.btn_bkgExport.Text = "Export Background Playlist";
            this.btn_bkgExport.UseVisualStyleBackColor = true;
            this.btn_bkgExport.Click += new System.EventHandler(this.btn_bkgExport_Click);
            // 
            // btn_flowExport
            // 
            this.btn_flowExport.Location = new System.Drawing.Point(6, 35);
            this.btn_flowExport.Name = "btn_flowExport";
            this.btn_flowExport.Size = new System.Drawing.Size(373, 23);
            this.btn_flowExport.TabIndex = 1;
            this.btn_flowExport.Text = "Export Playlist for the flow";
            this.btn_flowExport.UseVisualStyleBackColor = true;
            this.btn_flowExport.Click += new System.EventHandler(this.btn_flowExport_Click);
            // 
            // btn_AlbumPlaylist
            // 
            this.btn_AlbumPlaylist.Location = new System.Drawing.Point(6, 6);
            this.btn_AlbumPlaylist.Name = "btn_AlbumPlaylist";
            this.btn_AlbumPlaylist.Size = new System.Drawing.Size(373, 23);
            this.btn_AlbumPlaylist.TabIndex = 0;
            this.btn_AlbumPlaylist.Text = "Export Albums Playlist";
            this.btn_AlbumPlaylist.UseVisualStyleBackColor = true;
            this.btn_AlbumPlaylist.Click += new System.EventHandler(this.btn_AlbumPlaylist_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel_albums);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(312, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Copy Albums";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel_albums
            // 
            this.panel_albums.Controls.Add(this.lbl_selectedAlbum);
            this.panel_albums.Controls.Add(this.label3);
            this.panel_albums.Controls.Add(this.label2);
            this.panel_albums.Controls.Add(this.btn_fillWithAlbums);
            this.panel_albums.Controls.Add(this.btn_copyAlbum);
            this.panel_albums.Controls.Add(this.devicePath);
            this.panel_albums.Controls.Add(this.btn_skipAlbum);
            this.panel_albums.Enabled = false;
            this.panel_albums.Location = new System.Drawing.Point(3, 6);
            this.panel_albums.Name = "panel_albums";
            this.panel_albums.Size = new System.Drawing.Size(303, 164);
            this.panel_albums.TabIndex = 5;
            // 
            // lbl_selectedAlbum
            // 
            this.lbl_selectedAlbum.AutoSize = true;
            this.lbl_selectedAlbum.Location = new System.Drawing.Point(93, 32);
            this.lbl_selectedAlbum.Name = "lbl_selectedAlbum";
            this.lbl_selectedAlbum.Size = new System.Drawing.Size(0, 13);
            this.lbl_selectedAlbum.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selected Album:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copy To";
            // 
            // btn_fillWithAlbums
            // 
            this.btn_fillWithAlbums.Location = new System.Drawing.Point(223, 138);
            this.btn_fillWithAlbums.Name = "btn_fillWithAlbums";
            this.btn_fillWithAlbums.Size = new System.Drawing.Size(75, 23);
            this.btn_fillWithAlbums.TabIndex = 4;
            this.btn_fillWithAlbums.Text = "Fill";
            this.btn_fillWithAlbums.UseVisualStyleBackColor = true;
            this.btn_fillWithAlbums.Click += new System.EventHandler(this.btn_fillWithAlbums_Click);
            // 
            // btn_copyAlbum
            // 
            this.btn_copyAlbum.Location = new System.Drawing.Point(111, 138);
            this.btn_copyAlbum.Name = "btn_copyAlbum";
            this.btn_copyAlbum.Size = new System.Drawing.Size(75, 23);
            this.btn_copyAlbum.TabIndex = 3;
            this.btn_copyAlbum.Text = "Copy";
            this.btn_copyAlbum.UseVisualStyleBackColor = true;
            this.btn_copyAlbum.Click += new System.EventHandler(this.btn_copyAlbum_Click);
            // 
            // devicePath
            // 
            this.devicePath.Location = new System.Drawing.Point(53, 4);
            this.devicePath.Name = "devicePath";
            this.devicePath.Size = new System.Drawing.Size(247, 20);
            this.devicePath.TabIndex = 0;
            this.devicePath.Text = "G:\\Music";
            // 
            // btn_skipAlbum
            // 
            this.btn_skipAlbum.Location = new System.Drawing.Point(6, 138);
            this.btn_skipAlbum.Name = "btn_skipAlbum";
            this.btn_skipAlbum.Size = new System.Drawing.Size(75, 23);
            this.btn_skipAlbum.TabIndex = 2;
            this.btn_skipAlbum.Text = "Skip";
            this.btn_skipAlbum.UseVisualStyleBackColor = true;
            this.btn_skipAlbum.Click += new System.EventHandler(this.btn_skipAlbum_Click);
            // 
            // btn_CancelAnalize
            // 
            this.btn_CancelAnalize.Enabled = false;
            this.btn_CancelAnalize.Location = new System.Drawing.Point(311, 10);
            this.btn_CancelAnalize.Name = "btn_CancelAnalize";
            this.btn_CancelAnalize.Size = new System.Drawing.Size(90, 23);
            this.btn_CancelAnalize.TabIndex = 5;
            this.btn_CancelAnalize.Text = "Cancel";
            this.btn_CancelAnalize.UseVisualStyleBackColor = true;
            this.btn_CancelAnalize.Visible = false;
            this.btn_CancelAnalize.Click += new System.EventHandler(this.btn_CancelAnalize_Click);
            // 
            // analizer
            // 
            this.analizer.WorkerReportsProgress = true;
            this.analizer.WorkerSupportsCancellation = true;
            this.analizer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.analizer_DoWork);
            this.analizer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.analizer_ProgressChanged);
            this.analizer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.analizer_RunWorkerCopleted);
            // 
            // FileCopier
            // 
            this.FileCopier.WorkerReportsProgress = true;
            this.FileCopier.WorkerSupportsCancellation = true;
            this.FileCopier.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileCopier_DoWork);
            this.FileCopier.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileCopier_ProgressChanged);
            this.FileCopier.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileCopier_RunWorkerCopleted);
            // 
            // deviceFiller
            // 
            this.deviceFiller.WorkerReportsProgress = true;
            this.deviceFiller.WorkerSupportsCancellation = true;
            this.deviceFiller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.deviceFiller_DoWork);
            this.deviceFiller.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.deviceFiller_ProgressChanged);
            this.deviceFiller.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.deviceFiller_RunWorkerCopleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 295);
            this.Controls.Add(this.btn_CancelAnalize);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Playlist Creator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel_albums.ResumeLayout(false);
            this.panel_albums.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        





        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_AlbumPlaylist;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_flowExport;
        private System.Windows.Forms.Button btn_bkgExport;
        private System.Windows.Forms.Button btn_fillWithAlbums;
        private System.Windows.Forms.Button btn_copyAlbum;
        private System.Windows.Forms.Button btn_skipAlbum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox devicePath;
        private System.Windows.Forms.Panel panel_albums;
        private System.Windows.Forms.Label lbl_selectedAlbum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CancelAnalize;
        private System.ComponentModel.BackgroundWorker analizer;
        private System.ComponentModel.BackgroundWorker FileCopier;
        private BackgroundWorker deviceFiller;
    }
}

