using AutoMapper;
using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.DAL.Database;
using CRUD.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.BL.Repository
{
    public class CountryRepo : ICountry
    {
        ApplicationDbContext dbContext ;
        IMapper mapper ;
        public CountryRepo(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public async Task<IEnumerable<CountryVM>> GetAsync(Expression<Func<Country, bool>> filter = null)
        {
            if (filter != null)
            {
                var item = await dbContext.Country.Where(filter).ToListAsync();
                var data = mapper.Map<IEnumerable<CountryVM>>(item);
                return data;
            }
            else
            {
                var item = await dbContext.Country.ToListAsync();
                var data = mapper.Map<IEnumerable<CountryVM>>(item);
                return data;
            }
        }
    }
}
