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
using App1.Adapters;

namespace App1
{
    [Activity(Label = "ExercisesListActivity")]
    public class ExercisesListActivity : Activity
    {
        private ListView exerciseListView;
        private List<ExerciseDb.Exercise> allExerices;
        private ExerciseDb exDB; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ExercisesListView);

            exerciseListView = FindViewById<ListView>(Resource.Id.listExerices);
            exDB = new ExerciseDb();
            allExerices = exDB.Exercises.Values.ToList();

            exerciseListView.Adapter = new ExercisesListAdapter(this, allExerices);
            //exerciseListView.FastScrollEnabled = true;

            exerciseListView.ItemClick += ExerciseListView_ItemClick;
        }

        private void ExerciseListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var alert = new AlertDialog.Builder(this);
            alert.SetTitle(allExerices[e.Position].Title);
            alert.SetMessage(allExerices[e.Position].Description);
            alert.Show();
        }
    }
}