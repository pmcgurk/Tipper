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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            // view widgets
            Button button = FindViewById<Button>(Resource.Id.CalculateButton);
            EditText EditTextBill = FindViewById<EditText>(Resource.Id.billamount);
            EditText EditTextTipPercentage = FindViewById<EditText>(Resource.Id.tippercentage);
            TextView TextViewTip = FindViewById<TextView>(Resource.Id.tipamount);
            TextView TextViewTotal = FindViewById<TextView>(Resource.Id.totalamount);

            button.Click += delegate {
                try { 
                    double BillAmount = double.Parse(EditTextBill.Text);
                    double tipPercentage = double.Parse(EditTextTipPercentage.Text) / 100;
                    double tip = BillAmount * (tipPercentage);
                    double total = tip + BillAmount;
                    TextViewTip.Text = string.Format("Tip: {0:c}", tip);
                    TextViewTotal.Text = string.Format("Total: {0:c}", total);
                }
                catch (FormatException e)
                {
                    Toast.MakeText(this, "Invalid Input.", ToastLength.Short);
                }
         
            };
        }
    }
}

