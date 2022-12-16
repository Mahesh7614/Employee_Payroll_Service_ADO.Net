using Employee_Payroll_Service_ADO.Net.Repository;
namespace Employee_PayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmployeeRepository employee = new EmployeeRepository();
            string actual = employee.UpdateSalary();

            Assert.AreEqual("Data Updated", actual);
        }
    }
}