using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace lab1
{
    class AccommodationUnit
    {
        private int unit_id;
        private int campsite_id;
        private int accommodation_type_id;
        private int n_pitch;
        private string Status;
        OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.Database2ConnectionString);
       
        
        public AccommodationUnit( int id, int type_id, int n_pitch_, string status)
        {
            campsite_id = id;
            accommodation_type_id = type_id;
            n_pitch = n_pitch_;
            Status = status;
        }

        public AccommodationUnit(int id)  { unit_id = id;}

        public AccommodationUnit() { }

        public AccommodationUnit(int id, string accom_unit_status1) 
        {
            unit_id = id;
            Status = accom_unit_status1;
        }

        public void Insert()
        {

           
            OleDbCommand Insert = new OleDbCommand("insert into Unit(campsite_id,Type_id,n_pitch,status) values(" +

               
                "'" + campsite_id + "'," +
                "'" +accommodation_type_id + "'," +
                "'" + n_pitch + "'," +
                "'" +Status + "'" +                             
                 ")", connection);
            connection.Open();
            Insert.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete()
        {
            OleDbCommand Delete = new OleDbCommand("DELETE FROM Unit WHERE   unit_id =" + unit_id, connection);
            connection.Open();
            Delete.ExecuteNonQuery();
            connection.Close();
        }
        public void Update()
        {
            OleDbCommand Update = new OleDbCommand("UPDATE Unit SET status = '"+Status+"' WHERE unit_id ="+ unit_id, connection);
            connection.Open();
            Update.ExecuteNonQuery();
            connection.Close();
        }
        public void OutUnit()
        {
            string queryString =
             "SELECT * FROM Unit ";


         //   Properties.Settings.Default.Database2.1ConnectionString
          
                OleDbCommand command = new OleDbCommand(queryString, connection);
                // command.Parameters.AddWithValue("@idPoint", id);


                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("====================================================================================================");
                    while (reader.Read())
                    {
                        unit_id = (int)reader[0];
                        campsite_id = (int)reader[1];
                        accommodation_type_id = (int)reader[2];
                        n_pitch = (int)reader[3];
                        Status = (string)reader[4];
                       


                        Console.WriteLine("{0}  {1,10}  {2,10}  {3,20}  {4,10} ", unit_id, campsite_id,
                             accommodation_type_id, n_pitch, Status);
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
