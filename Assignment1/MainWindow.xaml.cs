using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        LoggerClass Logger;
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
           
            ValidationClass validation = new ValidationClass();          
            validation.FirstName = FirstName.Text;
            validation.LastName = LastName.Text;
            validation.mobileNumber = MobileNumber.Text;
            validation.Company = CompanyName.Text;
            validation.BussinessEmail = BussinessEmail.Text;
            validation.JobTitle = JobTitle.Text;
            validation.Website = WebsiteAddress.Text;
            
            validation.Country = Country.Text;
            validation.State = State.Text;
            validation.City = City.Text;
            validation.NumberOfEmployees = NumberOfEmployee.Text;
            validation.ImInterested = IAmInterestedIn.Text;
            validation.CommentsQuestions = CommentsQuestion.Text;           
            validation.Validation();
            DatabaseClass databaseClass = new DatabaseClass();
            Logger = new LoggerClass();
            databaseClass.Conn = new SqlConnection("Data Source=SCS-P100\\SQLEXPRESS;Initial Catalog=EmployeeInfo;Integrated Security=True");
            databaseClass.Conn.Open();                       
                try
                {
                if (validation.Counter < 1)
                {
                    databaseClass.command = new SqlCommand("[dbo].[InsertRecord]", databaseClass.Conn);
                    databaseClass.command.CommandType = System.Data.CommandType.StoredProcedure;
                    databaseClass.command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName.Text;
                    databaseClass.command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName.Text;
                    databaseClass.command.Parameters.Add("@Company", SqlDbType.VarChar).Value = CompanyName.Text;
                    databaseClass.command.Parameters.Add("@BussinessEmail", SqlDbType.VarChar).Value = BussinessEmail.Text;
                    databaseClass.command.Parameters.Add("@JobTitle", SqlDbType.VarChar).Value = JobTitle.Text;
                    databaseClass.command.Parameters.Add("@WebsiteAddress", SqlDbType.VarChar).Value = WebsiteAddress.Text;
                    databaseClass.command.Parameters.Add("@Phone", SqlDbType.BigInt).Value = MobileNumber.Text;
                    databaseClass.command.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country.Text;                                       
                    databaseClass.command.Parameters.Add("@State", SqlDbType.VarChar).Value = State.Text;                  
                    databaseClass.command.Parameters.Add("@City", SqlDbType.VarChar).Value = City.Text;
                    databaseClass.command.Parameters.Add("@NumberOfEmployees", SqlDbType.Int).Value = NumberOfEmployee.Text;
                    databaseClass.command.Parameters.Add("@ImInterested", SqlDbType.VarChar).Value = IAmInterestedIn.Text;
                    databaseClass.command.Parameters.Add("@Comments", SqlDbType.VarChar).Value = CommentsQuestion.Text;
                    int cmd = databaseClass.command.ExecuteNonQuery();
                    if (cmd > 0)
                    {
                        Logger.LogMesssage(FirstName.Text, LastName.Text, "Successfully Inserted");
                    }
                }                
                }
                            
            catch (Exception exp)
            {
                Logger.LogMesssage(FirstName.Text, LastName.Text, "Not Successfully Inserted");
               
            }
            databaseClass.Conn.Close();
        }

        public void ChangeCountry()
        {           
            if (Country.SelectedIndex == 1)
            {
                List<string> StateItems = new List<string>() { "Madhya Pradesh", "Uttar Pradesh", "Maharashtra" };
                StateItems.ForEach(i => State.Items.Add(i));
                if (State.Items.Contains("Florida"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("Florida"));
                }
                if (State.Items.Contains("New York"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("New York"));
                }
                if (State.Items.Contains("New Jersey"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("New Jersey"));
                }

            }
            else if (Country.SelectedIndex == 2)
            {
                List<string> StateItems = new List<string>() { "Florida", "New York", "New Jersey" };
                StateItems.ForEach(i => State.Items.Add(i));
                if (State.Items.Contains("Madhya Pradesh"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("Madhya Pradesh"));
                }
                if (State.Items.Contains("Uttar Pradesh"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("Uttar Pradesh"));
                }
                if (State.Items.Contains("Maharashtra"))
                {
                    State.Items.RemoveAt(State.Items.IndexOf("Maharashtra"));
                }
            }           
        }

        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeCountry();
        }
        

    }
}
