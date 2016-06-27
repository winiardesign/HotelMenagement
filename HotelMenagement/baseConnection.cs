using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelMenagement
{
    class  baseConnection
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;       
        
        //Constructor
        public baseConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "hotel_base";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection(string login, string password)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM uzytkownicy WHERE userName ='"+login+"' AND userPassword = PASSWORD('"+password+"');", connection);
            connection.Open();
            try
            {
                // otworzenie połączenia z bazą
                MySqlDataReader odczytanie;
                odczytanie = cmd.ExecuteReader();

                if (odczytanie.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Twoje połącznie z bazą danych jest niepoprawne, kod błędu to: {0}",ex.Message);
                return false;
            }
        }

        //Close connection
        public void CloseConnection()
        {
            connection.Close();
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
