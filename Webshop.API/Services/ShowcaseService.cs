using AutoMapper;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class ShowcaseService
    {
        private readonly ShowcaseRepository _showcaseRepository;
        private readonly IMapper _mapper;

        public ShowcaseService(ShowcaseRepository showcaseRepository, IMapper mapper)
        {
            _showcaseRepository = showcaseRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddShowcaseAsync(AddShowcaseDto newShowcase)
        {
            var entity = _mapper.Map<ShowcaseEntity>(newShowcase);
            entity.CreatedAt = DateTime.Now;
            return await _showcaseRepository.AddShowcaseAsync(entity);
        }

        public async Task<ShowcaseDto> GetNewShowcaseAsync()
        {
            return await _showcaseRepository.GetNewShowcaseAsync();
        }
    }
}

