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
    class AccommodationType
    {

        protected int accommodation_type_id;
        protected string  accommodation_type;
        protected int daily_rate;
        protected int no_of_occupants;
        protected int no_of_bedrooms;
        protected int Square_Meters;
        protected OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.Database2ConnectionString);
        public AccommodationType(  string type, int da_ra, int occupants, int bedrooms,int Square)
        {
         
            accommodation_type      = type;
            daily_rate              = da_ra;
            no_of_occupants         = occupants;
            no_of_bedrooms          = bedrooms;
            Square_Meters           = Square;
        }
        public AccommodationType(int id)
        {

            accommodation_type_id = id;
           
        }
        public AccommodationType()
        {
            
        }
        public void AccommodationTypeOut()
        {

            OleDbCommand command = new OleDbCommand("Select type_id, type, daily_rate From AccommodationType ", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0}  {1,20}  {2,20}   ", "ID", "Type", "Daily rate");
                Console.WriteLine("================================================================================================================");
                while (reader.Read())
                {
                    accommodation_type_id = (int)reader[0];
                    accommodation_type = (string)reader[1];
                    daily_rate = (int)reader[2];




                    Console.WriteLine("{0}  {1,20}  {2,20}  ", accommodation_type_id, accommodation_type, daily_rate);
                }
                reader.Close();

            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            connection.Close();
        }
        public void Search(int searchValue)
        {

            OleDbCommand command = new OleDbCommand("Select type_id, type, daily_rate From AccommodationType where daily_rate >=" + searchValue , connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0}  {1,20}  {2,20}   ", "ID", "Type", "Daily rate");
                Console.WriteLine("================================================================================================================");
                while (reader.Read())
                {
                    accommodation_type_id = (int)reader[0];
                    accommodation_type = (string)reader[1];
                    daily_rate= (int)reader[2];
                   



                    Console.WriteLine("{0}  {1,20}  {2,20}  ", accommodation_type_id, accommodation_type, daily_rate);
                }
                reader.Close();

            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            connection.Close();
        }
        public void Delete()
        {
            OleDbCommand Delete = new OleDbCommand("DELETE FROM AccommodationType WHERE  type_id =" + accommodation_type_id, connection);
            connection.Open();
            Delete.ExecuteNonQuery();
            connection.Close();
        }

    }
    class AccommodationTypeMobileHause: AccommodationType, IDatabaseAdd
    {
      
       private int no_of_batsrooms;
        private string decking;
        private string dishwater;

        public AccommodationTypeMobileHause( string type, int da_ra, int occupants, int bedrooms, int Square, int batsrooms, string deck, string dishw) : base( type, da_ra, occupants, bedrooms, Square)
        {
            no_of_batsrooms= batsrooms;
            decking = deck;
            dishwater= dishw;
        }
        public AccommodationTypeMobileHause()
        {
         
        }
        public void OutAccommodationTypeMobileHause()
        {

            //Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}\t {7} \t {8} \t", accommodation_type_id,
            //    accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, no_of_batsrooms, decking, dishwater);

            string queryString =
         "SELECT type_id, type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, no_of_batsrooms, decking, dishwater FROM AccommodationType";



           
                OleDbCommand command = new OleDbCommand(queryString, connection);
                // command.Parameters.AddWithValue("@idPoint", id);


                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("====================================================================================================");
                    while (reader.Read())
                    {
                        accommodation_type_id = (int)reader[0];
                        accommodation_type = (string)reader[1];
                        daily_rate = (int)reader[2];
                        no_of_occupants = (int)reader[3];
                        no_of_bedrooms = (int)reader[4];
                        Square_Meters = (int)reader[5];
                        no_of_batsrooms = (int)reader[6];
                        decking = (string)reader[7];
                        dishwater = (string)reader[8];
                      


                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}\t {7} \t {8} \t", accommodation_type_id,
                            accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, no_of_batsrooms, decking, dishwater);
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

            
            OleDbCommand Insert = new OleDbCommand("insert into AccommodationType(type,daily_rate,no_of_occupants,no_of_bedrooms,Square_Meters,no_of_batsrooms,decking,dishwater) values(" +
                
                "'" + accommodation_type + "'," +
                "'" + daily_rate + "'," +
                "'" + no_of_occupants + "'," +
                "'" + no_of_bedrooms + "'," +
                "'" + Square_Meters + "'," +
                "'" + no_of_batsrooms + "'," +
                "'" + decking + "'," +
                "'" + dishwater + "'" +             
                  ")", connection);
         
            connection.Open();
            Insert.ExecuteNonQuery();
            connection.Close();
        }

    }
    class AccommodationTypeTent : AccommodationType
    {
        private string grill_gas;
        private string terrace;
        public AccommodationTypeTent( string type, int da_ra, int occupants, int bedrooms, int Square, string grill, string terra) : base( type, da_ra, occupants, bedrooms, Square)
        {
            grill_gas = grill;
            terrace = terra;
        }
         public AccommodationTypeTent()
        {
            
        }
        public void Insert()
        {

           
            OleDbCommand Insert = new OleDbCommand("insert into AccommodationType(type,daily_rate,no_of_occupants,no_of_bedrooms,Square_Meters,grill_gas,terrace) values(" +
               
                "'" + accommodation_type +   "'," +
                "'" + daily_rate +           "'," +
                "'" + no_of_occupants +       "'," +
                "'" + no_of_bedrooms + "'," +
                "'" + Square_Meters + "'," +
                "'" + grill_gas + "'," +
                "'" + terrace + "'" +     
                  ")", connection);

            connection.Open();
            Insert.ExecuteNonQuery();
            connection.Close();
        }

        public void OutAccommodationTypeTent()
        {

            //Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}\t {7} \t ", accommodation_type_id,
            //    accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, grill_gas, terrace);

            string queryString =
            "SELECT  type_id,type , accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, grill_gas, terrace FROM AccommodationType ";



           
                OleDbCommand command = new OleDbCommand(queryString, connection);
                // command.Parameters.AddWithValue("@idPoint", id);


                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("====================================================================================================");
                    while (reader.Read())
                    {
                      
                        accommodation_type_id = (int)reader[0];
                        accommodation_type = (string)reader[1];
                        daily_rate = (int)reader[2];
                        no_of_occupants = (int)reader[3];
                        no_of_bedrooms = (int)reader[4];
                        Square_Meters = (int)reader[5];
                        grill_gas = (string)reader[6];
                        terrace = (string)reader[7];


                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}\t {7} \t ", accommodation_type_id,
                          accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, grill_gas, terrace);
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
    class AccommodationTypeCharles : AccommodationType
    {
        private int no_of_stories;
        private int no_of_batsrooms;
        private string beach;
        private string balcony;
        public AccommodationTypeCharles( string type, int da_ra, int occupants, int bedrooms, int Square, int stories, int batsrooms, string beac, string balco) : base(type, da_ra, occupants, bedrooms, Square)
        {
            no_of_stories = stories;
            no_of_batsrooms = batsrooms;
            beach = beac;
            balcony = balco;
        }
        public AccommodationTypeCharles()
        {
         
        }
        public void Insert()
        {

          
             OleDbCommand Insert = new OleDbCommand("insert into AccommodationType(type,daily_rate,no_of_occupants,no_of_bedrooms,Square_Meters,no_of_stories,no_of_batsrooms,beach,balcony) values(" +
                
                "'" + accommodation_type + "'," +
                "'" + daily_rate + "'," +
                "'" + no_of_occupants + "'," +
                "'" + no_of_bedrooms + "'," +
                "'" + Square_Meters + "'," +
                "'" + no_of_stories + "'," +
                "'" + no_of_batsrooms + "'," +
                "'" + beach + "'," +
                "'" + balcony + "'" +
                  ")", connection);

            connection.Open();
            Insert.ExecuteNonQuery();
            connection.Close();
        }

       
        public void OutAccommodationTypeCharles()
        {
            string queryString =
             "SELECT type_id, type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters,no_of_stories,no_of_batsrooms,beach,balcony FROM AccommodationType ";



           
                OleDbCommand command = new OleDbCommand(queryString, connection);
                // command.Parameters.AddWithValue("@idPoint", id);


                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("====================================================================================================");
                    while (reader.Read())
                    {
                        accommodation_type_id = (int)reader[0];
                        accommodation_type = (string)reader[1];
                        daily_rate = (int)reader[2];
                        no_of_occupants = (int)reader[3];
                        no_of_bedrooms = (int)reader[4];
                        Square_Meters = (int)reader[5];
                        no_of_stories = (int)reader[6];
                        no_of_batsrooms = (int)reader[7];
                        beach = (string)reader[8];
                        balcony = (string)reader[9];


                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}\t {7} \t {8}\t {9} \t", accommodation_type_id,
                            accommodation_type, daily_rate, no_of_occupants, no_of_bedrooms, Square_Meters, no_of_stories, no_of_batsrooms, beach, balcony);
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
