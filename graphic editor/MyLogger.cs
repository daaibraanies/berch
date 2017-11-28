using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace graphic_editor
{
   public static class MyLogger
    {
        #region DATA       
        private const string  filePath = @"C:\Users\daaibraanies\Desktop\pixbox editor\berch\graphic editor\LOGS.txt";
        public enum Importance
        {
            Info,
            Warrning,
            Fatal,
            SYSTEM
        };
        private static string _datestamp;
        #endregion

        public static void LogIt(string message, Importance imp = Importance.Info)
        {
            _datestamp = DateTime.Now.ToString();
            using (StreamWriter logWriter = new StreamWriter(filePath,true,Encoding.UTF8))
            {
                logWriter.WriteLine
                    (
                            "[" + imp + "]" +
                            " " + message + " " +
                            "[" + _datestamp + "]"
                    );
                logWriter.Close();
            }
        }
    
    }

}
