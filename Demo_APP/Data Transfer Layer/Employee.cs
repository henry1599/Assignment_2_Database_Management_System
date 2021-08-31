using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_APP.Data_Transfer_Layer
{
    public class Employee
    {
        public Employee() { }
        public Employee(string _employeeID, string _firstName, string _lastName, int _age, DateTime _startDate, int _baseSalary, int _currentSalary, DateTime _dayOfBirth, string _email, string _sex)
        {
            this.employeeID = _employeeID;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.age = _age;
            this.startDate = _startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.baseSalary = _baseSalary;
            this.currentSalary = _currentSalary;
            this.dayOfBirth = _dayOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.email = _email;
            this.Sex = _sex;
        }

        public Employee(DataRow row)
        {
            this.employeeID = row["employee_id"].ToString();
            this.firstName = row["first_name"].ToString();
            this.lastName = row["last_name"].ToString();
            this.age = (int)row["age"];
            this.startDate = ((DateTime)row["start_date"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.baseSalary = (int)row["base_salary"];
            this.currentSalary = (int)row["current_salary"];
            this.dayOfBirth = ((DateTime)row["data_of_birth"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.email = row["email"].ToString();
            this.Sex = row["sex"].ToString();
        }

        private string employeeID;
        private string firstName;
        private string lastName;
        private int age;
        private string startDate;
        private int baseSalary;
        private int currentSalary;
        private string dayOfBirth;
        private string email;
        private string sex;

        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public int BaseSalary { get => baseSalary; set => baseSalary = value; }
        public int CurrentSalary { get => currentSalary; set => currentSalary = value; }
        public string DayOfBirth { get => dayOfBirth; set => dayOfBirth = value; }
        public string Email { get => email; set => email = value; }
        public string Sex { get => sex; set => sex = value; }
    }
}
