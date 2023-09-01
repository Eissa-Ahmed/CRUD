using AutoMapper;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DepartmentRepo(ApplicationDbContext dbContext , IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public async Task Create(DepartmentVM departmentVM)
        {
            var department = _mapper.Map<Department>(departmentVM);
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
            var data1 = await _dbContext.Department.Select(i => i).ToListAsync();
            var data = _mapper.Map<List<DepartmentVM>>(data1);
            return data;
        }

        public async Task<DepartmentVM> GetById(int id)
        {
            var data1 = await _dbContext.Department.Where(i => i.ID == id).Select(i => i).FirstOrDefaultAsync();
            var data = _mapper.Map<DepartmentVM>(data1);
            return data;
        }
    }
}
