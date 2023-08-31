using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.PL.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDepartment DepartmentRepo ;
        public DeptController(IDepartment _DepartmentRepo)
        {
            this.DepartmentRepo = _DepartmentRepo ;
        }
        public async Task<IActionResult> Tables()
        {
            var data = await DepartmentRepo.GetAll();
            return View(data);
        }
        public async Task<IActionResult> Forms()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Forms(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                await DepartmentRepo.Create(departmentVM);
                return RedirectToAction("Tables", "Dept");
            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            await DepartmentRepo.Delete(id);
            return RedirectToAction("Tables" , "Dept");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await DepartmentRepo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                await DepartmentRepo.Edit(departmentVM);
            }
            return RedirectToAction("Tables" , "Dept");

        }
    }
}
