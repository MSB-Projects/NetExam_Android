using System;
using Android.Views;
using Android.OS;
using Android.App;
using Android.Widget;

namespace NetExam
{
	public class LeftMenuFragment:Fragment
	{
		public override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.menu_drawer, container, false);
		}
	}
}

