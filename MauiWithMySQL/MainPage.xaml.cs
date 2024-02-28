using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Text;

namespace MauiWithMySQL
{
    public partial class MainPage : ContentPage
    {
        // MySQL in Azure, https://azure.microsoft.com/en-us/products/mysql
        // Connection via, https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-connection.html
        // Create table via https://dev.mysql.com/doc/refman/8.0/en/creating-tables.html
        // Add data via https://dev.mysql.com/doc/refman/8.0/en/loading-tables.html

        public MainPage()
        {
            InitializeComponent();
        }



        private async void CheckConnection_Clicked(object sender, EventArgs e)
        {

            try
            {
                var myConnection = GetConnection();
                //open a connection
                myConnection.Open();

                // create a MySQL command and set the SQL statement with parameters
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = @"SELECT CURTIME() as time;";

                // execute the command and read the results
                using var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    var time = myReader.GetTimeSpan("time");
                    await DisplayAlert("Connection successful", $"Connection status is {myConnection.State} and the current time from database is {time}", "OK");
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection error", ex.Message, "OK");
            }
        }

        private MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            string server = this.Server.Text;
            string user = this.User.Text;
            string password = this.Password.Text;
            string database = this.Database.Text;

            //set the correct values for your server, user, password and database name
            string myConnectionString = $"server={server};uid={user};pwd={password};database={database}";

            return new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
        }

        private async void FetchData_Clicked(object sender, EventArgs e)
        {
            try
            {
                var myConnection = GetConnection();
                //open a connection
                myConnection.Open();

                // create a MySQL command and set the SQL statement with parameters
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = @"SELECT * FROM pet;";

                // execute the command and read the results
                StringBuilder sb = new StringBuilder();
                int counter = 0;
                using var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    sb.AppendLine($"{++counter}: Name: {myReader.GetString("name")}, Owner: {myReader.GetString("owner")}, Species: {myReader.GetString("species")}, Sex:  {myReader.GetString("sex")}, Birth: {myReader.GetDateTime("birth")}");
                }

                myConnection.Close();

                this.DataFromDb.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection error", ex.Message, "OK");
            }
        }

        private async void AddData_Clicked(object sender, EventArgs e)
        {
            try
            {
                var myConnection = GetConnection();
                //open a connection
                myConnection.Open();

                // create a MySQL command and set the SQL statement with parameters
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = $"INSERT INTO pet VALUES('Rekku', 'Ope', 'koira', 'm', '{DateTime.Now.ToString("yyyy-MM-dd")}', NULL);";

                var result = await myCommand.ExecuteNonQueryAsync();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection error", ex.Message, "OK");
            }

        }
    }

}
