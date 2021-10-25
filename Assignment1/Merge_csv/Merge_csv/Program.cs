using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Windows;
using System.Reflection;

namespace CSVProgram
{
    class Program
    {

        static void Main(string[] args)
        {

            // Starting stopwatch for excution time
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("This is a program to merge csvs in one csv file. Please change the file address as described in README");





            DirWalker dir = new DirWalker();


            // Setting the paths for read of directory, output of CSV file, log file
            Globals.file_path = @"C:/Users/Jongwon Shinn/Desktop/5510 Software Develpment/Assignments/A00407059_MCDA5510/Assignment1/6";
            Globals.output_path = @"C:/Users/Jongwon Shinn/Desktop/5510 Software Develpment/Assignments/A00407059_MCDA5510/Assignment1/Output/Merged.csv";
            Globals.log_path = @"C:/Users/Jongwon Shinn/Desktop/5510 Software Develpment/Assignments/A00407059_MCDA5510/Assignment1/logs/Log1.txt";



            Console.WriteLine("Current address is " + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));




            // Creating one CSV file with the columns below
            string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();

            string[] colum = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "email Address", "date" };

            sbOutput.AppendLine(string.Join(strSeperator, colum));

            File.WriteAllText(Globals.output_path, sbOutput.ToString());




            //travers the directories and find csv files and write it in the merged csv file
            dir.walk(Globals.file_path);


            //Logging for excution time and count total valid rows and skipped rows
            watch.Stop();
          
           

            LogWriter log = new LogWriter(watch.ElapsedMilliseconds, Globals.total_valid_rows, Globals.total_skipped_rows);

           
        }








    }




}
