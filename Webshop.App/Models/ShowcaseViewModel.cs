namespace Webshop.App.Models
{
    public class ShowcaseViewModel
    {
        public string Title { get; set; } 
        public string Ingress { get; set; } 
        public string Subtitle { get; set; } 
        public string ButtonCaption { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
