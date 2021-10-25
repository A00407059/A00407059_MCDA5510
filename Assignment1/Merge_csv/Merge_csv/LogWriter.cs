using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CSVProgram
{
    public class LogWriter
    {

        private string m_exePath = string.Empty;
        public LogWriter(double excution_time, int valid_row, int skipped_row)
        {
            LogWrite(excution_time, valid_row, skipped_row);
        }
        public void LogWrite(double excution_time, int valid_row, int skipped_row)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(Globals.log_path))
                {
                    Log(excution_time, valid_row, skipped_row, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(double excution_time, int valid_row, int skipped_row, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"\r\nLog Entry : {DateTime.Now}");
                txtWriter.WriteLine($"The excution time is: {excution_time / 1000} sec");

                txtWriter.WriteLine($"The valid row is: {valid_row}");
                txtWriter.WriteLine($"The skipped row is: {skipped_row}");

                for (int i = 0; i < Globals.exception.Length; i++)
                {

                txtWriter.WriteLine(Globals.exception[i]);

                }

                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }


    }
}