using System;
using System.Collections.Generic;
using System.Text;

namespace Mag1.Models
{
    public class Ledger
    {
        public float Purchase_Value { get; set; }
        public float Sale_Value { get; set; }

        public Ledger(float purchaseValue, float saleValue)
        {
            Purchase_Value = purchaseValue;
            Sale_Value = saleValue;
        }
    }
}
