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
    /// Interaction logic for AddRouteWindow.xaml
    /// </summary>
    public partial class AddRouteWindow : Window
    {
        private Route route;
        public AddRouteWindow()
        {
            InitializeComponent();
            route = new Route();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to confirm adding this route ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                route.RouteId = routeIdTextBox.Text;
                route.Distance = Int32.Parse(distanceTextBox.Text);
                route.EmployeeId = employeeIdTextBox.Text;
                route.LastName = lastNameTextBox.Text;
                route.FirstName = firstNameTextBox.Text;
                route.Email = emailTextBox.Text;
                this.Close();
                RouteDAO.Instance.AddListRoute(route);
            }
        }
    }
}
