using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webshop.API.Context;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;

namespace Webshop.API.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(ProductEntity entity)
        {
            try
            {
                _context.Products.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch 
            { 
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
			try
			{
				var entity = _context.Products.Single(p => p.Id == id);
				_context.Products.Remove(entity);
				await _context.SaveChangesAsync();

				return true;
			}
			catch
			{
				return false;
			}
		}

        public async Task<ICollection<ProductDto>> GetNewProductsAsync()
        {
            var products = await 
                _context.Products
                ?.Where(p => p.CreatedAt >= DateTime.Now.AddDays(-30))
                .Include(p => p.Ratings)
                .ToListAsync();

            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<ICollection<ProductDto>> GetPopularProductsAsync()
        {
            var products = await 
                _context.Products
                .Where(p => p.Ratings.Count > 0)
                .Include(p => p.Ratings)
                .OrderByDescending(p => p.Ratings.Average(r => r.Score))
                .Take(2)
                .ToListAsync();

            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<ICollection<ProductDto>> GetFeaturedProductsAsync()
        {
            var products = 
                await _context.Products
                .Where(p => p.IsFeatured)
                .Include(p => p.Ratings)
                .ToListAsync();

            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = 
                await _context.Products
                .Include(p => p.Ratings)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ICollection<ProductDto>> GetSpecialOfferProductsAsync()
        {
            var products = 
                await _context.Products
                .Include(p => p.Ratings)
                .Where(p => p.Discount != 0)
                .ToListAsync();

            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<ICollection<ProductRatingDto>> GetProductRatingsAsync(int id)
        {
            var ratings = await _context.Ratings.Where(r => r.ProductId == id).ToListAsync(); 
            return _mapper.Map<ICollection<ProductRatingDto>>(ratings);
        }

        public async Task<bool> AddProductRatingAsync(ProductRatingEntity entity)
        {
            try
            {
                _context.Ratings.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
