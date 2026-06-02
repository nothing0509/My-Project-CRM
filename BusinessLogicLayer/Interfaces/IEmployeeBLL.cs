

using DTO.Param;
using Model;

/// <summary>
/// Business logic layer
/// </summary>
public interface IEmployeeBLL
{
    //Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeQuery query);
    Task<Employee> GetEmployees();
    Task<Employee> CreateEmployee(Employee employee);
    Task<bool> DeleteEmployee(int employee_id);
    Task<bool> UpdateEmployee(int employee_id, EmployeeUpdateDTO model);
    Task<PagedResult<Employee>> PaginationEmployee(EmployeeQuery query);
}


