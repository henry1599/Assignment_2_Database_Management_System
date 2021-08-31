using Demo_APP.Data_Transfer_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_APP.Data_Access_Layer
{
    public class RouteDAO
    {
        private static RouteDAO instance;

        public static RouteDAO Instance
        {
            get { if (instance == null) instance = new RouteDAO(); return instance; }
            private set => instance = value;
        }

        private RouteDAO() { }

        public List<Route> GetListAllRoute()
        {
            List<Route> output = new List<Route>();

            string query = "SELECT r.route_id Route, r.distance Distance, e.last_name Ho, e.first_name Ten, e.email Email, e.employee_id EmployeeId FROM route r INNER JOIN employee e ON r.operating_staff_id = e.employee_id;";

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Route route = new Route(row);

                output.Add(route);
            }

            return output;
        }

        /// <summary>
        /// Nhớ để cái nút ô text box cho chức năng search này mặc định là giá trị 0 giùm tui
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public List<Route> FindRoutes(int distance = 0)
        {
            List<Route> output = new List<Route>();

            string query = "SELECT r.route_id Route, r.distance Distance, e.last_name Ho, e.first_name Ten, e.email Email, e.employee_id EmployeeId " +
                "FROM route r INNER JOIN employee e ON r.operating_staff_id = e.employee_id " +
                $"WHERE distance > { distance }";

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Route route = new Route(row);

                output.Add(route);
            }

            return output;
        }

        public void DeleteListRoute(List<Route> routes)
        {
            string query = "";

            foreach (Route route in routes)
            {
                query = $"DELETE FROM Route WHERE route_id = '{ route.RouteId }'";

                DataProviderDAO.Instance.ExecuteQuery(query);
            }
        }

        public void AddListRoute(Route route)
        {
            string query = $"INSERT INTO Route (route_id, distance, operating_staff_id)" +
                $"value ('{ route.RouteId }', { route.Distance }, '{ route.EmployeeId }')";

            DataProviderDAO.Instance.ExecuteQuery(query);
        }

        public void EditRoute(Route route, string routeId)
        {
            string query = $"UPDATE Route SET " +
                $"route_id = '{ route.RouteId }', distance = { route.Distance }, operating_staff_id = '{ route.EmployeeId }' " +
                $"WHERE route_id = '{ routeId }'";

            DataProviderDAO.Instance.ExecuteQuery(query);
        }
    }
}
