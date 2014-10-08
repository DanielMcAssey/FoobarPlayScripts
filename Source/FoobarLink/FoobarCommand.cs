using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace FoobarLink
{
    public static class FoobarCommand
    {
		private static string foobarLocation = "";
		private static bool foobarFound = false;

		static FoobarCommand()
		{
			if (!foobarFound)
				FindFoobar();
		}

		public static void FindFoobar()
		{
			if(File.Exists(@"path.txt"))
			{
				string fileLine;
				StreamReader pathFile = new StreamReader(@"path.txt");
				while ((fileLine = pathFile.ReadLine()) != null)
				{
					foobarLocation = fileLine;
				}
				pathFile.Close();
				foobarFound = true;
			}
			else
			{
				File.Create(@"path.txt");
			}
		}

		public static void SendCommand(string _command)
		{
			if (File.Exists(foobarLocation) && _command.Length > 0 && foobarFound)
			{
				Process process = new Process();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.FileName = @foobarLocation;
				process.StartInfo.Arguments = "/command:\"" + _command +"\"";
				process.Start();
			}
		}
    }
}
