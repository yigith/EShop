﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await (await ApplySpecification(specification)).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> specification)
        {
            return await (await ApplySpecification(specification)).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> specification)
        {
            return await(await ApplySpecification(specification)).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await (await ApplySpecification(specification)).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<IQueryable<T>> ApplySpecification(ISpecification<T> specification)
        {
            return await EfSpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
        }
    }
}
