using Android.App;
using Android.Widget;
using Android.OS;
using OpenALPR_Xamarin.Android_Library;
using OpenALPR_Xamarin.Android_Library.Models;
using System;

namespace OpenALPR_Xamarin.Android_Sample_App
{
    [Activity(Label = "OpenALPR Xamarin App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public string AndroidDataDir;
        public string OpenALPRConfigFile;
        public string OpenALPRRuntimeFolder;
        public string TestImagePath;
        public OpenALPR OpenALPRInstance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            AndroidDataDir = ApplicationInfo.DataDir;
            OpenALPRConfigFile = AndroidDataDir + "/runtime_data/openalpr.conf";
            OpenALPRRuntimeFolder = AndroidDataDir + "/runtime_data";
            TestImagePath = AndroidDataDir + "/runtime_data/image.jpg";

            OpenALPRInstance = new OpenALPR(this, AndroidDataDir, OpenALPRConfigFile, "eu");

            Button recognizeButton = FindViewById<Button>(Resource.Id.recognizeButton);
            recognizeButton.Click += RecognizeButton_Click;
        }

        private void RecognizeButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                string output = "";
                TextView licensePlateTV = FindViewById<TextView>(Resource.Id.licensePlateTextview);

                OpenALPR_Results results = OpenALPRInstance.Recognize(TestImagePath);

                if(results.DidErrorOccur == false)
                {
                    foreach (var rr in results.FoundLicensePlates)
                    {
                        output += "Best: " + rr.BestLicensePlate + "(" + rr.Confidence + "%)\n";
                        foreach (var rc in rr.OtherCandidates)
                        {
                            output += "- " + rc.LicensePlate + "(" + rc.Confidence + "%)\n";
                        }
                    }
                } else
                {
                    output = results.Error.Message + ", " + results.Error.Stacktrace;
                }

                licensePlateTV.Text = output;
                Toast.MakeText(this, output, ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message + ", " + ex.StackTrace, ToastLength.Long).Show();
            }
        }
    }
}

