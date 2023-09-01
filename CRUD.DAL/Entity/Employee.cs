using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string? Notes { get; set; }
        public DateTime HirDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool? IsUpdated { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

      
    }
}
