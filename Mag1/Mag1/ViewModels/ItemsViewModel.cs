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
        public static List<Ledger> ksiega_rachunkowa = new List<Ledger>();

        public ItemsViewModel()
        {
            Title = "Magazyn";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "Dodaj", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Models.SqlDBHandler sqlDBHandler = new Models.SqlDBHandler();
                var t = sqlDBHandler.ExecuteQuery("select nazwa_art, kod_kresk, zapas from artykuly");
                

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

        public ObservableCollection<Item> GetItems()
        {
            return Items;
        }
        
    }
    
}