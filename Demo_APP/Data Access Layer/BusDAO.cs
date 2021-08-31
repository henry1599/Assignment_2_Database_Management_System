using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Demo_APP.Data_Transfer_Layer;
namespace Demo_APP.Data_Access_Layer
{
    public class BusDAO
    {
        private static BusDAO instance;

        public static BusDAO Instance
        {
            get { if (instance == null) instance = new BusDAO(); return instance; }
            private set => instance = value;
        }
        private BusDAO() { }

        public List<Bus> GetListAllBus()
        {
            List<Bus> listBus = new List<Bus>();
            string query = "SELECT * FROM BUS";
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bus bus = new Bus(item);
                listBus.Add(bus);
            }
            return listBus;
        }

        public List<Bus> FindBus(string typeOfBus, string licensedPlateNo, int numberOfSeats = -1)
        {
            List<Bus> BusResult = new List<Bus>();
            string query = "SELECT * FROM BUS";
            if (!(typeOfBus == null && licensedPlateNo == null && numberOfSeats == -1 ))
            {
                query += " WHERE ";
                if (typeOfBus != null)
                {
                    string additional_query = "type_of_bus = '" + typeOfBus + "'";
                    query += additional_query;
                    query += " AND ";
                }
                if (licensedPlateNo != null)
                {
                    string additional_query = "license_plate_no = '" + licensedPlateNo + "'";
                    query += additional_query;
                    query += " AND ";
                }
                if (numberOfSeats != -1)
                {
                    string additional_query = "number_of_seats = " + numberOfSeats.ToString();
                    query += additional_query;
                    query += " AND ";
                }
                // Remove the final " AND "
                query = query.Remove(query.Length - 5);
            }

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Bus bus = new Bus(row);
                BusResult.Add(bus);
            }

            return BusResult;
        }

        public void DeleteListEmployee(List<Bus> Buss)
        {
            foreach (Bus bus in Buss)
            {
                string query = "DELETE FROM BUS WHERE license_plate_no = '" + bus.LicensedPlateNo + "'";
                DataProviderDAO.Instance.ExecuteQuery(query);
            }
        }

        public void AddListBus(Bus bus)
        {
            string query = "INSERT INTO BUS VALUES('" + bus.LicensedPlateNo + "','" + bus.TypeOfBus + "','" + bus.NumberOfSeats + "')";
            DataProviderDAO.Instance.ExecuteQuery(query);
        }

        public void EditBus(Bus bus, string licensedPlateNo)
        {
            string query = "UPDATE BUS SET license_plate_no = '" + bus.LicensedPlateNo + "', type_of_bus = '" + bus.TypeOfBus
                + "', number_of_seats = '" + bus.NumberOfSeats +  "' WHERE license_plate_no = '" + licensedPlateNo + "';";
            DataProviderDAO.Instance.ExecuteQuery(query);
        }
    }
}
