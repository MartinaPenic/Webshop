using AutoMapper;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(AddProductDto newProduct)
        {
            var entity = _mapper.Map<ProductEntity>(newProduct);
            entity.CreatedAt = DateTime.Now;
            entity.ModifiedAt = DateTime.Now;

            return await _productRepository.AddProductAsync(entity);
        }

        public async Task<ICollection<ProductDto>> GetNewProductsAsync()
        {
            return await _productRepository.GetNewProductsAsync();
        }

        public async Task<ICollection<ProductDto>> GetPopularProductsAsync()
        {
            return await _productRepository.GetPopularProductsAsync();
        }

        public async Task<ICollection<ProductDto>> GetFeaturedProductsAsync()
        {
            return await _productRepository.GetFeaturedProductsAsync();
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            return await _productRepository.GetProductAsync(id);
        }

        public async Task<ICollection<ProductDto>> GetSpecialOfferProductsAsync()
        {
            return await _productRepository.GetSpecialOfferProductsAsync();
        }

        public async Task<ICollection<ProductRatingDto>> GetProductRatingsAsync(int id)
        {
            return await _productRepository.GetProductRatingsAsync(id);
        }

        public async Task<bool> AddProductRatingAsync(int productId, AddProductRatingDto productRating)
        {
            var entity = _mapper.Map<ProductRatingEntity>(productRating);
            entity.ProductId = productId;
            entity.CreatedAt = DateTime.Now;

            return await _productRepository.AddProductRatingAsync(entity);
        }
    }
}
