﻿using Webshop.App.Models.Dto;

namespace Webshop.App.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetFeaturedProducts();

        Task<IEnumerable<Product>> GetNewProducts();

        Task<IEnumerable<Product>> GetPopularProducts();

        Task<Product> GetProduct(int id);

        Task<IEnumerable<ProductRating>> GetProductRatings(int id);
    }
}
