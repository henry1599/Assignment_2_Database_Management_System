using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Demo_APP.Data_Access_Layer;
using Demo_APP.Data_Transfer_Layer;

namespace Demo_APP
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private Employee employee;
        public AddWindow()
        {
            InitializeComponent();
            employee = new Employee();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to confirm adding this employee ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                employee.EmployeeID = idTextBox.Text;
                employee.FirstName = firstNameTextBox.Text;
                employee.LastName = lastNameTextBox.Text;
                if (int.TryParse(ageTextBox.Text, out int a)) employee.Age = Int32.Parse(ageTextBox.Text);
                employee.StartDate = startDateTextBox.Text;
                if (int.TryParse(baseSalaryTextBox.Text, out int b)) employee.BaseSalary = Int32.Parse(baseSalaryTextBox.Text);
                if (int.TryParse(currentSalaryTextBox.Text, out int c)) employee.CurrentSalary = Int32.Parse(currentSalaryTextBox.Text);
                employee.DayOfBirth = dateOfBirthTextBox.Text;
                employee.Email = emailTextBox.Text;
                employee.Sex = sexTextBox.Text;
                this.Close();
                EmployeeDAO.Instance.AddListEmployee(employee);
            }
        }
    }
}
