using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperStoredProc.Data;
using DapperStoredProc.Models;
using DapperStoredProc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperStoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _services;
       
     

        public EmployeeController(IEmployeeServices services )
        {
            _services = services;
            
            
        }
        public IActionResult Index()
        {
            return View(_services.GetAllEmployees());
        }
      public IActionResult GetEmpByID(int id)
        {
         
            return View(_services.GetEmpByID(id));
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind]Employee employee)
        {
          if(ModelState.IsValid)
            {
                if(_services.AddEmployee(employee)>0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);

        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Employee emp = _services.GetEmpByID(id);
            if (emp == null)
        
                return NotFound();
            
            return View(emp);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] Employee employee)
        {
            if (id != employee.EmpId)
                return NotFound();
            if(ModelState.IsValid)
            {
                _services.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            Employee emp = _services.GetEmpByID(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id, Employee employee)
        {
            if (_services.DeleteEmployee(id)>0)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
