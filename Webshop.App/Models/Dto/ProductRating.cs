namespace Webshop.App.Models.Dto
{
    public class ProductRating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Score { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
    }
}
