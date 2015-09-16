
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
//version check check
namespace NetExam
{
	[Activity (Label = "", Theme="@style/MyTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, NoHistory=true )]
	public class LoginHelpActivity : Activity
	{
		Button btnLaunch;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.LoginHelp);
			btnLaunch = FindViewById<Button>(Resource.Id.btnLaunch);
			ActionBar.SetDisplayShowHomeEnabled (false);
			ActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.topbar));
			btnLaunch.Click += async (sender, e) => {
				var uri = Android.Net.Uri.Parse ("http://www.google.com");
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity (intent);
			};
		}
	}
}

