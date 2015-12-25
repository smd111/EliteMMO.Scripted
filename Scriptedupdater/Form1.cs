using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.1));
            InitializeComponent();

            string apidll = "";
            string mmodll = "";
            string appexe = "";
            if (File.Exists(Application.StartupPath + @"\EliteAPI.dll"))
                apidll = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteAPI.dll").FileVersion;
            if (File.Exists(Application.StartupPath + @"\EliteMMO.API.dll"))
                mmodll = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteMMO.API.dll").FileVersion;
            if (File.Exists(Application.StartupPath + @"\Scripted.dll"))
                appexe = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\Scripted.exe").FileVersion;
            WebClient Client = new WebClient();
            if (apidll == "" || GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/eliteapi/index.php?v") != apidll)
            {
                label1.Text = "Downloading : EliteAPI.dll";
                Client.DownloadFile("http://ext.elitemmonetwork.com/downloads/eliteapi/EliteAPI.dll", Application.StartupPath + @"\EliteAPI.dll");
            }
            if (mmodll == "" || GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/elitemmo_api/index.php?v") != mmodll)
            {
                label1.Text = "Downloading : EliteMMO.API.dll";
                Client.DownloadFile("http://ext.elitemmonetwork.com/downloads/elitemmo_api/EliteMMO.API.dll", Application.StartupPath + @"\EliteMMO.API.dll");
            }
            if (appexe == ""  || GetStringFromUrl("https://raw.githubusercontent.com/smd111/EliteMMO.Scripted/master/EliteMMO.Scripted/ScriptedVer.txt").Replace("\n", "") != appexe)
            {
                label1.Text = "Downloading : Scripted.exe";
                Client.DownloadFile("http://github.com/smd111/EliteMMO.Scripted/blob/master/EliteMMO.Scripted/bin/Release/Scripted.exe?raw=true", Application.StartupPath + @"\Scripted.exe");
            }
            Client.Dispose();
            Process.Start(Application.StartupPath + @"\Scripted.exe");
            Environment.Exit(0);
        }
        private string GetStringFromUrl(string location)
        {
            WebRequest request = WebRequest.Create(location);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;
        }
    }
}
