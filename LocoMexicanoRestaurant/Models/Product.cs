using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocoMexicanoRestaurant.Models
{
    public class Product
    {
        public Product()
        {
            ProductIngredients = new List<ProductIngredient>();
            //initialization
            //we cant add something to null but can add to empty list.
            //this is to store ingredients passed in addedit method
        }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category? Category { get; set; } //product belongs to a category
        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; } //a product can be in many orders
        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; } //a product can have many ingredients
        [NotMapped] //not mapping imagefile but we are mapping image url
        public IFormFile? ImageFile { get; set; }
        public string Imageurl { get; set; } = "https://via.placeholder.com/150";

    }
}
