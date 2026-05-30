using DataAccessLayer;
using DTO.Param;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace My_Project_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBLL _employeeBll;
        public EmployeeController(IEmployeeBLL employeeBll)
        {
            _employeeBll = employeeBll;
        }


        // ===============================
        // GET ALL EMPLOYEES
        // ===============================

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {

            var result = await _employeeBll.GetEmployees();

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var  result = await _employeeBll.CreateEmployee(employee);

            return Ok(result);
            
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteEmployee(int employee_id)
        {
            var result = await _employeeBll.DeleteEmployee(employee_id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmloyee(int employee_id,[FromBody] EmployeeUpdateDTO model)
        {
            var result= await _employeeBll.UpdateEmployee(employee_id, model);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //// ===============================
        //// GET EMPLOYEE BY ID
        //// ===============================
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetEmployee(int id)
        //{
        //    var employee = await _context.Employees
        //        .FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsDelete == false);

        //    if (employee == null)
        //        return NotFound();

        //    return Ok(employee);
        //}

        //// ===============================
        //// CREATE EMPLOYEE
        //// ===============================
        //[HttpPost]
        //public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        //{
        //    employee.IsDelete = false;
        //    employee.IsActive = true;

        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return Ok(employee);
        //}

        //// ===============================
        //// DELETE EMPLOYEE (SOFT DELETE)
        //// ===============================
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);

        //    if (employee == null)
        //        return NotFound();

        //    employee.IsDelete = true;

        //    await _context.SaveChangesAsync();

        //    return Ok("Employee deleted");
        //}

        //Viết 1 api có thể phân trang, tìm kiếm, xắp xếp
        //Học interface
        //=> Tối chủ nhật kiểm tra + dạy bài tiếp theo
        /*
        [HttpGet]
        public async Task<IActionResult> GetEmployeesAllFunction(
        int page = 1,
        int pageSize = 10,
        string search = "",
        string sortBy = "employeeid",
        string sortOrder = "asc"
    )
        {
            var query = _context.Employees.AsQueryable();

            // ❌ bỏ record đã delete
            query = query.Where(e => !e.IsDelete);

            // 🔍 SEARCH (FirstName, LastName, Email, Phone)
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();

                query = query.Where(e =>
                    e.FirstName.ToLower().Contains(search) ||
                    e.LastName.ToLower().Contains(search) ||
                    e.Email.ToLower().Contains(search) ||
                    e.Phone.Contains(search)
                );
            }

            // 🔃 SORT
            query = sortBy.ToLower() switch
            {
                "firstname" => sortOrder == "asc"
                    ? query.OrderBy(e => e.FirstName)
                    : query.OrderByDescending(e => e.FirstName),

                "lastname" => sortOrder == "asc"
                    ? query.OrderBy(e => e.LastName)
                    : query.OrderByDescending(e => e.LastName),

                "email" => sortOrder == "asc"
                    ? query.OrderBy(e => e.Email)
                    : query.OrderByDescending(e => e.Email),

                "salary" => sortOrder == "asc"
                    ? query.OrderBy(e => e.Salary)
                    : query.OrderByDescending(e => e.Salary),

                "hiredate" => sortOrder == "asc"
                    ? query.OrderBy(e => e.HireDate)
                    : query.OrderByDescending(e => e.HireDate),

                _ => query.OrderBy(e => e.EmployeeId)
            };

            // 📊 tổng record
            var totalRecords = await query.CountAsync();

            // 📄 pagination
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // 📦 response
            return Ok(new
            {
                totalRecords,
                page,
                pageSize,
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                data
            });
        }

        */
        //private readonly IEmployeeBLL _employeeService;

        //public EmployeeController(IEmployeeBLL employeeService)
        //{
        //    _employeeService = employeeService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetEmployees([FromQuery] EmployeeQuery query)
        //{
        //    var result = await _employeeService.GetEmployeesAsync(query);
        //    return Ok(result);
        //}
    }
}