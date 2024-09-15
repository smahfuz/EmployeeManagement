using EmployeeManagement.Core.Models;
using EmployeeManagement.Repo.IRepositories;
using EmployeeManagement.Repo.Repositories;
using EmployeeManagement.Service.Services.IService;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
        }

        public async Task DeleteAsync(Employee obj)
        {
           _employeeRepository.DeleteAsync(obj);
            _employeeRepository.SaveChangesAsync();

        }
        
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetIdAsync(Guid id)
        {
            var emp = await _employeeRepository.GetIdAsync(id);
            if (emp == null) throw new KeyNotFoundException($"Student with id {id} not found.");
            return emp;
        }

        public async Task InsertAsync(Employee obj)
        {
            await _employeeRepository.InsertAsync(obj);
        }

        public async Task SaveChangesAsync()
        {
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee obj)
        {
            await _employeeRepository.UpdateAsync(obj);
        }

        //public async Task<List<Employee>> GetPagedProductsAsync(int pageNumber, int pageSize)
        //{
        //    return await _employeeRepository.GetPagedProductsAsync(pageNumber, pageSize);
        //}

        //public async Task<int> GetTotalProductsCountAsync()
        //{
        //    return await _employeeRepository.GetTotalProductsCountAsync();
        //}

        //public async Task AddProductAsync(Employee employee)
        //{
        //    await _employeeRepository.AddProductAsync(employee);
        //}

        //public async Task<(IEnumerable<Employee> Employees, int TotalCount)> GetEmployeesAsync(string searchString,string SEmail,string SMobile, DateOnly DateOfBirth, int page, int pageSize)
        //{
        //    int skip = (page - 1) * pageSize;
        //    var employees = await _employeeRepository.GetEmployeesAsync(searchString,SEmail,SMobile, DateOfBirth, skip, pageSize);
        //    var totalCount = await _employeeRepository.GetTotalCountAsync(searchString,SEmail,SMobile, DateOfBirth);

        //    return (employees, totalCount);
        //}

        public async Task<(IEnumerable<Employee> Employees, int TotalCount)> GetEmployeesAsync(string searchString, string SEmail, string SMobile, DateOnly? DateOfBirth, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            var employees = await _employeeRepository.GetEmployeesAsync(searchString, SEmail, SMobile, DateOfBirth, skip, pageSize);
            var totalCount = await _employeeRepository.GetTotalCountAsync(searchString, SEmail, SMobile, DateOfBirth);

            return (employees, totalCount);
        }


        //public Task<int> GetTotalProductsCountAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
