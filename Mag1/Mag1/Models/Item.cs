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
        public Ledger Ledger { get; set; }


        public Item() { }

        public Item(string name, string kod, string pieces, Ledger ledger)
        {
            Name = name;
            Pieces = pieces;
            Kod = kod;
            Ledger = ledger;
        }
               
    }
}