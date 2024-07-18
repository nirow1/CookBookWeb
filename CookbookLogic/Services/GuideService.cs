using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;

namespace CookbookLogic.Services
{
    internal class GuideService
    {
        private readonly GuideRepository _guideRepository;

        public GuideService(GuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        public async Task<IEnumerable<GuideDto>>GetGuides() =>(await _guideRepository.GetGuides()).Select(r=> new GuideDto(r));
    }
}
