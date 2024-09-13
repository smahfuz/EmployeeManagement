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
    }
}
