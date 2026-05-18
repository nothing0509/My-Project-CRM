using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
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
            await _context.employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
