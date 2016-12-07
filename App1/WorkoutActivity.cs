using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading.Tasks;

namespace App1
{
    [Activity(Label = "Workout")]
    public class WorkoutActivity : Activity
    {
        private EditText woTime;
        private EditText pauseTime;
        private TextView descr;
        private TextView currentEx;
        private ImageView picture;

		private int woTimeTmp = 4;
		private int pauseTimeTmp = 2;
		private static System.Timers.Timer aTimer;

		private int counter = 0;

        //private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        //Kas on ikka vaja? https://msdn.microsoft.com/en-us/library/system.diagnostics.stopwatch(v=vs.110).aspx
        private bool toggleStartStop = false;

        private Button StartPauseBtn;

        private ExerciseDb Exercises;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Exercises = new ExerciseDb();

            SetContentView(Resource.Layout.WorkoutView);

            FindViews();

            PrepareTimer();

            currentEx.Text = Exercises.Exercises["plank"].Title;
            descr.Text = Exercises.Exercises["plank"].Description;
            picture.SetImageResource(Resource.Drawable.Icon);

            HandleEvent();
        }

        private void PrepareTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
			aTimer.Elapsed += async ( sender, e ) => await OnTimedEvent();
			//aTimer.AutoReset = true; //vb pole vaja
			//aTimer.Enabled = true; //vb pole vaja
        }

		private void StartTimer()
		{
			aTimer.Start ();
            StartPauseBtn.Text = "Stop";
            //stopwatch.Start ();
        }

        private void StopTimer()
        {
            aTimer.Stop();
            StartPauseBtn.Text = "Start";
            //stopwatch.Stop ();

            //await TaskOfTResult_MethodAsync();
            //currentEx.Text = "finito";
        }

        private void FindViews()
        {
            descr = FindViewById<TextView>(Resource.Id.textDescription);
            currentEx = FindViewById<TextView>(Resource.Id.currentExercise);
            picture = FindViewById<ImageView>(Resource.Id.workoutView);
            StartPauseBtn = FindViewById<Button>(Resource.Id.startPauseButton);

            woTime = FindViewById<EditText>(Resource.Id.workoutTime);
            pauseTime = FindViewById<EditText>(Resource.Id.restTime);
        }


        private void HandleEvent()
        {
            StartPauseBtn.Click += StartPauseBtn_Click;
        }

        private void StartPauseBtn_Click(object sender, EventArgs e)
        {
			if (!toggleStartStop) { //negatiivne, kuna muutuja esialgne v‰‰rtus on false
				StartTimer();
			} else {
                StopTimer();
			}
			toggleStartStop = !toggleStartStop;

            //var alert = new AlertDialog.Builder(this);
            //alert.SetTitle("tere");
            //alert.SetMessage("tere aavo");
            //alert.Show();
        }

		private async Task OnTimedEvent()
		{
			//currentEx.Text = counter.ToString ();
			await TaskOfTResult_MethodAsync();
			counter++;
			//throw new NotImplementedException ();
		}

		async Task<int> TaskOfTResult_MethodAsync()
		{

			RunOnUiThread (() => currentEx.Text = counter.ToString());
			//foreach (var exercise in Exercises.Exercises.Values) {
			//	currentEx.Text = exercise.Title;
			//	descr.Text = exercise.Description;
			//	await Task.Run(() => System.Threading.Thread.Sleep(1000));
			//	//var alert = new AlertDialog.Builder(this);
				//alert.SetTitle("tere");
				//alert.SetMessage(exercise.Title);
				//alert.Show();
			//}
			return 1;
		}
    }
}