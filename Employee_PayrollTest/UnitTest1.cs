using Employee_Payroll_Service_ADO.Net.Model;
using Employee_Payroll_Service_ADO.Net.Repository;
namespace Employee_PayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Checks the data updated or not.
        /// </summary>
        [TestMethod]
        public void CheckDataUpdatedOrNot()
        {
            EmployeeRepository employee = new EmployeeRepository();
            string actual = employee.UpdateSalary();

            Assert.AreEqual("Data Updated", actual);
        }
        /// <summary>
        /// Checks the data updated or not using stored procedure.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Gets the name of the data by.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void GetDataByName()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Name = "Shubhanjli";
            string actual = employee.GetDataByName(model);

            Assert.AreEqual("Data Found", actual);
        }
        /// <summary>
        /// Retrives the data within date range.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void RetriveDataWithinDateRange()
        {
            EmployeeRepository employee = new EmployeeRepository();
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2022, 12, 25);
            string actual = employee.GetDataWithinDateRange(start, end);

            Assert.AreEqual("Data Found", actual);
        }
        /// <summary>
        /// Inserts the data to database.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void InsertDataToDatabase()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Name = "Tushar";
            model.PhoneNumber = 8999;
            model.Address = "Patherdi";
            model.Department = "Chemical";
            model.Gender = 'M';
            model.Basic_Pay = 3500000;
            model.Deductions = 15000;
            model.Taxable_Pay = 25000;
            model.Tax = 50000;
            model.Net_Pay = 2500000;
            DateTime start = new DateTime(2022, 01, 02);
            model.StartDate = start;
            model.City = "Ahmednagar";
            model.Country = "INDIA";

            string actual = employee.InsertEmployee(model);

            Assert.AreEqual("Data Inserted Successfully", actual);
        }
        [TestMethod]
        public void InsertDataInEmployeePayrollAsWellAsPayrollDetail()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Name = "Piyush";
            model.PhoneNumber = 84232;
            model.Address = "Nagpur";
            model.Department = "Production";
            model.Gender = 'M';
            model.Basic_Pay = 4500000;
            model.Deductions = 15000;
            model.Taxable_Pay = 25000;
            model.Tax = 50000;
            model.Net_Pay = 2500000;
            DateTime start = new DateTime(2022, 01, 02);
            model.StartDate = start;
            model.City = "Nagpur";
            model.Country = "INDIA";

            string actual = employee.InsertEmployee_EmployeePayroll_AsWellAs_PayrollDetail(model);

            Assert.AreEqual("Data Inserted Successfully in Both Tables", actual);
        }
    }
}