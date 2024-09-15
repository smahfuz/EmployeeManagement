using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repo.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        // You can define specific methods for EmployeeRepository here if needed.
        Task<IEnumerable<Employee>> GetEmployeesAsync(string searchString,string SEmail, string SMobile, DateOnly? DateOfBirth, int skip, int take);
        Task<int> GetTotalCountAsync(string searchString,string SEmail, string SMobile, DateOnly? DateOfBirth);
    }
}
