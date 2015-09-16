
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

namespace NetExam
{
	[Activity (Label = "")]			
	public class MyEventsActivity : Activity
	{
		ListView eventsListView;
		Button btnCreateEvent;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MyEvents);
			//eventsListView = FindViewById<ListView>(Resource.Id.lstEvents);
			btnCreateEvent = FindViewById<Button>(Resource.Id.btnCreateEvent);
			string[] items = new string[] { "00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees"};
			//eventsListView.Adapter = new NetExam.MyEvent_ItemAdapter(this, items);
			btnCreateEvent.Click += delegate {
				//var intent = new Intent(this, typeof(NewEventActivity));
				//StartActivity(intent);
			};
		}
	}
}

