using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using System.Threading;
using System.Reflection;
using System.CodeDom.Compiler;

namespace LightNite
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void DashBoard_loaded(object sender, RoutedEventArgs e)
		{
			LogBR.Text = "Welcome to LightNite. Credits to Fexor for the Launcher. Credits to AuroraFN For the backend and rift for ingame!.";
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Launches Fortnite. We will have a better way soon.
			Process process = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe", true, "");
			Process process2 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe", true, "");
			Process process4 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe", true, "");
			Process process3 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe", false, "-AUTH_TYPE=epic -AUTH_LOGIN=\"" + this.EmailBR.Text + "\" -AUTH_PASSWORD=\"" + this.PasswordBR.Text + "\" - SKIPPATCHCHECK");
			LogBR.Text = "Launching Fortnite (This could take a few minutes) and the window may seem frozen but it's not.";
			process3.WaitForInputIdle();
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LightNiteSSL.dll"));
			Thread.Sleep(1000);
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Rift.dll"));
			process3.WaitForExit();
			process.Kill();
			process2.Kill();
			LogBR.Text = "I hope you have a great day! :) You can always click Start Game to begin another session.";
		}

		private void InstallModules_Clicked(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("installmodules.bat");
		}

		private void StartBackend_Clicked(object sender, RoutedEventArgs e)
		{
			
			System.Diagnostics.Process.Start("startbackend.bat");
		}

		private void Instructions_Clicked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("How to use LightNite\n\n LightNite is a Light-Weight Fortnite Private Server\n\n 1. Make sure you have Nodejs and easyinstaller on your computer. (you can find the downloads in downloadme.txt)\n 2. After you are done that click *Install Modules* in the Launcher to Install ALL Modules needed for LightNite.\n 3. After you are finished installing modules click the *Start Backend* Button on the launcher to Start the Backend (DO NOT CLOSE THE COMMAND PROMPT WHILE USING LIGHTNITE).\n 4. Put in your Email and Password that was registered to your name (You can make an LightNite account by going to your browser and typing in http://localhost ).\n 5. Now put the path to your Fortnite Installation and click *Start Game* To Begin A session.\n\n Coded with Love by FexorDEV.\n LightNite is a Brand of AnomalyApps. Unauthorized use is prohibited");
		}

		private void VersionInfo_Clicked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("L I G H T N I T E\n\n Version: 1.1.0-Prod\n Product Key: Coming Soon\n\n\n Coded with ♡ by FexorDEV");
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://lightnite.vortyxdev.repl.co/signup");
		}
	}
}
