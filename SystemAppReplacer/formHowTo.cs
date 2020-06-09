using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemAppReplacer.Properties;

namespace SystemAppReplacer
{
    public partial class formHowTo : Form
    {
        public formHowTo()
        {
            InitializeComponent();
        }

        string tmpFile,tmpDir,tmpHtml;

        private void formHowTo_Load(object sender, EventArgs e)
        {
            
            var strBldr = new StringBuilder();
            var rand = new Random();
            var chr = new char();
            var pathRandomLength = 8;

            strBldr.Append("000_SystemAppReplacer_");

            for(var i = 0; i<+ pathRandomLength; i++)
            {
                var flt = rand.NextDouble();
                var shift = Convert.ToInt32(Math.Floor(25 * flt));
                chr = Convert.ToChar(shift + 65);
                strBldr.Append(chr);
            }

            tmpDir = Path.GetTempPath().ToString() + strBldr.ToString();
            tmpHtml = tmpDir + @"\README.html";

            Directory.CreateDirectory(tmpDir);

            var htmlBuilder = new StringBuilder();

            using (var fs = File.Create(tmpHtml))
            {
                

                htmlBuilder.AppendLine("<!DOCTYPE html><html lang=\"en\"><html><head><title>README</title><meta charset=\"utf-8\"></head><body>");
                htmlBuilder.AppendLine("<h1 id=\"systemappreplacer\">SystemAppReplacer</h1><h2 id=\"make-windows-run-the-app-you-want-to-run\">Make Windows run the app YOU want to run</h2><h3 id=\"1-what-is-this-program-and-what-does-it-do-\">1. What is this program and what does it do?</h3><p>The primary purpose of this application is to replace first party apps from within Windows (especially ones that allow keyboard shortcuts or cannot [easily] be replaced natively). It does this by using the <em> <strong>Image File Execution Options</strong> </em> located at <strong>HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options</strong>, creating an entry for your selected program, and attaching the program you want to use as a &quot;debugger&quot;. Since most applications are not, in fact, debuggers, it cannot create the process to launch the app it&#39;s replacing. Instead, it simply launches the app you want.</p><p>The secondary purpose of the app is to show and manage what apps you have swapped out. This allows you to disable or delete entries that you no longer want to be swapped.</p><h3 id=\"2-bugs-and-known-issues\">2. Bugs and Known Issues</h3><p>At this moment, there are no known bugs (though I will admit, there is very little error checking and prevention, and no exception handling at the moment... if an exception is thrown, it will not be handled and will crash the program).</p><p>There is one known issue at the moment: if you try to swap an app with another app that depends on that app, you will get an infinite number of iterations spawned until you can kill that process.</p><p>To elaborate, here&#39;s an example of this happening. During testing I attempted to swap cmd.exe with Microsoft&#39;s new Windows Terminal. Unfortunately, it appears as if Windows Terminal actually takes instances of cmd.exe, powershell.exe, and other terminals that get added to it, and runs instances of the original app within the Windows Terminal container. Essentially, it just wraps existing software in a prettier wrapper. Launching Windows Terminal from the run box by entering &quot;cmd.exe&quot; with the swap resulted in 569 instances of Windows Terminal windows generating, one after another, because it called upon cmd.exe as part of it&#39;s loading routine. I had to hard reboot my computer to fix it.</p><p>If anybody has any suggestions on how to fix this particular issue, please feel free to suggest them in the project&#39;s Issues section. I have a couple ideas on how to fix it, but maybe someone else will have suggest something better and more light weight.</p><p>This isn&#39;t a bug, per se, because System App Replacer is performing exactly as it&#39;s designed: it&#39;s taking a call to run <em>cmd.exe</em> and executing <em>WindowsTerminal.exe</em> instead. Just because <em>WindowsTerminal.exe</em> calls <em>cmd.exe</em> is irrelevant. That said, it is an obstacle to overcome, albeit not a very high priority one. Once all the other things listed in Section 3 are implemented, I will focus on this.</p><h4 id=\"2a-a-lot-of-this-remains-untested\">2a. A lot of this remains untested</h4><p>There&#39;s a lot of testing that must be done in various scenarios. For instance, <em> <strong>Image File Execution Options</strong> </em> exists at two different locations:</p><ul><li><strong>HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options</strong>; and</li><li><strong>HKLM\\SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options</strong></li></ul><p>In theory on 64 bit Windows, 64 bit apps should go into <strong>HKLM\\SOFWARE</strong> whereas 32 bit apps should go in <strong>HKLM\\SOFTWARE\\WOW6432Node</strong>. That said, I&#39;m not 100% sure how applications in cross-environments would behave. Most first-party Windows apps, such as CMD and NotePad are cross-compiled, and there are actually 3 versions on each machine. For example, on 64 bit Windows 10 Pro 2004, notepad.exe exists in the following locations:</p><ul><li>C:\\Windows*<em>notepad.exe*</em></li><li>C:\\Windows\\System32*<em>notepad.exe*</em></li><li>C:\\Windows\\SysWOW64*<em>notepad.exe*</em></li></ul><p>The executable in System32 is the 64 bit version of the app, whereas the executable in SysWOW64 is the 32 bit version of the app. The version in C:\\Windows is essentially a dummy, a placeholder to be called by a process, and then gets routed to the version in System32 or SysWOW64 depending on whether the calling process is 32 bit or 64 bit. This is one of the easiest ways to see clearly how 32 bit applications are able to be run natively on a 64 bit operating system, through what Microsoft calls the &quot;Windows on Windows&quot; implementation (Sys&quot;WOW&quot;64).</p><p>System App Replacer realistically doesn&#39;t care whether the app being replaced or doing the replacing is 32 bit or 64 bit, but this could potentially cause some problems down the line if a 32bit process is wanting to launch notepad, and instead of launching notepad++ as expected, it launches notepad because the entry doesn&#39;t exist in Wow6432Node branch of the registry.</p><p>If this happens, please submit an issue and I will attempt to address it.</p><h3 id=\"3-to-do\">3. To Do</h3><ul><li>Updating README.md to reflect everything currently supported.</li><li>Implement Help → How To Use (which will essentially be a slimmed-down version of the README, just Sections 5 and 6.</li><li>Implement more granular error checks for unpredictable scenarios and exception handling.</li><li>Implement checking to make sure an entry doesn&#39;t contain anything other than values created by System App Replacer</li><li>Implement just the executable file, without the path to it.</li><li>Code commenting. I got in the zone and just stopped commenting.</li><li>Implementing File → Export operations</li><li>Implementing File → Import operations</li><li>A &quot;Details&quot; page for the software replacing another app that shows command line arguments used.</li><li>Include database of known file arguments for popular software. The idea is to have these auto-populate when a known executable is selected to replace an app. For instance, if you want to replace notepad.exe with notepad++.exe, once you select the notepad++.exe executable, the line for arguments is automatically filled with &quot;-notepadStyleCmdline -z&quot;, as this is what is needed for notepad++ to open files from folders rather than from File → Open</li></ul><h3 id=\"4-installing-and-running-the-software\">4. Installing and Running the software</h3><p>Because this is a simple application that requires no external libraries, everything is compiled into a single executable.</p><p>You do need to make sure that .Net 4.7.2 is installed for this application to work. Additionally, because System App Replacer interacts with <strong>HKEY_LOCAL_MACHINE</strong> in the registry, it does require that you have admin rights on your computer. This app is made for power users, and doesn&#39;t do anything you cannot do manually. It&#39;s simply there to make it easier and to save time.</p><p>Simply download the application from the releases page and run it. A UAC prompt will appear (as long as your system UAC settings permit) allowing you to elevate the app.</p><h3 id=\"5-replacing-a-default-program-using-system-app-replacer\">5. Replacing a default program using System App Replacer</h3><p>You have 2 options on selecting an app to replace and an app to replace it with:</p><ol><li>Click the Select App To Replace button to browse to the app&#39;s executable. For notepad.exe, this would be C:\\Windows\\notepad.exe. </li><li>Paste the full path for C:\\Windows\\notepad.exe a. A future release will allow for just including &quot;notepad.exe&quot; without using the path, but this is currently not possible at the moment because of the method of checking the registry. Once I implement more exception handling, I&#39;ll be able to slip this feature in.</li><li>Determine if you need any command line arguments.<ol><li>A good rule of thumb, if you can open a document from the Run box, then likely it only needs the -z command line option.</li><li>A good place to start on finding command line options is on <a href=\"https://stackoverflow.com/questions/8869219/how-can-i-find-out-if-an-exe-has-command-line-options\">this Stack Overflow question</a>. Anybody who has experience as a software deployment package admin should be pretty familiar with this process.</li></ol></li><li>Click the button labeled &quot;Replace It!&quot;</li></ol><p><img src=\"https://i.imgur.com/m3xT3a7.png\" alt=\"Replace An App\"></p><p>It&#39;s that simple!</p><h3 id=\"6-reviewing-disabling-and-enabling-app-replacements\">6. Reviewing, Disabling, and Enabling app replacements</h3><p>As well as being able to create app replacements, you can also see what you have replaced and with what you replaced it with. On the left side of the window are two groupboxes, &quot;Replaced Programs&quot; and &quot;Replaced With&quot;. The one on the left is what was replaced, and directly across from it on the right is what it&#39;s replaced with.</p><p><img src=\"https://i.imgur.com/HS3dCdd.png\" alt=\"Review Replaced Apps\"></p><p>If you right click on either the replaced or replaced with app names, you&#39;ll see a context menu appear with the options &quot;Enable&quot;, &quot;Disable&quot;, &quot;Delete Entry&quot;.</p><p><img src=\"https://i.imgur.com/P2oBQIt.png\" alt=\"Review Replaced Apps\"></p><p>If an app is already enabled, the &quot;Enable&quot; option will be greyed out and not selectable. Consequently, if it is already disabled, &quot;Disable&quot; will be greyed out and not selectable. If you click &quot;Delete Entry&quot;, it will permanently remove that app and it&#39;s settings from the registry.</p><h4 id=\"-beware-\"><em> <strong>BEWARE</strong> </em></h4><p>It is possible that a replaced app could already exist within the registry before System App Replacer modified that registry key. Deleting an app is therefore not recommended until a future version is included, UNLESS you manually check that registry key and can confirm it is safe to delete.</p><p>All entries will be in the following location in the registry:</p><p>HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options[ReplacedAppName].exe</p><p>For example, notepad.exe&#39;s entry will be:</p><p>HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\notepad.exe</p><p>If any values exist under that registry key besides &quot;Debugger&quot; and &quot;SystemAppReplacerManaged&quot;, do not delete it!</p><p>A future version will include checking to make sure that it will not be deleted unless it was created by System App Replacer.</p><h3 id=\"7-conclusion\">7. Conclusion</h3><p>I sincerely hope that you enjoy my app. If you have any bugs, issues, or suggestions, please, please, please check out the Issue Tracker on GitHub. Thanks, and have a great day!</p><h1 id=\"_jparnell_\"><em>jParnell</em></h1>");
                htmlBuilder.AppendLine("</body></html>");
              
            }

            using (var htmlWriter = new StreamWriter(tmpHtml))
            {
                htmlWriter.Write(htmlBuilder.ToString());
            }

            var tmpNavigateHTML = @"File:///" + tmpHtml.Replace('\\', '/');

            webHowTo.Navigate(tmpNavigateHTML);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe",tmpDir);
        }

        private void formHowTo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Directory.Delete(tmpDir,true);
        }
    }
}
