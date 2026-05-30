using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DTO.Param;
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
    public async Task<bool> DeleteEmployee(int employee_id)
    {
        return await _employeeDAL.DeleteEmployee(employee_id);
    }

    public async Task<bool> UpdateEmployee(int employee_id, EmployeeUpdateDTO model)
    {
        return await _employeeDAL.UpdateEmployee(employee_id, model);
    }



}