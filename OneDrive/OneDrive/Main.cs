using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;    
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Live;

namespace OneDrive
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string ClientID = "000000004814AD4C";
        MyBrowser myBrowser;
        LiveAuthClient liveAuthClient;
        LiveConnectClient liveConnectClient;
        string[] Scopes = { "wl.signin", "wl.basic", "wl.photos", "wl.share", "wl.skydrive", "wl.skydrive_update", "wl.work_profile" };

        LiveAuthClient AuthClient
        {
            get
            {
                if (this.liveAuthClient == null)
                {
                    this.AuthClient = new LiveAuthClient(ClientID/*, this*/);
                }

                return this.liveAuthClient;
            }

            set // удалена обработка ошибок?
            {
                this.liveAuthClient = value;
                this.liveConnectClient = null;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string startUri = this.AuthClient.GetLoginUrl(Scopes);
            string endUri = "http://google.com"; // ??
            this.myBrowser = new MyBrowser(startUri, endUri);
            this.myBrowser.Show();
            this.myBrowser.MyBrowser_Load();
        }
    }
}
