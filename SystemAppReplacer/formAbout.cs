using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
            var BuildNumber = (FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)).FileVersion;
            lblVersion.Text = BuildNumber;
            var BuildDate = "2020/06/09";
            lblReleaseDate.Text = BuildDate;
            List<string> aboutProgram = new List<string>();

            
            aboutProgram.Add(Environment.NewLine);
            aboutProgram.Add(String.Format("Version {0} - {1}",BuildNumber,BuildDate));
            aboutProgram.Add("• Completed Help → How To Use");
            aboutProgram.Add("• Built some variables for build number and build date to more easily replicate things.");
            //aboutProgram.Add("• ");
            aboutProgram.Add("");

            aboutProgram.Add("To Do:");
            aboutProgram.Add("• Code commenting. I got in the zone and just stopped commenting.");
            aboutProgram.Add("• Implementing File → Export operations");
            aboutProgram.Add("• Implementing File → Import operations");
            aboutProgram.Add("• Implement more granular error checks for unpredictable scenarios and exception handling.");
            aboutProgram.Add("• Implement checking to make sure an entry doesn't contain anything other than values created by System App Replacer");
            aboutProgram.Add("• Implement just the executable file, without the path to it.");
            aboutProgram.Add("• A \"Details\" page for the software replacing another app that shows command line arguments used.");
            aboutProgram.Add("• Include database of known file arguments for popular software.");
            aboutProgram.Add("----------------------------------------------------------------------------------------------------------------------------");
            aboutProgram.Add("0.1.0 - Released 2020/06/05");
            aboutProgram.Add("Enjoy! Please submit all bug reports to the github issue tracker at https://github.com/jparnell8839/SystemAppReplacer/issues");
            aboutProgram.Add("Please suggest new features and improvements at the github issue tracker as well.");

            foreach (var item in aboutProgram)
            {
                listBox1.Items.Add(item);
            }
        }

        private void linkLabelReportIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jparnell8839/SystemAppReplacer/issues");
        }

        #region Gets the build date and time (by reading the COFF header)

        // http://msdn.microsoft.com/en-us/library/ms680313

        struct _IMAGE_FILE_HEADER
        {
            public ushort Machine;
            public ushort NumberOfSections;
            public uint TimeDateStamp;
            public uint PointerToSymbolTable;
            public uint NumberOfSymbols;
            public ushort SizeOfOptionalHeader;
            public ushort Characteristics;
        };

        static DateTime GetBuildDateTime(Assembly assembly)
        {
            var path = assembly.GetName().CodeBase;
            if (File.Exists(path))
            {
                var buffer = new byte[Math.Max(Marshal.SizeOf(typeof(_IMAGE_FILE_HEADER)), 4)];
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    fileStream.Position = 0x3C;
                    fileStream.Read(buffer, 0, 4);
                    fileStream.Position = BitConverter.ToUInt32(buffer, 0); // COFF header offset
                    fileStream.Read(buffer, 0, 4); // "PE\0\0"
                    fileStream.Read(buffer, 0, buffer.Length);
                }
                var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    var coffHeader = (_IMAGE_FILE_HEADER)Marshal.PtrToStructure(pinnedBuffer.AddrOfPinnedObject(), typeof(_IMAGE_FILE_HEADER));

                    return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1) + new TimeSpan(coffHeader.TimeDateStamp * TimeSpan.TicksPerSecond));
                }
                finally
                {
                    pinnedBuffer.Free();
                }
            }
            return new DateTime();
        }

        #endregion
    }
}
