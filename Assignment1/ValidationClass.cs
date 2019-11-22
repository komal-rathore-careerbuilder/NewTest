using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.ComponentModel;

namespace Assignment1
{
    class ValidationClass
    {
        public string FirstName;
        public string LastName;
        public string mobileNumber;
        public string Company;
        public string JobTitle;
        public string BussinessEmail;
        public string State;
        public string Website;
        public string Country;
        public string City;
        public string NumberOfEmployees;
        public string ImInterested;
        public string CommentsQuestions;
        public int Counter = 0;
        /*private string MobileNumber
        {         
          get {return mobileNumber ;}
          set {
                ValidatePhone(value);
                MobileNumber=value;
                PropertyChanged(this, new PropertyChangedEventArgs("MobileNumber"));
               }
        }*/

        public void Validation()
        {
            if (FirstName == "" || LastName == "" || Company == "" || JobTitle == "" || BussinessEmail == "" || State == "" || Website == "" || Country == "" || NumberOfEmployees == "" || ImInterested == "" || CommentsQuestions == "")
            {
                MessageBox.Show("Please fill fields");
                Counter++;
            }
            else
            {
                IList<string> strList1 = new List<string>() { FirstName, LastName, Company };
                foreach (string str in strList1)
                {
                    if (!Regex.Match(str, @"^[a-zA-Z]+$").Success)
                    {
                        MessageBox.Show("Invalid Field :" + str);
                        Counter++;
                    }
                }
                if (!Regex.Match(mobileNumber, "^([0-9]{10})$").Success)
                {
                    MessageBox.Show("Please Enter valid Number");
                    Counter++;
                }
                string email = "^[a - z0 - 9][-a - z0 - 9._] +@([-a - z0 - 9] +.) +[a - z]{ 2,5}$";
                if (!Regex.IsMatch(BussinessEmail, email))
                {
                    MessageBox.Show("Please Enter valid Email");
                    Counter++;
                }
                if (!Uri.IsWellFormedUriString(Website, UriKind.Absolute))
                {
                    MessageBox.Show("Please Enter valid Website");
                    Counter++;
                }               
            }
        }
    }
 }


    

