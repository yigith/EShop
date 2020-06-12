using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ShopContext _dbContext;

        public EfRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
