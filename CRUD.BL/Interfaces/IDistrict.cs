using CRUD.BL.Model;
using CRUD.DAL.Entity;
using System.Linq.Expressions;

namespace CRUD.BL.Interfaces
{
    public interface IDistrict
    {
        public Task<IEnumerable<DistrictVM>> GetAsync(Expression<Func<District , bool>> filter = null);

    }
}
