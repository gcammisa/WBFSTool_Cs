using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Store the drive letters in a string array
            string[] drives = Environment.GetLogicalDrives();
            // Loop to add drive letters in the array
            foreach (string strDrive in drives)
            {
                // Add items to the array
                CBDrives.Items.Add(strDrive.ToString());
            }
        }

        public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
        {


            System.DateTime ThisMoment = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
            System.DateTime AfterWards = ThisMoment.Add(duration);


            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = System.DateTime.Now;
            }


            return System.DateTime.Now;
        }


        private void BTApriUnità_Click(object sender, EventArgs e)
        {
            string unità = "";
            try
            {
                unità = CBDrives.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Inserisci una lettera di unità!");
                return;
            }
            libwbfsNET.WbfsIntermWrapper.OpenDrive(unità.Substring(0, 1));


            //Get the number of games in the partition
            int NumeroGiochi = libwbfsNET.WbfsIntermWrapper.GetDiscCount();
            string NumeroGiochiStr = System.Convert.ToString(NumeroGiochi, 10);
            if (NumeroGiochi == -1)
            {
                MessageBox.Show("Inserisci una lettera di unità WBFS valida!");
                return;
            }
            BTCheatDL.Enabled = true;
            BTCoverDL.Enabled = true;
            BTSave.Enabled = true;

            TBNGiochi.Text = NumeroGiochiStr;

            //Getting total space, free space and used space of the partition
            uint blocks = 0;
            float total = 0;
            float free = 0;
            float used = 0;
            libwbfsNET.WbfsIntermWrapper.GetDriveStats(ref blocks, ref total, ref used, ref free);
            string totalstr = System.Convert.ToString(total);
            string usedstr = System.Convert.ToString(used);
            string freestr = System.Convert.ToString(free);
            TBGBTotali.Text = totalstr;
            TBGBUsati.Text = usedstr;
            TBGBLiberi.Text = freestr;

            //Writing the games list in an RTB (Rich text box)
            for (int i = 1; i < NumeroGiochi; i++)
            {
                float size = 0;
                StringBuilder discId = new StringBuilder();
                StringBuilder discName = new StringBuilder(256);
                libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                string indexstr = System.Convert.ToString(i);
                RTBGiochi.Text += indexstr;
                RTBGiochi.Text += " - " + discId;
                RTBGiochi.Text += " - " + discName;
                RTBGiochi.Text += " - " + size + " GB";
                RTBGiochi.Text += " - " + regioncode;
                RTBGiochi.Text += Environment.NewLine;

            }
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
                // Text from the rich textbox RTBGiochi
                string str = RTBGiochi.Text;
                // Create a new SaveFileDialog object
                using (SaveFileDialog dlgSave = new SaveFileDialog())
                    try
                    {
                        // Available file extensions
                        dlgSave.Filter = "Text File (*.txt)|*.txt*";
                        // SaveFileDialog title
                        dlgSave.Title = "Save";
                        // Show SaveFileDialog
                        if (dlgSave.ShowDialog() == DialogResult.OK && dlgSave.FileName.Length > 0)
                        {
                            // Save file as utf8 without byte order mark (BOM)
                            UTF8Encoding utf8 = new UTF8Encoding();
                            StreamWriter sw = new StreamWriter(dlgSave.FileName, false, utf8);
                            sw.Write(str);
                            sw.Close();
                        }
                    }
                    catch (Exception errorMsg)
                    {
                        MessageBox.Show(errorMsg.Message);
                    }
 

        }

        private void BTCheatDL_Click(object sender, EventArgs e)
        {
            //Get the number of games in the partition
            int NumeroGiochi = libwbfsNET.WbfsIntermWrapper.GetDiscCount();

            //Folder Browser Dialog to select the directory for saving cheats
            if (FBCheat.ShowDialog() == DialogResult.OK)
            {
                //Confirming the download directory
                string DLDir = FBCheat.SelectedPath;
                //Start cheats download
                string dlurl = "http://geckocodes.org/txt.php?txt=";
                List<string> links = new List<string>();

                for (int i = 1; i < NumeroGiochi; i++)
                {
                    float size = 0;
                    StringBuilder discId = new StringBuilder();
                    StringBuilder discName = new StringBuilder(256);
                    libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                    libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                    string indexstr = System.Convert.ToString(i);
                    string fileurl = dlurl + discId + ".txt";
                    links.Add(fileurl);
                }
                string[] linkArray = links.ToArray();
                WebClient cc = new WebClient();
                cc.DownloadFileCompleted += new AsyncCompletedEventHandler(cc_DownloadFileCompleted);
                cc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(cc_DownloadProgressChanged);
                try
                {
                    float size = 0;
                    StringBuilder discId = new StringBuilder();
                    StringBuilder discName = new StringBuilder(256);
                    libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                    libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(0, discId, ref size, discName, ref  regioncode);
                    MessageBox.Show("Inizio del download dei cheat, un messaggio vi avviserà a download completato.");   
                    cc.DownloadFileAsync(new Uri(linkArray[0]), @DLDir + "/" + discId + ".txt");

                }

                catch (InvalidOperationException ioEx)
                {
                    if (ioEx is WebException)
                    {
                        MessageBox.Show("File non trovato");
                    }
                }

            }
            else
            {
                MessageBox.Show("Download dei cheats annullato.");
            }

        }

        int cheatCount = 0;
        void cc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the number of games in the partition
            int NumeroGiochi = libwbfsNET.WbfsIntermWrapper.GetDiscCount();

            //Folder Browser Dialog to select the directory for saving cheats
                string DLDir = FBCheat.SelectedPath;
                //Start download
                string dlurl = "http://geckocodes.org/txt.php?txt=";
                List<string> links = new List<string>();

                for (int i = 0; i < NumeroGiochi; i++)
                {
                    float size = 0;
                    StringBuilder discId = new StringBuilder();
                    StringBuilder discName = new StringBuilder(256);
                    libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                    libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                    string indexstr = System.Convert.ToString(i);
                    string fileurl = dlurl + discId;
                    links.Add(fileurl);
                }
                string[] linkArray = links.ToArray();
                WebClient cc = new WebClient();
                cc.DownloadFileCompleted += new AsyncCompletedEventHandler(cc_DownloadFileCompleted);
                cc.DownloadProgressChanged +=new DownloadProgressChangedEventHandler(cc_DownloadProgressChanged);
                try
                {
                    float size = 0;
                    StringBuilder discId = new StringBuilder();
                    StringBuilder discName = new StringBuilder(256);
                    libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                    libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(cheatCount, discId, ref size, discName, ref  regioncode);
                    cc.DownloadFileAsync(new Uri(linkArray[cheatCount]), @DLDir + "/" + discId + ".txt");
                    cheatCount++;
                }

                catch (IndexOutOfRangeException)
                {
                    int notfound = 0;
                    for (int i = 1; i < NumeroGiochi; i++)
                    {
                        try
                        {
                            float size = 0;
                            StringBuilder discId = new StringBuilder();
                            StringBuilder discName = new StringBuilder(256);
                            libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                            libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                            string indexstr = System.Convert.ToString(i);
                            string filelocation = FBCheat.SelectedPath + @"\" + discId + ".txt";
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filelocation);
                            string lenghtstr = fileInfo.Length.ToString();
                            int lenght = Convert.ToInt32(lenghtstr);
                            if (lenght >= 29500 && lenght <= 30500)
                            {
                                System.IO.File.Delete(filelocation);
                                notfound++;
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            notfound++;
                        }
                    }
                    MessageBox.Show("Cheats non trovati: " + notfound);
                }

        }

        void cc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;

                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            }
            catch (Exception)
            {
            }
        }

        private void BTCoverDL_Click(object sender, EventArgs e)
        {
            //Get the number of games in the partition
            int NumeroGiochi = libwbfsNET.WbfsIntermWrapper.GetDiscCount();

            //Folder Browser Dialog to select the directory for saving covers
            if (FBCover.ShowDialog() == DialogResult.OK)
            {
                //Confirming the download directory
                string DLDir = FBCover.SelectedPath;
                //Download Start
                string dlurl = "";
                if (RBEng.Checked)
                {
                    dlurl = "http://art.gametdb.com/wii/coverfullHQ/EN/";
                }
                else if (RBIta.Checked)
                {
                    dlurl = "http://art.gametdb.com/wii/coverfullHQ/IT/";
                }

	            List<string> links = new List<string>();

                for (int i = 1; i < NumeroGiochi; i++)
                        {
                            float size = 0;
                            StringBuilder discId = new StringBuilder();
                            StringBuilder discName = new StringBuilder(256);
                            libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                            libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                            string indexstr = System.Convert.ToString(i);
                            string fileurl = dlurl + discId + ".png";
                            links.Add(fileurl);
                        }
                            string[] linkArray = links.ToArray();
                            WebClient wc = new WebClient();
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                                    try
                                    {
                                        float size = 0;
                                        StringBuilder discId = new StringBuilder();
                                        StringBuilder discName = new StringBuilder(256);
                                        libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                                        libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(0, discId, ref size, discName, ref  regioncode);

                                        wc.DownloadFileAsync(new Uri(linkArray[0]), @DLDir + "/" + discId + ".png");

                                    }

                                    catch (InvalidOperationException ioEx)
                                    {
                                        if (ioEx is WebException)
                                        {
                                            MessageBox.Show("File non trovato");
                                        }
                                    }

            }
            else
            {
                MessageBox.Show("Download delle cover annullato.");
            }

        }
        
        int c = 0;
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the number of games in the partition
            int NumeroGiochi = libwbfsNET.WbfsIntermWrapper.GetDiscCount();

                //Confirming the download directory
                string DLDir = FBCover.SelectedPath;
                //Download Start
                string dlurl = "";
                if (RBEng.Checked)
                {
                    dlurl = "http://art.gametdb.com/wii/coverfullHQ/EN/";
                }
                else if (RBIta.Checked)
                {
                    dlurl = "http://art.gametdb.com/wii/coverfullHQ/IT/";
                }

                List<string> links = new List<string>();

                for (int i = 1; i < NumeroGiochi; i++)
                {
                    float size = 0;
                    StringBuilder discId = new StringBuilder();
                    StringBuilder discName = new StringBuilder(256);
                    libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                    libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                    string indexstr = System.Convert.ToString(i);
                    string fileurl = dlurl + discId + ".png";
                    links.Add(fileurl);
                }

                string[] linkArray = links.ToArray();
                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);


                    try
                    {
                        float size = 0;
                        StringBuilder discId = new StringBuilder();
                        StringBuilder discName = new StringBuilder(256);
                        libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                        libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(c, discId, ref size, discName, ref  regioncode);
                        PauseForMilliSeconds(500);
                            wc.DownloadFileAsync(new Uri(linkArray[c]), @DLDir + "/" + discId + ".png");
                            c++;
                    }

                    catch (IndexOutOfRangeException)
                    {
                        int notfound = 0;
                        for (int i = 1; i < NumeroGiochi; i++)
                        {
                            try
                            {
                                float size = 0;
                                StringBuilder discId = new StringBuilder();
                                StringBuilder discName = new StringBuilder(256);
                                libwbfsNET.WbfsIntermWrapper.RegionCode regioncode = new libwbfsNET.WbfsIntermWrapper.RegionCode();
                                libwbfsNET.WbfsIntermWrapper.GetDiscInfoEx(i, discId, ref size, discName, ref  regioncode);
                                string indexstr = System.Convert.ToString(i);
                                string filelocation = FBCover.SelectedPath + @"\" + discId + ".png";
                                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filelocation);
                                string lenghtstr = fileInfo.Length.ToString();
                                int lenght = Convert.ToInt32(lenghtstr);
                                if (lenght == 0)
                                {
                                    System.IO.File.Delete(filelocation);
                                    notfound++;
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                notfound++;
                            }
                        }
                        MessageBox.Show("Cover non trovate: " + notfound);
                    }
                }
            
        

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
 

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void officialPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "www.hackwii.it";
            proc.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 FormAbout = new Form2();
            FormAbout.Show();
        }
        

        }
    }

