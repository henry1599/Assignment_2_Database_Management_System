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
    public partial class EditTicketWindow : Window
    {
        private Ticket ticket;
        private string _ticketId;
        public EditTicketWindow(Ticket _ticket)
        {
            InitializeComponent();
            ticket = new Ticket();

            updateTicketIdTextBox.Text = _ticket.TicketID;
            _ticketId = _ticket.TicketID;

            updatePaymentIdTicketTextBox.Text = _ticket.PaymentID;
            updateRouteIdTicketTextBox.Text = _ticket.RouteID;
            updateTypeTicketTextBox.Text = _ticket.Type;

            updateTripNoTicketTextBox.Text = _ticket.TripNo.ToString();
            updatePriceTicketTextBox.Text = _ticket.Price.ToString();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkInput(string _ticketId, string _paymentId, string _type, string _routeId)
        {
            if (_ticketId.Length > 10 || _paymentId.Length > 11 || _type.Length > 1 || _routeId.Length > 2)
                return false;
            return true;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkInput(updateTicketIdTextBox.Text, updatePaymentIdTicketTextBox.Text, updateTypeTicketTextBox.Text, updateRouteIdTicketTextBox.Text))
            {
                MessageBox.Show("Warning: Please check the format of the input again!!!" +
                    "\nticket_id: varchar(10)\ntype: varchar(1)\nroute_id: varchar(2)\npayment_id: varchar(11)");

            }
            else
            if (MessageBox.Show("Do you want to confirm editing this ticket?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ticket.PaymentID = updatePaymentIdTicketTextBox.Text;
                ticket.RouteID = updateRouteIdTicketTextBox.Text;
                ticket.TicketID = updateTicketIdTextBox.Text;
                ticket.Type = updateTypeTicketTextBox.Text;

                ticket.Price = Int32.Parse(updatePriceTicketTextBox.Text);
                ticket.TripNo = Int32.Parse(updateTripNoTicketTextBox.Text);

                this.Close();
                TicketDAO.Instance.UpdateTicket(ticket, _ticketId);
            }
        }
    }
}
