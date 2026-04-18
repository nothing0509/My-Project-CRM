using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // ===============================
        // GET ALL EMPLOYEES
        // ===============================
      
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees
                .Where(e => e.IsDelete == false)
                .ToListAsync();

            return Ok(employees);
        }
        // ===============================
        // GET EMPLOYEE BY ID
        // ===============================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsDelete == false);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // ===============================
        // CREATE EMPLOYEE
        // ===============================
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            employee.IsDelete = false;
            employee.IsActive = true;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // ===============================
        // DELETE EMPLOYEE (SOFT DELETE)
        // ===============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            employee.IsDelete = true;

            await _context.SaveChangesAsync();

            return Ok("Employee deleted");
        }
    }
}