using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
    public class CollectionItemViewModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }    
        public string Title { get; set; } 
        public string ImageUrl { get; set; } 
        public decimal Price { get; set; }  
        public string ButtonCaption { get; set; } 
        public decimal AverageRating { get; set; }


        public static implicit operator CollectionItemViewModel(Product product)
        {
            return new CollectionItemViewModel
            {
               Id = product.Id,   
               Category = product.Category,
               Title = product.Name,
               ImageUrl = product.PictureUrl,   
               Price = (int)product.Price, 
               AverageRating = product.AverageRating,
               ButtonCaption = "QUICK VIEW"
            };
        }
    }
}
