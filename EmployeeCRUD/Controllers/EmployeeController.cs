using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.Controllers
{
   
    
    public class EmployeeController : Controller
    {
        EmployeeDAL EmpDal = new EmployeeDAL();
        public IActionResult Index()
        {
            MultiModels MulMod = new MultiModels();
            Employee empt = new Employee();
            empt.EmployeeId = 0;
            MulMod.LstEmployee = EmpDal.GetAllEmployee().ToList();
            MulMod.Emp = empt;
            return View("Index", MulMod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrUpdate([Bind] Employee emp)
        {   if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (emp.EmployeeId == 0)
            {
                EmpDal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            EmpDal.UpdateEmployee(emp);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpDal.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    
        public IActionResult Update(int? id)
        {

            if (id == null)
            {
                return NotFound();
               
            }
            MultiModels MulMod = new MultiModels();

            MulMod.Emp = EmpDal.GetEmployeeById(id);
            
            if (MulMod.Emp == null)
            {
                return NotFound();
            }
            MulMod.LstEmployee = EmpDal.GetAllEmployee().ToList();
            return View("Index", MulMod);
        }
    }
}