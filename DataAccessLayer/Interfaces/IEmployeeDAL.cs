using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeDAL
    {
        Task<Employee> GetEmployees();
        Task<Employee> CreateEmployee(Employee employee);
    }
    
}
