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
    /// Interaction logic for EditRouteWindow.xaml
    /// </summary>
    public partial class EditRouteWindow : Window
    {
        private Route route;
        private string routeId;
        public EditRouteWindow(Route _route)
        {
            InitializeComponent();
            route = new Route();
            routeId = routeIdTextBox.Text = _route.RouteId;
            distanceTextBox.Text = _route.Distance.ToString();
            employeeIdTextBox.Text = _route.EmployeeId;
            lastNameTextBox.Text = _route.LastName;
            firstNameTextBox.Text = _route.FirstName;
            emailTextBox.Text = _route.Email;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to confirm editing this employee ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                route.RouteId = routeIdTextBox.Text;
                route.Distance = Int32.Parse(distanceTextBox.Text);
                route.EmployeeId = employeeIdTextBox.Text;
                route.LastName = lastNameTextBox.Text;
                route.FirstName = firstNameTextBox.Text;
                route.Email = emailTextBox.Text;
                this.Close();
                RouteDAO.Instance.EditRoute(route, routeId);
            }
        }
    }
}
