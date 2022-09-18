using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag1.Models;

namespace Mag1.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "First item", Pieces="This is an item description." },
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "Second item", Pieces="This is an item description." },
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "Third item", Pieces="This is an item description." },
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "Fourth item", Pieces="This is an item description." },
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "Fifth item", Pieces="This is an item description." },
                new Item { Symbol = Guid.NewGuid().ToString(), Name = "Sixth item", Pieces="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Symbol == item.Symbol).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Symbol == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Symbol == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}