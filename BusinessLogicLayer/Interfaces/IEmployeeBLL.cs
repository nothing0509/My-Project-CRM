

using Model;

/// <summary>
/// Business logic layer
/// </summary>
public interface IEmployeeBLL
{
    //Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeQuery query);
    Task<Employee> GetEmployees();
    Task<Employee> CreateEmployee(Employee employee);
}

