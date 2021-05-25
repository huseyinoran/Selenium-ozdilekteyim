using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ozdilekteyim
{
    public class ExceptionLogging
    {
        //private static string GetLogsPath()
        //{
        //    string path = Path.Combine(Program.GetAppDataLocalPath(), "Logs");
        //    bool exists = Directory.Exists(path);

        //    if (!exists)
        //        Directory.CreateDirectory(path);
        //    return path;
        //}

        private static String ErrorlineNo, Errormsg, extype, ErrorLocation, BaseErrorLocation;

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine;

            ErrorlineNo = ex.StackTrace;
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            ErrorLocation = ex.Message.ToString();
            BaseErrorLocation = ex.GetBaseException().Message.ToString();

            try
            {
                string filepath = "Logs";  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = Path.Combine(filepath, DateTime.Today.ToString("yy-MM-dd") + ".txt");   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = $@"Log Written Date: {DateTime.Now.ToString()}
 
Error Line No : {ErrorlineNo}
 
Error Message: {Errormsg}
 
Exception Type: {extype}
 
Error Location : {ErrorLocation}
 
Base Error Location : {BaseErrorLocation}";
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }
    }
}
