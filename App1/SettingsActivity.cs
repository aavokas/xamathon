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
    [Activity(Label = "Settings")]
    public class SettingsActivity : Activity
    {
        private Button SaveBtn;
        private TextView WorkoutTimeSet;
        private TextView RestTimeSet;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SettingsView);

            FindViews();
            HandleEvent();
        }

        private void FindViews()
        {
            SaveBtn = FindViewById<Button>(Resource.Id.saveButton);
            WorkoutTimeSet = FindViewById<TextView>(Resource.Id.workoutTime);
            RestTimeSet = FindViewById<TextView>(Resource.Id.restTime);
        }

        private void HandleEvent()
        {
            SaveBtn.Click += SaveBtn_Click;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //V‰‰rtused tuleb panna kuskile andmebaasi
            //db... = Int32.Parse(WorkoutTimeSet.Text);
            //db... = Int32.Parse(RestTimeSet.Text);
        }
    }
}