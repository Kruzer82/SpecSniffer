using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sniffer
{
    static class Path
    {
        static private string _run;
        static public string Run
        {
            get
            {
                if(string.IsNullOrWhiteSpace(_run))
                {
                    try
                    {
                        _run = System.IO.Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath).Replace("%20", " ");
                    }
                    catch { _run = "error"; }
                    return _run;
                }
                else
                {
                    return _run;
                }
            }
        }
        static public string NetworkLetter { get => "S:"; }
        static public string DriversFolder { get => NetworkLetter + @"\Drivers\"; }


        static public string SoSettings { get => Run + @"\Data\Settings.csv"; }
        static public string InstallBAT { get => Run + @"\Data\Run.bat"; }
        static public string ConnNetworkFolderBAT { get => Run + @"\Data\NetDrive.bat"; }

        static public string HDTuneProNet { get => NetworkLetter + @"\Programy\HDTunePro.exe"; }
        static public string HDTunePro { get => Run + @"\Programy\HDTunePro.exe"; }

        static public string ShowKeyPlusNet { get => NetworkLetter + @"\Programy\ShowKeyPlus.exe"; }
        static public string ShowKeyPlus { get => Run + @"\Programy\ShowKeyPlus.exe"; }

        static public string KeyboardTestNet { get => NetworkLetter + @"\Programy\keyboardtestutility.exe"; }
        static public string KeyboardTest { get => Run + @"\Programy\keyboardtestutility.exe"; }

        static public string CurrentVerFile { get => NetworkLetter+ @"\SpecSnifferVer.txt"; }
    }
}
