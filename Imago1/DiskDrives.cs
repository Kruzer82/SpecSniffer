using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sniffer
{
    class DiskDrives
    {
        public string Error { get; private set; }
        public string Model { get; private set; }
        public string Size { get; private set; }
        public string Serial { get; private set; }
        public string IsOK { get; private set; }
        public Dictionary<int, Smart> Attributes = new Dictionary<int, Smart>() {
                {0x00, new Smart("Invalid")},
                {0x01, new Smart("Raw read error rate")},
                {0x02, new Smart("Throughput performance")},
                {0x03, new Smart("Spinup time")},
                {0x04, new Smart("Start/Stop count")},
                {0x05, new Smart("Reallocated sector count")},
                {0x06, new Smart("Read channel margin")},
                {0x07, new Smart("Seek error rate")},
                {0x08, new Smart("Seek timer performance")},
                {0x09, new Smart("Power-on hours count")},
                {0x0A, new Smart("Spin Retry Count")},
                {0x0B, new Smart("Calibration retry count")},
                {0x0C, new Smart("Power cycle count")},
                {0x0D, new Smart("Soft read error rate")},
                {0xB8, new Smart("End-to-End error")},
                {0xBE, new Smart("Airflow Temperature")},
                {0xBF, new Smart("G-sense error rate")},
                {0xC0, new Smart("Power-off retract count")},
                {0xC1, new Smart("Load/Unload cycle count")},
                {0xC2, new Smart("HDD temperature")},
                {0xC3, new Smart("Hardware ECC recovered")},
                {0xC4, new Smart("Reallocation event count")},
                {0xC5, new Smart("Current pending sector count")},
                {0xC6, new Smart("Offline scan uncorrectable count")},
                {0xC7, new Smart("UDMA CRC error rate")},
                {0xC8, new Smart("Write error rate")},
                {0xC9, new Smart("Soft read error rate")},
                {0xCA, new Smart("Data Address Mark errors")},
                {0xCB, new Smart("Run out cancel")},
                {0xCC, new Smart("Soft ECC correction")},
                {0xCD, new Smart("Thermal asperity rate (TAR)")},
                {0xCE, new Smart("Flying height")},
                {0xCF, new Smart("Spin high current")},
                {0xD0, new Smart("Spin buzz")},
                {0xD1, new Smart("Offline seek performance")},
                {0xDC, new Smart("Disk shift")},
                {0xDD, new Smart("G-sense error rate")},
                {0xDE, new Smart("Loaded hours")},
                {0xDF, new Smart("Load/unload retry count")},
                {0xE0, new Smart("Load friction")},
                {0xE1, new Smart("Load/Unload cycle count")},
                {0xE2, new Smart("Load-in time")},
                {0xE3, new Smart("Torque amplification count")},
                {0xE4, new Smart("Power-off retract count")},
                {0xE6, new Smart("GMR head amplitude")},
                {0xE7, new Smart("Temperature")},
                {0xF0, new Smart("Head flying hours")},
                {0xFA, new Smart("Read error retry rate")},
                {0x16, new Smart("Current Helium Level")},
                {0xAA, new Smart("Available Reserved Space")},
                {0xAB, new Smart("SSD Program Fail Count")},
                {0xAC, new Smart("SSD Erase Fail Count")},
                {0xAD, new Smart("SSD Wear Leveling Count")},
                {0xAE, new Smart("Unexpected power loss count")},
                {0xAF, new Smart("Power Loss Protection Failure")},
                {0xB0, new Smart("Erase Fail Count")},
                {0xB1, new Smart("Wear Range Delta")},
                {0xB3, new Smart("Used Reserved Block Count Total")},
                {0xB4, new Smart("Unused Reserved Block Count Total")},
                {0xB5, new Smart("Program Fail Count Total")},
                {0xB6, new Smart("Erase Fail Count")},
                {0xB7, new Smart("SATA Downshift Error Count")},
                {0xB9, new Smart("Head Stability")},
                {0xBA, new Smart("Induced Op-Vibration Detection")},
                {0xBB, new Smart("Reported Uncorrectable Errors")},
                {0xBC, new Smart("Command Timeout")},
                {0xBD, new Smart("High Fly Writes")},
                {0xD2, new Smart("Vibration During Write")},
                {0xD3, new Smart("Vibration During Write")},
                {0xD4, new Smart("Shock During Write")},
                {0xE8, new Smart("Endurance Remaining or Available Reserved Space")},
                {0xE9, new Smart("Media Wearout Indicator")},
                {0xEA, new Smart("Average erase count")},
                {0xEB, new Smart("Good Block Count")},
                {0xF1, new Smart("Total LBAs Written")},
                {0xF2, new Smart("Total LBAs Read")},
                {0xF3, new Smart("Total LBAs Written Expanded")},
                {0xF4, new Smart("Total LBAs Read Expanded")},
                {0xF9, new Smart("NAND Writes (1GiB)")},
                {0xFE, new Smart("Free Fall Protection")},
                /* slot in any new codes you find in here */
            };
        public class Smart
        {
            public string Attribute { get; set; }
            public int Current { get; set; }
            public int Worst { get; set; }
            public int Threshold { get; set; }
            public int Data { get; set; }
            public bool IsOK { get; set; }


            public bool HasData
            {
                get
                {
                    if (Current == 0 && Worst == 0 && Threshold == 0 && Data == 0)
                        return false;
                    return true;
                }
            }

            public Smart(string attributeName)
            {
                this.Attribute = attributeName;
            }
        }
        public Dictionary<int, DiskDrives> HDDs { get; private set; }



        public void GetDiskInfo()
        {
            HDDs = new Dictionary<int, DiskDrives>();
            int driveIndex = 0;

            ManagementObjectSearcher Win32_DiskDrive = new ManagementObjectSearcher("root\\CIMV2", "SELECT Size,Model,InterfaceType,SerialNumber FROM Win32_DiskDrive");
            try
            {
                foreach (ManagementObject query in Win32_DiskDrive.Get())
                {
                    if ((string)query["InterfaceType"] != "USB")
                    {
                        var driveToAdd = new DiskDrives
                        {
                            Model = (string)query["Model"],
                            Size = ((UInt64)query["Size"] / (1000 * 1000 * 1000)).ToString()+"GB",
                            Serial = ((string)query["SerialNumber"]).Trim()
                        };
                        HDDs.Add(driveIndex, driveToAdd);
                        driveIndex++;
                    }
                }
            }
            catch (Exception)
            {
                var driveToAdd = new DiskDrives
                {
                    Model = "WMI_Error",
                    Size = "WMI_Error",
                    Serial = "WMI_Error"
                };
                HDDs.Add(0, driveToAdd);

            }

            #region Is SMART failing
            try
            {
                Win32_DiskDrive.Scope = new ManagementScope(@"\root\wmi");
                Win32_DiskDrive.Query = new ObjectQuery("Select PredictFailure from MSStorageDriver_FailurePredictStatus");
                driveIndex = 0;
                foreach (ManagementObject drive in Win32_DiskDrive.Get())
                {
                    if ((bool)drive.Properties["PredictFailure"].Value == false)
                        HDDs[driveIndex].IsOK = "OK";
                    else
                        HDDs[driveIndex].IsOK = "Fail";

                    driveIndex++;
                }
            }
            catch { }

            #endregion


            //get Current Worst data and attribute 
            try
            {
                driveIndex = 0;

                Win32_DiskDrive.Query = new ObjectQuery("Select VendorSpecific from MSStorageDriver_FailurePredictData");
                foreach (ManagementObject query in Win32_DiskDrive.Get())
                {
                    Byte[] bytes = (Byte[])query.Properties["VendorSpecific"].Value;
                    for (int i = 0; i < 82; ++i)
                    {
                        try
                        {
                            int id = bytes[i * 12 + 2];

                            int flags = bytes[i * 12 + 4]; //bool advisory = (flags & 0x1) == 0x0;

                            bool failureImminent = (flags & 0x1) == 0x1;
                            //bool onlineDataCollection = (flags & 0x2) == 0x2;

                            int value = bytes[i * 12 + 5];
                            int worst = bytes[i * 12 + 6];
                            int vendordata = BitConverter.ToInt32(bytes, i * 12 + 7);
                            if (id == 0) continue;

                            var attr = HDDs[driveIndex].Attributes[id];
                            attr.Current = value;
                            attr.Worst = worst;
                            attr.Data = vendordata;
                            attr.IsOK = failureImminent == false;
                        }
                        catch (Exception)
                        {

                        }

                    }
                    driveIndex++;
                }
            }
            catch { }
            

            //get threshold - admin privileges required !!! (HRresoult -2146233087)
            driveIndex = 0;
            try
            {
                Win32_DiskDrive.Query = new ObjectQuery("Select VendorSpecific from MSStorageDriver_FailurePredictThresholds");
                foreach (ManagementObject data in Win32_DiskDrive.Get())
                {
                    Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                    for (int i = 0; i < 82; ++i)
                    {
                        try
                        {
                            int id = bytes[i * 12 + 2];
                            int thresh = bytes[i * 12 + 3];
                            if (id == 0) continue;

                            var attr = HDDs[driveIndex].Attributes[id];
                            attr.Threshold = thresh;
                        }
                        catch {/*atribute not in the dictionary of attributes*/}
                    }
                    driveIndex++;
                }
            }
            catch { }



            #region :: S.M.A.R.T Auto Check ::


            try
            {
                foreach (var checkSMART in HDDs)
                {
                    if (checkSMART.Value.IsOK == "OK")
                    {
                        int searched = 0;

                        foreach (var att in checkSMART.Value.Attributes)
                        {
                            if (att.Value.Attribute == "Reallocated sector count")
                            {
                                if (att.Value.Data > 0)
                                {
                                    checkSMART.Value.IsOK = "Fail";
                                    break;
                                }
                                searched++;
                            }
                            else if (att.Value.Attribute == "Current pending sector count")
                            {
                                if (att.Value.Data > 0)
                                {
                                    checkSMART.Value.IsOK = "Fail";
                                    break;
                                }
                                searched++;
                            }
                            else if (att.Value.Attribute == "Reallocation event count")
                            {
                                if (att.Value.Data > 0)
                                {
                                    checkSMART.Value.IsOK = "Fail";
                                    break;
                                }
                                searched++;
                            }
                            else if (searched>2)
                                break;
                        }
                    }
                }
            }
            catch  { }
            #endregion
        }
    }
}
