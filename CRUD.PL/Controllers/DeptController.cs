using CRUD.BL.Model;
using CRUD.BL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.PL.Controllers
{
    public class DeptController : Controller
    {
        DepartmentRepo DepartmentRepo = new DepartmentRepo();
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
