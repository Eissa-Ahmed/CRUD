using CRUD.BL.Model;
using CRUD.DAL.Entity;
using System.Linq.Expressions;

namespace CRUD.BL.Interfaces
{
    public interface IEmployee
    {
        Task<List<EmployeeVM>> GetAll(Expression<Func<Employee, bool>> filter = null);
        Task<EmployeeVM> GetById(Expression<Func<Employee, bool>> filter = null);
        Task Create(EmployeeVM EmployeeVM);
        Task Delete(int id);
        Task Edit(EmployeeVM EmployeeVM);
        Task<IEnumerable<EmployeeVM>> Serach(string name);
    }
}
