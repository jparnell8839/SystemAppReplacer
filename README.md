# SystemAppReplacer
## Make Windows run the app YOU want to run

### 1. What is this program and what does it do?

The primary purpose of this application is to replace first party apps from within Windows (especially ones that allow keyboard shortcuts or cannot [easily] be replaced natively). It does this by using the * **Image File Execution Options** * located at **HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options**, creating an entry for your selected program, and attaching the program you want to use as a "debugger". Since most applications are not, in fact, debuggers, it cannot create the process to launch the app it's replacing. Instead, it simply launches the app you want.

The secondary purpose of the app is to show and manage what apps you have swapped out. This allows you to disable or delete entries that you no longer want to be swapped.

### 2. Bugs and Known Issues

At this moment, there are no known bugs (though I will admit, there is very little error checking and prevention, and no exception handling at the moment... if an exception is thrown, it will not be handled and will crash the program).

There is one known issue at the moment: if you try to swap an app with another app that depends on that app, you will get an infinite number of iterations spawned until you can kill that process.

To elaborate, here's an example of this happening. During testing I attempted to swap cmd.exe with Microsoft's new Windows Terminal. Unfortunately, it appears as if Windows Terminal actually takes instances of cmd.exe, powershell.exe, and other terminals that get added to it, and runs instances of the original app within the Windows Terminal container. Essentially, it just wraps existing software in a prettier wrapper. Launching Windows Terminal from the run box by entering "cmd.exe" with the swap resulted in 569 instances of Windows Terminal windows generating, one after another, because it called upon cmd.exe as part of it's loading routine. I had to hard reboot my computer to fix it.

If anybody has any suggestions on how to fix this particular issue, please feel free to suggest them in the project's Issues section. I have a couple ideas on how to fix it, but maybe someone else will have suggest something better and more light weight.

This isn't a bug, per se, because System App Replacer is performing exactly as it's designed: it's taking a call to run *cmd.exe* and executing *WindowsTerminal.exe* instead. Just because *WindowsTerminal.exe* calls *cmd.exe* is irrelevant. That said, it is an obstacle to overcome, albeit not a very high priority one. Once all the other things listed in Section 3 are implemented, I will focus on this.

#### 2a. A lot of this remains untested

There's a lot of testing that must be done in various scenarios. For instance, * **Image File Execution Options** * exists at two different locations:

* **HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options**; and
* **HKLM\\SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options**

In theory on 64 bit Windows, 64 bit apps should go into **HKLM\\SOFWARE** whereas 32 bit apps should go in **HKLM\\SOFTWARE\\WOW6432Node**. That said, I'm not 100% sure how applications in cross-environments would behave. Most first-party Windows apps, such as CMD and NotePad are cross-compiled, and there are actually 3 versions on each machine. For example, on 64 bit Windows 10 Pro 2004, notepad.exe exists in the following locations:

* C:\Windows\**notepad.exe**
* C:\Windows\System32\**notepad.exe**
* C:\Windows\SysWOW64\**notepad.exe**

The executable in System32 is the 64 bit version of the app, whereas the executable in SysWOW64 is the 32 bit version of the app. The version in C:\Windows is essentially a dummy, a placeholder to be called by a process, and then gets routed to the version in System32 or SysWOW64 depending on whether the calling process is 32 bit or 64 bit. This is one of the easiest ways to see clearly how 32 bit applications are able to be run natively on a 64 bit operating system, through what Microsoft calls the "Windows on Windows" implementation (Sys"WOW"64).

System App Replacer realistically doesn't care whether the app being replaced or doing the replacing is 32 bit or 64 bit, but this could potentially cause some problems down the line if a 32bit process is wanting to launch notepad, and instead of launching notepad++ as expected, it launches notepad because the entry doesn't exist in Wow6432Node branch of the registry.

If this happens, please submit an issue and I will attempt to address it.

### 3. To Do

Beta Ready Milestone will have the following:

* Code commenting. I got in the zone and just stopped commenting.
* Implementing File → Export operations
* Implementing File → Import operations

Version 1.0 Milestone will have the following:

* Implement more granular error checks for unpredictable scenarios and exception handling.
* Implement checking to make sure an entry doesn't contain anything other than values created by System App Replacer
* Implement just the executable file, without the path to it.
* A "Details" page for the software replacing another app that shows command line arguments used.

Version 2.0 Milestone will have the following:

* Include database of known file arguments for popular software. The idea is to have these auto-populate when a known executable is selected to replace an app. For instance, if you want to replace notepad.exe with notepad++.exe, once you select the notepad++.exe executable, the line for arguments is automatically filled with "-notepadStyleCmdline -z", as this is what is needed for notepad++ to open files from folders rather than from File → Open
* Optional Cloud Sync to sync configuration between multiple devices.

### 4. Installing and Running the software

Because this is a simple application that requires no external libraries, everything is compiled into a single executable.

You do need to make sure that .Net 4.7.2 is installed for this application to work. Additionally, because System App Replacer interacts with **HKEY\_LOCAL\_MACHINE** in the registry, it does require that you have admin rights on your computer. This app is made for power users, and doesn't do anything you cannot do manually. It's simply there to make it easier and to save time.

Simply download the application from the releases page and run it. A UAC prompt will appear (as long as your system UAC settings permit) allowing you to elevate the app.

### 5. Replacing a default program using System App Replacer

You have 2 options on selecting an app to replace and an app to replace it with:
1. Click the Select App To Replace button to browse to the app's executable. For notepad.exe, this would be C:\Windows\notepad.exe. 
2. Paste the full path for C:\Windows\notepad.exe
	a. A future release will allow for just including "notepad.exe" without using the path, but this is currently not possible at the moment because of the method of checking the registry. Once I implement more exception handling, I'll be able to slip this feature in.
3. Determine if you need any command line arguments.
	1. A good rule of thumb, if you can open a document from the Run box, then likely it only needs the -z command line option.
	2. A good place to start on finding command line options is on [this Stack Overflow question](https://stackoverflow.com/questions/8869219/how-can-i-find-out-if-an-exe-has-command-line-options). Anybody who has experience as a software deployment package admin should be pretty familiar with this process.
4. Click the button labeled "Replace It!"

![Replace An App](https://i.imgur.com/m3xT3a7.png)

It's that simple!

### 6. Reviewing, Disabling, and Enabling app replacements

As well as being able to create app replacements, you can also see what you have replaced and with what you replaced it with. On the left side of the window are two groupboxes, "Replaced Programs" and "Replaced With". The one on the left is what was replaced, and directly across from it on the right is what it's replaced with.

![Review Replaced Apps](https://i.imgur.com/HS3dCdd.png)

If you right click on either the replaced or replaced with app names, you'll see a context menu appear with the options "Enable", "Disable", "Delete Entry".

![Review Replaced Apps](https://i.imgur.com/P2oBQIt.png)

If an app is already enabled, the "Enable" option will be greyed out and not selectable. Consequently, if it is already disabled, "Disable" will be greyed out and not selectable. If you click "Delete Entry", it will permanently remove that app and it's settings from the registry.

#### * **BEWARE** *

It is possible that a replaced app could already exist within the registry before System App Replacer modified that registry key. Deleting an app is therefore not recommended until a future version is included, UNLESS you manually check that registry key and can confirm it is safe to delete.

All entries will be in the following location in the registry:

HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\[ReplacedAppName].exe

For example, notepad.exe's entry will be:

HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe

If any values exist under that registry key besides "Debugger" and "SystemAppReplacerManaged", do not delete it!

A future version will include checking to make sure that it will not be deleted unless it was created by System App Replacer.

### 7. Conclusion

I sincerely hope that you enjoy my app. If you have any bugs, issues, or suggestions, please, please, please check out the Issue Tracker on GitHub. Thanks, and have a great day!

# _jParnell_