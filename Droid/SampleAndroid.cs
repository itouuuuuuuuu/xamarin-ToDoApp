using System.IO;
using System;
using SampleApp.Droid;
using Xamarin.Forms;
using SamplePCL;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
[assembly: Dependency(typeof(SampleAndroid))]

namespace SampleApp.Droid
{
	public class SampleAndroid : ISqliteConnection
	{
		public SQLiteConnection GetConnection()
		{
			// SQLiteデータベースパス
			var wSqlitePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			// SQLiteデータベース名
			const string wSqliteName = "SampleSQLite.db";

			// SQLiteデータベースのパスとファイル名を結合
			var wPath = Path.Combine(wSqlitePath, wSqliteName);

			// SQLIteデータベースコネクションの生成
			var wPlatform = new SQLitePlatformAndroid();
			var wConnect = new SQLiteConnection(wPlatform, wPath);
			return wConnect;
		}
	}
}
