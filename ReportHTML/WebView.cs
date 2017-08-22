using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportHTML
{
    public partial class WebView : Form
    {
        private string _url;

        public WebView()
        {
            InitializeComponent();
        }

        public void navigateTo(string url)
        {
            _url = url;

            webBrowser.Navigate(url);
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            Process.Start(_url);
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintDialog();
        }
    }
}
