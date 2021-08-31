using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Demo_APP.Data_Access_Layer;
using Demo_APP.Data_Transfer_Layer;

namespace Demo_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddWindow addWindow;
        private EditEmployeeWindow editEmployeeWindow;
        private AddRouteWindow addRouteWindow;
        private EditRouteWindow editRouteWindow;
        private AddTicketWindow addTicketWindow;
        private EditTicketWindow editTicketWindow;
        private AddBusWindow addBusWindow;
        private EditBusWindow editBusWindow;

        public MainWindow()
        {
            InitializeComponent();
            DataEstablishment.Instance.Establish();
            Load();
        }

        public void Load()
        {
            DataContext = this;
            //Employee_List_View.DisplayMemberPath = "Name";
            List<Employee> employees = EmployeeDAO.Instance.GetListAllEmployee();
            Employee_List_View.ItemsSource = employees;
            List<Bus> buses = BusDAO.Instance.GetListAllBus();
            Bus_List_View.ItemsSource = buses;
            List<Route> routes = RouteDAO.Instance.GetListAllRoute();
            Route_List_View.ItemsSource = routes;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = (firstNameTextbox.Text == "" ? null : firstNameTextbox.Text);
            string lastName = (lastNameTextBox.Text == "" ? null : lastNameTextBox.Text);
            string employeeId = (codeTextBox.Text == "" ? null : codeTextBox.Text);
            int age;
            int salary;
            if (Int32.TryParse(ageTextBox.Text, out age))
            {
                ;
            }
            else
            {
                if (ageTextBox.Text != "")
                {
                    MessageBox.Show("Invalid age, must be an integer number");
                }
                age = -1;
            }
            if (Int32.TryParse(salaryTextBox.Text, out salary))
            {
                ;
            }
            else
            {
                if (salaryTextBox.Text != "")
                {
                    MessageBox.Show("Invalid salary, must be an integer number");
                }
                salary = -1;
            }
            List<Employee> employees = EmployeeDAO.Instance.FindEmployees(employeeId, firstName, lastName, age, salary);
            Employee_List_View.ItemsSource = employees;
        }

        private void Employee_List_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)    
        {
            if (MessageBox.Show("Do you want to delete the selection ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Employee> employees = new List<Employee>();
                for (int i = 0; i < Employee_List_View.SelectedItems.Count; i++)
                {
                    employees.Add((Employee)Employee_List_View.SelectedItems[i]);
                }
                EmployeeDAO.Instance.DeleteListEmployee(employees);
                Load();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addWindow = new AddWindow();
            addWindow.ShowDialog();
            Load();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
            MessageBox.Show("Loaded succesfully!!");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Employee editEmployee = (Employee)Employee_List_View.SelectedItem;
            editEmployeeWindow = new EditEmployeeWindow(editEmployee);
            editEmployeeWindow.ShowDialog();
            Load();
        }

        /* -----------------------------------------------------ROUTE SECTION ---------------------------------------------------*/
        private void routeAddButton_Click(object sender, RoutedEventArgs e)
        {
            addRouteWindow = new AddRouteWindow();
            addRouteWindow.ShowDialog();
            Load();
        }

        private void routeLoadButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
            MessageBox.Show("Loaded successfully!!");
        }

        private void routeClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selection ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Route> routes = new List<Route>();
                for (int i = 0; i < Route_List_View.SelectedItems.Count; i++)
                {
                    routes.Add((Route)Route_List_View.SelectedItems[i]);
                }
                RouteDAO.Instance.DeleteListRoute(routes);
                Load();
            }
        }

        private void routeSearchButton_Click(object sender, RoutedEventArgs e)
        {
            int distance;

            if (Int32.TryParse(routeDistanceTextBox.Text, out distance))
            {
                ;
            }
            else
            {
                if (routeDistanceTextBox.Text != "")
                {
                    MessageBox.Show("Invalid distance, must be an integer number");
                }

                distance = 0;
            }

            List<Route> routes = RouteDAO.Instance.FindRoutes(distance);
            Route_List_View.ItemsSource = routes;
        }
        private void routeEditButton_Click(object sender, RoutedEventArgs e)
        {
            Route editRoute = (Route)Route_List_View.SelectedItem;
            editRouteWindow = new EditRouteWindow(editRoute);
            editRouteWindow.ShowDialog();
            Load();

        }
        private void Route_List_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // đừng xóa hàm ni nghen, để trống đấy
        }


        /* -----------------------------------------------------END ROUTE SECTION ---------------------------------------------------*/


        //=========================================== Ticket section =============================================
        public void TicketLoad(bool __DESC = false)
        {
            if (__DESC == false)
            {
                DataContext = this;
                List<Ticket> tickets = TicketDAO.Instance.GetListAllTicket();
                Ticket_List_View.ItemsSource = tickets;
            }
            else
            {
                DataContext = this;
                List<Ticket> tickets = TicketDAO.Instance.GetListAllTicketDESC();
                Ticket_List_View.ItemsSource = tickets;
            }
        }

        private void TicketReload(object sender, MouseButtonEventArgs e)
        {
            TicketLoad();
        }


        private void TicketSearchButton_Click(object sender, RoutedEventArgs e)
        {
            
            string ticketId = (ticketIdTextBox.Text == "" ? null : ticketIdTextBox.Text);
            string type = (typeTicketTextBox.Text == "" ? null : typeTicketTextBox.Text);
            string routeId = (routeIdTextBox.Text == "" ? null : routeIdTextBox.Text);
            string paymentId = (paymentIdTextBox.Text == "" ? null : paymentIdTextBox.Text);
            int price, tripNo;
            if (Int32.TryParse(priceTextBox.Text, out price))
            {
                ;
            }
            else
            {
                if (priceTextBox.Text != "")
                {
                    MessageBox.Show("Invalid price, must be an integer number");
                }
                price = -1;
            }

            if (Int32.TryParse(tripNoTextBox.Text, out tripNo))
            {
                ;
            }
            else
            {
                if (tripNoTextBox.Text != "")
                {
                    MessageBox.Show("Invalid trip no., must be an integer number");
                }
                tripNo = -1;
            }
            //string msg = "search " + ticketId + " " + type + " " + price.ToString() + " " + routeId + " " + tripNo.ToString() + " " + paymentId + ".";
            //MessageBox.Show(msg);

            List<Ticket> res = TicketDAO.Instance.LookForTicket(ticketId, type, price, routeId, tripNo, paymentId);
            Ticket_List_View.ItemsSource = res;
        }

        private void ticketAddButton_Click(object sender, RoutedEventArgs e)
        {
            addTicketWindow = new AddTicketWindow();
            addTicketWindow.ShowDialog();
            TicketLoad();
        }

        private void TicketUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Ticket editTicket = (Ticket)Ticket_List_View.SelectedItem;
            if (editTicket == null) MessageBox.Show("You haven't choose any ticket yet, please choose one for the editing");
            else
            {
                editTicketWindow = new EditTicketWindow(editTicket);
                editTicketWindow.ShowDialog();
                TicketLoad();
            }
        }



        private void TicketReloadButton_Click(object sender, RoutedEventArgs e)
        {
            TicketLoad();
            MessageBox.Show("Reloaded successfully!!");
        }

        private void TicketDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(Ticket_List_View.SelectedItems.Count == 0)
            {
                    MessageBox.Show("You haven't choose any ticket yet. Please try again!");
            }
            else
            if (MessageBox.Show("Do you want to delete the selection?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Ticket> tickets = new List<Ticket>();
                for (int i = 0; i < Ticket_List_View.SelectedItems.Count; i++)
                {
                    tickets.Add((Ticket)Ticket_List_View.SelectedItems[i]);
                }
                TicketDAO.Instance.DeleteListTicket(tickets);
                TicketLoad();
            }
        }
        /* -----------------------------------------------------END Ticket SECTION ---------------------------------------------------*/


        /* -----------------------------------------------------BUS SECTION ---------------------------------------------------*/
        private void Bus_List_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addBusButton_Click(object sender, RoutedEventArgs e)
        {
            addBusWindow = new AddBusWindow();
            addBusWindow.ShowDialog();
            Load();
        }

        private void clearBusButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selection ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Bus> buss = new List<Bus>();
                for (int i = 0; i < Bus_List_View.SelectedItems.Count; i++)
                {
                    buss.Add((Bus)Bus_List_View.SelectedItems[i]);
                }
                BusDAO.Instance.DeleteListEmployee(buss);
                Load();
            }
        }
        private void searchBusButton_Click(object sender, RoutedEventArgs e)
        {
            string LPN = (licensedPlateNoTextbox.Text == "" ? null : licensedPlateNoTextbox.Text);
            string TOB = (typeOfBusTextBox.Text == "" ? null : typeOfBusTextBox.Text);
            int NOS;
            if (Int32.TryParse(NoOfSeatsTextBox.Text, out NOS))
            {
                ;
            }
            else
            {
                if (NoOfSeatsTextBox.Text != "")
                {
                    MessageBox.Show("Invalid input, must be an integer number");
                }
                NOS = -1;
            }
            List<Bus> buses = BusDAO.Instance.FindBus(TOB, LPN, NOS);
            Bus_List_View.ItemsSource = buses;
        }

        private void reloadBusButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
            MessageBox.Show("Loaded succesfully!!");
        }

        private void editBusButton_Click(object sender, RoutedEventArgs e)
        {
            Bus editBus = (Bus)Bus_List_View.SelectedItem;
            if (editBus != null)
            {
                editBusWindow = new EditBusWindow(editBus);
                editBusWindow.ShowDialog();
                Load();
            }
        }
    }
}
