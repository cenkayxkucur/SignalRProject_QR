﻿namespace SignalR.DtoLayer.ProductDto
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public bool ProductStatus { get; set; }
    }
}
