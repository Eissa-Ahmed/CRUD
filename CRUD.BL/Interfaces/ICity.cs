using CRUD.BL.Model;
using CRUD.DAL.Entity;
using System.Linq.Expressions;

namespace CRUD.BL.Interfaces
{
    public interface ICity
    {
        public Task<IEnumerable<CityVM>> GetAsync(Expression<Func<City, bool>> filter = null);

    }
}
