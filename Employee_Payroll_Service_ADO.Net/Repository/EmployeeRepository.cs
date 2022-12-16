
using Employee_Payroll_Service_ADO.Net.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Employee_Payroll_Service_ADO.Net.Repository
{
    public class EmployeeRepository
    {
        public static string connectionString = "Server=localhost;Database=Employee_Payroll_Services;User ID=MAHESH/Mahesh;Password=;TrustServerCertificate=True;integrated security=SSPI;";

        public void GetAllEmployee()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel objEmployeeModel = new EmployeeModel();
                using (objConnection)
                {
                    string query = @"SELECT * FROM Employee_Payroll";

                    SqlCommand objCommand = new SqlCommand(query, objConnection);
                    objConnection.Open();
                    SqlDataReader objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        Console.WriteLine("******************************** Employee Data From Database ********************************\n");
                        while (objDataReader.Read())
                        {
                            objEmployeeModel.Id = objDataReader.IsDBNull("EmployeeID") ? 0 : objDataReader.GetInt32("EmployeeID");
                            objEmployeeModel.Name = objDataReader.IsDBNull("EmployeeName") ? string.Empty : objDataReader.GetString("EmployeeName");
                            objEmployeeModel.PhoneNumber = objDataReader.IsDBNull("PhoneNumber") ? 0 : objDataReader.GetInt32("PhoneNumber");
                            objEmployeeModel.Address = objDataReader.IsDBNull("Address") ? string.Empty : objDataReader.GetString("Address");
                            objEmployeeModel.Department = objDataReader.IsDBNull("Department") ? string.Empty : objDataReader.GetString("Department");
                            objEmployeeModel.Gender = Convert.ToChar(objDataReader.IsDBNull("Gender") ? string.Empty : objDataReader.GetString("Gender"));
                            objEmployeeModel.Basic_Pay = objDataReader.IsDBNull("Basic_Pay") ? 0.0 : (Double)(objDataReader.GetDecimal("Basic_Pay"));
                            objEmployeeModel.Deductions = objDataReader.IsDBNull("Deductions") ? 0.0 : (Double)objDataReader.GetDecimal("Deductions");
                            objEmployeeModel.Taxable_Pay = objDataReader.IsDBNull("Taxable_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Taxable_Pay");
                            objEmployeeModel.Tax = objDataReader.IsDBNull("Tax") ? 0.0 : (Double)objDataReader.GetDecimal("Tax");
                            objEmployeeModel.Net_Pay = objDataReader.IsDBNull("Net_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Net_Pay");
                            objEmployeeModel.StartDate = objDataReader.IsDBNull("StartDate") ? DateTime.MinValue : objDataReader.GetDateTime("StartDate");
                            objEmployeeModel.City = objDataReader.IsDBNull("City") ? string.Empty : objDataReader.GetString("City");
                            objEmployeeModel.Country = objDataReader.IsDBNull("Country") ? string.Empty : objDataReader.GetString("Country");

                            Console.WriteLine($"Employee ID   : {objEmployeeModel.Id},\n" +
                                              $"Employee Name : {objEmployeeModel.Name},\n" +
                                              $"PhoneNumber   : {objEmployeeModel.PhoneNumber},\n" +
                                              $"Address       : {objEmployeeModel.Address},\n" +
                                              $"Department    : {objEmployeeModel.Department},\n" +
                                              $"Gender        : {objEmployeeModel.Gender},\n" +
                                              $"Basic_Pay     : {objEmployeeModel.Basic_Pay},\n" +
                                              $"Deductions    : {objEmployeeModel.Deductions},\n" +
                                              $"Taxable_Pay   : {objEmployeeModel.Taxable_Pay},\n" +
                                              $"Tax           : {objEmployeeModel.Tax},\n" +
                                              $"Net_Pay       : {objEmployeeModel.Net_Pay},\n" +
                                              $"StartDate     : {objEmployeeModel.StartDate},\n" +
                                              $"City          : {objEmployeeModel.City},\n" +
                                              $"Country       : {objEmployeeModel.Country}\n");
                            Console.WriteLine("----------------------------------------------------\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found in the table");
                    }
                    objDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (objConnection.State == ConnectionState.Open)
                {
                    objConnection.Close();
                }
            }
        }
        public string UpdateSalary()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            using (objConnection)
            {
                string query = @"Update Employee_Payroll Set Basic_Pay = 3000000 Where EmployeeName = 'Shubhanjli' and EmployeeID = 4";

                SqlCommand objCommand = new SqlCommand(query, objConnection);
                objConnection.Open();
                try
                {
                    var objDataReader = objCommand.ExecuteNonQuery();
                    if (objDataReader >= 1)
                    {
                        return "Data Updated";
                    }
                    else
                    {
                        return "Data  Not Updated";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (objConnection.State == ConnectionState.Open)
                    {
                        objConnection.Close();
                    }
                }
            }
        }
        public string UpdateSaralyUsingStoredProcedure(EmployeeModel employee)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            using (objConnection)
            {
                SqlCommand objCommand = new SqlCommand("UpdateSalary", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ID", employee.Id);
                objCommand.Parameters.AddWithValue("@Name", employee.Name);
                objCommand.Parameters.AddWithValue("@Salary", employee.Basic_Pay);
                objConnection.Open();
                try
                {
                    var objDataReader = objCommand.ExecuteNonQuery();
                    if (objDataReader >= 1)
                    {
                        return "Data Updated";
                    }
                    else
                    {
                        return "Data  Not Updated";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (objConnection.State == ConnectionState.Open)
                    {
                        objConnection.Close();
                    }
                }
            }
        }
        public string GetDataByName(EmployeeModel model)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            EmployeeModel objEmployeeModel = new EmployeeModel();
            try
            {
                using (objConnection)
                {
                    SqlCommand objCommand = new SqlCommand("GetByName", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Name", model.Name);
                    objConnection.Open();
                    SqlDataReader objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        Console.WriteLine("******************************** Employee Data BY Name ********************************\n");
                        while (objDataReader.Read())
                        {
                            objEmployeeModel.Id = objDataReader.IsDBNull("EmployeeID") ? 0 : objDataReader.GetInt32("EmployeeID");
                            objEmployeeModel.Name = objDataReader.IsDBNull("EmployeeName") ? string.Empty : objDataReader.GetString("EmployeeName");
                            objEmployeeModel.PhoneNumber = objDataReader.IsDBNull("PhoneNumber") ? 0 : objDataReader.GetInt32("PhoneNumber");
                            objEmployeeModel.Address = objDataReader.IsDBNull("Address") ? string.Empty : objDataReader.GetString("Address");
                            objEmployeeModel.Department = objDataReader.IsDBNull("Department") ? string.Empty : objDataReader.GetString("Department");
                            objEmployeeModel.Gender = Convert.ToChar(objDataReader.IsDBNull("Gender") ? string.Empty : objDataReader.GetString("Gender"));
                            objEmployeeModel.Basic_Pay = objDataReader.IsDBNull("Basic_Pay") ? 0.0 : (Double)(objDataReader.GetDecimal("Basic_Pay"));
                            objEmployeeModel.Deductions = objDataReader.IsDBNull("Deductions") ? 0.0 : (Double)objDataReader.GetDecimal("Deductions");
                            objEmployeeModel.Taxable_Pay = objDataReader.IsDBNull("Taxable_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Taxable_Pay");
                            objEmployeeModel.Tax = objDataReader.IsDBNull("Tax") ? 0.0 : (Double)objDataReader.GetDecimal("Tax");
                            objEmployeeModel.Net_Pay = objDataReader.IsDBNull("Net_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Net_Pay");
                            objEmployeeModel.StartDate = objDataReader.IsDBNull("StartDate") ? DateTime.MinValue : objDataReader.GetDateTime("StartDate");
                            objEmployeeModel.City = objDataReader.IsDBNull("City") ? string.Empty : objDataReader.GetString("City");
                            objEmployeeModel.Country = objDataReader.IsDBNull("Country") ? string.Empty : objDataReader.GetString("Country");

                            Console.WriteLine($"Employee ID   : {objEmployeeModel.Id},\n" +
                                              $"Employee Name : {objEmployeeModel.Name},\n" +
                                              $"PhoneNumber   : {objEmployeeModel.PhoneNumber},\n" +
                                              $"Address       : {objEmployeeModel.Address},\n" +
                                              $"Department    : {objEmployeeModel.Department},\n" +
                                              $"Gender        : {objEmployeeModel.Gender},\n" +
                                              $"Basic_Pay     : {objEmployeeModel.Basic_Pay},\n" +
                                              $"Deductions    : {objEmployeeModel.Deductions},\n" +
                                              $"Taxable_Pay   : {objEmployeeModel.Taxable_Pay},\n" +
                                              $"Tax           : {objEmployeeModel.Tax},\n" +
                                              $"Net_Pay       : {objEmployeeModel.Net_Pay},\n" +
                                              $"StartDate     : {objEmployeeModel.StartDate},\n" +
                                              $"City          : {objEmployeeModel.City},\n" +
                                              $"Country       : {objEmployeeModel.Country}\n");
                            Console.WriteLine("----------------------------------------------------\n");
                        }
                        objDataReader.Close();
                        return "Data Found";
                    }
                    else
                    {
                        Console.WriteLine("No Records Found in the table");
                        objDataReader.Close();
                        return "Data Not Found";
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (objConnection.State == ConnectionState.Open)
                {
                    objConnection.Close();
                }
            }
        }
        public string GetDataWithinDateRange(DateTime start, DateTime end)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            EmployeeModel objEmployeeModel = new EmployeeModel();
            try
            {
                using (objConnection)
                {
                    SqlCommand objCommand = new SqlCommand("GetByDateWithinRange", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Start", start);
                    objCommand.Parameters.AddWithValue("@End", end);
                    objConnection.Open();
                    SqlDataReader objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        Console.WriteLine("******************************** Employee Data BY Name ********************************\n");
                        while (objDataReader.Read())
                        {
                            objEmployeeModel.Id = objDataReader.IsDBNull("EmployeeID") ? 0 : objDataReader.GetInt32("EmployeeID");
                            objEmployeeModel.Name = objDataReader.IsDBNull("EmployeeName") ? string.Empty : objDataReader.GetString("EmployeeName");
                            objEmployeeModel.PhoneNumber = objDataReader.IsDBNull("PhoneNumber") ? 0 : objDataReader.GetInt32("PhoneNumber");
                            objEmployeeModel.Address = objDataReader.IsDBNull("Address") ? string.Empty : objDataReader.GetString("Address");
                            objEmployeeModel.Department = objDataReader.IsDBNull("Department") ? string.Empty : objDataReader.GetString("Department");
                            objEmployeeModel.Gender = Convert.ToChar(objDataReader.IsDBNull("Gender") ? string.Empty : objDataReader.GetString("Gender"));
                            objEmployeeModel.Basic_Pay = objDataReader.IsDBNull("Basic_Pay") ? 0.0 : (Double)(objDataReader.GetDecimal("Basic_Pay"));
                            objEmployeeModel.Deductions = objDataReader.IsDBNull("Deductions") ? 0.0 : (Double)objDataReader.GetDecimal("Deductions");
                            objEmployeeModel.Taxable_Pay = objDataReader.IsDBNull("Taxable_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Taxable_Pay");
                            objEmployeeModel.Tax = objDataReader.IsDBNull("Tax") ? 0.0 : (Double)objDataReader.GetDecimal("Tax");
                            objEmployeeModel.Net_Pay = objDataReader.IsDBNull("Net_Pay") ? 0.0 : (Double)objDataReader.GetDecimal("Net_Pay");
                            objEmployeeModel.StartDate = objDataReader.IsDBNull("StartDate") ? DateTime.MinValue : objDataReader.GetDateTime("StartDate");
                            objEmployeeModel.City = objDataReader.IsDBNull("City") ? string.Empty : objDataReader.GetString("City");
                            objEmployeeModel.Country = objDataReader.IsDBNull("Country") ? string.Empty : objDataReader.GetString("Country");

                            Console.WriteLine($"Employee ID   : {objEmployeeModel.Id},\n" +
                                              $"Employee Name : {objEmployeeModel.Name},\n" +
                                              $"PhoneNumber   : {objEmployeeModel.PhoneNumber},\n" +
                                              $"Address       : {objEmployeeModel.Address},\n" +
                                              $"Department    : {objEmployeeModel.Department},\n" +
                                              $"Gender        : {objEmployeeModel.Gender},\n" +
                                              $"Basic_Pay     : {objEmployeeModel.Basic_Pay},\n" +
                                              $"Deductions    : {objEmployeeModel.Deductions},\n" +
                                              $"Taxable_Pay   : {objEmployeeModel.Taxable_Pay},\n" +
                                              $"Tax           : {objEmployeeModel.Tax},\n" +
                                              $"Net_Pay       : {objEmployeeModel.Net_Pay},\n" +
                                              $"StartDate     : {objEmployeeModel.StartDate},\n" +
                                              $"City          : {objEmployeeModel.City},\n" +
                                              $"Country       : {objEmployeeModel.Country}\n");
                            Console.WriteLine("----------------------------------------------------\n");
                        }
                        objDataReader.Close();
                        return "Data Found";
                    }
                    else
                    {
                        Console.WriteLine("No Records Found in the table");
                        objDataReader.Close();
                        return "Data Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (objConnection.State == ConnectionState.Open)
                {
                    objConnection.Close();
                }
            }
        }
        public void AggregateFunction(char gender)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            try
            {
                using (objConnection)
                {
                    string query = @$"SELECT SUM(Basic_Pay),MAX(Basic_Pay),MIN(Basic_Pay),AVG(Basic_Pay),Gender,COUNT(*) FROM Employee_Payroll WHERE Gender = '{gender}'  GROUP BY Gender";
                    SqlCommand command = new SqlCommand(query, objConnection);

                    objConnection.Open();
                    SqlDataReader result = command.ExecuteReader();

                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Console.WriteLine($"Total Salary = {result[0]}\n Max Salary = {result[1]}\n Min Salary = {result[2]}\n Avg Salary = {result[3]}\n Gender = {result[4]} \n Count = {result[5]}\n");
                        }
                        result.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
        }
    }
}

