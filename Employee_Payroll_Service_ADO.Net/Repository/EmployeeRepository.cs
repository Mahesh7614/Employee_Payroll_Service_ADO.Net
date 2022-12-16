
using Employee_Payroll_Service_ADO.Net.Model;
using System.Data;
using System.Data.SqlClient;

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
                        Console.WriteLine("Connection Established with Database");
                    }
                    else
                    {
                        Console.WriteLine("Connection not Established with Database");
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
    }
}
