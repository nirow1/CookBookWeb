﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookbookDataAccess.Models;
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
        
        public async Task<GuideDto> GetGuideById(int id)
        {
            var newGuide = await _guideRepository.GetGuideById(id);
            if (newGuide == null)
                throw new KeyNotFoundException($"recipe with id {id} not found");

            return new GuideDto(newGuide);
        }

        public async Task CreateGuide(GuideDto guide)
        {
            var newGuide = new Guide
            {
                Id = guide.Id,
                RecipeId = guide.RecipeId,
                Type = guide.Type,
                Score = guide.Score,
                WritenGuide = guide.WritenGuide,
                Ingredients = guide.Ingredients,
            };
            await _guideRepository.CreateGuide(newGuide);
        }
    
    }
}