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
        TextView tipPercent;
        EditText subTotal;
        EditText tipValue;
        EditText total;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            tipPercent = FindViewById<TextView>(Resource.Id.textView1);
            var seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            subTotal = FindViewById<EditText>(Resource.Id.subTotal);
            tipValue = FindViewById<EditText>(Resource.Id.tipValue);
            total = FindViewById<EditText>(Resource.Id.total);

            seekBar.ProgressChanged += SeekBar_ProgressChanged;
            subTotal.TextChanged += SubTotal_TextChanged;
        }

        private void Calculate()
        {
            int money = 0;
            int tipPerc = 0;

            try
            {
                money = int.Parse(subTotal.Text);
                tipPerc = int.Parse(tipPercent.Text);
            }
            catch
            {
                tipValue.Text = "0";
                total.Text = "0";
                return;
            }

            if (money == 0)
            {
                tipValue.Text = "0";
                total.Text = "0";
                return;
            }

            int tip = money * tipPerc / 100;
            int sum = money + tip;

            tipValue.Text = tip.ToString();
            total.Text = sum.ToString();
        }

        private void SubTotal_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            Calculate();
        }

        private void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            tipPercent.Text = e.Progress.ToString();
            Calculate();
        }
    }
}