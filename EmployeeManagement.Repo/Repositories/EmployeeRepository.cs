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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository

    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext context) : base(context)
        {
            _dbContext = context;
        }


    }
}
