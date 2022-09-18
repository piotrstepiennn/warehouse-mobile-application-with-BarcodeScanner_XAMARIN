using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Mag1.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        public AddItemViewModel()
        {
            Title = "Dodaj Produkt";

        }

        public ICommand OpenWebCommand { get; }
    }
}