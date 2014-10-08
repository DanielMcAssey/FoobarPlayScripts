using System;
using System.Windows.Forms;
using FoobarLink;

namespace FPS_VolumeUp
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.SetCompatibleTextRenderingDefault(false);
			Application.UseWaitCursor = false;
			FoobarCommand.SendCommand("/command:up");
			Application.Exit();
		}
	}
}
