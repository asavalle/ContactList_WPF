using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dapper;

namespace DBAccessDemo
{
    public class DataAccess
    {
        public List<Person> GetPeople(string LastName)
        {
            //Opens a connection and automatically closes connection when complete
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                return connection.Query<Person>($"SELECT * FROM People WHERE LastName = '{LastName}'").ToList();
                 
            }
        }

        public void AddUser(String firstName, string lastName, string email, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                connection.Query($"INSERT INTO People (FirstName, LastName, Email, PhoneNumber) VALUES ('{firstName}','{lastName}','{email}','{phoneNumber}'  )");

            }
        }

        public List<Person> GetAllData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                return connection.Query<Person>($"SELECT * FROM People;").ToList();

            }
        }

        public void DelUser(Person listItem)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var userID = listItem.User_ID.ToString();
                connection.Query<string>($"DELETE FROM People WHERE User_ID={userID}");

                MessageBox.Show("User has been deleted.");


            }   
        }
        public void UpdateUser(int UserID, string FirstName, string LastName,string Email, string PhoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {

                connection.Query<string>(
                    $"Update People " +
                    $"Set FirstName ='{FirstName}', " +
                    $"LastName ='{LastName}', " +
                    $"Email='{Email}', " +
                    $"PhoneNumber = '{PhoneNumber}' " +
                    $"WHERE User_ID={UserID}");

                MessageBox.Show("User has been Updated.");


            }

        }


    }
}
