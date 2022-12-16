using Employee_Payroll_Service_ADO.Net.Model;
using Employee_Payroll_Service_ADO.Net.Repository;
namespace Employee_PayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDataUpdatedOrNot()
        {
            EmployeeRepository employee = new EmployeeRepository();
            string actual = employee.UpdateSalary();

            Assert.AreEqual("Data Updated", actual);
        }
        [TestMethod]
        public void CheckDataUpdatedOrNotUsingStoredProcedure()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Id = 4;
            model.Name = "Shubhanjli";
            model.Basic_Pay = 4000000;
            string actual = employee.UpdateSaralyUsingStoredProcedure(model);

            Assert.AreEqual("Data Updated", actual);
        }
        [TestMethod]
        public void GetDataByName()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Name = "Shubhanjli";
            string actual = employee.GetDataByName(model);

            Assert.AreEqual("Data Found", actual);
        }
        [TestMethod]
        public void RetriveDataWithinDateRange()
        {
            EmployeeRepository employee = new EmployeeRepository();
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2022, 12, 25);
            string actual = employee.GetDataWithinDateRange(start, end);

            Assert.AreEqual("Data Found", actual);
        }
    }
}