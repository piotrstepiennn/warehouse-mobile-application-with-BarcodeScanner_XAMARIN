using Mag1.Models;
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
    public partial class EditItemPage : ContentPage
    {

        EditItemViewModel viewModel;
        ItemsViewModel ItemViewModel = new ItemsViewModel();

        public EditItemPage()
        {
            InitializeComponent();
        }

        public EditItemPage(EditItemViewModel viewModel)
        {
            InitializeComponent();


            BindingContext = this.viewModel = viewModel;
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            string OldItem = KodProduktu_Label.Text;
            string NewItemNazwa = NazwaProduktu_Entry.Text; if (NewItemNazwa is null) NewItemNazwa = NazwaProduktu_Label.Text;
            string NewItemKod = KodProduktu_Entry.Text; if (NewItemKod is null) NewItemKod = KodProduktu_Label.Text;
            string NewItemZapas = ZapasProduktu_Entry.Text; if (NewItemZapas is null) NewItemZapas = ZapasProduktu_Label.Text;
            string NewItemCenaZakupu = CenaZakupu_Entry.Text; if (NewItemCenaZakupu is null) NewItemCenaZakupu = CenaZakupu_Label.Text;
            string NewItemCenaSprzedazy = CenaSprzedazy_Entry.Text; if (NewItemCenaSprzedazy is null) NewItemCenaSprzedazy = CenaSprzedazy_Label.Text;
            string NewItem = NewItemNazwa + "," + NewItemKod + "," + NewItemZapas + "," + NewItemCenaZakupu + "," + NewItemCenaSprzedazy + "," + OldItem;
            var action = await DisplayAlert("Uwaga!", "Czy na pewno chcesz zapisać zmiany?", "Tak", "Nie");
            if (action)
            {
                var result = ItemViewModel.EditItem(NewItem);
                if (result)
                {
                    await DisplayAlert("Powiadomienie", "Udało się zmienić dane produktu.", "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new ItemsPage()));
                }           
            }
            else
            {
                await DisplayAlert("Powiadomienie", "Coś poszło nie tak.", "OK");
            }
        }
    }
}