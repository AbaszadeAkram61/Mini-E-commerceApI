using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Domain.Entities;
using E_TicaretApI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Persistence.Repositories
{
    public class Repostory<T> : IRepository<T> where T: BaseEntity
    {
        private readonly E_TicaretApiDbContext _context;

        public Repostory(E_TicaretApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
           EntityEntry<T> entityEntry=await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return Table;
            
        }

        public async Task<T> GetByIdAsync(string id)
        {
            T model= await Table.FindAsync(int.Parse(id));
            return model;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
           T model=await Table.FirstOrDefaultAsync(method);
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
           return Table.Where(method);
        }

        public bool Remove(T model)
        {
           EntityEntry<T> entityEntry= Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
           T model=await Table.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
           return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public bool Update(T model)
        {
           EntityEntry<T> entityEntry= Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
