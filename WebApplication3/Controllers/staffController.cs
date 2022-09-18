using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.database;
using WebApplication3.Migrations;
using WebApplication3.Models;
using staff = WebApplication3.Models.staff;

namespace WebApplication3.Controllers
{
    public class StaffController : Controller
    {
        private readonly hpkm pump;
        private int id;

        public StaffController(hpkm pump)
        {
            this.pump = pump;
        }
        public IActionResult Index()
        {
            var result = pump.staffs;
            return View(result);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(staff data)
        {

            if (ModelState.IsValid)
            {
                var emp = new staff();
                emp.Name = data.Name;
                emp.role = data.role;
                emp.salary = data.salary;
                emp.DOJ = data.DOJ;

                pump.staffs.Add(emp);
                pump.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "emoty field can not sumbit";
                return View("model");
            }
        }

        public IActionResult Delete(int id)
        {
            var emp = pump.staffs.SingleOrDefault(e => e.Id == id);
            pump.staffs.Remove(emp);
            pump.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = pump.staffs.SingleOrDefault(e => e.Id == id);
            var result = new staff()
            {
                Name = emp.Name,
                role = emp.role,
                salary = emp.salary,
                DOJ = emp.DOJ
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult edit(staff data)
        {
            var emp = new staff()
            {
                Id = data.Id,
                Name = data.Name,
                role = data.role,
                salary=data.salary,
                DOJ = data.DOJ
            };
            pump.staffs.Update(emp);
            pump.SaveChanges();
            return RedirectToAction("index");
        }


    }
}
