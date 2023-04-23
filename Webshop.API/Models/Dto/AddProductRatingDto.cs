namespace Webshop.API.Models.Dto
{
    public class AddProductRatingDto
    {
        public int Score { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
    }
}
