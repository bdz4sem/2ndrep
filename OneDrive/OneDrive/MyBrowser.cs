using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OneDrive
{
    delegate void AuthCompletedDelegate(AuthResult au);
    public partial class MyBrowser : Form
    {
        string startUrl;
        string endUrl;
        private AuthCompletedDelegate callback;
        
        public MyBrowser(string startUrl, string endUrl)
        {
            this.startUrl = startUrl;
            this.endUrl = endUrl;
            InitializeComponent();
        }
        public void MyBrowser_Load(/*object sender, EventArgs e*/)
        {
            this.webBrowser1.Navigated += WebBrowser_Navigated;//?
            webBrowser1.Navigate(this.startUrl);
        }
        void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (this.webBrowser1.Url.AbsoluteUri.StartsWith(this.endUrl))//?
            {
                if (this.callback != null)
                {
                    this.callback(new AuthResult(this.webBrowser1.Url));
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
        }
        
    }
}
