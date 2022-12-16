using Employee_Payroll_Service_ADO.Net.Repository;

namespace Employee_Payroll_Service_ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository obj = new EmployeeRepository();
            obj.UpdateSalary();
            obj.GetAllEmployee();
        }
    }
}