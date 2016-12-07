using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class ExerciseDb
    {
        public Dictionary<string, Exercise> Exercises = new Dictionary<string, Exercise>()
        {
            {"plank", new Exercise() {Title = "plank", Description = "p6ve toomine kylje juurde"}},
            {"p2kaseis", new Exercise() {Title = "p2kalseis", Description = "p2ksetervitus b, kuid päkkade peal"}},
			{"k6ht1", new Exercise() {Title = "k2ht1", Description = "selili, jalad k6erdatud kuid tallad maas, vii k2d jalgade vahelt ette"}},
			{"k6ht2", new Exercise() {Title = "k2ht2", Description = "selili, jalad k6erdatud kuid tallad maas, vii k2d jalgade vahelt ette"}},
            {"k6ht3", new Exercise() {Title = "k2ht3", Description = "selili, jalad k6erdatud kuid tallad maas, vii k2d jalgade vahelt ette"}},

        };
        public class Exercise
        {
            public string Title;
            public string Description;

        }
    }
}