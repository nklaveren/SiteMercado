﻿using SiteMercado.Core.Entities;

using System.ComponentModel.DataAnnotations;

namespace SiteMercado.WebApi.Api.Products
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Description are required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Price are required")]
        [Range(0.01D, double.MaxValue)]
        public decimal Price { get; set; }
        public string Image { get; set; }


        public Product ToProduct(int id)
        {
            var product = ToProduct();
            product.Id = id;
            return product;
        }

        public Product ToProduct()
        {
            return new Product(Description, Price, Image);
        }
    }
}
