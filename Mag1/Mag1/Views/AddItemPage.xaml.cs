using Mag1.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mag1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        ItemsViewModel viewModel = new ItemsViewModel();
        public AddItemPage()
        {
            InitializeComponent();
        }

        private void AddProduct_Clicked(object sender, EventArgs e)
        {
            string nazwa = NazwaProduktu_Entry.Text;
            string zapas = StanMagazynowy_Entry.Text;
            string kod = Kod_Entry.Text;
            string cenaZakupu = CenaZakupu_Entry.Text;
            string cenaSprzedazy = CenaSprzedazy_Entry.Text;
            var result = viewModel.AddNewItem(nazwa, zapas, kod, cenaZakupu, cenaSprzedazy);
            if (result)
            {
                DisplayAlert("Powiadomienie", "Udało się dodać produkt.", "OK");
            }
            else
            {
                DisplayAlert("Powiadomienie", "Coś poszło nie tak.", "OK");
            }
        }
    }
}