using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using SampleApp.iOS;
using Xamarin.Forms;
using SamplePCL;
[assembly: Dependency(typeof(SampleiOS))]

namespace SampleApp.iOS
{
	public class SampleiOS : ISqliteConnection
	{
		public SQLiteConnection GetConnection()
		{
			// SQLiteデータベースパス
			var wFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var wSqlitePath = Path.Combine(wFolderPath, "..", "Library");

			// SQLiteデータベース名
			const string wSqliteName = "SampleSQLite.db";

			// SQLiteデータベースのパスとファイル名を結合
			var wPath = Path.Combine(wSqlitePath, wSqliteName);

			// SQLIteデータベースコネクションの生成
			var wPlatform = new SQLitePlatformIOS();
			var wConnect = new SQLiteConnection(wPlatform, wPath);
			return wConnect;
		}
	}
}
