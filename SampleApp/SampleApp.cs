using System;
using Xamarin.Forms;
using SamplePCL;

namespace SampleApp
{
	public class SampleAppPage : ContentPage
	{
		readonly SqliteControll wSqliteControll = new SqliteControll();
        private int padding = 0;  // OS毎のpadding

		public SampleAppPage()
		{
			// データ表示用リスト
			var wListView = new ListView
			{
				ItemsSource = wSqliteControll.GetItems(),
				ItemTemplate = new DataTemplate(typeof(TextCell))
			};

			wListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
			wListView.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("InsertDate", stringFormat: "{0:yyy/MM/dd hh:mm}"));

			// データタップ時の処理
			wListView.ItemTapped += async (s, a) =>
			{
				var wItem = (SqliteItem)a.Item;
				if (await DisplayAlert("以下の内容を削除しますか", wItem.Text, "はい", "いいえ"))
				{
					// データの削除
					wSqliteControll.DeleteItem(wItem);

					// データの取得
					wListView.ItemsSource = wSqliteControll.GetItems();
				}
			};

			// ラベル１
			var wLabel1 = new Label
			{
				Text = "ToDoアプリ",
				BackgroundColor = Color.Navy,
				TextColor = Color.White,
				WidthRequest = 300
			};

			// ラベル２
			var wLavel2 = new Label
			{
				Text = "登録データ一覧",
				BackgroundColor = Color.Gray,
				TextColor = Color.White,
				WidthRequest = 300
			};

			// データの入力
			var wEntry = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			// 登録ボタン
			var wButtonIns = new Button
			{
                
				WidthRequest = 60,
				TextColor = Color.White,
				Text = "登録"
			};

			// 登録ボタン押下時の処理
			wButtonIns.Clicked += (s, a) =>
			{
				if (!String.IsNullOrEmpty(wEntry.Text))
				{
					// 登録データ設定
					var item = new SqliteItem
					{
						Text = wEntry.Text,
						InsertDate = DateTime.Now
					};

					// データの登録
					wSqliteControll.InsertItem(item);

					// データの再取得
					wListView.ItemsSource = wSqliteControll.GetItems();

					// 入力データの初期化
					wEntry.Text = "";
				}
			};

            // OS毎のpaddingを設定
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
                    this.padding = 20;
					break;
				case Device.Android:
                    this.padding = 0;
					break;
			}

			// 画面レイアウト
			Content = new StackLayout
			{
				Padding = new Thickness(0, this.padding, 0, 0),
				Children = {
					wLabel1,
					new StackLayout{
                        BackgroundColor = Color.Gray,
						Padding = 5,
						Orientation = StackOrientation.Horizontal,
						Children = {wEntry, wButtonIns}
					},
					wLavel2,
					wListView
				}
			};
		}
	}
}
