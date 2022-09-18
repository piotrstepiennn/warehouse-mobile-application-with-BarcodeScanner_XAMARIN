using System;
using Mag1.ViewModels;
namespace Mag1.Models
{
    public class Item
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Pieces { get; set; }
        public string Kod { get; set; }

        public Item(string name, string pieces, string kod)
        {
            Name = name;
            Pieces = pieces;
            Kod = kod;
        }
        public Item() { }

               
    }
}