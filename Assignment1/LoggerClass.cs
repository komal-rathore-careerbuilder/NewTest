using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Assignment1
{
    class LoggerClass
    {        
         public void LogMesssage(string FirstName,string LastName,string Message)
        {
            try
            {
                /*  DatabaseClass databaseClass = new DatabaseClass();
                  databaseClass.Conn = new SqlConnection("Data Source=SCS-P100\\SQLEXPRESS;Initial Catalog=EmployeeInfo;Integrated Security=True");
                  databaseClass.Conn.Open();
                  databaseClass.command = new SqlCommand("[dbo].[LogRecord]", databaseClass.Conn);
                  databaseClass.command.CommandType = CommandType.StoredProcedure;
                  databaseClass.command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                  databaseClass.command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                  databaseClass.command.Parameters.Add("@Message", SqlDbType.VarChar).Value = Message;
                  databaseClass.command.Parameters.Add("@Description", SqlDbType.VarChar).Value = "ContactForm";
                  databaseClass.command.ExecuteNonQuery();*/

                //public void LogFile(string sExceptionName, string sEventName, string sControlName, int nErrorLineNo, string sFormName)
                
                    StreamWriter log;
                    if (!File.Exists("logfile.txt"))
                    {
                        log = new StreamWriter("logfile.txt");
                    }
                    else
                    {
                        log = File.AppendText("logfile.txt");
                    }
                    // Write to the file:
                    log.WriteLine("Data Time:" + DateTime.Now);
                    log.WriteLine("First Name:" + FirstName);
                    log.WriteLine("Last Name:" + LastName);
                    log.WriteLine("Message:" + Message);
                    // Close the stream:
                    log.Close();
            }
            catch { }
        }

    }
}
