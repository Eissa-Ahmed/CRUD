using CRUD.DAL.Entity;

namespace CRUD.BL.Model
{
    public class CityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
