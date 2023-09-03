using CRUD.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BL.Model
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            IsActive = true;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email Is Not Valid")]
        public string Email { get; set; }
        [Range(2000,6000,ErrorMessage = "Range From 2K To 6K")]
        public double Salary { get; set; }
        [RegularExpression("[1-9]{1,3}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}", ErrorMessage = "12-StreetName-City")]
        public string Address { get; set; }
        public string? Notes { get; set; }

        public DateTime HirDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool? IsUpdated { get; set; }
        [Required(ErrorMessage = "Department Is Required")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int DistrictId { get; set; }

        public District District { get; set; }

    }
}
