using EmployeeManagement.Core.Models.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Models
{
    public class Employee : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PhotoPath { get; set; }
        [NotMapped]
        public IFormFile ImageFile {  get; set; } 

        [NotMapped]
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }  
        }
        

    }

}
