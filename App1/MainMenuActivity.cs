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

namespace App1
{
	[Activity(Label = "Exercises", MainLauncher = true)]
    public class MainMenuActivity : Activity
    {
        private Button navToWorkout;
        private Button navToSettings;
        private Button navToExList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            // Create your application here
            HandleEvents();
        }

        private void FindViews()
        {
            navToWorkout = FindViewById<Button>(Resource.Id.btnNavToWorkout);
            navToSettings = FindViewById<Button>(Resource.Id.btnNavToSettings);
            navToExList = FindViewById<Button>(Resource.Id.btnNavToExList);
        }

        private void HandleEvents()
        {
            navToWorkout.Click += NavToWorkout_Click;
			navToSettings.Click += NavToSettings_Click;
			navToExList.Click += NavToExList_Click;
        }

        void NavToExList_Click (object sender, EventArgs e)
        {
			var intent = new Intent(this, typeof(ExercisesListActivity));
			StartActivity(intent);
        }

        void NavToSettings_Click (object sender, EventArgs e)
        {
			var intent = new Intent(this, typeof(SettingsActivity));
			StartActivity(intent);	
        }

        private void NavToWorkout_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(WorkoutActivity));
            StartActivity(intent);

            // make intent
            // StartActivityForResult
        }
    }
}