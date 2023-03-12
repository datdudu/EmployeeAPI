using System.Data;
using System.Data.SqlClient;

namespace EmployeeAPI.Models
{
    public class DAL
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Employee", connection);
            DataTable dataTable = new DataTable();
            List<Employee> listEmployees = new List<Employee>();

            dataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count > 0 )
            {
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dataTable.Rows[row]["ID"]);
                    employee.Name = Convert.ToString(dataTable.Rows[row]["Name"]);
                    employee.Email = Convert.ToString(dataTable.Rows[row]["Email"]);
                    employee.IsActive = Convert.ToInt32(dataTable.Rows[row]["IsActive"]);

                    listEmployees.Add(employee);
                }
            }

            if (listEmployees.Count > 0)
            {
                response.StatusCode = 100;
                response.StatusMessage = "Data found";
                response.ListEmployee = listEmployees;
            }
            else
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Data found";
                response.ListEmployee = null;
            }

            return response;
        }

        public Response GetEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Employee WHERE ID = '"+id+"' AND IsActive = 1", connection);
            DataTable dataTable = new DataTable();
            Employee employee = new Employee();

            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                employee.Id = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                employee.Name = Convert.ToString(dataTable.Rows[0]["Name"]);
                employee.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                employee.IsActive = Convert.ToInt32(dataTable.Rows[0]["IsActive"]);

                response.StatusCode = 100;
                response.StatusMessage = "Data found";
                response.Employee = employee;
            }
            else
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Data found";
                response.Employee = null;
            }

            return response;
        }

        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand command = new SqlCommand("INSERT INTO Employee(Name,Email,IsActive,CreationDate) VALUES ('"+ employee .Name +"','" + employee.Email + "','" + employee.IsActive + "',GETDATE())", connection);
            
            connection.Open();
            int isExecuted = command.ExecuteNonQuery();
            connection.Close();

            if (isExecuted > 0)
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Added";
            }
            else
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Data Inserted";
            }


            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand command = new SqlCommand("UPDATE Employee SET Name ='" + employee.Name + "', Email = '" + employee.Email + "' WHERE ID = '"+ employee.Id +"' ", connection);

            connection.Open();
            int isExecuted = command.ExecuteNonQuery();
            connection.Close();

            if (isExecuted > 0)
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Updated";
            }
            else
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Data Updated";
            }


            return response;
        }

        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand command = new SqlCommand("Delete from Employee WHERE ID = '"+id+"' ", connection);

            connection.Open();
            int IsExecuted = command.ExecuteNonQuery();
            connection.Close();

            if (IsExecuted > 0) 
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No employee deleted";
            }

            return response;
        }
    }
}

