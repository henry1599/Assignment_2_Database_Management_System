using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Demo_APP.Data_Transfer_Layer;

namespace Demo_APP.Data_Access_Layer
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set => instance = value;
        }
        private EmployeeDAO() { }

        public List<Employee> GetListAllEmployee()
        {
            List<Employee> listEmployee = new List<Employee>();
            string query = "SELECT * FROM EMPLOYEE";
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                listEmployee.Add(employee);
            }
            return listEmployee;
        }

        public List<Employee> FindEmployees(string _employeeID, string _firstName, string _lastName, int _age, int _currentSalary)
        {
            List<Employee> result = new List<Employee>();
            string query = "SELECT * FROM EMPLOYEE";
            if (!(_employeeID == null && _firstName == null && _lastName == null && _age == -1 && _currentSalary == -1))
            {
                query += " WHERE ";
                if (_employeeID != null)
                {
                    string additional_query = "employee_id = '" + _employeeID + "'";
                    query += additional_query;
                    query += " AND ";
                }
                if (_firstName != null)
                {
                    string additional_query = "first_name = '" + _firstName + "'";
                    query += additional_query;
                    query += " AND ";
                }
                if (_lastName != null)
                {
                    string additional_query = "last_name = '" + _lastName + "'";
                    query += additional_query;
                    query += " AND ";
                }
                if (_age != -1)
                {
                    string additional_query = "age = " + _age.ToString();
                    query += additional_query;
                    query += " AND ";
                }
                if (_currentSalary != -1)
                {
                    string additional_query = "current_salary = " + _currentSalary.ToString();
                    query += additional_query;
                    query += " AND ";
                }
                // Remove the final " AND "
                query = query.Remove(query.Length - 5);
            }

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                result.Add(employee);
            }

            return result;
        }

        public void DeleteListEmployee(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                string query = "DELETE FROM EMPLOYEE WHERE employee_id = '" + employee.EmployeeID + "'";
                DataProviderDAO.Instance.ExecuteQuery(query);
            }
        }

        public void AddListEmployee(Employee employee)
        {
            string query = "INSERT INTO EMPLOYEE VALUES('" + employee.EmployeeID + "','" + employee.FirstName + "','" + employee.LastName
            + "'," + employee.Age.ToString() + ",'" + employee.StartDate  + "'," + employee.BaseSalary.ToString() + "," + employee.CurrentSalary.ToString()
            + ",'" + employee.DayOfBirth + "','" + employee.Email + "','" + employee.Sex + "')";
            DataProviderDAO.Instance.ExecuteQuery(query);
        }

        public void EditEmployee(Employee employee, string _employeeID)
        {
            string query = "UPDATE EMPLOYEE SET employee_id = '" + employee.EmployeeID + "', first_name = '" + employee.FirstName
                + "', last_name = '" + employee.LastName + "', age = " + employee.Age + ", start_date = '" + employee.StartDate
                + "', base_salary = " + employee.BaseSalary.ToString() + ", current_salary = " + employee.CurrentSalary.ToString()
                + ", data_of_birth = '" + employee.DayOfBirth + "', email = '" + employee.Email + "', sex = '" + employee.Sex
                + "' WHERE employee_id = '" + _employeeID + "';";
            DataProviderDAO.Instance.ExecuteQuery(query);
        }
    }
}
