using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Model;

public class EmployeeBLL : IEmployeeBLL
{
    protected readonly IEmployeeDAL _employeeDAL;

    public EmployeeBLL(IEmployeeDAL employeeDAL)
    {
        _employeeDAL = employeeDAL;
    }
    public async Task<Employee> GetEmployees()
    {
        var result = await _employeeDAL.GetEmployees();
        return result;
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {

        return await _employeeDAL.CreateEmployee(employee);

    }



}