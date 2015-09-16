using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V4.App;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace NetExam
{
	[Activity (Label = "",ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public abstract class BaseActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			
		}

	}
}
