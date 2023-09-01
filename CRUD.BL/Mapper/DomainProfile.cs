using AutoMapper;
using CRUD.BL.Model;
using CRUD.DAL.Entity;

namespace CRUD.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //From Entity To ViewModel & ReverseMap => (Send Data To View)
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();

            //From ViewModel To Entity => (Get Data From View)
            //CreateMap<DepartmentVM, Department>();

        }
    }
}
