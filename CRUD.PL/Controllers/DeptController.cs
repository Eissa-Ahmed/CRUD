using AutoMapper;
using CRUD.BL.Interfaces;
using CRUD.BL.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.PL.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDepartment DepartmentRepo ;
        private readonly IMapper IMapper;
        public DeptController(IDepartment _DepartmentRepo , IMapper _IMapper)
        {
            this.DepartmentRepo = _DepartmentRepo ;
            this.IMapper = _IMapper;
        }
        
        public async Task<IActionResult> Tables()
        {
            HttpContext.Session.SetString("name" , "Leel Ahmed");
            TempData["Name"] = "Essa Ahmed";
            TempData.Keep("Name");
            var data = await DepartmentRepo.GetAll();
            return View(data);
        }
        public async Task<IActionResult> Forms()
        {
            var name = "";
            if (TempData.ContainsKey("Name"))
            {
                name = (string)TempData["Name"];
                //TempData.Keep("Name");
            }
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
