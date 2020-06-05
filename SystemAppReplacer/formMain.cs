using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAppReplacer
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        /***********************************
        * Executes at load, before formMain is shown.
        ***********************************/
        {
            GetReplacedSystemAppList();
        }






























        private void GetReplacedSystemAppList()
        /***********************************
         * Loops through HKML\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options
         * and attempts to find a value by the name of "Debugger". If found, looks for a value named
         * "SystemAppReplacerConfigured" to indicate this is an app that has been replaced with the
         * program. Cleans up the value data of Debugger to find the exact executable it's replaced with.
         * Adds those listed items to the listboxes on formMain.
         ***********************************/
        {
            listboxReplaced.Items.Clear();
            listboxReplacedWith.Items.Clear();
            var IFEOList = new List<string>();
            var IFEOListData = new List<string>();
            using(var ImageFileExecutionOptionsReg =  Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options",false))
                // The registry key we're searching under
            {
                foreach(var subkey in ImageFileExecutionOptionsReg.GetSubKeyNames())
                    // search every registry key under Image File Execution Options,
                    // do something for each one
                {
                    if (ImageFileExecutionOptionsReg.OpenSubKey(subkey, false).GetValueNames().Contains("SystemAppReplacerConfigured"))
                        // Looking for a value with name "SystemAppReplacerConfigured". If present, proceed.
                    {
                        var ValuePresent = String.Empty;
                        
                        if (ImageFileExecutionOptionsReg.OpenSubKey(subkey).GetValueNames().Contains("Debugger"))
                            // Now we're gonna look for "Debugger" or "Debugger_disabled". If they're present, assign
                            // the value name to the variable
                        {
                            ValuePresent = "Debugger";
                        }
                        else if (ImageFileExecutionOptionsReg.OpenSubKey(subkey, false).GetValueNames().Contains("Debugger_disabled"))
                        {
                            ValuePresent = "Debugger_disabled";
                        }

                        if (!String.IsNullOrEmpty(ValuePresent))
                            // If the variable isn't empty, we can be sure we found one.
                        {
                            IFEOList.Add("  " + subkey); // Whitespace for readability.

                            var DebuggerInfo = ImageFileExecutionOptionsReg.OpenSubKey(subkey).GetValue(ValuePresent).ToString();
                            var subFrom = DebuggerInfo.LastIndexOf(@"\") + 1;
                            var subTo = DebuggerInfo.IndexOf(".exe") + 4;
                            var DebuggerCleaned = DebuggerInfo.Substring(subFrom, subTo - subFrom);

                            IFEOListData.Add("  " + DebuggerCleaned);
                        }
                    }
                }
            }

            if(IFEOListData.Count > 0)
                // No sense doing anything if there's nothing in the list...
            {
                foreach (var app in IFEOListData)
                    // Add each instance in our lists to our listboxes.
                {
                    listboxReplaced.Items.Add(IFEOList[IFEOListData.IndexOf(app)]);
                    listboxReplacedWith.Items.Add(app);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        /***********************************
         * Shows the About dialog
         ***********************************/
        {
            var AboutWindow = new About();
            AboutWindow.ShowDialog();
        }

        private void listboxReplaced_SelectedIndexChanged(object sender, EventArgs e)
        /***********************************
        * When the selected index of the Replaced listbox is changed, select the same
        * index on the Replaced With listbox
        ***********************************/
        {
            listboxReplacedWith.SelectedIndex = listboxReplaced.SelectedIndex;
        }

        private void listboxReplacedWith_SelectedIndexChanged(object sender, EventArgs e)
        /***********************************
        * When the selected index of the Replaced With listbox is changed, select the
        * same index on the Replaced listbox
        ***********************************/
        {
            listboxReplaced.SelectedIndex = listboxReplacedWith.SelectedIndex;
        }

        private void toolStripMenuEnable_Click(object sender, EventArgs e)
            // Enables the selected index item, if disabled
        {
            using(var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + listboxReplaced.SelectedItem.ToString().Replace("  ", ""), true))
            {
                registryKey.SetValue("Debugger", registryKey.GetValue("Debugger_disabled"));
                registryKey.DeleteValue("Debugger_disabled");
                listboxReplaced.ClearSelected();
                listboxReplacedWith.ClearSelected();
            }
        }

        private void toolStripMenuDisable_Click(object sender, EventArgs e)
            // Disables the selected index item, if enabled
        {
            using (var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + listboxReplaced.SelectedItem.ToString().Replace("  ", ""), true))
            {
                registryKey.SetValue("Debugger_disabled", registryKey.GetValue("Debugger"));
                registryKey.DeleteValue("Debugger");
                listboxReplaced.ClearSelected();
                listboxReplacedWith.ClearSelected();
            }
        }

        private void listboxReplaced_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (listboxReplaced.Items.Count <= 0) return;
            listboxReplaced.SelectedIndex = listboxReplaced.IndexFromPoint(e.Location);

            using (var ImageFileExecutionOptionsReg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + listboxReplaced.SelectedItem.ToString().Replace("  ", ""), false))
            {
                if (ImageFileExecutionOptionsReg.GetValueNames().Contains("Debugger_disabled"))
                {
                    toolStripMenuEnable.Enabled = true;
                    toolStripMenuDisable.Enabled = false;
                }
                else
                {
                    toolStripMenuEnable.Enabled = false;
                    toolStripMenuDisable.Enabled = true;
                }
            }
            this.Cursor = new Cursor(Cursor.Current.Handle);
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            contextMenuStrip1.Visible = true;
            
        }

        private void listboxReplacedWith_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (listboxReplacedWith.Items.Count <= 0) return;
            listboxReplacedWith.SelectedIndex = listboxReplacedWith.IndexFromPoint(e.Location);

            using (var ImageFileExecutionOptionsReg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + listboxReplaced.SelectedItem.ToString().Replace("  ", ""), false))
            {
                if (ImageFileExecutionOptionsReg.GetValueNames().Contains("Debugger_disabled"))
                {
                    toolStripMenuEnable.Enabled = true;
                    toolStripMenuDisable.Enabled = false;
                }
                else
                {
                    toolStripMenuEnable.Enabled = false;
                    toolStripMenuDisable.Enabled = true;
                }
            }
            this.Cursor = new Cursor(Cursor.Current.Handle);
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            contextMenuStrip1.Visible = true;
        }

        private void formMain_MouseUp(object sender, MouseEventArgs e)
        {
            listboxReplaced.ClearSelected();
            listboxReplacedWith.ClearSelected();
        }

        private void deleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var UserAcceptedRisk = MessageBox.Show("This action is permanent and cannot be undone. Are you sure you want to do this?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(UserAcceptedRisk == DialogResult.Yes)
            {
                using (var EntryToDelete = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true))
                {
                    EntryToDelete.DeleteSubKey(listboxReplaced.SelectedItem.ToString().Replace("  ", ""));
                }
                GetReplacedSystemAppList();
            }
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSelectReplace_Click(object sender, EventArgs e)
        {
            var AppToReplace = new OpenFileDialog();
            AppToReplace.Filter = "EXE Programs|*.exe";
            AppToReplace.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if(AppToReplace.ShowDialog() == DialogResult.OK)
            {
                txtProgramToReplace.Text = AppToReplace.FileName;
            }
        }

        private void btnSelectReplaceWith_Click(object sender, EventArgs e)
        {
            var AppToReplace = new OpenFileDialog();
            AppToReplace.Filter = "EXE Programs|*.exe";
            AppToReplace.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (AppToReplace.ShowDialog() == DialogResult.OK)
            {
                txtReplaceItWith.Text = AppToReplace.FileName;
            }
        }

        private void btnReplaceIt_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProgramToReplace.Text))
            {
                MessageBox.Show("It appears as if your program to replace does not have a valid file path. Please check this program exists and try again.","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtReplaceItWith.Text))
            {
                MessageBox.Show("It appears as if your program you're intending to use does not have a valid file path. Please check this program exists and try again.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtArgs.Text))
            {
                var UserResponse = MessageBox.Show("Usually a program needs to have arguments in order to function properly, such as arguments that allow opening " +
                                                   "a file directly from a folder rather than from within the program itself." + Environment.NewLine + Environment.NewLine +
                                                   "Do you want to proceed?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(UserResponse != DialogResult.Yes)
                {
                    return;
                }
            }

            DoTheThing();
        }

        private void DoTheThing()
        {
            var replacingFrom = txtProgramToReplace.Text.LastIndexOf(@"\") + 1;
            var replacingTo = txtProgramToReplace.Text.IndexOf(".exe") + 4;

            var exeToReplace = txtProgramToReplace.Text.Substring(replacingFrom, replacingTo - replacingFrom);

            using (var AppToReplace = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true))
            {
                AppToReplace.CreateSubKey(exeToReplace);
                using (var AppSubKey = AppToReplace.OpenSubKey(exeToReplace, true))
                {
                    AppSubKey.SetValue("Debugger", txtReplaceItWith.Text + " " + txtArgs.Text,RegistryValueKind.String);
                    AppSubKey.SetValue("SystemAppReplacerConfigured", 1, RegistryValueKind.DWord);
                }
            }
            
            
            
            
            
            txtProgramToReplace.Text = string.Empty;
            txtReplaceItWith.Text = string.Empty;
            txtArgs.Text = string.Empty;
            GetReplacedSystemAppList();
        }
    }
}
