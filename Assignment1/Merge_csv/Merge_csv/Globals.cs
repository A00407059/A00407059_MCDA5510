using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProgram
{
    public class Globals
    {




        public static int total_valid_rows;
        public static int total_skipped_rows;

        public static string date = DateTime.Now.ToString("yyyy/MM/dd");


        public static string output_path;
        public static string file_path;
        public static string log_path;

        public static string[] exception;
        public static int number_excpetion = 0;

    }
}
