using System.ComponentModel.DataAnnotations;

namespace CRUD.BL.Model
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Is Required") , MaxLength(15 , ErrorMessage = "MaxLength Is 15")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address Is Required") , MaxLength(25, ErrorMessage = "MaxLength Is 25")]
        public string Address { get; set; }
    }
}
