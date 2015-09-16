
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NetExam
{
	public class MyEventsFragment : Fragment
	{
		Button btnCreateEvent;
		ListView eventsListView;
		string[] items = new string[] { "00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees","00 Attendees"};
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.MyEvents, container, false);
			btnCreateEvent = view.FindViewById<Button> (Resource.Id.btnCreateEvent);
			eventsListView = view.FindViewById<ListView>(Resource.Id.lstEvents);
			eventsListView.Adapter = new NetExam.MyEvent_ItemAdapter(this.Activity, items);
			eventsListView.ItemClick += OnListEventClick;
			btnCreateEvent.Click += delegate {
				var fragTx = FragmentManager.BeginTransaction();
				var frag = new CreateEventFragment();
				fragTx.Replace(Resource.Id.framelayout_maincontainer, frag);
				fragTx.Commit();			
			};
			return view;
		}
		void OnListEventClick(object sender, AdapterView.ItemClickEventArgs e) {
			var fragTx = FragmentManager.BeginTransaction();
			var frag = new ViewEventFragment();
			fragTx.Replace(Resource.Id.framelayout_maincontainer, frag);
			fragTx.Commit();
		}
	}
}

