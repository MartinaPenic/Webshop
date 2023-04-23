namespace Webshop.App.Models
{
    public class CollectionItemViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }    
        public string Title { get; set; } 
        public string ImageUrl { get; set; } 
        public decimal Price { get; set; }  
        public string ButtonCaption { get; set; } 
        public decimal AverageRating { get; set; }   
    }
}
