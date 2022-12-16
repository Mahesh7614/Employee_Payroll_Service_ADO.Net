using Employee_Payroll_Service_ADO.Net.Model;
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
            EmployeeModel model = new EmployeeModel();
            model.Id = 4;
            model.Name = "Shubhanjli";
            model.Basic_Pay = 4000000;
            obj.UpdateSaralyUsingStoredProcedure(model);
            obj.GetAllEmployee();
        }
    }
}