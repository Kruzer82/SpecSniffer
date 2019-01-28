using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MetroFramework;
using MySql.Data.MySqlClient;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using SimpleWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using SpecSniffer;



namespace Sniffer
{

    public partial class MainWindow : MetroFramework.Forms.MetroForm 
    {
        #region Methods

        /// <summary>
        /// Write text to console
        /// </summary>
        /// <param name="text">console output</param>
        private void ConsoleWrite(string text)
        {
            TBMain_cmd.AppendText(text);
            TBMain_cmd.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Connects to AP and set Wifi presence
        /// </summary>
        Wifi wifi = new Wifi();
        private void WiFiConnect()
        {
            try
            {
                IEnumerable<AccessPoint> apList = wifi.GetAccessPoints(); // get list of access points

                foreach (AccessPoint ap in apList)// for each access point from the list
                {
                    if (ap.Name == Settings.apNameToConn)
                    {
                        AuthRequest authRequest = new AuthRequest(ap);
                        if (authRequest.IsUsernameRequired)
                            authRequest.Username = Settings.apNameToConn;

                        authRequest.Password = Settings.apPSWD;
                        ap.ConnectAsync(authRequest, true);
                    }
                }
                if (apList.Count() > 1)
                {
                    Spec.WifiPresence = true;
                }
            }
            catch (Exception)
            {
                Spec.WifiPresence = false;
            }
        }

        /// <summary>
        /// Run batch file that connects to network drive
        /// </summary>
        private void ConnectToNetworkFolder()
        {
            if (CheckForNetworkFolder() == false && CheckForInternetConnection() == true)
            {
                Process.Start(Path.ConnNetworkFolderBAT);
                ConsoleWrite("Network folder has been mounted.");
            }
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckForNetworkFolder()
        {
            return (Directory.Exists(Path.NetworkLetter)) ? true : false;
        }

        /// <summary>
        /// Checks if location from which program has been started still exists
        /// </summary>
        /// <returns></returns>
        public bool CheckForUSB()
        {
            return (Directory.Exists(Path.Run)) ? true : false;
        }

        private void SetStatusStrip()
        {
            if (CheckForInternetConnection())
            {
                StatusInternet.Text = "on";
                StatusInternet.ForeColor = Color.MediumSpringGreen;
            }
            else
            {
                StatusInternet.Text = "off";
                StatusInternet.ForeColor = Color.IndianRed;
            }

            if (CheckForNetworkFolder())
            {
                StatusNetworkFolder.Text = "on";
                StatusNetworkFolder.ForeColor = Color.MediumSpringGreen;
            }
            else
            {
                StatusNetworkFolder.Text = "off";
                StatusNetworkFolder.ForeColor = Color.IndianRed;
            }

            if (CheckForUSB())
            {
                StatusUSB.Text = "on";
                StatusUSB.ForeColor = Color.MediumSpringGreen;
            }
            else
            {
                StatusUSB.Text = "off";
                StatusUSB.ForeColor = Color.IndianRed;
            }
        }

        /// <summary>
        /// Populate dataGridFileList with name of all executable files in 'folderName'
        /// </summary>
        /// <param name="folderName"> path of folder from with you want to list files</param>
        /// <returns></returns>
        private bool ShowFilesInFolder(string folderName)
        {
            //Remove all after char selected character
            string RemoveAfter(string value, string character)
            {
                int index = value.IndexOf(character);
                if (index > 0)
                    value = value.Substring(0, index);
                return value;
            }
            
            dataGridFileList.Rows.Clear();

            if (CheckForNetworkFolder())
            {
                string[] files;
                try
                {
                    files = Directory.GetFiles(folderName, "*.exe", SearchOption.TopDirectoryOnly);

                    foreach (var f in files)
                    {
                        dataGridFileList.Rows.Add(RemoveAfter(System.IO.Path.GetFileName(f), "."));
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Populate combo list in Drivers Tab with folders name found on network drive
        /// </summary>
        private void ListFoldersInDirectory()
        {
            cb_DriverPackList.Items.Clear();
            if (CheckForNetworkFolder())
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(Path.DriversFolder);
                    foreach (var dir in di.GetDirectories())
                        cb_DriverPackList.Items.Add(dir);
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    ConsoleWrite("!DriverPackList: Directory " + Path.DriversFolder + " not found.");
                }
                catch (Exception ex)
                {
                    ConsoleWrite("!DriverPackList: " + ex.Message);
                }
            }

        }

        /// <summary>
        /// Drivers installation. Method try to run 'run.bat.' from 'driverPackModel' path. if .bat not found it try to copy it.
        /// </summary>
        /// <param name="driverPackModelPath">path for driver pack folder</param>
        private void RunDriverPack(string driverPackModelPath)
        {
            if (!String.IsNullOrWhiteSpace(driverPackModelPath))
            {
                if (CheckForInternetConnection())
                {
                    if (CheckForNetworkFolder())
                    {
                        if (Directory.Exists(driverPackModelPath))
                        {
                            if (File.Exists(driverPackModelPath + "\\Run.bat"))
                            {
                                try
                                {
                                    Process.Start(driverPackModelPath + "\\Run.bat");
                                }
                                catch (Exception ex)
                                {
                                    ConsoleWrite("!Drivers: Driver's installation error.");
                                    MetroMessageBox.Show(this, "", "Driver's installation error." + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "Plug in USB before click OK.\nSome file has to be copied from USB to driver pack folder.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (CheckForUSB())
                                {
                                    try
                                    {
                                        File.Copy(Path.InstallBAT, driverPackModelPath + "\\Run.bat"); //file.copy(source,destination);
                                        ConsoleWrite("@Drivers: Files copied successfully.");

                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "Error while copying files. Try copy it manually", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        ConsoleWrite("!!! Drivers@: Error while copying files. Try copy it manually");
                                    }
                                    finally
                                    {
                                        Process.Start(driverPackModelPath + "\\Run.bat");
                                    }
                                }
                                else
                                {
                                    MetroMessageBox.Show(this, "No data source. Plug in USB and try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "No drier pack for that model has been found. Check model name.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Network folder not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Check internet connection.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Model has not been set", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #region Validate Save Textbox's

        private bool HasDataTextBox(MetroFramework.Controls.MetroTextBox tBox, bool sendMsg)
        {
            if (!String.IsNullOrWhiteSpace(tBox.Text))
            {
                return true;
            }
            else
            {
                if (sendMsg) { ConsoleWrite("!!SpecSniffer: " + tBox.Tag + " can't be empty."); }
                return false;
            }
        }

        private bool Validate_TBox(MetroFramework.Controls.MetroTextBox txtBox, string msg, bool isTrue, bool sendMsg)
        {
            if (isTrue == true)
            {
                txtBox.BackColor = Color.FromArgb(45, 45, 45);
                txtBox.ForeColor = Color.DarkOliveGreen;
                return true;
            }
            else
            {
                txtBox.BackColor = Color.DarkRed;
                if (sendMsg) { ConsoleWrite("!DataValidate: " + msg); }
                return false;
            }
        }

        private bool ValidateSO(bool sendMsg)
        {
            if (String.IsNullOrWhiteSpace(TBox_SO.Text))
                return Validate_TBox(TBox_SO, "SO can't be null", false, sendMsg);
            else
                return Validate_TBox(TBox_SO, "", true, sendMsg);
        }

        private bool ValidateRP(bool sendMsg)
        {
            if (String.IsNullOrWhiteSpace(TBox_RP.Text))
                return Validate_TBox(TBox_RP, "RP can't be null", false, sendMsg);
            else
                return Validate_TBox(TBox_RP, "", true, sendMsg);
        }
       
        private bool ValidateLicence()
        {
            if (String.IsNullOrEmpty(LBox_Licence.Text))
            {
                LBox_Licence.BackColor = Color.DarkRed;
                ConsoleWrite("!DataValidate: Select device type or enter old licence.");
                return false;
            }
            else
            {
                LBox_Licence.BackColor = Color.FromArgb(45, 45, 45);
                LBox_Licence.ForeColor = Color.DarkOliveGreen;
                return true;
            }
        }
        #endregion

        #region Audio
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;
        private bool audioPlay = true;
        /// <summary>
        /// start / stop audio play. audioPlay is mark current status, timerAudio enables volume peak visualization.
        /// </summary>
        private void AudioPlay()
        {
            if (audioPlay == true)
            {
                timerAudio.Enabled = true;
                MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
                wave = new WaveFileReader(Sniffer.Properties.Resources.AudioTest);
                output = new DirectSoundOut();
                output.Init(new WaveChannel32(wave));
                try
                {
                    output.Play();
                    audioPlay = false;
                }

                catch (Exception)
                {
                    ConsoleWrite("!SpecSniffer: Audio output error...");
                }
            }
            else
            {
                output.Stop();
                output.Dispose();
                timerAudio.Enabled = false;
                audioPlay = true;
            }
        }
        MMDevice device = null;

        /// <summary>
        /// displays volume peak on 'pbarAudio'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAudio_Tick_1(object sender, EventArgs e)
        {
            device = GetDefaultAudioEndpoint();

            if (device != null)
                pbarAudio.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
            else
            {
                output.Stop();
                output.Dispose();
                timerAudio.Enabled = false;
                pbarAudio.Value = 0;
            }
        }

        //gets default audio device
        public MMDevice GetDefaultAudioEndpoint()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        }
        #endregion

        #region Microphone
        int n = 4000; //number of x-axis pints
        WaveIn wi;
        Queue<double> myQ;
        private bool micStart = true;

        private void MicStart()
        {
            if (micStart == true)
            {
                myQ = new Queue<double>(Enumerable.Repeat(0.0, n).ToList()); // fill myQ w/ zeros
                micChart.ChartAreas[0].AxisY.Minimum = -10000;
                micChart.ChartAreas[0].AxisY.Maximum = 10000;
                wi = new WaveIn();
                try
                {
                    wi.StartRecording();
                    wi.WaveFormat = new WaveFormat(4, 16, 1); // (44100, 16, 1);
                    wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
                    timerMic.Enabled = true;

                }
                catch (NAudio.MmException) { micChart.Visible = false; }
                catch (Exception) { }

                void wi_DataAvailable(object sender, WaveInEventArgs e)
                {
                    for (int i = 0; i < e.BytesRecorded; i += 2)
                    {
                        myQ.Enqueue(BitConverter.ToInt16(e.Buffer, i));
                        myQ.Dequeue();
                    }
                }
                micStart = false;
            }
            else
            {
                MicStop();
                micStart = true;
            }
        }

        private void timerMic_Tick(object sender, EventArgs e)
        {
            try { micChart.Series["Series1"].Points.DataBindY(myQ); }
            catch { MessageBox.Show("No bytes recorded"); }
        }

        private void MicStop()
        {
            wi.StopRecording();
            wi.Dispose();
            wi = null;
            timerMic.Enabled = false;
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            if (CheckForUSB())
                MicStart();
            else
                MetroMessageBox.Show(this, "\n\nPlug in USB and try again.", "No data to work with...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Camera

        VideoCapture capture;
        private void ProcessFrame(object sender, EventArgs e)
        {
            imageBox1.Image = capture.QuerySmallFrame();
        }
        bool runCam = true;

        private void RunCam()
        {
            if (runCam == true)
            {
                try
                {
                    capture = new VideoCapture();
                    if (capture.QuerySmallFrame() != null)
                    {
                        Application.Idle += ProcessFrame;
                        runCam = false;

                        if (Spec.CameraPresence != true)
                        {
                            Spec.CameraPresence = true;
                            cbCamera.Checked = true;
                        }
                    }
                    else
                    {
                        Mat img = new Mat(450, 700, DepthType.Cv8U, 3);
                        img.SetTo(new Bgr(100, 90, 80).MCvScalar);
                        CvInvoke.PutText(
                        img,
                        "No camera detected...",
                        new System.Drawing.Point(180, 240),
                        FontFace.HersheyDuplex,
                        0.9,
                        new Bgr(0, 10, 255).MCvScalar);
                        imageBox1.Image = img;
                    }
                }
                catch (Exception) { ConsoleWrite("!SpecSniffer: Camera capture error..."); }
            }
            else
            {
                capture.Stop();
                capture.Dispose();
                runCam = true;
            }
        }
        #endregion

        #endregion

        DiskDrives hdd = new DiskDrives();
        Stopwatch timer = new Stopwatch();

        public MainWindow()
        {
            
            timer.Start();
            InitializeComponent();

            //check if program is running as administrator
            if ((new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                MetroMessageBox.Show(this, "\nAdministrator privileges are required to run program.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            
            backgroundWorker.RunWorkerAsync();
            //some of get spec methods are here for performance
            Spec.GetFingerprint();
            Spec.GetLicenceKey();

            //get hdd info
            hdd.GetDiskInfo();
            //set hdd TextBoxses
            TBox_HDDsize.Lines = hdd.HDDs.Select(m => m.Value.Size).ToArray();
            TBox_HDDname.Lines = hdd.HDDs.Select(m => m.Value.Model).ToArray();
            TBox_HDDstatus.Lines = hdd.HDDs.Select(m => m.Value.IsOK).ToArray();
            if (TBox_HDDstatus.Text.Contains("Fail"))
                TBox_HDDstatus.ForeColor = Color.PaleVioletRed;

            //Load & apply last settings
            SaveTab.ReadLastSettings();
            TBox_RP.Text = SaveTab.Rep;
            TBox_SO.Text = SaveTab.SaleOrderId;
            TBox_comments.Text = SaveTab.Comments;
            LBox_Licence.Text = SaveTab.Licence;


            WiFiConnect();
        }

        #region Background Worker
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (i == 12)
                {
                    backgroundWorker.ReportProgress(12);
                }
                else if (i == 11)
                {
                    Spec.GetDriversHealth();
                    backgroundWorker.ReportProgress(11);
                }
                else if (i == 10)
                {
                    Spec.GetWirelessDevices();
                    backgroundWorker.ReportProgress(10);
                }
                else if (i == 9)
                {
                    Spec.GetOSinfo();
                    backgroundWorker.ReportProgress(9);
                }
                else if (i == 8)
                {
                    Spec.GetDiagonal();
                    backgroundWorker.ReportProgress(8);
                }
                else if (i == 7)
                {
                    Spec.GetGpuAndResolution();
                    backgroundWorker.ReportProgress(7);
                }
                else if (i == 6)
                {
                    Spec.GetOpticalDrive();
                    backgroundWorker.ReportProgress(6);
                }
                else if (i == 5)
                {
                    Spec.GetBatteryHealth();
                    backgroundWorker.ReportProgress(5);
                }
                else if (i == 4)
                {
                    Spec.GetRAM();
                    backgroundWorker.ReportProgress(4);
                }
                else if (i == 3)
                {
                    Spec.GetCPU();
                    backgroundWorker.ReportProgress(3);
                }
                else if (i == 2)
                {
                    Spec.GetSerialNumber();
                    backgroundWorker.ReportProgress(2);
                }
                else if (i == 1)
                {
                    Spec.GetManufacturer();
                    Spec.GetModel();
                    backgroundWorker.ReportProgress(1);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 12)
            {
                ConsoleWrite(@"# # # # # # # # # # # # # # # # Ready # # # # # # # # # # # # # # # # #");
            }
            else if (e.ProgressPercentage == 11)
            {
                TBox_driversStatus.Text=(Spec.DriversHealth == true)? " OK": " Warning!";
                TBox_driversStatus.ForeColor = (Spec.DriversHealth == true) ? Color.DarkGreen : Color.Goldenrod;
            }
            else if (e.ProgressPercentage == 10) { }

            else if (e.ProgressPercentage == 9)
            {
                TBox_os_build.Text = Spec.OsBuild;
                TBox_os_name.Text = Spec.OsName;
                TBox_os_language.Text = Spec.OsLanguages;
                TBox_os_language.ForeColor = (Spec.OsLanguages.Contains("PL")) ? Color.DarkGreen : Color.IndianRed;
            }
            else if (e.ProgressPercentage == 8)
            {
                TBox_diagonal.Text = Spec.Diagonal + @"""";
            }
                
            else if (e.ProgressPercentage == 7)
            {
                TBox_resname.Text = Spec.ResolutionName;
                TBox_resolution.Text = Spec.Resolution;
                TBox_gpu.Lines = Spec.GraphicCard.ToArray();
                if (TBox_gpu.Text.Contains("Microsoft"))
                    TBox_gpu.ForeColor = Color.PaleVioletRed;
            }
            else if (e.ProgressPercentage == 6)
            {
                TBox_optical.Text = Spec.OpticalDrive;
            }
            else if (e.ProgressPercentage == 5)
            {
                TBox_batteryHealth.Text = Spec.BatteryHealth+"%";
            }
            else if (e.ProgressPercentage == 4)
            {
                TBox_ram.Text = Spec.RamSum;
            }
            else if (e.ProgressPercentage == 3)
            {
                TBox_cpu.Text = Spec.CPU;
            }
            else if (e.ProgressPercentage == 2)
            {
                TBox_serial.Text = Spec.SerialNumber;
            }
            else if (e.ProgressPercentage == 1)
            {
                TBox_model.Text = Spec.ModelShort; TBox_FolderName.Text = Spec.ModelShort;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbWIFI.Checked = (Spec.WifiPresence == true) ? true : false;
            cbWWAN.Checked = (Spec.WwanPresence == true) ? true : false;
            cbBluetooth.Checked = (Spec.BluetoothPresence == true) ? true : false;
            cbCamera.Checked = (Spec.CameraPresence == true) ? true : false;
            cbFPR.Checked = (Spec.FingerPrintPresence == true) ? true : false;

            SetStatusStrip();

            //set battery Health Textbox
            if (int.TryParse(Spec.BatteryHealth, out int bat))
            {
                if (bat > 74)
                {
                    TBox_batteryHealth.ForeColor = Color.ForestGreen;
                }
                else if (bat > 60)
                {
                    TBox_batteryHealth.ForeColor = Color.DarkGreen;
                }
                else if (bat > 50)
                {
                    TBox_batteryHealth.ForeColor = Color.DarkGoldenrod;
                }
                else
                {
                    TBox_batteryHealth.ForeColor = Color.OrangeRed;
                }
                //starts timer thats show battery chare rate
                timerBattery.Enabled = true;
            }

            timer.Stop();
            ConsoleWrite("Load time: " + timer.ElapsedMilliseconds.ToString() + "ms");

        }
        #endregion

        #region Buttons

        #region Drivers 
        private void BTN_driverPack_Click(object sender, EventArgs e)
        {
            RunDriverPack(Path.DriversFolder + "\\" + TBox_FolderName.Text);
        }

        string fileSelectedFromList;

        private void BTN_RunSelectedinDataGrid_Click(object sender, EventArgs e)
        {
            try { Process.Start(Path.DriversFolder + "\\" + TBox_FolderName.Text + "\\" + fileSelectedFromList + ".exe"); }
            catch (Exception ex) { ConsoleWrite("!Drivers: " + ex.Message); }
        }
        #endregion

        #region Save
        private void btnCMARlog_Click(object sender, EventArgs e)
        {
            bool ValidateData()
            {
                bool validationLicence;
                bool validationSO;
                bool validationLog;
                //validate new licence
                if (String.IsNullOrWhiteSpace(TBox_newLicence.Text))
                    validationLicence = Validate_TBox(TBox_newLicence, "CMAR can't be empty.", false, true);
                else if (TBox_newLicence.Text.StartsWith("03") == false)
                    validationLicence = Validate_TBox(TBox_newLicence, "Incorrect CMAR licence.", false, true);
                else if (TBox_newLicence.Text.Count() < 13)
                    validationLicence = Validate_TBox(TBox_newLicence, "CMAR licence to short.", false, true);
                else
                    validationLicence = Validate_TBox(TBox_newLicence, "", true, false);

                //Validate so
                if (String.IsNullOrWhiteSpace(TBox_SO.Text))
                    validationSO = Validate_TBox(TBox_SO, "Set SO number.", false, true);
                else
                    validationSO = Validate_TBox(TBox_SO, "", true, false);

               

                if(MySQL.IsInTable("serial", "so_log", TBox_serial.Text)==false)
                {
                    btnSaveSO.BackColor = Color.DarkRed;
                    ConsoleWrite("!DataValidate: " + "Save spec first.");
                    validationLog = false;
                }
                else
                {
                    btnSaveSO.BackColor = Color.DarkOliveGreen;
                    validationLog = true;
                }

                if(validationLicence&& validationSO&& validationLog)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            if(ValidateData())
            {
                if(TBox_oldLicence.Text.Count() > 13)
                {
                    // Perform Old COA save 
                    if (MySQL.SaveCmarWithCoa(TBox_oldLicence.Text, TBox_newLicence.Text, TBox_SO.Text))
                    {
                        ConsoleWrite("@MySQL:CMAR saved to Old COA database.");
                        //update column new licence in main database and print status
                        ConsoleWrite(MySQL.UpdateValue("so_log", "new_licence", TBox_newLicence.Text, "serial", TBox_serial.Text));
                        btnCMARlog.Text = "Saved";
                        btnCMARlog.Enabled = false;
                    }
                    else
                    {
                        ConsoleWrite("!!MySQL: Licence has not been saved!");
                    }
                }
                else
                {
                    //validate device type
                    if (string.IsNullOrEmpty(CBox_DeviceType.Text))
                    {
                        CBox_DeviceType.BackColor = Color.DarkRed;
                        ConsoleWrite("!DataValidate: " + "Set device type.");
                    }
                    else
                    {
                        //perform no coa save 
                        if (MySQL.SaveCmarWithoutCoa(TBox_os_name.Text, CBox_DeviceType.Text, TBox_serial.Text, Spec.Manufacturer, TBox_model.Text, TBox_cpu.Text, TBox_newLicence.Text, TBox_SO.Text))
                        {
                            ConsoleWrite("@MySQL:CMAR saved to No COA database.");
                            //update column new licence in main database and print status
                            ConsoleWrite(MySQL.UpdateValue("so_log", "new_licence", TBox_newLicence.Text, "serial", TBox_serial.Text));
                            btnCMARlog.Text = "Saved";
                            btnCMARlog.Enabled = false;
                        }
                        else
                        {
                            ConsoleWrite("!!MySQL: Licence has not been saved!");
                        }

                        CBox_DeviceType.BackColor = Color.FromArgb(45, 45, 45);
                        CBox_DeviceType.ForeColor = Color.DarkOliveGreen;

                    }
                }
            }  
        }


        private void BtnSaveSO_Click(object sender, EventArgs e)
        {
            string hdd1Name;
            string hdd1Size;
            string hdd1Serial;
            string hdd2Name;
            string hdd2Size;
            string hdd2Serial;
            string gpu1;
            string gpu2;
            string bluetooth;
            string wifi;
            string camera;
            string fpr;
            // format some of specification data and save in new string
            void PrepareDataToSave()
            {


                try
                {
                    hdd1Name = TBox_HDDname.Lines[0];
                    hdd1Size = TBox_HDDsize.Lines[0];
                }
                catch (Exception)
                {
                    hdd1Name = "n/a";
                    hdd1Size = "n/a";
                }
                try
                {
                    hdd1Serial = hdd.HDDs[0].Serial;
                }
                catch (Exception)
                {
                    hdd1Serial = "n/a";
                }

                try
                {
                    hdd2Name = TBox_HDDname.Lines[1];
                    hdd2Size = TBox_HDDsize.Lines[1];
                }
                catch (Exception)
                {
                    hdd2Name = "n/a";
                    hdd2Size = "n/a";
                }
                try
                {
                    hdd2Serial = hdd.HDDs[1].Serial;
                }
                catch (Exception)
                {
                    hdd2Serial = "n/a";
                }

                try
                {
                    gpu1 = TBox_gpu.Lines[0];
                }
                catch (Exception)
                {

                    gpu1 = "n/a";
                }
                try
                {
                    gpu2 = TBox_gpu.Lines[1];
                }
                catch (Exception)
                {

                    gpu2 = "n/a";
                }


                SaveTab.Comments= TBox_comments.Text;

                bluetooth = (Spec.BluetoothPresence == true) ? "1" : "0";
                wifi = (Spec.WifiPresence == true) ? "1" : "0";
                camera = (Spec.CameraPresence == true) ? "1" : "0";
                fpr = (Spec.FingerPrintPresence == true) ? "1" : "0";
            }

            //Check if got all data required to save.
            bool AllDataReady()
            {
                //if any Text box with data used in save to database is empty return false
                 if (HasDataTextBox(TBox_RP, true) && HasDataTextBox(TBox_SO, true) &&
                HasDataTextBox(TBox_model, true) && HasDataTextBox(TBox_serial, true) &&
                HasDataTextBox(TBox_cpu, true) && HasDataTextBox(TBox_optical, true) &&
                HasDataTextBox(TBox_ram, true) && HasDataTextBox(TBox_diagonal, true) &&
                HasDataTextBox(TBox_resname, true) && HasDataTextBox(TBox_os_name, true) &&
                HasDataTextBox(TBox_os_build, true) && HasDataTextBox(TBox_gpu, true) &&
                HasDataTextBox(TBox_os_language, true) && HasDataTextBox(TBox_HDDname, true) &&
                HasDataTextBox(TBox_HDDsize, true))
                {
                  //  Not installed GPU driver returns false
                    foreach (var t in TBox_gpu.Lines)
                    {
                        if (t.Contains("Microsoft"))// Microsoft in gpu name indicates that driver has not been installed
                        {
                            ConsoleWrite("!!SpecSniffer: Install GPU driver before save!");
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if(AllDataReady())
            {
                PrepareDataToSave();
                //run sae to database and return string with status of save.
                string status = MySQL.SaveSpec(TBox_SO.Text, TBox_RP.Text, TBox_model.Text, TBox_cpu.Text, TBox_serial.Text, TBox_ram.Text,
                   hdd1Size, hdd1Name, hdd1Serial, hdd2Size, hdd2Name, hdd2Serial, TBox_optical.Text, gpu1, gpu2, TBox_resname.Text,
                   TBox_diagonal.Text, TBox_os_name.Text, TBox_os_build.Text, TBox_os_language.Text,
                   Spec.LicenceKey, LBox_Licence.Text, SaveTab.Comments, bluetooth, wifi, camera, fpr);
                    
                if (status.Contains("@MySQL"))
                {
                    ConsoleWrite(status);
                    btnSaveSO.Text = "Saved :)";
                    btnSaveSO.Enabled = false;
                }// if save to database succeeded
                else
                {
                    ConsoleWrite(status);
                }

                //Save last used settings (SO, RP comments etc.) if Pendrive is pluged in
                if (CheckForUSB())
                {
                    SaveTab.WriteSettings(TBox_SO.Text, TBox_RP.Text, SaveTab.Comments, LBox_Licence.Text);
                }
            }
        }

        #endregion

        #endregion

        #region Events

        #region Click buttons
        private void btnEditMode_Click(object sender, EventArgs e)
        {
            void ChangeEnableStatus(MetroFramework.Controls.MetroTextBox name)
            {
                if (name.ReadOnly == true)
                { name.ReadOnly = false; name.BackColor = Color.FromArgb(60, 60, 60); }
                else
                { name.ReadOnly = true; name.BackColor = Color.FromArgb(45, 45, 45); }
            }

            ChangeEnableStatus(TBox_model);
            ChangeEnableStatus(TBox_serial);
            ChangeEnableStatus(TBox_cpu);
            ChangeEnableStatus(TBox_ram);
            ChangeEnableStatus(TBox_optical);
            ChangeEnableStatus(TBox_diagonal);
            ChangeEnableStatus(TBox_resname);
            ChangeEnableStatus(TBox_os_name);
            ChangeEnableStatus(TBox_os_build);
            ChangeEnableStatus(TBox_os_language);
            ChangeEnableStatus(TBox_HDDsize);
            ChangeEnableStatus(TBox_HDDname);
            ChangeEnableStatus(TBox_gpu);

            cbCamera.Enabled = (cbCamera.Enabled == false) ? cbCamera.Enabled = true : cbCamera.Enabled = false;
            cbBluetooth.Enabled = (cbBluetooth.Enabled == false) ? cbBluetooth.Enabled = true : cbBluetooth.Enabled = false;
            cbWIFI.Enabled = (cbWIFI.Enabled == false) ? cbWIFI.Enabled = true : cbWIFI.Enabled = false;
            cbWWAN.Enabled = (cbWWAN.Enabled == false) ? cbWWAN.Enabled = true : cbWWAN.Enabled = false;
            cbFPR.Enabled = (cbFPR.Enabled == false) ? cbFPR.Enabled = true : cbFPR.Enabled = false;
        }



        private void btn_devmgr_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void btn_diskmgr_Click(object sender, EventArgs e)
        {
            Process.Start("diskmgmt.msc");
        }

        private void btn_control_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe");
        }

        private void btn_mount_Click(object sender, EventArgs e)
        {
            ConnectToNetworkFolder();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 1");
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 1");
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Process.Start("diskmgmt.msc");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            ConnectToNetworkFolder();
        }

        private void timerStatus_Tick_1(object sender, EventArgs e)
        {
            SetStatusStrip();
        }
        private void btnLCD_Click(object sender, EventArgs e)
        {
            LCDTest LCDTest = new LCDTest();
            LCDTest.Show();
        }

        private void btnCam_Click(object sender, EventArgs e)
        {
            if (CheckForUSB())
            {
                RunCam();
            }
            else
            {
                MetroMessageBox.Show(this, "\n\nPlug in USB and try again.", "No data to work with...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnMain_HDTune_Click(object sender, EventArgs e)
        {

            if (CheckForUSB())
                System.Diagnostics.Process.Start(Path.HDTunePro);
            else if (CheckForInternetConnection())
            {
                try { System.Diagnostics.Process.Start(Path.HDTuneProNet); }
                catch (Exception ex) { ConsoleWrite("!SpecSniffer: " + ex.Message); }
            }

        }

        private void btnMain_ShowKey_Click(object sender, EventArgs e)
        {
            if (CheckForUSB())
                System.Diagnostics.Process.Start(Path.ShowKeyPlus);
            else if (CheckForInternetConnection())
            {
                try { System.Diagnostics.Process.Start(Path.ShowKeyPlusNet); }
                catch (Exception ex) { ConsoleWrite("!SpecSniffer: " + ex.Message); }
            }

        }

        private void btnAudio_Click(object sender, EventArgs e)
        {
            if (CheckForUSB())
                AudioPlay();
            else
                MetroMessageBox.Show(this, "\n\nPlug in USB and try again.", "No data to work with...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnKeyboadTest_Click(object sender, EventArgs e)
        {
            if (CheckForUSB())
            {
                try { System.Diagnostics.Process.Start(Path.KeyboardTest); }
                catch (Exception ex) { ConsoleWrite("!SpecSniffer: " + ex.Message); }
            }
            else if (CheckForInternetConnection())
            {
                try { System.Diagnostics.Process.Start(Path.KeyboardTestNet); }
                catch (Exception ex) { ConsoleWrite("!SpecSniffer: " + ex.Message); }
            }
        }

        #endregion

        #region Main events

        private void KeyPreviewToFalseWhen_Enter(object sender, EventArgs e)
        {
            KeyPreview = (TBox_model.ReadOnly == false) ? false : true;
        }

        private void KeyPreviewToTrueWhen_Leave(object sender, EventArgs e)
        {
            if (KeyPreview == false)
                KeyPreview = true;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (Tab.SelectedTab == Tab.TabPages["tabDiagnostic"])
            {
                if (e.KeyCode == Keys.D1)
                    btnLCDtest.PerformClick();
                if (e.KeyCode == Keys.D2)
                    btnCamera.PerformClick();
                if (e.KeyCode == Keys.D3)
                    btnMic.PerformClick();
                if (e.KeyCode == Keys.D4)
                    btnAudio.PerformClick();
                if (e.KeyCode == Keys.D5)
                    btnHDTune.PerformClick();
                if (e.KeyCode == Keys.D6)
                    btnShowKey.PerformClick();
                if (e.KeyCode == Keys.D7)
                    btnKeyboadTest.PerformClick();
                if (e.KeyCode == Keys.F2)
                    Tab.SelectedTab = tabSMART;
                if (e.KeyCode == Keys.F3)
                    Tab.SelectedTab = tabDrivers;
                if (e.KeyCode == Keys.F4)
                    Tab.SelectedTab = tabSO;
                if (e.KeyCode == Keys.Escape)
                    this.Close();
                if (e.KeyCode == Keys.F8)
                    Process.Start("devmgmt.msc");
                if (e.KeyCode == Keys.F9)
                    Process.Start("diskmgmt.msc");
                if (e.KeyCode == Keys.F10)
                    Process.Start("control.exe");
                if (e.KeyCode == Keys.F11)
                    Process.Start("shutdown", "/r /t 1");
                if (e.KeyCode == Keys.F12)
                    Process.Start("shutdown", "/s /t 1");
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                    ConnectToNetworkFolder();
            }
            else if (Tab.SelectedTab == Tab.TabPages["tabDrivers"])
            {
                if (e.KeyCode == Keys.F5)
                    btnDrivers.PerformClick();
                if (e.KeyCode == Keys.F7)
                    btnRunSelected.PerformClick();

                if (e.KeyCode == Keys.F1)
                    Tab.SelectedTab = tabDiagnostic;
                if (e.KeyCode == Keys.F2)
                    Tab.SelectedTab = tabSMART;
                if (e.KeyCode == Keys.F4)
                    Tab.SelectedTab = tabSO;
                if (e.KeyCode == Keys.Escape)
                    this.Close();
                if (e.KeyCode == Keys.F8)
                    Process.Start("devmgmt.msc");
                if (e.KeyCode == Keys.F9)
                    Process.Start("diskmgmt.msc");
                if (e.KeyCode == Keys.F10)
                    Process.Start("control.exe");
                if (e.KeyCode == Keys.F11)
                    Process.Start("shutdown", "/r /t 1");
                if (e.KeyCode == Keys.F12)
                    Process.Start("shutdown", "/s /t 1");
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                    ConnectToNetworkFolder();
            }

            else if (Tab.SelectedTab == Tab.TabPages["tabSMART"])
            {
                if (e.KeyCode == Keys.F1)
                    Tab.SelectedTab = tabDiagnostic;
                if (e.KeyCode == Keys.F2)
                    CBSMART_Disk.Focus();
                if (e.KeyCode == Keys.F3)
                    Tab.SelectedTab = tabDrivers;
                if (e.KeyCode == Keys.F4)
                    Tab.SelectedTab = tabSO;
                if (e.KeyCode == Keys.Escape)
                    this.Close();
                if (e.KeyCode == Keys.F8)
                    Process.Start("devmgmt.msc");
                if (e.KeyCode == Keys.F9)
                    Process.Start("diskmgmt.msc");
                if (e.KeyCode == Keys.F10)
                    Process.Start("control.exe");
                if (e.KeyCode == Keys.F11)
                    Process.Start("shutdown", "/r /t 1");
                if (e.KeyCode == Keys.F12)
                    Process.Start("shutdown", "/s /t 1");
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                    ConnectToNetworkFolder();
            }

            else if (Tab.SelectedTab == Tab.TabPages["tabSO"])
            {
                if (e.KeyCode == Keys.F5)
                    btnSaveSO.PerformClick();
                if (e.KeyCode == Keys.F7)
                    btnCMARlog.PerformClick();

                if (e.KeyCode == Keys.F1)
                    Tab.SelectedTab = tabDiagnostic;
                if (e.KeyCode == Keys.F2)
                    Tab.SelectedTab = tabSMART;
                if (e.KeyCode == Keys.F3)
                    Tab.SelectedTab = tabDrivers;
                if (e.KeyCode == Keys.Escape)
                    this.Close();
                if (e.KeyCode == Keys.F8)
                    Process.Start("devmgmt.msc");
                if (e.KeyCode == Keys.F9)
                    Process.Start("diskmgmt.msc");
                if (e.KeyCode == Keys.F10)
                    Process.Start("control.exe");
                if (e.KeyCode == Keys.F11)
                    Process.Start("shutdown", "/r /t 1");
                if (e.KeyCode == Keys.F12)
                    Process.Start("shutdown", "/s /t 1");
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                    ConnectToNetworkFolder();
            }

            else
            {
                if (e.KeyCode == Keys.Escape)
                    this.Close();
                if (e.KeyCode == Keys.F8)
                    Process.Start("devmgmt.msc");
                if (e.KeyCode == Keys.F9)
                    Process.Start("diskmgmt.msc");
                if (e.KeyCode == Keys.F10)
                    Process.Start("control.exe");
                if (e.KeyCode == Keys.F11)
                    Process.Start("shutdown", "/r /t 1");
                if (e.KeyCode == Keys.F12)
                    Process.Start("shutdown", "/s /t 1");
                if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
                    ConnectToNetworkFolder();
            }
        }
        //shows if battery is charging
        private void timerBattery_Tick(object sender, EventArgs e)
        {


            Spec.GetBatteryEstimatedCharge();
            TBox_batteryPower.Text = Spec.EstimatedChargeRemaining + "%";
            Spec.GetBatteryChargeRate();

            TBox_batteryCharging.Text = Spec.ChargeRate;
            if (TBox_batteryCharging.Text.Contains("-"))
            {
                TBox_batteryCharging.ForeColor = Color.PaleVioletRed;
            }
            else if (TBox_batteryCharging.Text == "null")
            {
                TBox_batteryCharging.ForeColor = Color.DimGray;

            }
            else
            {
                TBox_batteryCharging.ForeColor = Color.DarkGreen;
            }
        }
        private void StatusInternet_TextChanged(object sender, EventArgs e)
        {
            if (StatusInternet.Text == "on")
            {

                //    Connect to mysql and set status strip
                string mysqlRaport = MySQL.Connect();
                ConsoleWrite(mysqlRaport);
                if(mysqlRaport.Contains("Connected to server"))
                {
                    statusMySQL.Text = "on";
                    statusMySQL.ForeColor = Color.MediumSpringGreen;
                }
                else
                {
                    statusMySQL.Text = "off";
                    statusMySQL.ForeColor = Color.IndianRed;
                }
                //connect to network folder
                if (!CheckForNetworkFolder())
                    ConnectToNetworkFolder();

                //check program version
                try
                {
                    int desiredVer = Int32.Parse(File.ReadLines(Path.CurrentVerFile).First());

                    if (Settings.currentVer < desiredVer)
                    {
                        MessageBox.Show("You are running an outdated version of SpecSniffer.\n\nProgram will close now.");
                        this.Close();
                    }
                    else if (Settings.currentVer >= desiredVer)
                    {
                        ConsoleWrite("@SpecSniffer: You are running recommended program version.");
                    }
                }
                catch { }
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update spec after enter tab
            if (Tab.SelectedTab == Tab.TabPages["tabSO"])
            {

                if (TBox_gpu.Text.Contains("Microsoft"))
                {
                    Spec.GetGpuAndResolution();
                    TBox_gpu.Lines = Spec.GraphicCard.ToArray();
                    if ((TBox_gpu.Text.Contains("Microsoft")))
                        TBox_gpu.ForeColor = Color.PaleVioletRed;
                    else
                        TBox_gpu.ForeColor = Color.DarkGreen;
                }
                if (cbFPR.Checked == false)
                {
                    Spec.GetFingerprint();
                    cbFPR.Checked = Spec.FingerPrintPresence;
                }
                if (cbBluetooth.Checked == false || cbWWAN.Checked == false)
                {
                    Spec.GetWirelessDevices();
                    cbBluetooth.Checked = Spec.BluetoothPresence;
                    cbWWAN.Checked = Spec.WwanPresence;
                }

                Spec.GetDriversHealth();
                if (Spec.DriversHealth == true)
                {
                    TBox_driversStatus.Text = "OK";
                    TBox_driversStatus.ForeColor = Color.DarkGreen;
                }
                else
                {
                    TBox_driversStatus.Text = " Warning!";
                    TBox_driversStatus.ForeColor = Color.Goldenrod;
                }

            }

            else if (Tab.SelectedTab == Tab.TabPages["tabDrivers"])
            {

                TBox_FolderName.Focus();
                ListFoldersInDirectory();
                ShowFilesInFolder(Path.DriversFolder + "\\" + TBox_FolderName.Text);
                cb_DriverPackList.SelectedIndex = cb_DriverPackList.FindString(Spec.ModelShort);
            }

            else if (Tab.SelectedTab == Tab.TabPages["tabSMART"])
            {
                foreach (var diskName in hdd.HDDs)
                    CBSMART_Disk.Items.Add(diskName.Value.Model);
            }
        }

        #endregion

        #region Drivers

        private void cb_DriverPackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBox_FolderName.Text = cb_DriverPackList.Text;
        }

        /// <summary>
        /// Run method to list all files in given folder and change Tbox_folderName forecolor dependly on methods return.
        /// </summary>
        private void TBox_FolderName_TextChanged(object sender, EventArgs e)
        {
            if (CheckForNetworkFolder())
                TBox_FolderName.ForeColor = (ShowFilesInFolder(Path.DriversFolder + "\\" + TBox_FolderName.Text)) ? Color.DarkGreen : Color.IndianRed;


        }

        /// <summary>
        /// Gets name of selected file in data grid.
        /// </summary>
        /// <param fileSelectedFromList=item.ToString();>selected file text is stored in this string</param>
        private void SelectedFileName_cellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var item = dataGridFileList.Rows[e.RowIndex].Cells[0].Value;
                fileSelectedFromList = item.ToString();
            }
            catch (Exception) { ConsoleWrite("!Drivers: Cell enter error."); }
        }

        private void DataGrid_drivers_DoubleClick(object sender, EventArgs e)
        {
            btnRunSelected.PerformClick();
        }
        #endregion
                
        #region Save
        #region Change colors back to grey

        private void TBox_RP_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Text))
                TBox_RP.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void TBox_SO_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Text))
                TBox_SO.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void TBox_newCMAR_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Text))
                TBox_newLicence.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void CBox_DeviceType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Text))
                CBox_DeviceType.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void CBox_Licence_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Text))
                LBox_Licence.BackColor = Color.FromArgb(45, 45, 45);
        }
        #endregion
        #region change color after enter textboxes

        private void TBSO_SO_Enter(object sender, EventArgs e) { TBox_SO.ForeColor = Color.Gainsboro; }
        private void TBSO_RP_Enter(object sender, EventArgs e) { TBox_RP.ForeColor = Color.Gainsboro; }
        private void TBSO_Comments_Enter(object sender, EventArgs e) { TBox_comments.ForeColor = Color.Silver; }

        #endregion
        /// <summary>
        /// Set CBox_DeviceType to not visable if old coa has been entered
        /// </summary>
        private void TBox_oldCOA_Leave(object sender, EventArgs e)
        {
            if (TBox_oldLicence.Text.Count() > 13) { CBox_DeviceType.Visible = false; }
            else { CBox_DeviceType.Visible = true; }
        }

        #endregion

        #region SMART
        private void CBSMART_Disk_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var smart in hdd.HDDs)
                if (CBSMART_Disk.Text == smart.Value.Model)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var att in smart.Value.Attributes)
                        if (att.Value.HasData)
                            dataGridView1.Rows.Add(att.Value.Attribute, att.Value.Current, att.Value.Worst, att.Value.Threshold, att.Value.Data);
                }
        }
        #endregion

        #endregion


    }
}
