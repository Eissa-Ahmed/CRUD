using CRUD.BL.Model;

namespace CRUD.BL.Interfaces
{
    public interface IDepartment
    {
        Task<List<DepartmentVM>> GetAll();
        Task<DepartmentVM> GetById(int id);
        Task Create(DepartmentVM departmentVM);
        Task Delete(int id);
        Task Edit(DepartmentVM departmentVM);
    }
}
