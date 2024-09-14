using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repo.IRepositories
{
    public interface IRepository<T> where T : class
    {
       
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);       
        Task DeleteAsync(T entity);      
        Task SaveChangesAsync();      
        Task<IList<T>> GetAllAsync();
        Task<T> GetIdAsync(Guid id);
        Task<List<Employee>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalProductsCountAsync();
        Task AddProductAsync(Employee product);
    }
}
