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

       ///// <summary>
       ///// Save SO, RP licence and comments if USB is plugged in
       ///// </summary>
       // private void SaveLastKnownSettings()
       // {
       //     if (CheckForUSB())
       //     {
       //         StringBuilder sbSettings = new StringBuilder();
       //         string saveStr = String.Format("{0};{1};{2};{3};{4};{5};{6}",
       //             TBox_RP.Text,
       //             TBox_SO.Text, (CheckB_SO.Checked) ? "t" : "f",
       //             LBox_Licence.Text, (CheckB_Licence.Checked) ? "t" : "f",
       //             TBox_comments.Text.Replace("\r\n", "/").Replace(";", "/"), (CheckB_comments.Checked) ? "t" : "f");
       //         sbSettings.AppendLine(saveStr);
       //         try
       //         {
       //             File.WriteAllText(Path.SoSettings, string.Empty);
       //             File.AppendAllText(Path.SoSettings, sbSettings.ToString());
       //         }
       //         catch (Exception ex)
       //         {
       //             ConsoleWrite("Settings not saved. " + ex.Message);
       //         }
       //     }

       // }

        MySqlConnection connMySQL = null;
        /// <summary>
        /// Connect to MySQL server. Properties are edited in Settings class.
        /// </summary>
        private void ConnectToMySQL()
        {
            string connStr = "SERVER=" + Settings.server + ";PORT=" + Settings.port + ";USERID=" + Settings.userID + ";PASSWORD=" + Settings.dbPSWD + ";DATABASE=" + Settings.database +
            ";Connection Timeout=3;";
            try
            {
                connMySQL = new MySqlConnection(@connStr);
                connMySQL.Open();
                statusMySQL.Text = "on";
                statusMySQL.ForeColor = Color.MediumSpringGreen;
            }
            catch (Exception ex)
            {
                ConsoleWrite("MySQL connection errror. "+ex.Message);
            }
            finally
            {
                if (connMySQL != null)
                    connMySQL.Close(); //Closes DB connection.
            }
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

        /// <summary>
        /// Search for given value in specific mySQL database
        /// </summary>
        /// <param name="column">MySQL colummn name</param>
        /// <param name="table">MySQL table name</param>
        /// <param name="value">value to inset into MySQL table</param>
        /// <param name="msg"></param>
        /// <returns>0=error, 1= value found 2=value not found</returns>
        private bool IsValueInDB(string column, string table, string value, bool dataMsg, bool noDataMsg)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connMySQL;
            cmd.CommandText = String.Format("SELECT {0} FROM {1} WHERE {0} = @value ORDER BY id DESC LIMIT 1", column, table);
            cmd.Parameters.AddWithValue("@value", value);
            try
            {
                connMySQL.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    if (dataMsg)
                    {
                        DialogResult dialogResult = MessageBox.Show(String.Format(
                        "{0} '{1}' already exist's in {2} database.\nAdd anyway?", column.ToUpper(), value.ToUpper(), table.ToUpper()), "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes) { return false; }
                        else if (dialogResult == DialogResult.No) { return true; }
                        else { return true; }
                    }
                    else { return true; }
                }
                else
                {
                    if (noDataMsg)
                    {
                        DialogResult dialogResult = MessageBox.Show("Serial not found in SO database.\nIf this PC is for SO\nclick 'Yes', make SO log and try again.\n\n" +
                                                                    "To cancel and save CMAR anyway click 'No'.", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No) { return true; }
                        else { return false; }
                    }
                    else { return false; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IsValueInDB error: " + ex.Message);
                return false;
            }
            finally { if (connMySQL != null) { connMySQL.Close(); } }

        }

        /// <summary>
        /// Update last row in MySQL database. Used to add licence number of existing in database model.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="updateColumn"></param>
        /// <param name="newValue"></param>
        /// <param name="searchColumn"></param>
        /// <param name="searchValue"></param>
        private void MySQL_UpdateValue(string table, string updateColumn, string newValue, string searchColumn, string searchValue)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connMySQL;
            cmd.CommandText = String.Format("UPDATE {0} SET {1} = @newValue WHERE {2} = @searchValue ORDER BY id DESC LIMIT 1", table, updateColumn, searchColumn);
            cmd.Parameters.AddWithValue("@newValue", newValue);
            cmd.Parameters.AddWithValue("@searchValue", searchValue);
            try
            {
                connMySQL.Open();
                cmd.ExecuteNonQuery();
                ConsoleWrite(String.Format("@MySQLUpdate: PC identificated by {0} has been updated with value {1} on column {2}", searchValue, newValue, updateColumn));
            }
            catch (Exception ex)
            {
                ConsoleWrite("!MySQLUpdate: Error " + ex.Message);
                ConsoleWrite("!MySQLUpdate: Couldn't update value...");
            }
            finally
            {
                if (connMySQL != null)
                    connMySQL.Close();
            }
        }

       

        #region Validate Save Textbox's
        private bool ValidateTB(MetroFramework.Controls.MetroTextBox tBox, bool sendMsg)
        {
            if (!String.IsNullOrWhiteSpace(tBox.Text))
            {
                tBox.BackColor = Color.FromArgb(45, 45, 45);
                tBox.ForeColor = Color.DarkOliveGreen;
                return true;
            }
            else
            {
                tBox.BackColor = Color.DarkRed;
                if (sendMsg) { ConsoleWrite("!DataValidate: " + tBox.Tag + " can't be null."); }
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
        private bool ValidateCMAR(bool sendMsg)
        {
            if (String.IsNullOrWhiteSpace(TBox_newLicence.Text))
                return Validate_TBox(TBox_newLicence, "CMAR cant be null.", false, sendMsg);
            else if (TBox_newLicence.Text.StartsWith("03") == false)
                return Validate_TBox(TBox_newLicence, "Incorrect CMAR licence.", false, sendMsg);
            else if (TBox_newLicence.Text.Count() < 13)
                return Validate_TBox(TBox_newLicence, "CMAR licence to short.", false, sendMsg);
            else
                return Validate_TBox(TBox_newLicence, "", true, sendMsg);
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
        private void CBox_Licence_Validating(object sender, CancelEventArgs e) { ValidateLicence(); }
        private bool ValidateDevice()
        {
            if (String.IsNullOrEmpty(CBox_DeviceType.Text))
            {
                CBox_DeviceType.BackColor = Color.DarkRed;
                ConsoleWrite("!DataValidate: Select valid licence.");
                return false;
            }
            else
            {
                CBox_DeviceType.BackColor = Color.FromArgb(45, 45, 45);
                CBox_DeviceType.BackColor = Color.DarkOliveGreen;
                return true;
            }
        }
        private void TBox_newCMAR_Validating(object sender, CancelEventArgs e) { ValidateCMAR(false); }
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


            //Load & apply last settings
            SaveTab.ReadLastSettings();
            TBox_RP.Text = SaveTab.Rep;
            TBox_SO.Text = SaveTab.SaleOrderId;
            LBox_Licence.Text = SaveTab.Licence;


            //set hdd info TextBoxses
            TBox_HDDsize.Lines = hdd.HDDs.Select(m => m.Value.Size).ToArray();
            TBox_HDDname.Lines = hdd.HDDs.Select(m => m.Value.Model).ToArray();
            TBox_HDDstatus.Lines = hdd.HDDs.Select(m => m.Value.IsOK).ToArray();
            if (TBox_HDDstatus.Text.Contains("Fail"))
                TBox_HDDstatus.ForeColor = Color.PaleVioletRed;

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
            void NoCoaSave()
            {
                try
                {
                    connMySQL.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connMySQL;
                    cmd.CommandText = String.Format("INSERT INTO tpr_no_coa" +
                              "( os_name, device_type, serial, manufacturer, model, cpu, new_mar, so) " +
                        "VALUES(@os_name,@device_type,@serial,@manufacturer,@model,@cpu,@new_mar,@so)");//Prepare placeholder statement.

                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@os_name", TBox_os_name.Text);
                    cmd.Parameters.AddWithValue("@device_type", CBox_DeviceType.Text);
                    cmd.Parameters.AddWithValue("@serial", TBox_serial.Text);
                    cmd.Parameters.AddWithValue("@manufacturer", Spec.Manufacturer);
                    cmd.Parameters.AddWithValue("@model", TBox_model.Text);
                    cmd.Parameters.AddWithValue("@cpu", TBox_cpu.Text);
                    cmd.Parameters.AddWithValue("@new_mar", TBox_newLicence.Text);
                    cmd.Parameters.AddWithValue("@so", TBox_SO.Text);

                    cmd.ExecuteNonQuery();

                    ConsoleWrite("");
                    ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");
                    ConsoleWrite(@"# # # # # # # # # # CMAR loged in no coa database # # # # # # # # # #");
                    ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");
                    btnCMARlog.Enabled = false;
                    btnCMARlog.Text = "done";
                }
                catch (Exception ex) { ConsoleWrite("!CMARsave: " + ex.Message); }
                finally
                {
                    if (connMySQL != null)
                        connMySQL.Close();
                }
            }
            void OldCoaSave()
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connMySQL;
                    cmd.CommandText = String.Format("INSERT INTO tpr_old_coa (old_licence,new_mar,so) VALUES (@old_licence,@new_mar,@so)");
                    connMySQL.Open();

                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@old_licence", TBox_oldLicence.Text);
                    cmd.Parameters.AddWithValue("@new_mar", TBox_newLicence.Text);
                    cmd.Parameters.AddWithValue("@so", TBox_SO.Text);
                    cmd.ExecuteNonQuery();

                    ConsoleWrite("");
                    ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");
                    ConsoleWrite(@" # # # # # # # # # CMAR loged in OLD COA database # # # # # # # # # #");
                    ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");
                    btnCMARlog.Enabled = false;
                    btnCMARlog.Text = "done";

                }
                catch (Exception ex) { ConsoleWrite("!CMARsave: " + ex.Message); }
                finally
                {
                    if (connMySQL != null)
                        connMySQL.Close();
                }
            }

            if (ValidateSO(true) && ValidateCMAR(true) && IsValueInDB("serial", "so_log", TBox_serial.Text, false, true))
                if (TBox_oldLicence.Text.Count() > 13) { OldCoaSave(); MySQL_UpdateValue("so_log", "new_licence", TBox_newLicence.Text, "serial", TBox_serial.Text); }
                else if (ValidateDevice()) { NoCoaSave(); MySQL_UpdateValue("so_log", "new_licence", TBox_newLicence.Text, "serial", TBox_serial.Text); }

        }

        private void ServerSave_Click(object sender, EventArgs e)
        {
            void SaveSpec()
            {
                int errorCode = 0;
                string hdd1Size;
                string hdd1Model;
                string hdd1Serial = "";
                string hdd2Size;
                string hdd2Model;
                string hdd2Serial = "";
                string gpu1;
                string gpu2;
                string comments;
                string bluetooth;
                string wifi;
                string camera;
                string fpr;

                #region prepare data to save
                bluetooth = (Spec.BluetoothPresence == true) ? "1" : "0";
                wifi = (Spec.WifiPresence == true) ? "1" : "0";
                camera = (Spec.CameraPresence == true) ? "1" : "0";
                fpr = (Spec.FingerPrintPresence == true) ? "1" : "0";

                try { hdd1Size = TBox_HDDsize.Lines[0]; } catch (Exception) { errorCode = 1; goto noData; }

                try { hdd1Model = TBox_HDDname.Lines[0]; } catch (Exception) { errorCode = 1; goto noData; }

                try { hdd1Serial = hdd.HDDs[0].Serial; }
                catch (Exception)
                {
                    DialogResult dialogResult = MessageBox.Show("Couldn't read SERIAL NUMBER for disk 1.\nClick Yes if You want save spec anyway(without SN)\nClick No if You want abort save.", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) { hdd1Serial = "NoSerial"; }
                    else if (dialogResult == DialogResult.No)
                    {
                        errorCode = 1;
                        goto noData;
                    }
                }

                try { hdd2Size = TBox_HDDsize.Lines[1]; } catch (Exception) { hdd2Size = "noHDD2"; }

                try { hdd2Model = TBox_HDDname.Lines[1]; } catch (Exception) { hdd2Model = "noHDD2"; }

                try { hdd2Serial = hdd.HDDs[1].Serial; } catch (Exception) { hdd2Serial = "noHDD2"; }

                try
                {
                    gpu1 = TBox_gpu.Lines[0];
                    if (gpu1.Contains("Microsoft")) { errorCode = 2; goto noGPUdriver; }
                }
                catch (Exception) { errorCode = 1; goto noData; }

                try
                {
                    gpu2 = TBox_gpu.Lines[1];
                    if (gpu2.Contains("Microsoft")) { errorCode = 2; goto noGPUdriver; }
                }
                catch (Exception) { gpu2 = "noGPU2"; }

                comments = TBox_comments.Text;
                if (!String.IsNullOrWhiteSpace(TBox_comments.Text))
                {
                    comments = TBox_comments.Text;
                    comments = comments.Replace(";", "/");
                    comments = comments.Replace("\r\n", "/");
                }
                else { comments = "n/a"; }
                #endregion
                if (btnServerSave.Enabled == true)
                {
                    try
                    {
                        connMySQL.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connMySQL;

                        cmd.CommandText = String.Format("INSERT INTO so_log" +
                    "( so, rp, model,cpu, serial, ram, hdd1_size, hdd1_model, hdd1_serial,  hdd2_size, hdd2_model, hdd2_serial, optical, gpu1, gpu2, resname, diagonal, os_name, os_build, os_language, os_key, os_label, comments, bluetooth, wifi, camera, fpr) VALUES" +
                    "(@so,@rp,@model,@cpu,@serial,@ram,@hdd1_size,@hdd1_model,@hdd1_serial,@hdd2_size,@hdd2_model,@hdd2_serial,@optical,@gpu1,@gpu2,@resname,@diagonal,@os_name,@os_build,@os_language,@os_key,@os_label,@comments,@bluetooth,@wifi,@camera,@fpr)");
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@so", TBox_SO.Text);
                        cmd.Parameters.AddWithValue("@rp", TBox_RP.Text);
                        cmd.Parameters.AddWithValue("@model", TBox_model.Text);
                        cmd.Parameters.AddWithValue("@cpu", TBox_cpu.Text);
                        cmd.Parameters.AddWithValue("@serial", TBox_serial.Text);
                        cmd.Parameters.AddWithValue("@ram", TBox_ram.Text);

                        cmd.Parameters.AddWithValue("@hdd1_size", hdd1Size);
                        cmd.Parameters.AddWithValue("@hdd1_model", hdd1Model);
                        cmd.Parameters.AddWithValue("@hdd1_serial", hdd1Serial);
                        cmd.Parameters.AddWithValue("@hdd2_size", hdd2Size);
                        cmd.Parameters.AddWithValue("@hdd2_model", hdd2Model);
                        cmd.Parameters.AddWithValue("@hdd2_serial", hdd2Serial);

                        cmd.Parameters.AddWithValue("@optical", TBox_optical.Text);
                        cmd.Parameters.AddWithValue("@gpu1", gpu1);
                        cmd.Parameters.AddWithValue("@gpu2", gpu2);

                        cmd.Parameters.AddWithValue("@resname", TBox_resname.Text);
                        cmd.Parameters.AddWithValue("@diagonal", TBox_diagonal.Text);
                        cmd.Parameters.AddWithValue("@os_name", TBox_os_name.Text);
                        cmd.Parameters.AddWithValue("@os_build", TBox_os_build.Text);

                        cmd.Parameters.AddWithValue("@os_language", TBox_os_language.Text);
                        cmd.Parameters.AddWithValue("@os_key", Spec.LicenceKey);
                        cmd.Parameters.AddWithValue("@os_label", LBox_Licence.Text);
                        cmd.Parameters.AddWithValue("@comments", comments);

                        cmd.Parameters.AddWithValue("@bluetooth", bluetooth);
                        cmd.Parameters.AddWithValue("@wifi", wifi);
                        cmd.Parameters.AddWithValue("@camera", camera);
                        cmd.Parameters.AddWithValue("@fpr", fpr);

                        cmd.ExecuteNonQuery();

                        ConsoleWrite("");
                        ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");
                        ConsoleWrite(@"# # # # # # # # # # # # # Sale Order No. " + TBox_SO.Text + " # # # # # # # # # # # #");
                        ConsoleWrite(@"# # # # # # # # # # Successfully Logged in Database # # # # # # # # #");
                        ConsoleWrite(@"# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #");

                        btnServerSave.Enabled = false;
                        btnServerSave.Text = "done";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { if (connMySQL != null) { connMySQL.Close(); } }
                } //save to DB

                noData:
                if (errorCode == 1) { MessageBox.Show("Log has not been made!\nCause:\nNot all fields contains data. "); }

                noGPUdriver:
                if (errorCode == 2) { MessageBox.Show("Log has not been made!\nCause:\nGPU driver not installed. "); }
            }

            if (ValidateTB(TBox_RP, true) && ValidateTB(TBox_SO, true) && ValidateTB(TBox_model, true) && ValidateTB(TBox_serial, true) && ValidateTB(TBox_cpu, true) && ValidateTB(TBox_optical, true) && ValidateTB(TBox_ram, true) && ValidateTB(TBox_diagonal, true)
                && ValidateTB(TBox_resname, true) && ValidateTB(TBox_os_name, true) && ValidateTB(TBox_os_build, true) && ValidateTB(TBox_gpu, true) && ValidateTB(TBox_os_language, true) && ValidateTB(TBox_HDDname, true) && ValidateTB(TBox_HDDsize, true)
                && ValidateLicence())
            {
                SaveSpec();
               // SaveLastKnownSettings();
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
                    btnServerSave.PerformClick();
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
                // connect to MySQL server
                if (connMySQL == null)
                    ConnectToMySQL();

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
