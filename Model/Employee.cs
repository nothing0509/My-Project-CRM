using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("employee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}