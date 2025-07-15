﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Cart
    {
        public string UserId { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Total => Items.Sum(item => item.TotalPrice);
        public int TotalQuantity => Items.Sum(item => item.Quantity);
    }

}
