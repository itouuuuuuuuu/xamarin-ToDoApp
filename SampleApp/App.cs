﻿using System;
using Xamarin.Forms;
using SamplePCL;

namespace SampleApp
{
	public partial class App : Application
	{
		public App()
		{
			MainPage = new SampleAppPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
