
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
using Android.Graphics.Drawables;
using Android.Content.PM;
using Android.Graphics;

namespace NetExam
{
	[Activity (Label = "", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class LoginActivity : Activity
	{
		TextView lblLogin;
		bool isValidLogin = false;
		bool isValidCredential = false;
		EditText userName;
		EditText password;
		Button button;
		string apiKey = "tHEDj5d2ASNitubiNf1zpzw7AqGodk";
		String sessionId;
		String userid;
		ProgressBar progressbar;
		protected override void OnCreate (Bundle bundle)
		{

			//ActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.menutopbar));
			ActionBar.SetBackgroundDrawable (new ColorDrawable (Color.ParseColor ("#EE0018")));
			progressbar = (ProgressBar)FindViewById (Resource.Id.progress_bar);
			base.OnCreate (bundle);
			ActionBar.SetDisplayShowHomeEnabled (false);
			ActionBar.SetDisplayHomeAsUpEnabled (false);
			ActionBar.SetHomeButtonEnabled (false);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			// Get the username/password EditBox and button resources:
			userName = FindViewById<EditText> (Resource.Id.txtUsername);
			password = FindViewById<EditText> (Resource.Id.txtPassword);
			button = FindViewById<Button> (Resource.Id.btnLogin);
			lblLogin = FindViewById<TextView> (Resource.Id.lblLogin);

			//Typeface face=Typeface.CreateFromAsset(Application.Context.Assets,  "fonts/Montserrat-Light.otf");
			//for bold text
			//Typeface boldFace=Typeface.CreateFromAsset(Application.Context.Assets,  "fonts/Montserrat-Regular.otf");
//			userName.SetTypeface (face, TypefaceStyle.Normal);
//			userName.TextSize = 15;
//			password.TextSize = 15;
//			password.SetTypeface (face, TypefaceStyle.Normal);
//			lblLogin.SetTypeface (face, TypefaceStyle.Normal);
//			button.SetTypeface (boldFace, TypefaceStyle.Normal);
			//userName.Typeface = face;


			// Get our button from the layout resource,
			// and attach an event to it

			lblLogin.Click += async (sender, e) => {
				//progressbar.Visibility = ViewStates.Visible;
				var intent = new Intent (this, typeof(LoginHelpActivity));
				StartActivity (intent);
			};


			button.Click += async (sender, e) => {
				try {
					var intent = new Intent (this, typeof(MainActivity));
					StartActivity (intent);

						
				} catch (Exception ex) {
					AlertDialog.Builder alert = new AlertDialog.Builder (this);
					alert.SetTitle (ex.Message);
				}

			};


		}



		public bool checkLoginCredential (string loginUserName, string loginPassword)
		{
			try {
				loginUserName = loginUserName.Trim ();
				loginPassword = loginPassword.Trim ();

				Drawable icon_error = Resources.GetDrawable (Resource.Drawable.downArrow);

				if (string.IsNullOrEmpty (loginUserName) || loginUserName == "") {
					userName.SetError ("Please enter UserName", icon_error);
					return false;
				}

				if (string.IsNullOrEmpty (loginPassword) || loginPassword == "") {
					password.SetError ("Please enter Password", icon_error);
					return false;
				}

			} catch (Exception ex) {
				AlertDialog.Builder alert = new AlertDialog.Builder (this);
				alert.SetTitle (ex.Message);
			}
			return true;
		}

		public bool checkValidCredential (string loginUserName, string loginPassword)
		{
			try {

				//string sfdcToken = "tHEDj5d2ASNitubiNf1zpzw7AqGodk";
				//string sfdcUserName = "TechAffinityAPI@netexam.com";
				//string sfdcPassword = "netExam-6824";


			} catch (Exception ex) {
				AlertDialog.Builder alert = new AlertDialog.Builder (this);
				alert.SetTitle (ex.Message);
			}

			return false;

		}

	}
}


