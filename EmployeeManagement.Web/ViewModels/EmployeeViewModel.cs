using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Core.Models.Base;

namespace EmployeeManagement.Web.ViewModels
{
    public class EmployeeViewModel : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid mobile number format.")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateOnly DateOfBirth { get; set; }

        public string? PhotoPath { get; set; }

        [Required(ErrorMessage = "Image file is required.")]
        public IFormFile? ImageFile { get; set; }

        public string? FullName { get; set; }
    }
}
