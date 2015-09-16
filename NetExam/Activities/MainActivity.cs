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
using Android.Animation;

namespace NetExam
{
	[Activity (Label = "",ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		private DrawerLayout mDrawerLayout;
		private ActionBarDrawerToggle mDrawerToggle;
		private RelativeLayout mLeftDrawer;
		private FrameLayout mainContainer;
		private Button btnSignout;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myMenuDrawer);
			mLeftDrawer = FindViewById<RelativeLayout> (Resource.Id.left_fragment_container);
			mainContainer = FindViewById<FrameLayout> (Resource.Id.framelayout_maincontainer);
			//set icon for Drawer
			mDrawerToggle = new ActionBarDrawerToggle(this,mDrawerLayout,Resource.Drawable.Menu,Resource.String.Open_Drawer, Resource.String.Close_Drawer);
			mDrawerLayout.SetDrawerListener (mDrawerToggle);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetHomeButtonEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			//Hide the Application icon
			ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
			ActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.topbar));
			mLeftDrawer.BringToFront ();
			BindSideMenuClickEvents();
			//Call My Events initially
			CallFragment(1);
		}
		//for slidding menu
		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate( savedInstanceState);
			mDrawerToggle.SyncState ();
		}

		//for slidding menu
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (mDrawerToggle.OnOptionsItemSelected (item))
				return true;
			return
				base.OnOptionsItemSelected (item);
		}


		private void BindSideMenuClickEvents()
		{
			RelativeLayout relativeHome = (RelativeLayout)FindViewById (Resource.Id.relativeLayoutcontainerHome);
			relativeHome.Click+= delegate {
				CallFragment(Resource.Id.relativeLayoutcontainerHome);
			};
			RelativeLayout relativeCreateEvent = (RelativeLayout)FindViewById (Resource.Id.relativeLayoutcontainerCreateEvent);
			relativeCreateEvent.Click+= delegate {
				CallFragment(Resource.Id.relativeLayoutcontainerCreateEvent);
			};
			RelativeLayout relativeMyEvents = (RelativeLayout)FindViewById (Resource.Id.relativeLayoutcontainerMyEvents);
			relativeMyEvents.Click+= delegate {
				CallFragment(Resource.Id.relativeLayoutcontainerMyEvents);
			};
			RelativeLayout relativeCreateAttendee = (RelativeLayout)FindViewById (Resource.Id.relativeLayoutcontainerCreateAttendee);
			relativeCreateAttendee.Click+= delegate {
				CallFragment(Resource.Id.relativeLayoutcontainerCreateAttendee);
			};
			RelativeLayout relativeMyAttendees = (RelativeLayout)FindViewById (Resource.Id.relativeLayoutcontainerMyAttendees);
			relativeMyAttendees.Click+= delegate {
				CallFragment(Resource.Id.relativeLayoutcontainerMyAttendees);
			};
			btnSignout = (Button)FindViewById (Resource.Id.btnSignout);		
			btnSignout.Click+= delegate {
				Signout();
			};
		}

		private void CallFragment(int Id)
		{
			var frag =new Android.App.Fragment();
			var fragTx = FragmentManager.BeginTransaction();
			fragTx.SetCustomAnimations (Resource.Animation.slide_in_left, Resource.Animation.slide_out_right);
			switch (Id) {
			case Resource.Id.relativeLayoutcontainerHome:
			case Resource.Id.relativeLayoutcontainerMyEvents:
				frag =new MyEventsFragment();
				fragTx.Replace(Resource.Id.framelayout_maincontainer, frag);
				break;
			case Resource.Id.relativeLayoutcontainerCreateEvent:
				frag = new CreateEventFragment ();
				fragTx.Replace (Resource.Id.framelayout_maincontainer, frag).AddToBackStack("CREATEEVENT");
				break;
			case Resource.Id.relativeLayoutcontainerCreateAttendee:
				frag = new CreateAttendeeFragment ();
				fragTx.Replace (Resource.Id.framelayout_maincontainer, frag).AddToBackStack("CREATEATTENDEE");
				break;
			case Resource.Id.relativeLayoutcontainerMyAttendees:
				frag = new MyAttendeesFragment ();
				fragTx.Replace (Resource.Id.framelayout_maincontainer, frag).AddToBackStack("MYATTENDEES");
				break;
			default:
				frag =new MyEventsFragment();
				fragTx.Add(Resource.Id.framelayout_maincontainer, frag).AddToBackStack("MYEVENTS");
				break;
			}
			fragTx.Commit();
			mDrawerLayout.CloseDrawers ();
		}


		private void Signout()
		{
			Intent intent = new Intent(this,typeof(LoginActivity));
			//close all the other intent
			intent.AddFlags(ActivityFlags.ClearTop);
			StartActivity(intent);
		}
	}
}


