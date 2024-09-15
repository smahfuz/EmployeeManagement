using EmployeeManagement.Core.Models;
using EmployeeManagement.Repo.Data;
using EmployeeManagement.Repo.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(string searchString, string SEmail, string SMobile, DateOnly? DOB, int skip, int take)
        {
            var query = _dbContext.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(SEmail))
            {
                query = query.Where(e => e.Email.Contains(SEmail));
            }
            if (!string.IsNullOrEmpty(SMobile))
            {
                query = query.Where(e => e.Mobile == SMobile);
            }
            if (!string.IsNullOrEmpty(SMobile))
            {
                query = query.Where(e => e.Mobile == SMobile);
            }
            if ((DOB) != null)
            {
                query = query.Where(e => e.DateOfBirth == DOB);
            }

            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(string searchString,string SEmail, string SMobile, DateOnly? DOB)
        {
            var query = _dbContext.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(SEmail))
            {
                query = query.Where(e => e.Email.Contains(SEmail));
            }
            if (!string.IsNullOrEmpty(SMobile))
            {
                query = query.Where(e => e.Mobile == SMobile);
            }
            if ((DOB) != null)
            {
                query = query.Where(e => e.DateOfBirth == DOB);
            }

            return await query.CountAsync();
        }
    }
}
