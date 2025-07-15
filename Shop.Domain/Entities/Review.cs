﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public short Rating { get; set; }

        public int ProductId { get; set; }
        public int? UserId { get; set; }

        public Product Product { get; set; }
    }
}
