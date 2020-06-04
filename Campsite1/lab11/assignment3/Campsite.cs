using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace lab1
{
    class Campsite
    {
        private int campsite_id;
        private string name;
        private string country;
        private string region;
        private string telephone;
        private string email;
        private string url;
        OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.Database2ConnectionString);
        public Campsite(string na, string coun, string reg, string phone, string ema, string ur)
        {

            name = na;
            country = coun;
            region = reg;
            telephone = phone;
            email = ema;
            url = ur;
        }
        public Campsite() { }
        public Campsite(int id) {campsite_id = id;}    
        public void Search(string searchValue )
        {
           
            OleDbCommand command = new OleDbCommand("Select * From Campsite where country='" + searchValue + "'", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                  Console.WriteLine("{0}  {1,10}  {2,10}  {3,20}  {4,10} {5,10} {6,10}","ID","Name","Country","Region", "Telephone" , "Email", "Url");
                  Console.WriteLine("================================================================================================================");
                while (reader.Read())
                {
                    campsite_id = (int)reader[0];
                    name = (string)reader[1];
                    country = (string)reader[2];
                    region = (string)reader[3];
                    telephone = (string)reader[4];
                    email = (string)reader[5];
                    url = (string)reader[6];



                    Console.WriteLine("{0}  {1,10}  {2,10}  {3,20}  {4,10} {5,10} {6,10}", campsite_id,
                        name, country, region, telephone, email, url);
                }
                reader.Close();

            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            connection.Close();
        }
            public void Insert()
        {
            OleDbCommand Insert = new OleDbCommand("insert into Campsite(Campsite_name,country,region,telephone,email,url) values(" +
          
                "'" + name + "'," +
                "'" + country + "'," +          
                "'" + region + "'," +
                "'" + telephone + "'," +
                "'" + email + "'," +
                "'" + url + "'" +             
                  ")", connection);

            connection.Open();
            Insert.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete()
        {      
            OleDbCommand Delete = new OleDbCommand("DELETE FROM Campsite WHERE  campsite_id ="+campsite_id, connection);
            connection.Open();
           Delete.ExecuteNonQuery();
            connection.Close();
        }

        public void OutCampsite()
        {
            string queryString =
             "SELECT * FROM Campsite ";
                OleDbCommand command = new OleDbCommand(queryString, connection);
               


                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("====================================================================================================");
                    while (reader.Read())
                    {
                       campsite_id = (int)reader[0];
                       name = (string)reader[1];
                       country = (string)reader[2];
                       region = (string)reader[3];
                       telephone = (string)reader[4];
                       email = (string)reader[5];
                       url = (string)reader[6];
                      


                        Console.WriteLine("{0}  {1,10}  {2,10}  {3,20}  {4,10} {5,10} {6,10}", campsite_id,
                            name, country, region, telephone, email, url);
                    }
                    reader.Close();

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                connection.Close();
        }
    }
}
