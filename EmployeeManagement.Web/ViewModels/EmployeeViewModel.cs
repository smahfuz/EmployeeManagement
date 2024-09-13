using EmployeeManagement.Core.Models.Base;

namespace EmployeeManagement.Web.ViewModels
{
    public class EmployeeViewModel : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Images { get; set; }
    }
}
