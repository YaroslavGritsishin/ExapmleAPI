﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDataLayer
{
    public class ProductEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
