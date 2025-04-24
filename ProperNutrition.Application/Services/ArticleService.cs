using Microsoft.EntityFrameworkCore.Infrastructure;
using ProperNutrition.Application.Mappers;
using ProperNutrition.Application.Models;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticleService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<string> AddAsync(ArticleRequest model)
        {
            try
            {
                var entity = new ArticleEntity
                {
                    Head = model.Head,
                    Body = model.Body,
                    CreatedAt = DateTime.UtcNow
                };

                if (model.Image is not null)
                {
                    entity.Image = Convert.FromBase64String(model.Image);
                }

                await _articlesRepository.AddAsync(entity);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateAsync(Guid id, ArticleRequest model)
        {
            try
            {
                var entity = await _articlesRepository.GetAsync(id);

                if (entity is not null)
                {
                    entity.Head = model.Head;
                    entity.Body = model.Body;

                    if (model.Image is not null)
                    {
                        entity.Image = Convert.FromBase64String(model.Image);
                    }

                    await _articlesRepository.UpdateAsync(entity);

                    return string.Empty;
                }

                return "Такой новости не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _articlesRepository.GetAsync(id);

                if (entity is not null)
                {
                    await _articlesRepository.DeleteAsync(entity);

                    return string.Empty;
                }

                return "Такой новости не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Article>> GetAllAsync()
        {
            try
            {
                var entities = await _articlesRepository.GetAllAsync();

                if(entities is not null)
                {
                    return entities.Select(ArticleMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }
    }
}
