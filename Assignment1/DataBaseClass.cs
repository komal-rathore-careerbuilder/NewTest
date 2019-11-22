using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class DatabaseClass
    {
        public SqlConnection Conn;
        public SqlCommand command;
        public void DataBaseConnection()
        {
            Conn = new SqlConnection("Data Source=SCS-P100\\SQLEXPRESS;Initial Catalog=EmployeeInfo;Integrated Security=True");
            Conn.Open();
        }
    }
}
