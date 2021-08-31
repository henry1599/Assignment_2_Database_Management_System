using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_APP.Data_Transfer_Layer
{
    public class Ticket
    {
        public Ticket() { }

        public Ticket(string _ticketID, string _type, int _price, string _routeID, int _tripNo, string _paymentID)
        {
            this.TicketID = _ticketID;
            this.Type = _type;
            this.Price = _price;
            this.RouteID = _routeID;
            this.TripNo = _tripNo;
            this.PaymentID = _paymentID;

        }

        



        private string ticketID;
        private string type;
        private int price;
        private string routeID;
        private int tripNo;
        private string paymentID;
        //private string cardID;// dành cho member và monthly, đối với non member thì dùng 1 mã "ZZZZZZZZZZ"

        public Ticket(DataRow row)
        {
            this.TicketID = row["ticket_id"].ToString();
            this.Price = (int)row["price"];
            this.Type = row["type_ticket"].ToString();
            this.RouteID = row["route_id"].ToString();
            this.TripNo = (int)row["trip_no"];
            this.PaymentID = row["payment_id"].ToString();
        }


        public string Type { get => type; set => type = value; }
        public string RouteID { get => routeID; set => routeID = value; }
        public int TripNo { get => tripNo; set => tripNo = value; }
        public string TicketID { get => ticketID; set => ticketID = value; }
        public int Price { get => price; set => price = value; }
        public string PaymentID { get => paymentID; set => paymentID = value; }

    }
}