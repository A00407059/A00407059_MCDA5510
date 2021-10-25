using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Windows;
using System.Globalization;
using System.Threading;

namespace CSVProgram
{
    public class SimpleCSVParser
    {


        public void parse(String fileName)
        {




            try
            {



                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();



                    int key = 0;



                    while (!parser.EndOfData)
                    {



                        //Process row
                        string[] fields = parser.ReadFields();

                        foreach (string field in fields)
                        {
                            //Console.WriteLine(field);

                            string[] output = { fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9] };


                            key = 0;



                            // finding null value in any column
                            for (int i = 0; i < fields.Length; i++)
                            {
                                if (fields[i] == "")
                                {
                                    key = 1;
                                }

                                else if (i > 9)
                                {

                                    key = 1;

                                }


                            }


                        }




                        if (key == 1)
                        {

                            Globals.total_skipped_rows = Globals.total_skipped_rows + 1;
                            continue;

                        }

                        addRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9], Globals.date, Globals.output_path);



                        Globals.total_valid_rows = Globals.total_valid_rows + 1;
                    }


                }


            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
                Globals.exception[Globals.number_excpetion] = "IOException ioe was caught";
                Globals.number_excpetion = Globals.number_excpetion + 1;
            }

            catch (UnauthorizedAccessException)
            {

                Console.WriteLine("You do not have permission to create the file");
                Globals.exception[Globals.number_excpetion] = "UnauthorizedAccessException was caught";
                Globals.number_excpetion = Globals.number_excpetion + 1;
            }

            catch (System.ApplicationException)
            {

                Console.WriteLine("ApplicationException");
                Globals.exception[Globals.number_excpetion] = "ApplicationException was caught";
                Globals.number_excpetion = Globals.number_excpetion + 1;
            }

            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("Out of range");
                Globals.exception[Globals.number_excpetion] = "IndexOutOfRangeException was caught";
                Globals.number_excpetion = Globals.number_excpetion + 1;
            }


        }


        public static void addRecord(string first_name, string last_name, string street_number, string street, string city, string province, string country, string postal_code, string phone_number, string email, string date, string file_path)
        {

            DateTime today = DateTime.Now;
            date = today.ToString("yyyy") + "/" + today.ToString("MM") + "/" + today.ToString("dd");



            try
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@file_path, true))
                {
                    file.WriteLine(first_name + "," + last_name + "," + street_number + "," + street + "," + city + "," + province + "," + country + "," + postal_code + "," + phone_number + "," + email + "," + date);

                }


            }

            catch (Exception ex)
            {
                throw new ApplicationException("This program did a oopsie :", ex);
                Globals.exception[Globals.number_excpetion] = "Exception ex was caught";
                Globals.number_excpetion = Globals.number_excpetion + 1;
            }





        }
    }
}