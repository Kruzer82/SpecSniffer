using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

namespace SpecSniffer
{
    public static class Spec
    {
        public static string Manufacturer { get; private set; }
        public static string ModelFull { get; private set; }
        public static string ModelShort { get; private set; }
        public static string SerialNumber { get; private set; }
        public static string CPU { get; private set; }
        public static List<byte> Ram { get; private set; }
        public static string RamSum { get; private set; }
        public static string OpticalDrive { get; private set; }
        public static List<string> GraphicCard { get; private set; }
        public static string Resolution { get; private set; }
        public static string ResolutionName { get; private set; }
        public static string Diagonal { get; private set; }
        public static string OsName { get; private set; }
        public static string OsBuild { get; private set; }
        public static string OsLanguages { get; private set; }
        public static string LicenceKey { get; private set; }
        public static string BatteryHealth { get; private set; }
        public static bool WwanPresence { get; private set; }
        public static bool WifiPresence { get; set; } //Set when connected to AP
        public static bool CameraPresence { get; set; } //Set when received camera image
        public static bool BluetoothPresence { get; private set; }
        public static bool FingerPrintPresence { get; private set; }
        public static bool DriversHealth { get; private set; }
        public static string EstimatedChargeRemaining { get; private set; }
        public static string ChargeRate { get; private set; }



         
        //Displays charge/discharge rate of battery
        public static void GetBatteryChargeRate()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\WMI", "SELECT ChargeRate, Charging,Discharging, DischargeRate  FROM BatteryStatus").Get())
                {
                    if ((bool)Obj["Charging"] == true)
                    {
                        ChargeRate = Obj["ChargeRate"].ToString();
                        break;
                    }
                    else if ((bool)Obj["Discharging"] == true)
                    {
                        ChargeRate = "-" + Obj["DischargeRate"].ToString();
                        break;
                    }
                    else
                    {
                        ChargeRate = "null";
                    }
                }
            }
            catch { }
        }
        //Displays battery estimated charge in %. 
        public static void GetBatteryEstimatedCharge()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT EstimatedChargeRemaining  FROM Win32_Battery").Get())
                {
                    // Availability = Obj["Availability"].ToString();
                    //  BatteryStatus = Obj["BatteryStatus"].ToString();
                    EstimatedChargeRemaining = Obj["EstimatedChargeRemaining"].ToString();
                    // EstimatedRunTime = Obj["EstimatedRunTime"].ToString();
                    break;
                }
                //when battery is full wmi can show values over 100%. Fixing it here
                if(Int32.TryParse(EstimatedChargeRemaining, out int charge))
                {
                    EstimatedChargeRemaining = (charge > 100) ? "100" : EstimatedChargeRemaining;
                }
            }
            catch { }
        }

        public static void GetDriversHealth()
        {
            //false if driver dont have state 0
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT ConfigManagerErrorCode FROM  Win32_PnPEntity").Get())
                {
                    if ((UInt32)Obj["ConfigManagerErrorCode"] != 0) //22-Device is disabled.
                    {
                        DriversHealth = false;
                        break;
                    }
                    else
                    {
                        DriversHealth = true;
                    }
                }
            }
            catch { }
        }

        public static void GetFingerprint()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT PNPClass FROM  Win32_PnPEntity  WHERE PNPClass='BIOMETRIC'").Get())
                    FingerPrintPresence = true;
            }
            catch { }
            //some of Dell models display FPR in different class
            if (FingerPrintPresence == false)
            {
                try
                {
                    foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT PNPClass,Description FROM  Win32_PnPEntity WHERE PNPClass='CVAULT'").Get())
                    {
                        if (((string)Obj["Description"]).Contains("w/ Fingerprint"))
                        {
                            FingerPrintPresence = true;
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        public static void GetWirelessDevices()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\StandardCimv2", "SELECT NdisPhysicalMedium FROM MSFT_NetAdapter").Get())
                {
                    if ((UInt32)Obj["NdisPhysicalMedium"] == 8) //wwan
                        WwanPresence = true;

                    else if ((UInt32)Obj["NdisPhysicalMedium"] == 10) //bluetooth
                        BluetoothPresence = true;
                }

            }
            catch { }
            if (BluetoothPresence == false)
            {
                try
                {
                    foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT PNPClass FROM  Win32_PnPEntity  WHERE PNPClass='Bluetooth'").Get())
                        BluetoothPresence = true;
                }
                catch { }
            }

        }

        public static void GetBatteryHealth()// slow query response (~180ms)
        {
            //HP dont save battery health info in WMI.
            if(!Manufacturer.Contains("HEWLETT-PACKARD"))
            {
                UInt32 designedCapacity = 000;
                UInt32 currentCapacity = 000;
                try
                {
                    foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\WMI", "SELECT DesignedCapacity FROM BatteryStaticData").Get())
                    {
                        designedCapacity = (UInt32)(Obj["DesignedCapacity"]);
                        break;
                    }

                    foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\WMI", "SELECT FullChargedCapacity FROM BatteryFullChargedCapacity").Get())
                    {
                        currentCapacity = (UInt32)(Obj["FullChargedCapacity"]);
                        break;
                    }

                    BatteryHealth = ((currentCapacity * 100) / designedCapacity).ToString();
                }
                catch (Exception) { BatteryHealth = ""; }
            }
            else
            {
                BatteryHealth = "n/a";
            }
        }

        public static void GetLicenceKey() // slow query response (~172ms)
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT OA3xOriginalProductKey FROM SoftwareLicensingService").Get())
                    LicenceKey = (string)Obj["OA3xOriginalProductKey"];
            }
            catch (Exception) { LicenceKey = "WMI_Error"; }
        }

        public static void GetOSinfo()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT Buildnumber,Caption,MUILanguages FROM Win32_OperatingSystem").Get())
                {
                    OsBuild = (string)Obj["buildnumber"];
                    OsName = (string)Obj["Caption"];
                    OsLanguages = string.Join("/", (String[])(Obj["MUILanguages"]));
                }
            }
            catch (Exception) { OsBuild = "WMI_Error"; OsName = "WMI_Error"; OsLanguages = "WMI_Error"; }
        }

        public static void GetDiagonal()
        {
            List<double> listaPrzekatnych = new List<double>
            { 10.1, 11.6, 12, 12.5, 14, 15.6, 17.3, 18, 19, 20, 20.1, 21, 21.3, 22, 22.2, 23, 24, 26, 27 };
            double przekatna = 0;
            double wysokosc = 0;
            double szerokosc = 0;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\root\\wmi", "SELECT * FROM WmiMonitorBasicDisplayParams");
                foreach (ManagementObject ask in searcher.Get())
                {
                    szerokosc = (byte)ask["MaxHorizontalImageSize"] / 2.54;
                    wysokosc = (byte)ask["MaxVerticalImageSize"] / 2.54;
                }

                if (szerokosc > 0)
                {
                    przekatna = Math.Sqrt(szerokosc * szerokosc + wysokosc * wysokosc);
                    Diagonal = listaPrzekatnych.Aggregate((x, y) => Math.Abs(x - przekatna) < Math.Abs(y - przekatna) ? x : y).ToString();
                }
            }
            catch { Diagonal = "WMI_Error"; }
        }

        public static void GetGpuAndResolution()
        {
            GraphicCard = new List<string>();
            try
            {

                ManagementObjectSearcher GPUsearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption FROM Win32_VideoController");

                foreach (ManagementObject gpu in GPUsearcher.Get())
                {
                    GraphicCard.Add((string)gpu["Caption"]);
                }

                GPUsearcher.Query = new ObjectQuery("SELECT CurrentHorizontalResolution,CurrentVerticalResolution FROM Win32_VideoController");
                foreach (ManagementObject res in GPUsearcher.Get())
                {
                    if (res["CurrentHorizontalResolution"] != null)
                        Resolution = res["CurrentHorizontalResolution"].ToString() + "x" + res["CurrentVerticalResolution"].ToString();
                }
                

            }
            catch (Exception) { GraphicCard.Add("WMI_Error"); Resolution = "WMI_Error"; }

            //set Resolution name
            if (Resolution == "1280x1024")
                ResolutionName = "SXGA";
            else if (Resolution == "1360x768")
                ResolutionName = "HD";
            else if (Resolution == "1366x768")
                ResolutionName = "HD";
            else if (Resolution == "1600x900")
                ResolutionName = "HD+";
            else if (Resolution == "1920x1080")
                ResolutionName = "FHD";
            else if (Resolution == "1280x800")
                ResolutionName = "WXGA";
            else if (Resolution == "1280x768")
                ResolutionName = "WXGA";
            else if (Resolution == "1280x720")
                ResolutionName = "WXGA";
            else if (Resolution == "1440x900")
                ResolutionName = "WXGA";
            else if (Resolution == "1680x1050")
                ResolutionName = "WSXGA";
            else if (Resolution == "1920x1200")
                ResolutionName = "WUXGA";
            else if (Resolution == "1152x864")
                ResolutionName = "XGA+";
            else if (Resolution == "1024x768")
                ResolutionName = "XGA";
            else if (Resolution == "1024x600")
                ResolutionName = "WSVGA";
            else if (Resolution == "800x600")
                ResolutionName = "SVGA";
            else if (Resolution == "2560x1440")
                ResolutionName = "WQHD";
            else if (Resolution == "3840x2160")
                ResolutionName = "UHD";
            else if (Resolution == "4096x2160")
                ResolutionName = "UHD";
            else
                ResolutionName = "n/a";
        }

        public static void GetOpticalDrive()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT MediaType FROM Win32_CDROMDrive").Get())
                    OpticalDrive = (string)Obj["MediaType"];
            }
            catch (Exception) { OpticalDrive = "WMI_Error"; }

            OpticalDrive = (string.IsNullOrWhiteSpace(OpticalDrive)) ? "n/a" : OpticalDrive;
        }

        public static void GetRAM()
        {
            byte sum = 0;
            string ramStr = "";
            Ram = new List<byte>();
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT Capacity FROM Win32_PhysicalMemory").Get())
                    if ((ulong)Obj["Capacity"] > 0)
                    {
                        Ram.Add(Convert.ToByte((ulong)Obj["Capacity"] / (1024 * 1024 * 1024)));
                    }

                for (int i = 0; i < Ram.Count; i++)
                {
                    sum += Ram[i];
                    ramStr += Ram[i].ToString() + "+";
                }

                ramStr = ramStr.Remove(ramStr.Length - 1);
                RamSum = sum + "GB " + "(" + ramStr + ")";
            }
            catch (Exception) { RamSum= "WMI_Error"; }
        }

        public static void GetCPU()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_Processor").Get())
                    CPU = (string)Obj["Name"];
            }
            catch (Exception) { CPU = "WMI_Error"; }
        }

        public static void GetSerialNumber()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT SerialNumber FROM Win32_SystemEnclosure").Get())
                    //Adding PN if manufactured by lenovo to match SN with this labeled on laptop
                    SerialNumber = (Manufacturer.Contains("LENOVO")) ? "1s" + ModelFull.ToLower()+(string)Obj["SerialNumber"] : (string)Obj["SerialNumber"];
            }
            catch (Exception) { SerialNumber = "WMI_Error"; }
        }

        public static void GetModel()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT Model FROM Win32_ComputerSystem").Get())
                    ModelFull = (string)Obj["Model"];
            }
            catch (Exception) { ModelFull = "WMI_Error"; }

            //seting ModelShort here
            if(!string.IsNullOrWhiteSpace(ModelFull)&& ModelFull != "WMI_Error")
            {

                if (Manufacturer.Contains("DELL"))
                {
                    StringBuilder dellTrimm = new StringBuilder(ModelFull);
                    dellTrimm.Replace("Latitude", "");
                    dellTrimm.Replace("OptiPlex", "");
                    dellTrimm.Replace("Precision", "");
                    dellTrimm.Replace("Workstation", "");
                    dellTrimm.Replace("Vostro", "");
                    dellTrimm.Replace("non-vPro", "");
                    dellTrimm.Replace("Tower", "");
                    dellTrimm.Replace("AIO", "");
                    ModelShort = Regex.Replace(dellTrimm.ToString(), @"\s+", " ").Trim(); //remove extra spaces
                }
                else if (Manufacturer.Contains("HEWLETT-PACKARD"))
                {
                    StringBuilder hpTrimm = new StringBuilder(ModelFull);
                    hpTrimm.Replace("HP", "");
                    hpTrimm.Replace("Compaq", "");
                    hpTrimm.Replace("ProBook", "");
                    hpTrimm.Replace("EliteBook", "");
                    hpTrimm.Replace("Precision", "");
                    hpTrimm.Replace("Workstation", "");
                    hpTrimm.Replace("Pro", "");
                    hpTrimm.Replace("EliteDesk", "");
                    hpTrimm.Replace("TWR", "");
                    hpTrimm.Replace("Elite", "");
                    hpTrimm.Replace("SFF", "");
                    hpTrimm.Replace("PC", "");
                    hpTrimm.Replace("All-in-One", " AiO ");
                    hpTrimm.Replace("SFF", "");
                    ModelShort = Regex.Replace(hpTrimm.ToString(), @"\s+", " ").Trim();
                }
                else if (Manufacturer.Contains("LENOVO"))
                {
                    if (ModelFull.ToUpper() == "4236K63") { ModelShort = "T420"; }
                    else if (ModelFull.ToUpper() == "2349P25") { ModelShort = "T430"; }
                    else if (ModelFull.ToUpper() == "2349FC4") { ModelShort = "T430"; }
                    else if (ModelFull.ToUpper() == "2347G2U") { ModelShort = "T430"; }
                    else if (ModelFull.ToUpper() == "2351BH6") { ModelShort = "T430"; }
                    else if (ModelFull.ToUpper() == "20AWS1U308") { ModelShort = "T440p"; }
                    else if (ModelFull.ToUpper() == "20AWS2CH00") { ModelShort = "T440p"; }
                    else if (ModelFull.ToUpper() == "20AWS1DA09") { ModelShort = "T440p"; }
                    else if (ModelFull.ToUpper() == "42404BG") { ModelShort = "T520"; }
                    else if (ModelFull.ToUpper() == "42435UG") { ModelShort = "T520"; }
                    else if (ModelFull.ToUpper() == "20BE0088MS") { ModelShort = "T540p"; }
                    else if (ModelFull.ToUpper() == "20BH002QMS") { ModelShort = "W540"; }
                    else if (ModelFull.ToUpper() == "2429AQ9") { ModelShort = "T530"; }
                    else if (ModelFull.ToUpper() == "24295XG") { ModelShort = "T530"; }
                    else if (ModelFull.ToUpper() == "7033GQ1") { ModelShort = "M91p"; }
                    else if (ModelFull.ToUpper() == "10A6A0WB00") { ModelShort = "M93p"; }
                    else if (ModelFull.ToUpper() == "10A7000LMH") { ModelShort = "M93p"; }
                    else if (ModelFull.ToUpper() == "10M90004UK") { ModelShort = "M710t"; }
                    else if (ModelFull.ToUpper() == "10MQS2KG00") { ModelShort = "M710q"; }
                    else if (ModelFull.ToUpper() == "20CDS04J00") { ModelShort = "S1 Yoga"; }
                    else if (ModelFull.ToUpper() == "20C3S0YQ00") { ModelShort = "ThinkPad 10"; }
                    else if (ModelFull.ToUpper() == "10AAS0G50L") { ModelShort = "M93p Tiny"; }
                    else { ModelShort = ModelFull; }
                }
                else if (Manufacturer.Contains("FUJITSU"))
                {
                    StringBuilder fujitsuTrimm = new StringBuilder(ModelFull);
                    fujitsuTrimm.Replace("LIFEBOOK", "");
                    ModelShort = Regex.Replace(fujitsuTrimm.ToString(), @"\s+", " ").Trim();
                }
                else
                {
                    ModelShort = ModelFull;
                }
            }
            else
            {
                ModelShort = "WMI_Error";
            }
        }

        public static void GetManufacturer()
        {
            try
            {
                foreach (ManagementObject Obj in new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer FROM Win32_ComputerSystem").Get())
                    Manufacturer = ((string)Obj["Manufacturer"]).ToUpper();
            }
            catch { Manufacturer = "WMI_Error"; }
        }

    }
}
