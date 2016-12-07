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

namespace App1.Adapters
{
    public class ExercisesListAdapter : BaseAdapter<ExerciseDb.Exercise>
    {
        List<ExerciseDb.Exercise> items;
        Activity context;

        public ExercisesListAdapter(Activity context, List<ExerciseDb.Exercise> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int postion)
        {
            return postion;
        }

        public override ExerciseDb.Exercise this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Title;
            return convertView;
        }
    }
}