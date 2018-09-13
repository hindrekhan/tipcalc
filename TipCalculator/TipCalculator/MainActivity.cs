using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            textView = FindViewById<TextView>(Resource.Id.textView1);
            var seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);

            seekBar.ProgressChanged += SeekBar_ProgressChanged;
        }

        private void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            textView.Text = e.Progress.ToString();
        }
    }
}