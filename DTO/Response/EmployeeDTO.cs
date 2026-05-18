using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{

    public class EmployeeDTO : Employee
    {
        public string FullName { get; set; }
    }
}
