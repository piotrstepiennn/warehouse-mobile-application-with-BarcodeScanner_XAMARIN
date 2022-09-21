using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mag1.Models;
using Mag1.ViewModels;

namespace Mag1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        ItemsViewModel ItemViewModel = new ItemsViewModel();

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Item 1",
                Pieces = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var item = new Item(NazwaProduktu_Label.Text, KodProduktu_Label.Text, ZapasProduktu_Label.Text, new Ledger(float.Parse(CenaZakupy_Label.Text), float.Parse(CenaSprzedazy_Label.Text)));
            await Navigation.PushModalAsync(new NavigationPage(new EditItemPage(new EditItemViewModel(item))));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            string kod = KodProduktu_Label.Text;
            var action = await DisplayAlert("Uwaga!", "Czy na pewno chcesz usunąć przedmiot?", "Tak", "Nie");
            if (action)
            {
                var result = ItemViewModel.DeleteItem(kod);
                if (result)
                {
                    await DisplayAlert("Powiadomienie", "Udało się usunąć produkt.", "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new ItemsPage()));
                }
            }
            else
            {
                await DisplayAlert("Powiadomienie", "Przedmiot nie został usunięty.", "OK");
            }
        }
    }
}