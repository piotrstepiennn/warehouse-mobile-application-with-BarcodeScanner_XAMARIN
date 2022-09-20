using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mag1.Models;
using Mag1.Views;
using System.Collections.Generic;

namespace Mag1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public static List<Item> produkty = new List<Item>();
        Models.SqlDBHandler sqlDBHandler = new Models.SqlDBHandler();

        public ItemsViewModel()
        {
            Title = "Magazyn";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var t = sqlDBHandler.GetAllItems("select nazwa_art, kod_kresk, zapas, koszt_zakupu, wartosc_sprzedazy from artykuly");
                Items.Clear();
                produkty.Clear();

                if (t != null)
                {
                    foreach (var entity in t)
                    {
                        if (entity == null || entity.Equals(""))
                        {
                            continue;
                        }

                        var table = entity.Split('*');
                        Item item = new Item();

                        item.Name = table[0];
                        item.Kod = table[1];
                        item.Pieces = table[2];
                        item.Ledger = new Ledger(float.Parse(table[3]), float.Parse(table[4]));

                        Items.Add(item);
                        produkty.Add(item);
                    }
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        public bool AddNewItem(string nazwa, string zapas, string kod, string cena_zakupu, string cena_sprzedazy)
        {
            var result = sqlDBHandler.CreateItem($"insert into artykuly (nazwa_art, zapas, kod_kresk, wartosc_sprzedazy, koszt_zakupu) values ('{nazwa}',{zapas},{kod},{cena_zakupu}, {cena_sprzedazy})");
            if(result)
            return true;
            return false;
        }
    }
    
    

}