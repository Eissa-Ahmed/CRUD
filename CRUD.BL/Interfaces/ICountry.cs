using CRUD.BL.Model;
using CRUD.DAL.Entity;
using System.Linq.Expressions;

namespace CRUD.BL.Interfaces
{
    public interface ICountry
    {
        public Task<IEnumerable<CountryVM>> GetAsync(Expression<Func<Country, bool>> filter = null);

    }
}
