using AutoMapper;
using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.DAL.Database;
using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.BL.Repository
{
    public class CityRepo : ICity
    {
        ApplicationDbContext dbContext;
        IMapper mapper;
        public CityRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public async Task<IEnumerable<CityVM>> GetAsync(Expression<Func<City, bool>> filter = null)
        {
            if (filter != null)
            {
                var item = await dbContext.City.Where(filter).Include("Country").ToListAsync();
                var data = mapper.Map<IEnumerable<CityVM>>(item);
                return data;
            }
            else
            {
                var item = await dbContext.City.Include("Country").ToListAsync();
                var data = mapper.Map<IEnumerable<CityVM>>(item);
                return data;
            }
        }
    }
}
