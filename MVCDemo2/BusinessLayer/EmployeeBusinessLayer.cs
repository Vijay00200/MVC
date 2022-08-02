using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Employee> employees = new List<Employee>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee()
                        {
                            ID = Convert.ToInt32(rdr["ID"]),
                            Name = Convert.ToString(rdr["Name"]),
                            City = Convert.ToString(rdr["City"]),
                            Gender = Convert.ToString(rdr["Gender"]),
                            DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])
                        };
                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployees",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(paramName);


                SqlParameter paramGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter()
                {
                    ParameterName = "@City",
                    Value = employee.City
                };
                cmd.Parameters.Add(paramCity);


                SqlParameter paramDateOfBirth = new SqlParameter()
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(paramDateOfBirth);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void SaveEmployee(Employee employee) 
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = employee.ID
                };
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(paramName);


                SqlParameter paramGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter()
                {
                    ParameterName = "@City",
                    Value = employee.City
                };
                cmd.Parameters.Add(paramCity);


                SqlParameter paramDateOfBirth = new SqlParameter()
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(paramDateOfBirth);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(paramId);

                conn.Open();
                cmd.ExecuteNonQuery();

            }

        }
    }
}
