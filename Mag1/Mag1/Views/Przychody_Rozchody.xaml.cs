using Mag1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mag1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Przychody_Rozchody : ContentPage
	{
		public Przychody_Rozchody ()
		{
			InitializeComponent ();
		}


        private void ObliczBilans_Button_Clicked(object sender, EventArgs e)
        {
            var item = ItemsViewModel.ksiega_rachunkowa;

            double koszt = 0;
            foreach (var i in item)
            {
                
                koszt += Convert.ToDouble(i.Sale_Value);
            }
            Przychody_label.Text = koszt.ToString() + " zl";

            double wydatek = 0;
            foreach (var i in item)
            {
                
                wydatek += Convert.ToDouble(i.Purchase_Value);
                Wydatki_label.Text = wydatek.ToString() + " zl";
            }
            
        }
    }
}