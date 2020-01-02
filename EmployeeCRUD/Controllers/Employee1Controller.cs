using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class Employee1Controller : Controller
    {
        private readonly MvcEmployeeContext Empcontext;
        public Employee1Controller (MvcEmployeeContext context)
        {
            Empcontext = context;
        }
        public IActionResult Index()
        {
            MultiModels Mulmodel = new MultiModels();
            Mulmodel.LstEmployee = Empcontext.Employees.ToList();
            Mulmodel.Emp = new Employee();

            return View("Index2", Mulmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind] Employee emp)
        {   if (ModelState.IsValid)
            {
                if (emp.EmployeeId == 0)
                    Empcontext.Add(emp);
                else
                    Empcontext.Update(emp);
                await Empcontext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id !=null)
            {
                Employee emp = await Empcontext.Employees.FindAsync(id);
                Empcontext.Remove(emp);
                await Empcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Employee emp = await Empcontext.Employees.FindAsync(id);
                MultiModels Mulmodel = new MultiModels();
                Mulmodel.LstEmployee = Empcontext.Employees.ToList();
                Mulmodel.Emp = emp;
                return View("Index2", Mulmodel);
            }
            return RedirectToAction("Index");
        }
    }
}