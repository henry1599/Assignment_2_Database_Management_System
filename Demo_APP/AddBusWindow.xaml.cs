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
    /// Interaction logic for AddBusWindow.xaml
    /// </summary>
    public partial class AddBusWindow : Window
    {
        private Bus bus;
        public AddBusWindow()
        {
            InitializeComponent();
            bus = new Bus();
        }

        private void submitAddBusButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to confirm adding this bus ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bus.TypeOfBus = typeOfBusTextBox.Text;
                bus.LicensedPlateNo = license_plateTextBox.Text;
                if (int.TryParse(seatnoTextBox.Text, out int a)) bus.NumberOfSeats = Int32.Parse(seatnoTextBox.Text);
                this.Close();
                BusDAO.Instance.AddListBus(bus);
            }
        }

        private void returnAddBusButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
