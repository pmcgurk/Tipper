using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "Tipper", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double tipPercentage = 10;
        double billAmount = 0;
        int splitAmount = 1;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            EditText EditTextBill = FindViewById<EditText>(Resource.Id.billamount);
            SeekBar SeekBarTip = FindViewById<SeekBar>(Resource.Id.seekBar1);
            TextView TextViewSplit = FindViewById<TextView>(Resource.Id.splitamount);

            SeekBarTip.ProgressChanged += delegate { seekBarChange(); };
            EditTextBill.TextChanged += delegate { billAmountChange(); };
            TextViewSplit.TextChanged += delegate { splitAmountChange(); };
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
                Console.WriteLine(e.ToString());
            }
        }

        private void splitAmountChange()
        {
            try
            {
                EditText EditTextSplit = FindViewById<EditText>(Resource.Id.splitamount);
                splitAmount = int.Parse(EditTextSplit.Text);
                changeCalculation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void seekBarChange()
        {
            SeekBar SeekBarTip = FindViewById<SeekBar>(Resource.Id.seekBar1);
            TextView TextViewSeekAmount = FindViewById<TextView>(Resource.Id.SeekTipAmount);
            tipPercentage = SeekBarTip.Progress;
            TextViewSeekAmount.Text = string.Format("+{0}%", SeekBarTip.Progress);

            changeCalculation();
        }

        private void changeCalculation()
        {
            TextView TextViewTip = FindViewById<TextView>(Resource.Id.tipamount);
            TextView TextViewTotal = FindViewById<TextView>(Resource.Id.totalamount);
            TextView TextViewSplit = FindViewById<TextView>(Resource.Id.splittotal);
            
            double tip = billAmount * (tipPercentage / 100);
            double total = tip + billAmount;
            double split = total / splitAmount;
            
            TextViewTip.Text = string.Format("Tip: {0:c} ({1}%)", tip, tipPercentage);
            TextViewTotal.Text = string.Format("Total: {0:c}", total);
            TextViewSplit.Text = string.Format("Split: {0:c} ({1})", split, splitAmount);
        }
    }
}

