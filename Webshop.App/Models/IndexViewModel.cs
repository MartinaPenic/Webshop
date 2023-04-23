using Webshop.App.Models;

namespace Webshop.App.ViewModels
{
    public class IndexViewModel
    {
        public ShowcaseViewModel Showcase { get; set; }
        public CollectionViewModel Featured { get; set; }
        public CollectionViewModel New { get; set; }
        public CollectionViewModel Popular { get; set; }
    }
}
