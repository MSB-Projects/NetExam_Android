
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
	public class MyAttendeesFragment : Fragment
	{
		Button btnCreateAttendee;
		ListView attendeesListView;
		string[] items = new string[] { "Attendee 01","Attendee 02","Attendee 03","Attendee 04","Attendee 05","Attendee 06","Attendee 07","Attendee 08","Attendee 09","Attendee 10"};
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.MyAttendees, container, false);
			btnCreateAttendee = view.FindViewById<Button> (Resource.Id.btnCreateAttendee);
			attendeesListView = view.FindViewById<ListView>(Resource.Id.lstAttendees);
			attendeesListView.Adapter = new MyAttendee_ItemAdapter (this.Activity, items);
			attendeesListView.ItemClick += OnListEventClick;
			btnCreateAttendee.Click += delegate {
				var fragTx = FragmentManager.BeginTransaction();
				var frag = new CreateAttendeeFragment();
				fragTx.Replace(Resource.Id.framelayout_maincontainer, frag);
				fragTx.Commit();			
			};
			return view;
		}
		void OnListEventClick(object sender, AdapterView.ItemClickEventArgs e) {
			var fragTx = FragmentManager.BeginTransaction();
			var frag = new ViewAttendeeFragment();
			fragTx.Replace(Resource.Id.framelayout_maincontainer, frag);
			fragTx.Commit();
		}

	}
}

