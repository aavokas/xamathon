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
using Android.Preferences;
using Android.Text;

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
            GetSettings();
        }

        private void FindViews()
        {
            WorkoutTimeSet = FindViewById<TextView>(Resource.Id.workoutTime);
            RestTimeSet = FindViewById<TextView>(Resource.Id.restTime);
        }

        private void HandleEvent()
        {
            //SaveBtn.Click += SaveBtn_Click;
            WorkoutTimeSet.TextChanged += WorkoutTimeSet_TextChanged;
            RestTimeSet.TextChanged += RestTimeSet_TextChanged;
        }

        private void GetSettings()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("WorkoutSettings", FileCreationMode.Private);

            WorkoutTimeSet.Text = pref.GetInt("WorkoutTimeSetting", 20).ToString();
            RestTimeSet.Text = pref.GetInt("RestTimeSetting", 40).ToString();
        }

        private void WorkoutTimeSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            bool result = int.TryParse(WorkoutTimeSet.Text, out i);
            if (!result)
                WorkoutTimeSet.Text = "0";

            ISharedPreferences pref = Application.Context.GetSharedPreferences("WorkoutSettings", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutInt("WorkoutTimeSetting", int.Parse(WorkoutTimeSet.Text));
            edit.Apply();
        }

        private void RestTimeSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            bool result = int.TryParse(RestTimeSet.Text, out i);
            if (!result)
                RestTimeSet.Text = "0";


            ISharedPreferences pref = Application.Context.GetSharedPreferences("WorkoutSettings", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutInt("RestTimeSetting", int.Parse(RestTimeSet.Text));
            edit.Apply();
        }

    }
}