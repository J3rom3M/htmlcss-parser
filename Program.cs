using System;
using System.IO;
using ConvertToZendesk;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace ConvertToZendesk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadWrite wr = new ConvertToZendesk.ReadWrite();
            Html web = new ConvertToZendesk.Html();
 
            string szPath1 = "";            
            string szFile1 = "";
            string szPath2 = "";
            string szFile2 = "template.html";            
            var html = new List<string>();

            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  

                szPath1 = appSettings["path1"] ?? "Not Found"; 
                szFile1 = appSettings["path1"] ?? "Not Found";                 
                szPath2 = appSettings["path2"] ?? "Not Found"; 
                Console.WriteLine(szPath2);   
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error reading app settings");  
            }  

            string sztemplate = szPath2 + "\\" + szFile2;
            if(File.Exists(sztemplate))
            {
                File.Delete(sztemplate);
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

            CopyFile cp = new CopyFile();
            cp.Copy();

            // wr.Write(szPath, szFile);
           // wr.ReadFiles(szPath, szFile);
            // List<string> lst = wr.ReadFiles(szPath, szFile); 
            // Console.Write(lst);
            // wr.ReadTemplate(szPath2, szFile2);          

            web.ReadHtml();
            // var key = ConfigurationManager.AppSettings["key"];
            // var appSettings = ConfigurationManager.AppSettings;
        }

        static void ReadSetting(string key)  
        {  
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  
                string result = appSettings[key] ?? "Not Found";  
                Console.WriteLine(result);  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error reading app settings");  
            }  
        }         
    }
}