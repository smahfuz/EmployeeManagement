using EmployeeManagement.Core.Models;
using EmployeeManagement.Repo.Data;
using EmployeeManagement.Repo.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EmployeeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }



        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                _context.SaveChangesAsync();
            });
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<Employee>> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            return await _context.Employees
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalProductsCountAsync()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task AddProductAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }


    }
}
