using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
    public class ShowcaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonCaption { get; set; }

        public static implicit operator ShowcaseViewModel(Showcase showcase)
        {
            return new ShowcaseViewModel
            {
                Id = showcase.Id,
                Title = showcase.Title,
                Description = showcase.Description,  
                Subtitle = showcase.Subtitle,
                ImageUrl = showcase.ImageUrl,
                ButtonCaption = "SHOP NOW"
            };
        }
    }
}

