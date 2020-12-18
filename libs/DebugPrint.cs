/*
 * Created by SharpDevelop.
 * User: justi
 * Date: 9/4/2018
 * Time: 3:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace debuggerPrint
{
	/// <summary>
	/// Description of DebugPrint.
	/// </summary>
	public class DebugPrint
	{
		public static void LogToFile(string msg)
		{
			using (TextWriter tw = File.AppendText(@"C:\Users\Jmorrow\Desktop\debugtxt.txt"))
			{
				tw.WriteLine(msg);
				tw.Close();
			}
		}
	}
}
