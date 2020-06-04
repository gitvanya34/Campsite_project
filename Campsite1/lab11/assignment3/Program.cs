using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AccommodationTypeCharles> Charles = new List<AccommodationTypeCharles>();
            List<AccommodationTypeTent> Tent = new List<AccommodationTypeTent>();
            List<AccommodationTypeMobileHause> Mobile = new List<AccommodationTypeMobileHause>();
            List<Campsite> Campsite = new List<Campsite>();
            List<AccommodationUnit> Unit = new List<AccommodationUnit>();
            List<AccommodationType> Type = new List<AccommodationType>();


            Charles.Add(new AccommodationTypeCharles());
            Tent.Add(new AccommodationTypeTent());
            Mobile.Add(new AccommodationTypeMobileHause());
            Campsite.Add(new Campsite());
            Unit.Add(new AccommodationUnit());
            Type.Add(new AccommodationType());
            




            int option = -1;
           

            string key ="0";
            ///
            while ( key !="10")
            {
                Console.WriteLine("\nPlease select one of the following " +
                            "options:");
                Console.WriteLine("1. Add Campsite ");
                Console.WriteLine("2. Accommodation Type ");
                Console.WriteLine("3. Add Accommodation Unit ");
                Console.WriteLine("4. Delete Campsite ");
                Console.WriteLine("5. Delete Accommodation Type ");
                Console.WriteLine("6. Delete Accommodation Unit ");
                Console.WriteLine("7. Update Accommodation Unit Status ");
                Console.WriteLine("8. Search Accommodation Types by Daily Rate  ");
                Console.WriteLine("9. Search Campsites by Country  ");
                Console.WriteLine("10. Exit");
                ///

                try
                {


                    key = Console.ReadLine();

                    option = int.Parse(key);

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Add Campsite");

                            Console.WriteLine("Enter Campsite name:");
                            string campsite_name = Console.ReadLine();

                            Console.WriteLine("Enter  Country:");
                            Console.WriteLine("   \t1)France\n" +
                                                 "\t2)Spain\n" +
                                                 "\t3)Italy\n" +
                                                 "\t4)Portugal\n" +
                                                 "\t5)Greece\n" +
                                                 "\t6)Croatia\n");
                            string campsite_country = Console.ReadLine();


                            switch (campsite_country)
                            {
                                case "1":
                                    campsite_country = "France";
                                    break;
                                case "2":
                                    campsite_country = "Spain";
                                    break;
                                case "3":
                                    campsite_country = "Italy";
                                    break;
                                case "4":
                                    campsite_country = "Portugal";
                                    break;
                                case "5":
                                    campsite_country = "Greece";
                                    break;
                                case "6":
                                    campsite_country = "Croatia";
                                    break;
                                default:
                                    campsite_country = "not value";
                                    break;
                            }

                            Console.WriteLine("Enter  Region:");
                            string campsite_region = Console.ReadLine();

                            Console.WriteLine("Enter  telephone:");
                            var campsite_phone = Console.ReadLine();

                            Console.WriteLine("Enter  email:");
                            var campsite_email = Console.ReadLine();

                            Console.WriteLine("Enter URL:");
                            var campsite_url = Console.ReadLine();

                            Campsite.Add(new Campsite(

                                      campsite_name,
                                     campsite_country,
                                      campsite_region,
                                      campsite_phone,
                                      campsite_email,
                                      campsite_url

                                      ));
                            Campsite[Campsite.Count - 1].Insert();


                            break;
                        case 2:
                            Console.WriteLine("Add Accommodation Type ");

                            var accom_type= "";
                            for (bool pr = false; pr == false;)
                            {
                                Console.WriteLine("Enter Accommodation Type:");

                               
                                Console.WriteLine("\t1)Mobile home\n\t2)Tent\n\t3)Chalet");
                                accom_type = Console.ReadLine();
                                switch (accom_type)
                                {
                                    case "1":
                                        accom_type = "Mobile home";
                                        pr = true;

                                        break;
                                    case "2":
                                        accom_type = "Tent";
                                        pr = true;
                                        break;
                                    case "3":
                                        accom_type = "Chalet";
                                        pr = true;
                                        break;
                                    default:

                                        break;


                                }
                            }
                            Console.WriteLine("Enter Daily Rate :");
                            int accom_type_daily_rate = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter No. of occupants :");
                            int accom_type_occupants = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter No. of bedrooms :");
                            int accom_type_Nbedrooms = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Square Meters  :");

                            int accom_type_square = Convert.ToInt32(Console.ReadLine());
                            if (accom_type == "Mobile home")
                            {

                                Console.WriteLine("Enter No. of bathrooms:");
                                int accom_type_Nbathrooms = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter Decking (y/n)");
                                string accom_type_decking = (Console.ReadLine() == "y") ? "yes" : "no";

                                Console.WriteLine("Enter Dishwasher(y / n)");
                                string accom_type_dishwasher = (Console.ReadLine() == "y") ? "yes" : "no";
                               

                                Mobile.Add(new AccommodationTypeMobileHause(

                                     accom_type,
                                     accom_type_daily_rate,
                                     accom_type_occupants,
                                     accom_type_Nbedrooms,
                                     accom_type_square,
                                     accom_type_Nbathrooms,
                                      accom_type_decking,
                                     accom_type_dishwasher

                                     ));
                                Mobile[Mobile.Count - 1].Insert();

                            }
                            else if (accom_type == "Tent")
                            {
                                Console.WriteLine("Enter Grill and gas hob (y/n)");
                                string accom_type_grill = (Console.ReadLine() == "y") ? "yes" : "no";
                                Console.WriteLine("Enter Covered terrace (y/n)");
                                string accom_type_terrace = (Console.ReadLine() == "y") ? "yes" : "no";
                               
                                Tent.Add(new AccommodationTypeTent(

                                     accom_type,
                                     accom_type_daily_rate,
                                    accom_type_occupants,
                                    accom_type_Nbedrooms,
                                    accom_type_square,
                                    accom_type_grill,
                                    accom_type_terrace
                                    ));
                                Tent[Tent.Count - 1].Insert();
                            }
                            else if (accom_type == "Chalet")
                            {
                                Console.WriteLine("Enter No. of stories:");
                                int accom_type_Nstories = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter No. of bathrooms:");
                                int accom_type_Nbathrooms = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter Adjacent to beach (y/n)");
                                string accom_type_beach = (Console.ReadLine() == "y") ? "yes" : "no";

                                Console.WriteLine("Enter Balcony (y/n)");
                                string accom_type_balcony = (Console.ReadLine() == "y") ? "yes" : "no";

                                Charles.Add(new AccommodationTypeCharles(

                                    accom_type,
                                    accom_type_daily_rate,
                                   accom_type_occupants,
                                   accom_type_Nbedrooms,
                                   accom_type_square,
                                  accom_type_Nstories,
                                   accom_type_Nbathrooms,
                                   accom_type_beach,
                                   accom_type_balcony
                                   ));

                                Charles[Charles.Count - 1].Insert();

                            }
                            break;
                        case 3:
                            Console.WriteLine("Add Accommodation Unit");



                            Console.WriteLine("Enter Campsite ID :");

                            Campsite[Campsite.Count - 1].OutCampsite();
                            int accom_unit_campasity_id = Convert.ToInt32(Console.ReadLine());


                            Console.WriteLine("Enter Accommodation Type ID :");
                          
                            Type.Add(new AccommodationType());
                            Type[Type.Count - 1].AccommodationTypeOut();

                            int accom_unit_accom_type = Convert.ToInt32(Console.ReadLine());


                            Console.WriteLine("Enter Pitch No. :");
                            int accom_unit_Npitch = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Status:");
                            Console.WriteLine("\t1)Ready for Summer Season\n" +
                                              "\t2)Under Construction\n" +
                                              "\t3)Under Routine Maintenance\n" +
                                              "\t4)Under Refurbishment\n" +
                                              "\t5)Retired");
                            var accom_unit_status = Console.ReadLine();
                            switch (accom_unit_status)
                            {
                                case "1":
                                    accom_unit_status = "Ready for Summer Season";
                                    break;
                                case "2":
                                    accom_unit_status = "Under Construction";
                                    break;
                                case "3":
                                    accom_unit_status = "Under Routine Maintenance";
                                    break;
                                case "4":
                                    accom_unit_status = "Under Refurbishment";
                                    break;
                                case "5":
                                    accom_unit_status = "Retired";
                                    break;
                                default:
                                    accom_unit_status = "Not value";
                                    break;
                            }
                            Console.WriteLine(accom_unit_status);
                            Unit.Add(new AccommodationUnit(

                                 accom_unit_campasity_id,
                                accom_unit_accom_type,
                                  accom_unit_Npitch,
                                  accom_unit_status

                                  ));
                            Unit[Unit.Count - 1].Insert();
                            break;
                        case 4:
                            Console.WriteLine("Delete Campsite ");

                            Campsite.Add(new Campsite());
                            Campsite[Campsite.Count - 1].OutCampsite();
                            Console.WriteLine("Enter Campsite id:");
                            Campsite.Add(new Campsite(Convert.ToInt32(Console.ReadLine())));

                            Campsite[Campsite.Count - 1].Delete();

                            break;
                        case 5:
                            Console.WriteLine("Delete Accommodation Type ");
                        Type.Add(new AccommodationType());
                        Type[Type.Count - 1].AccommodationTypeOut();

                        Console.WriteLine("Enter Unit id:");
                        Type.Add(new AccommodationType(Convert.ToInt32(Console.ReadLine())));
                        Type[Type.Count - 1].Delete();

                        break;
                        case 6:
                            Console.WriteLine("Delete Accommodation Unit ");

                            Unit.Add(new AccommodationUnit());
                            Unit[Unit.Count - 1].OutUnit();

                            Console.WriteLine("Enter Unit id:");
                            Unit.Add(new AccommodationUnit(Convert.ToInt32(Console.ReadLine())));
                            Unit[Unit.Count - 1].Delete();
                            break;
                        case 7:
                            Console.WriteLine("Update Accommodation Unit Status ");
                            Unit.Add(new AccommodationUnit());
                            Unit[Unit.Count - 1].OutUnit();
                            Console.WriteLine("Enter Unit id:");

                            int accom_unit_id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Status:");
                            Console.WriteLine("\t1)Ready for Summer Season\n" +
                                              "\t2)Under Construction\n" +
                                              "\t3)Under Routine Maintenance\n" +
                                              "\t4)Under Refurbishment\n" +
                                              "\t5)Retired");
                            accom_unit_status = Console.ReadLine();
                            switch (accom_unit_status)
                            {
                                case "1":
                                    accom_unit_status = "Ready for Summer Season";
                                    break;
                                case "2":
                                    accom_unit_status = "Under Construction";
                                    break;
                                case "3":
                                    accom_unit_status = "Under Routine Maintenance";
                                    break;
                                case "4":
                                    accom_unit_status = "Under Refurbishment";
                                    break;
                                case "5":
                                    accom_unit_status = "Retired";
                                    break;
                                default:
                                    accom_unit_status = "Not value";
                                    break;
                            }
                            Unit.Add(new AccommodationUnit(accom_unit_id, accom_unit_status));
                            Unit[Unit.Count - 1].Update();
                            break;

                        case 8:
                            Console.WriteLine("Search Accommodation Types by Daily Rate  ");
                            Console.WriteLine("Enter Daily Rate :");
                            accom_type_daily_rate = Convert.ToInt32(Console.ReadLine());


                            Type.Add(new AccommodationType());
                            Type[Type.Count - 1].Search(accom_type_daily_rate);

                            break;
                        case 9:
                            Console.WriteLine("Search Campsites by Country  ");
                            Console.WriteLine("Enter  Country:");
                            Console.WriteLine("   \t1)France\n" +
                                                 "\t2)Spain\n" +
                                                 "\t3)Italy\n" +
                                                 "\t4)Portugal\n" +
                                                 "\t5)Greece\n" +
                                                 "\t6)Croatia\n");
                            campsite_country = Console.ReadLine();


                            switch (campsite_country)
                            {
                                case "1":
                                    campsite_country = "France";
                                    break;
                                case "2":
                                    campsite_country = "Spain";
                                    break;
                                case "3":
                                    campsite_country = "Italy";
                                    break;
                                case "4":
                                    campsite_country = "Portugal";
                                    break;
                                case "5":
                                    campsite_country = "Greece";
                                    break;
                                case "6":
                                    campsite_country = "Croatia";
                                    break;
                                default:
                                    campsite_country = "not value";
                                    break;
                            }

                            Campsite.Add(new Campsite());
                            Campsite[Campsite.Count - 1].Search(campsite_country);
                            break;
                        case 10:
                            Console.WriteLine("Exit");
                            break;
                       


                        default:
                            Console.WriteLine("Invalid options enetered.");
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("\nIncorrect data entered\n");
                }

            } 



        }
    }
}
