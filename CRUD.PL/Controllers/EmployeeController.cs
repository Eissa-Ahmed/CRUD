using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using CRUD.BL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD.PL.Controllers
{
    public class EmployeeController : Controller
    {

        #region Properities
        private readonly IEmployee employee;
        private readonly IDepartment department;
        private readonly ICity ICity;
        private readonly IDistrict IDistrict;
        #endregion

        #region Ctor
        public EmployeeController(IEmployee _employee, IDepartment _department , ICity _ICity , IDistrict _IDistrict)
        {
            this.employee = _employee;
            this.department = _department;
            this.ICity = _ICity;
            this.IDistrict = _IDistrict;
        }
        #endregion


        #region Action
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (SearchValue != null)
            {
                TempData["Search"] = SearchValue;
               var data = await employee.Serach(SearchValue);
                return View(data);
            }
            else
            {
                var data = await employee.GetAll(i => i.IsDeleted == false);
                return View(data);
            }
            
        }
        public async Task<IActionResult> Create()
        {
            var data = await department.GetAll();
            ViewBag.departmentList = new SelectList(data, "ID", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM EmployeeVM)
        {
            var data = await department.GetAll();
            ViewBag.departmentList = new SelectList(data, "ID", "Name");
            try
            {
                if (ModelState.IsValid)
                {
                    await employee.Create(EmployeeVM);
                    return RedirectToAction("Index", "Employee");
                }
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(EmployeeVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await employee.Delete(id);
            return RedirectToAction("Index", "Employee");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var items = await department.GetAll();
            ViewBag.departmentList = new SelectList(items, "ID", "Name");
            var data = await employee.GetById(i => i.Id == id && i.IsDeleted == false && i.IsActive == true);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM EmployeeVM)
        {
            var items = await department.GetAll();
            ViewBag.departmentList = new SelectList(items, "ID", "Name");
            if (ModelState.IsValid)
            {
                await employee.Edit(EmployeeVM);
                return RedirectToAction("Index", "Employee");

            }

            return View(EmployeeVM);

        }

        #endregion


        #region Ajax Call
        //Get Data City Based Country Id
        [HttpPost]
        public async Task<IActionResult> GetCityByCountryId(int id)
        {
            var data = await ICity.GetAsync(i => i.CountryId == id);
            return Json(data);
        }
        //Get Data District Based City Id
        [HttpPost]
        public async Task<IActionResult> GetDistrictByCityId(int id)
        {
            var data = await IDistrict.GetAsync(i => i.CityId == id);
            return Json(data);
        }
        #endregion
    }
}
