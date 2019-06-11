using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC1.Models;
using WebMVC1.Repository;

namespace WebMVC1.Controllers
{
    public class EmpController : Controller
    {
        //hello test
        private readonly IManagerEmployee EmpManager;

        public EmpController(IManagerEmployee context)
        {
            EmpManager = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel empView)
        {
            if (ModelState.IsValid)
            {
                EmpManager.SaveEmployee(empView);
                return RedirectToAction(nameof(Index));
            }
            return View(empView);
        }
        public IActionResult EmpList()
        {

            return View(EmpManager.GetEmployeeList());
        }
        [HttpGet("getEmployeeList")]
        public IActionResult GetEmployeeList()
        {

            return new JsonResult(EmpManager.GetEmployeeList());
        }
    }
}