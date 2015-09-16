
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Android.Content.PM;
//Testing
namespace NetExam
{
	[Activity (Label = "NetExam", Theme = "@style/Theme.Splash", NoHistory=true, ScreenOrientation = ScreenOrientation.Portrait, MainLauncher=true)]			
	public class LaunchActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Create your application here
			Thread.Sleep(300); // Simulate a delayed loading process on app startup.
			StartActivity(typeof(LoginActivity));
			//ActionBar.SetDisplayShowHomeEnabled (false);

		}
	}
}

