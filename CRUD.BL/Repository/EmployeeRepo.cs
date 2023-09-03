using AutoMapper;
using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.DAL.Database;
using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.BL.Repository
{
    public class EmployeeRepo : IEmployee

    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public EmployeeRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            this.dbContext = _dbContext;
            this.mapper = _mapper;
        }
        public async Task Create(EmployeeVM EmployeeVM)
        {
            var employee = mapper.Map<Employee>(EmployeeVM);
            dbContext.Employee.Add(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = dbContext.Employee.Find(id);
            item.IsDeleted = true;
            item.DeletedDate = DateTime.Now;
            item.IsActive = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(EmployeeVM EmployeeVM)
        {
            EmployeeVM.UpdateDate = DateTime.Now;
            EmployeeVM.IsUpdated = true;
            var item = mapper.Map<Employee>(EmployeeVM);
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeVM>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter != null)
            {
                var items = await dbContext.Employee.Where(filter).Include("Department").Include("District").ToListAsync();
                var data = mapper.Map<List<EmployeeVM>>(items);
                return data;
            }
            else
            {
                var items = await dbContext.Employee.ToListAsync();
                var data = mapper.Map<List<EmployeeVM>>(items);
                return data;
            }


        }

        public async Task<EmployeeVM> GetById(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter != null)
            {
                var item = await dbContext.Employee.Where(filter).FirstOrDefaultAsync();
                var data = mapper.Map<EmployeeVM>(item);
                return data;
            }
            else
            {
                var item = await dbContext.Employee.FirstOrDefaultAsync();
                var data = mapper.Map<EmployeeVM>(item);
                return data;
            }
        }

        public async Task<IEnumerable<EmployeeVM>> Serach(string name)
        {
            var item = await dbContext.Employee.Where(i => i.Name.StartsWith(name)).Include("Department").ToListAsync();
            var data = mapper.Map<IEnumerable<EmployeeVM>>(item);
            return data;
        }
    }
}
