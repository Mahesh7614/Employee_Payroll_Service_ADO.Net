
namespace Employee_Payroll_Service_ADO.Net.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public double Basic_Pay { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Tax { get; set; }
        public double Net_Pay { get; set; }
        public DateTime StartDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
