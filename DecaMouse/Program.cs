using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DecaMouse
{
	internal static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
#if DEBUG
			// [デバッグ用]UI言語切り替え
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
#endif
			// ユーザー単位のミューテックス（Local\）
			const string mutexName = "Local\\FumbleWarez.DecaMouse.AppLocker";
			using (var mutex = new Mutex(true, mutexName, out var createdNew))
			{
				if (!createdNew)
					return;
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
		}
	}
}
