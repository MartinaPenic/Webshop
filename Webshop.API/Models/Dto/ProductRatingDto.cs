namespace Webshop.API.Models.Dto
{
    public class ProductRatingDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
    }
}
