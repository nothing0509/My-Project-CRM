using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Model;
using DTO.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Class
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly AppDbContext _context;
        public EmployeeDAL(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Employee> GetEmployees()
        {
            var employee = await _context.employees
                .Where(e => e.IsDelete == false).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.employees.Add(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteEmployee(int employee_id)
        {


            /*
             _context.employees.FindAsysnc(id) => tìm id có trong DB hay không, trả về employee tương ứng -> trả về 1 employee, nếu không trả về null
            Tương tự: 
            + find(id) -> tìm bằng id, dùng cho primary key -> trả về 1 employee nếu không trả về null
            Tương tự: 
             */

            var employee = await _context.employees.FindAsync(employee_id);
            if (employee == null)
            {
                return false;
            }
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateEmployee(int employee_id,EmployeeUpdateDTO model)
        {
            var employee = await _context.employees.FindAsync(employee_id);
            if (employee == null)
            {
                return false;
            }
            employee.FirstName = model.first_name;
            employee.LastName = model.last_name;
            employee.Phone = model.phone;
            employee.Salary = model.salary;

            await _context.SaveChangesAsync();
            _context.employees.Update(employee);
            return true;
        }
    }
}
