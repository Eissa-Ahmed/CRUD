using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.DAL.Database;
using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CRUD.BL.Repository
{
    public class DepartmentRepo : IDepartment
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        public async Task Create(DepartmentVM departmentVM)
        {
            Department department = new Department();
            department.Name = departmentVM.Name;
            department.Address = departmentVM.Address;
            _dbContext.Department.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var OldData = _dbContext.Department.Find(id);
            _dbContext.Department.Remove(OldData);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Edit(DepartmentVM departmentVM)
        {
            var OldData = _dbContext.Department.Find(departmentVM.ID);
            if (OldData != null)
            {
                OldData.Name = departmentVM.Name;
                OldData.Address = departmentVM.Address;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentVM>> GetAll()
        {
            var data = await _dbContext.Department.Select(i => new DepartmentVM()
            {
                ID = i.ID,
                Name = i.Name,
                Address = i.Address,
            }).ToListAsync();
            return data;
        }

        public async Task<DepartmentVM> GetById(int id)
        {
            var data = await _dbContext.Department.Where(i => i.ID == id).Select(i => new DepartmentVM()
            {
                ID = i.ID,
                Name = i.Name,
                Address = i.Address,
            }).FirstOrDefaultAsync();
            return data;
        }
    }
}
