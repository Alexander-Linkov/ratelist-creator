using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TagLib;
using System.Diagnostics;

namespace PlaylistCreator
{
    public partial class Form1 : Form
    {
        string LibPath = @"D:\Music"; //default library path
        List<string> albumPaths = new List<string>();
        List<string> songsFlow = new List<string>();
        List<string> songsBkg = new List<string>();
        string selectedAlbum = "";
        int maxLabelLenght = 50;

        int effect;
        static int effect_1 = -1;
        static int effect_2 = 0;
        static int effect_3 = 3;
        static int effect_4 = 5;
        static int effect_5 = 10;
        static int flow_repeat_1 = 0;
        static int flow_repeat_2 = 1;
        static int flow_repeat_3 = 3;
        static int flow_repeat_4 = 5;
        static int flow_repeat_5 = 10;
        static int bkg_repeat_1 = 0;
        static int bkg_repeat_2 = 0;
        static int bkg_repeat_3 = 1;
        static int bkg_repeat_4 = 3;
        static int bkg_repeat_5 = 5;

        bool analized = false;

        public Form1()
        {
            InitializeComponent();
            label6.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LibPath = textBox1.Text;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            start_analize();
        }

        private void btn_CancelAnalize_Click(object sender, EventArgs e)
        {
            analizer.CancelAsync();
        }

        private void tabControl1_Selected(object sender, EventArgs e)
        {
            if (!analized)
            {
                panel_albums.Enabled = false;
            } else
            {
                updateTabs();
            }
        }

        private void updateTabs()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    if (selectedAlbum == "") select_Album();
                    break;
            }
        }

        private void start_analize()
        {
            if (!analizer.IsBusy)
            {
                generateButton.Visible = false;
                generateButton.Enabled = false;
                btn_CancelAnalize.Visible = true;
                btn_CancelAnalize.Enabled = true;

                label1.Text = "Analizing...";

                DirectoryInfo LibDirInfo = new DirectoryInfo(LibPath);

                progressBar1.Minimum = 0;
                progressBar1.Maximum = LibDirInfo.GetDirectories().Length;
                progressBar1.Step = 1;
                progressBar1.Value = 0;

                analizer.RunWorkerAsync(LibDirInfo);
            } else
            {
                MessageBox.Show("Analize is in progress. Please wait.", "Analize in progress");
            }
        }

        private void analizer_DoWork(object sender, DoWorkEventArgs e)
        {
            WalkDirectoryTree((DirectoryInfo)e.Argument);
            e.Cancel = analizer.CancellationPending;
        }

        private void analizer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (var s = 0; s < e.ProgressPercentage; s++) progressBar1.PerformStep();

            string fullName = (string)e.UserState;
            string reportedName = fullName.Remove(0, LibPath.Length);
            if (reportedName.Length > maxLabelLenght)
            {
                reportedName = reportedName.Remove(maxLabelLenght - 3);
                reportedName += "...";
            }
            label1.Text = "Processing: " + reportedName;
        }

        private void analizer_RunWorkerCopleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                analized = true;
                panel_albums.Enabled = true;
                updateTabs();

                label1.Text = "Library has been analized!";
                Console.WriteLine("Library at " + LibPath + " has been analized!");
            } else
            {
                label1.Text = "Analizing has been Canceled";
            }
            

            generateButton.Visible = true;
            generateButton.Enabled = true;
            btn_CancelAnalize.Visible = false;
            btn_CancelAnalize.Enabled = false;
        }

        private void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            subDirs = root.GetDirectories();

            analizer.ReportProgress(0, root.FullName);

            //label1.Text = "Processing: " + root.FullName;

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                if (analizer.CancellationPending)
                {
                    return;
                }
                WalkDirectoryTree(dirInfo);
            }
                 
            try
            {
                files = root.GetFiles("*.mp3");
                if (files != null && files.Length > 0)
                {
                    processAlbum(root);
                }
                if (root.Parent.FullName == LibPath)
                {
                    analizer.ReportProgress(1, root.FullName);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void processAlbum(DirectoryInfo root)
        {

            int rootRating = 0;
            int bkgInd = 0;
            int flowInd = 0;
            double rootDuration = 0;
            double curRating = 0;
            double curDuration;

            FileInfo[] files = root.GetFiles("*.mp3");

            foreach (FileInfo fi in files)
            {
                if (analizer.CancellationPending) return;

                bkgInd = 0;
                flowInd = 0;

                TagLib.File file = TagLib.File.Create(fi.FullName);
                TagLib.Tag tag = file.GetTag(TagTypes.Id3v2);

                byte Rating = TagLib.Id3v2.PopularimeterFrame.Get((TagLib.Id3v2.Tag)tag, "Windows Media Player 9 Series", true).Rating;
    
                switch (Rating)
                {
                    case 1:
                        // rating *
                        effect = effect_1;
                        flowInd = flow_repeat_1;
                        bkgInd = bkg_repeat_1;
                        break;
                    case 64:
                        // rating **
                        effect = effect_2;
                        flowInd = flow_repeat_2;
                        bkgInd = bkg_repeat_2;
                        break;
                    case 128:
                        // rating ***
                        effect = effect_3;
                        flowInd = flow_repeat_3;
                        bkgInd = bkg_repeat_3;
                        break;
                    case 196:
                        // rating ****
                        effect = effect_4;
                        flowInd = flow_repeat_4;
                        bkgInd = bkg_repeat_4;
                        break;
                    case 255:
                        // rating *****
                        effect = effect_5;
                        flowInd = flow_repeat_5;
                        bkgInd = bkg_repeat_5;
                        break;
                    default:
                        // threat as rating **
                        Console.WriteLine("wor: " + fi.FullName);
                        effect = effect_2;
                        flowInd = flow_repeat_2;
                        bkgInd = bkg_repeat_2;
                        break;
                }
                
                for (var flowI = 0; flowI < flowInd; flowI++)
                {
                    songsFlow.Add(fi.FullName);
                }
                for (var bkgI = 0; bkgI < bkgInd; bkgI++)
                {
                    songsBkg.Add(fi.FullName);
                }
                curDuration = file.Properties.Duration.TotalSeconds;
                rootDuration = rootDuration + curDuration;
                curRating += curDuration * effect;
                // 255 - 5
                // 196 - 4
                // 128 - 3
                // 64 - 2
                // 1 - 1
                // 0 - 0

            }
            
            rootRating = (int)Math.Round((curRating / rootDuration));
            Console.WriteLine(root.FullName + " has rating " + rootRating);
            StreamWriter csvf = new StreamWriter("D:\\test.csv", true);
            csvf.WriteLine(root.FullName + "\t" + rootRating);
            csvf.Close();

            if (rootRating > 0)
            {
                for (var i = 0; i < rootRating; i++)
                {
                    albumPaths.Add(root.FullName);
                }
            }

        }

        private void btn_AlbumPlaylist_Click(object sender, EventArgs e)
        {
            if (!analized) start_analize();

            List<string> tmpList = new List<string>(albumPaths);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "m3u8 files (*.m3u8)|*.m3u8|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                StreamWriter playlist = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                //if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                Random rnd = new Random();
                while (tmpList.Count > 0)
                {
                    var curInd = rnd.Next(tmpList.Count);
                    DirectoryInfo curPath = new DirectoryInfo(tmpList[curInd]);
                    //StreamReader sr = new StreamReader(albumPaths[curInd]);
                    
                    foreach (FileInfo file in curPath.GetFiles("*.mp3"))
                    {
                        playlist.WriteLine(file.FullName);
                    }
                    tmpList.RemoveAt(curInd);
                    
                }
                playlist.Close();
                label1.Text = "Playlist has been saved to " + saveFileDialog1.FileName;
            }       
        }

        private void btn_flowExport_Click(object sender, EventArgs e)
        {
            if (!analized) start_analize();

            export_song_list(songsFlow);
            
        }

        private void btn_bkgExport_Click(object sender, EventArgs e)
        {
            if (!analized) start_analize();

            export_song_list(songsBkg);
            
        }

        private void export_song_list(List<string> sourceList)
        {

            List<string> tmpPlst = new List<string>(sourceList);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "m3u8 files (*.m3u8)|*.m3u8|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                StreamWriter playlist = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                //if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                Random rnd = new Random();
                while (tmpPlst.Count > 0)
                {
                    var curInd = rnd.Next(tmpPlst.Count);
                    playlist.WriteLine(tmpPlst[curInd]);
                    tmpPlst.RemoveAt(curInd);

                }
                playlist.Close();
                label1.Text = "Playlist has been saved to " + saveFileDialog1.FileName;
            }
        }

        private void select_Album()
        {
            Random rnd = new Random();
            int curInd = rnd.Next(albumPaths.Count);
            selectedAlbum = albumPaths[curInd];
            lbl_selectedAlbum.Invoke((MethodInvoker)delegate
            {
                lbl_selectedAlbum.Text = selectedAlbum.Remove(0, LibPath.Length+1);
            });
            
        }

        private void btn_skipAlbum_Click(object sender, EventArgs e)
        {
            select_Album();
        }

        private void btn_copyAlbum_Click(object sender, EventArgs e)
        {
            // копирует mp3 файлы из папки альбома в путь (пока абсолютный)
            DirectoryInfo curPath = new DirectoryInfo(selectedAlbum);

            if (Directory.Exists(devicePath.Text.Substring(0,3)))
            {
                FileCopier.RunWorkerAsync(curPath);
                label1.Text = "Copying album...";
            } else
            {
                MessageBox.Show("Target drive does not exist.");
            }
        }

        private void btn_fillWithAlbums_Click(object sender, EventArgs e)
        {
            // берет диск куда копировать

            // цикл: р=определяет свободное место, смотрит сколько места занимает selectedAlbum, если меньше, то копирует. Если больше то выход
            if (Directory.Exists(devicePath.Text.Substring(0, 3)))
            {
                deviceFiller.RunWorkerAsync();
                label1.Text = "Copying albums...";
            }
            else
            {
                MessageBox.Show("Target drive does not exist.");
            }
        }

        private long getAlbumSize(DirectoryInfo dir)
        {
            long totalSize = 0;
            List<FileInfo> files = dir.GetFiles("*.mp3").ToList();
            foreach (FileInfo file in files)
            {
                totalSize += file.Length;
            }

            return totalSize;
        }

        private void FileCopier_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo copiedAlbumInfo = (DirectoryInfo)e.Argument;
            List < FileInfo > files = copiedAlbumInfo.GetFiles("*.mp3").ToList();
            progressBar1.Invoke((MethodInvoker)delegate {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = files.Count;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
            });

            copyAlbum(copiedAlbumInfo, FileCopier);
        }

        private void FileCopier_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Increment(e.ProgressPercentage);
        }

        private void FileCopier_RunWorkerCopleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string albumName = "";
            albumName = selectedAlbum.Substring(selectedAlbum.LastIndexOf("\\")+1);
            label1.Text = "Album " + albumName + " has been copied.";
            select_Album();
        }

        private void copyAlbum(DirectoryInfo curPath, BackgroundWorker sender)
        {

            foreach (FileInfo file in curPath.GetFiles("*.mp3"))
            {
                // определение пути куда копировать
                // ==== временная  мера, пока не научу класть по шаблону
                string refFilePath = file.FullName.Remove(0, LibPath.Length);
                string refPath = refFilePath.Remove(refFilePath.IndexOf(file.Name)); // путь до папки относительно корня библиотеки
                // ==== конец меры

                string destPathG = getDestinationPath(file);

                //string destPath = devicePath.Text + refPath;
                string destPath = destPathG;

                string fileName = file.Name;

                // надо проверить наличие пути копирования. Если нет, попытаться создать. Если не получится, сказать, что копирование по выбранному пути невозможно.
                if (!Directory.Exists(destPath))
                {
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch
                    {
                        //Console.WriteLine("Cannot create a dir. Check destination path.");
                        MessageBox.Show("Cannot create a dir. Check destination path.");
                        return;
                    }

                }
                try
                {
                    System.IO.File.Copy(file.FullName, destPath + fileName);
                }
                catch
                {
                    MessageBox.Show("Cannot copy a file " + file.Name);
                    // обработка ошибки копирования
                }
                sender.ReportProgress(1);
            }
        }

        private void deviceFiller_DoWork(object sender, DoWorkEventArgs e)
        {
            string targetDriveChar = devicePath.Text.Substring(0, 1);
            DriveInfo targetDriveInfo = new DriveInfo(targetDriveChar);

            progressBar1.Invoke((MethodInvoker)delegate {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = int.Parse(targetDriveInfo.TotalFreeSpace.ToString());
                progressBar1.Step = 1;
                progressBar1.Value = 0;
            });

            DirectoryInfo selectedAlbumInfo = new DirectoryInfo(selectedAlbum);
            List<string> addedAlbums = new List<string>();
            while (targetDriveInfo.TotalFreeSpace > getAlbumSize(selectedAlbumInfo))
            {
                if (!addedAlbums.Contains(selectedAlbum))
                {
                    copyAlbum(selectedAlbumInfo, deviceFiller);
                    deviceFiller.ReportProgress(int.Parse(getAlbumSize(selectedAlbumInfo).ToString()));
                    addedAlbums.Add(selectedAlbum);
                    
                }
                select_Album();
                selectedAlbumInfo = new DirectoryInfo(selectedAlbum);
            }
            e.Result = addedAlbums.Count;
        }

        private void deviceFiller_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            progressBar1.Increment(e.ProgressPercentage);
        }

        private void deviceFiller_RunWorkerCopleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;
            label1.Text = e.Result + " albums have been copied";
        }

        private void BtnSelectLibraryPath_Click(object sender, EventArgs e)
        {
            string cur_folder = textBox1.Text;
            if (cur_folder != "") LibraryFolderSelector.SelectedPath = cur_folder;
            if (LibraryFolderSelector.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = LibraryFolderSelector.SelectedPath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Alexander-Linkov/ratelist-creator");
        }

        private string getDestinationPath(FileInfo file)
        {
            string path = "";

            TagLib.File mp3 = TagLib.File.Create(file.FullName);
            TagLib.Tag tag = mp3.GetTag(TagTypes.Id3v2);


            path = devicePath.Text;
            path = path.Replace("%album%", tag.Album);
            path = path.Replace("%artist%", tag.Performers[0]);
            path = path.Replace("%track%", tag.Track.ToString());
            path = path.Replace("%year%", tag.Year.ToString());
            path = path.Replace("%title%", tag.Title);
            return path;
        }

    }
}
