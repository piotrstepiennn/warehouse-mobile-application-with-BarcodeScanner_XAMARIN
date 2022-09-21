using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mag1.Models;
using Mag1.ViewModels;
using System.Collections.ObjectModel;

namespace Mag1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanPage : ContentPage
	{
        public ScanPage ()
		{
			InitializeComponent ();
            scanResultText.Text = "Szukam...";
            stanMagazynowyText.Text = "0";
        }


        void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                scanResultText.Text = result.Text;

                var item = ItemsViewModel.produkty;
                foreach (var i in item)
                {

                    if (i.Kod.Contains(result.Text) || i.Kod.Equals(result.Text.ToString()))
                    {
                        stanMagazynowyText.Text = "Nazwa produktu: " + i.Name.ToString() + " Stan Magazynowy: " + i.Pieces.ToString(); break;
                    }
                    else stanMagazynowyText.Text = "Brak produktu w bazie";

                }
                
            });
            
        }


    }
}