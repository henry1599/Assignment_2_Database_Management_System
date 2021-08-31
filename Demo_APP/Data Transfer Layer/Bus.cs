using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_APP.Data_Transfer_Layer
{
    public class Bus
    {


        public Bus() { }
        public Bus(string typeOfBuss, string licensedPlateNo, int numberOfSeats)
        {
            this.typeOfBus = typeOfBuss;
            this.licensedPlateNo = licensedPlateNo;
            this.numberOfSeats = numberOfSeats;
        }
        public Bus(DataRow row)
        {
            this.typeOfBus = row["type_of_bus"].ToString();
            this.licensedPlateNo = row["license_plate_no"].ToString();
            this.numberOfSeats = (int)row["number_of_seats"];
        }
        private string typeOfBus;
        private string licensedPlateNo;
        private int numberOfSeats;
        public string TypeOfBus{ get => typeOfBus; set => typeOfBus = value; }
        public string LicensedPlateNo { get => licensedPlateNo; set => licensedPlateNo = value; }
        public int NumberOfSeats { get => numberOfSeats; set => numberOfSeats = value; }
    }
} 