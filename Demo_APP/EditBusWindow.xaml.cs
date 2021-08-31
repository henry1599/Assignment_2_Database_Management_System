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
    /// Interaction logic for EditBusWindow.xaml
    /// </summary>
    public partial class EditBusWindow : Window
    {
        private Bus bus;
        string license_plate_no;
        public EditBusWindow(Bus _bus)
        {
            InitializeComponent();
            bus = new Bus();
            license_plate_no = licenseNoTextBox.Text = _bus.LicensedPlateNo;
            typeBusTextBox.Text = _bus.TypeOfBus;
            NoSeatTextBox.Text = _bus.NumberOfSeats.ToString();
        }

        private void returnBusButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBusButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to confirm editing this bus ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bus.LicensedPlateNo = licenseNoTextBox.Text;
                bus.TypeOfBus = typeBusTextBox.Text;
                if (int.TryParse(NoSeatTextBox.Text, out int a))
                    bus.NumberOfSeats = Int32.Parse(NoSeatTextBox.Text);
                this.Close();
                BusDAO.Instance.EditBus(bus, bus.LicensedPlateNo);
            }
        }
    }
}
