using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Param
{
    public class EmployeeUpdateDTO
    {
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string phone { get; set; }

        public decimal salary { get; set; }
    }
}
