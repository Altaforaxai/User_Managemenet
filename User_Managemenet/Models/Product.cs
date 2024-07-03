﻿namespace User_Managemenet.Models
{
    public class Product
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
