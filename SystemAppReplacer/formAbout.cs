using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAppReplacer
{
    public partial class About : Form
    {
        
        public About()
        {
            InitializeComponent();
        }

        private void linkLabelAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flaticon.com/authors/good-ware");
        }

        private void linkLabelHost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flaticon.com/free-icon/process_2928541");
        }

        private void About_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lblVersion.Text = (FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)).FileVersion;
            lblReleaseDate.Text = "2020/06/05";
            List<string> aboutProgram = new List<string>();

            aboutProgram.Add("0.1.0 - Released 2020/06/05");
            aboutProgram.Add("Enjoy! Please submit all bug reports to the github issue tracker at https://github.com/jparnell8839/SystemAppReplacer/issues");
            aboutProgram.Add("Please suggest new features and improvements at the github issue tracker as well.");
            aboutProgram.Add(Environment.NewLine);
            aboutProgram.Add("To Do:");
            aboutProgram.Add("• README.md");
            aboutProgram.Add("• Help → How To Use");
            aboutProgram.Add("• File → Export");
            aboutProgram.Add("• File → Import");
            aboutProgram.Add("• Include database of known file arguments for popular software");

            foreach(var item in aboutProgram)
            {
                listBox1.Items.Add(item);
            }
        }

        private void linkLabelReportIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jparnell8839/SystemAppReplacer/issues");
        }
    }
}
