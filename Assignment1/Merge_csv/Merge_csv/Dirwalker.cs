using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSVProgram
{
    public class DirWalker
    {


        SimpleCSVParser parser = new SimpleCSVParser();
        public void walk(String path)
        {



            string[] list = Directory.GetDirectories(path);

            if (list == null)
            {
                return;
            }

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);




            foreach (string filepath in fileList)
            {




                Console.WriteLine("File:" + filepath);
                parser.parse(filepath);



            }





            return;

        }

    }
}
