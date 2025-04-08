using Microsoft.EntityFrameworkCore;
using ProperNutrition.DataAccess.Entities;
using ProperNutrition.DataAccess.Mappers;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProperNutritionDbContext _context;

        public UsersRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetAsync(Guid id)
        {
            var userEntity = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ue => ue.Id == id);

            if (userEntity is not null)
            {
                return UserMapper.ToDomain(userEntity);
            }

            return null;
        }

        public async Task<List<User>?> GetAllAsync()
        {
            var userEntities = await _context.Users
                    .AsNoTracking()
                    .ToListAsync();

            if (userEntities is not null)
            {
                return userEntities.Select(UserMapper.ToDomain).ToList();
            }

            return null;
        }

        public async Task AddAsync(User user)
        {
            var userEntity = UserMapper.ToEntity(user);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var userEntity = UserMapper.ToEntity(user);

            _context.Users.Update(userEntity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            var userEntity = UserMapper.ToEntity(user);

            _context.Users.Remove(userEntity);

            await _context.SaveChangesAsync();
        }
    }
}
