using Mag1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mag1.ViewModels
{
    public class EditItemViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public EditItemViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
