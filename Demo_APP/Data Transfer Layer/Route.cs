using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_APP.Data_Transfer_Layer
{
    public class Route
    {
        public Route()
        {

        }

        public Route(string routeId, int distance, string employeeId)
        {
            RouteId = routeId;
            Distance = distance;
            EmployeeId = employeeId;
        }

        public Route(DataRow row)
        {
            RouteId = row["Route"].ToString();
            Distance = (int)row["Distance"];
            LastName = row["Ho"].ToString();
            FirstName = row["Ten"].ToString();
            Email = row["Email"].ToString();
            EmployeeId = row["EmployeeId"].ToString();
        }

        private string routeId;
        private int distance;
        private string lastName; // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        private string firstName; // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        private string email; // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        private string employeeId;

        public string RouteId { get => routeId; set => routeId = value; }
        public int Distance { get => distance; set => distance = value; }
        public string LastName { get => lastName; set => lastName = value; } // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        public string FirstName { get => firstName; set => firstName = value; } // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        public string Email { get => email; set => email = value; } // Có thể không cần field này (vì chỉ dùng để hiển thị cho nút AddButton)
        public string EmployeeId { get => employeeId; set => employeeId = value; }
    }
}
