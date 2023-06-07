﻿namespace MicroPlate.Product.Domain.Entities
{
    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public Int16 BuyingPrice { get; set; }
        public Int16 Rate { get; set; }

    }
}
