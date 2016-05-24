using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double tipPercentage = 0;
        double billAmount = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            EditText EditTextBill = FindViewById<EditText>(Resource.Id.billamount);
            SeekBar SeekBarTip = FindViewById<SeekBar>(Resource.Id.seekBar1);


            SeekBarTip.ProgressChanged += delegate { seekBarChange(); };
            EditTextBill.TextChanged += delegate { billAmountChange(); };
        }

        private void billAmountChange()
        {
            try
            {
                EditText EditTextBill = FindViewById<EditText>(Resource.Id.billamount);
                billAmount = double.Parse(EditTextBill.Text);
                changeCalculation();
            } 
            catch (Exception e)
            {

            }
        }

        private void seekBarChange()
        {
            SeekBar SeekBarTip = FindViewById<SeekBar>(Resource.Id.seekBar1);
            TextView TextViewSeekAmount = FindViewById<TextView>(Resource.Id.SeekTipAmount);
            tipPercentage = SeekBarTip.Progress;
            TextViewSeekAmount.Text = string.Format("{0}%", SeekBarTip.Progress);

            changeCalculation();
        }

        private void changeCalculation()
        {
            TextView TextViewTip = FindViewById<TextView>(Resource.Id.tipamount);
            TextView TextViewTotal = FindViewById<TextView>(Resource.Id.totalamount);
            
            double tip = billAmount * (tipPercentage / 100);
            double total = tip + billAmount;
            
            TextViewTip.Text = string.Format("Tip: {0:c}", tip);
            TextViewTotal.Text = string.Format("Total: {0:c}", total);
        }
    }
}

