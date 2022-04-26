using Dapper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBAccessDemo
{

    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();

            PeopleFoundListBox.ItemsSource = people;
            PeopleFoundListBox.DisplayMemberPath = "";
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            people = db.GetPeople(LastNameText.Text);

            PeopleFoundListBox.ItemsSource = people;
            PeopleFoundListBox.DisplayMemberPath = "FullInfo";
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.AddUser(FirstName.Text, LastName.Text, Email.Text, PhoneNumber.Text);
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            PhoneNumber.Text = "";
            Update.Text = "A new user has been added!";

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update.Text = "";
        }

        private void AllBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.GetAllData();
            people = db.GetAllData();
            PeopleFoundListBox.ItemsSource = people;
            PeopleFoundListBox.DisplayMemberPath = "FullInfo";
        }

        private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            //create button
            Button delUser = new Button();

            delUser.Name = "DelUserBtn";
            delUser.MaxHeight = 30;
            delUser.MaxWidth = 100;
            delUser.Content = "Delete User";
            gridMain.Children.Add(delUser);

            Grid.SetColumn(delUser, 1);
            Grid.SetRow(delUser, 7);
            delUser.Click += new RoutedEventHandler(DelUserBtn_Click);

            //Update user button - not implemented 
            Button updateUser = new Button();

            updateUser.Name = "UpdateBtn";
            updateUser.MaxHeight = 30;
            updateUser.MaxWidth = 100;
            updateUser.Content = "Update User";
            gridMain.Children.Add(updateUser);

            Grid.SetColumn(updateUser, 3);
            Grid.SetRow(updateUser, 7);
            updateUser.Click += new RoutedEventHandler(UpdateUserBtn_Click); //need to change event handler

        }

        void DelUserBtn_Click(object sender, RoutedEventArgs e)
        {
            var personToDel = (Person)PeopleFoundListBox.SelectedItem;

            DataAccess db = new DataAccess();
            db.DelUser(personToDel);

            PeopleFoundListBox.UnselectAll();
            LastNameText.Text = "";

            PeopleFoundListBox.ItemsSource = people;
            PeopleFoundListBox.DisplayMemberPath = "FullInfo";
        }
        void UpdateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            var personToUpdate = (Person)PeopleFoundListBox.SelectedItem;
           

            UpdateWindow1 userUpdateWindow = new UpdateWindow1(personToUpdate);
            userUpdateWindow.Show();

            
        }
    }
}


