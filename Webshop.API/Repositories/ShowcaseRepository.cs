using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webshop.API.Context;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;

namespace Webshop.API.Repositories
{
    public class ShowcaseRepository
    {


        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ShowcaseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddShowcaseAsync(ShowcaseEntity newShowcase)
        {
            try
            {
                _context.Showcases.Add(newShowcase);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ShowcaseDto> GetNewShowcaseAsync()
        {
            var showcase = await _context.Showcases.OrderByDescending(s => s.CreatedAt).FirstOrDefaultAsync();

            return _mapper.Map<ShowcaseDto>(showcase);
        }
    }
}

