using Information_system_i_ASP.Net.Data;
using Information_system_i_ASP.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Information_system_i_ASP.Net.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;

        public EmployeeController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        // Visa alla anställda (Index)
        public IActionResult Index()
        {
            var employees = _userManager.Users;
            return View(employees); // Returnerar en lista av Employee
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new Employee
                {
                    UserName = employee.Email,
                    Email = employee.Email,
                    Name = employee.Name,
                    EmailConfirmed = true,
                };

                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("Password", "Password is required");
                    return View(employee);
                }

                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
           
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string name)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Email = email;
            employee.Name = name;

            var result = await _userManager.UpdateAsync(employee);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee != null)
            {
                var result = await _userManager.DeleteAsync(employee);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(employee);
        }
    }
}

