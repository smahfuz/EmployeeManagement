using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services.IService
{
    public interface IEmployeeService
    {
        Task InsertAsync(Employee obj);
        Task UpdateAsync(Employee obj);
        Task DeleteAsync(Employee obj);
        Task SaveChangesAsync();
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetIdAsync(Guid id);
        Task<List<Employee>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalProductsCountAsync();
        Task AddProductAsync(Employee product);
    }
}
