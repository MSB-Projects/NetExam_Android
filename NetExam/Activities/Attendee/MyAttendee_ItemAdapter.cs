
using System;
using Android.App;
using Android.Widget;
using Android.Views;

namespace NetExam
{
	public class MyAttendee_ItemAdapter: BaseAdapter<string> 
	{
		string[] items;
		int [] images;
		Activity context;
		public MyAttendee_ItemAdapter(Activity context, string[] items) : base() {
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override string this[int position] {  
			get { return items[position]; }

		}
		public override int Count {
			get { return items.Length; }
		}


		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.myattendee_item, parent, false);
			var eventName = view.FindViewById<TextView> (Resource.Id.lblTxt);
			eventName.Text =  items[position];
			return view;
		}
	}
}
