using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBAccessDemo
{
    /// <summary>
    /// Interaction logic for UpdateWindow1.xaml
    /// </summary>
    public partial class UpdateWindow1 : Window
    {
        public UpdateWindow1(Person person)
        {
            InitializeComponent();
            FNdata.Content = (string)person.FName;
            LNdata.Content = (string)person.LName;
            Emaildata.Content = (string)person.email;
            Phonedata.Content = (string)person.PhoneNum;
            IDdata.Content = person.User_ID;


        }

        void UpdateData_Clicked(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            Person updatedPerson = new Person();

            //set new Person objects to value in text field, or the value of the current label if textbox is blank
            updatedPerson.FirstName = NewFNTextbox.Text.ToString() == ""? FNdata.Content.ToString(): NewFNTextbox.Text;
            updatedPerson.LastName = NewLNTextbox.Text.ToString() == "" ? LNdata.Content.ToString() : NewLNTextbox.Text;
            updatedPerson.Email = NewEmailTextbox.Text.ToString() == "" ? Emaildata.Content.ToString() : NewEmailTextbox.Text;
            updatedPerson.PhoneNumber = NewPhoneTextbox.Text.ToString() == "" ? Phonedata.Content.ToString() : NewPhoneTextbox.Text;
            updatedPerson.User_ID = (int)IDdata.Content;
            

            
            //Forward updated to Data Access method to be sent to the database.
            db.UpdateUser(updatedPerson.User_ID, updatedPerson.FirstName, updatedPerson.LastName, updatedPerson.email, updatedPerson.PhoneNum);


            NewFNTextbox.Text = "";
            NewLNTextbox.Text = "";
            NewEmailTextbox.Text = "";
            NewPhoneTextbox.Text = "";
            NewIDTextbox.Text = "";
            Update.Content = "The user has been Updated!";
        }

       
    }
}
