using AutoMapper;
using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.DAL.Database;
using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.BL.Repository
{
    public class DistrictRepo : IDistrict
    {
        ApplicationDbContext dbContext;
        IMapper mapper;
        public DistrictRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<IEnumerable<DistrictVM>> GetAsync(Expression<Func<District, bool>> filter = null)
        {
            if (filter != null)
            {
                var item = await dbContext.District.Where(filter).Include("City").ToListAsync();
                var data = mapper.Map<IEnumerable<DistrictVM>>(item);
                return data;
            }
            else
            {
                var item = await dbContext.Country.ToListAsync();
                var data = mapper.Map<IEnumerable<DistrictVM>>(item);
                return data;
            }
        }
    }
}
