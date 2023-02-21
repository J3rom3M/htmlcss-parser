using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConvertToZendesk
{
    public class ReadWrite
    {
        public bool Write(string szPath, string szFile)
        {
            DirectoryInfo[] cDirs = new DirectoryInfo(szPath).GetDirectories();
            using (StreamWriter sw = new StreamWriter(szFile))
            {
                foreach (DirectoryInfo dir in cDirs)
                {
                    sw.WriteLine(dir.Name);
                }
                sw.Close();
            }

            return true;
        }

        public List<string> ReadFiles(string szPath, string szFile)
        {
            string line = "";
            string szStream = szPath + "\\" + szFile;
            var html = new List<string>();

            using (StreamReader sr = new StreamReader(szStream))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string szLine = line.Trim();
                    Console.WriteLine(line);

                    if (szLine.StartsWith("<p") | szLine.StartsWith("<a") | szLine.StartsWith("<h2") | szLine.StartsWith("<h3") |szLine.StartsWith("<h4") | szLine.StartsWith("<h5") | szLine.StartsWith("<h6") | szLine.StartsWith("<li>")) {
                        // string result = szLine.TrimStart('<a>');
                        string result = Regex.Replace(szLine, "<[a-zA-Z/].*?>", String.Empty);
                        if(szLine.StartsWith("<p")) {
                            if(szLine.Contains("Blocremarque")) {
                            html.Add(szLine.Replace("<p class='Blocremarque'>", "<p class='Blocremarque' style='background-color: #87cefa;'>"));
                            }
                            html.Add(szLine.Replace("<p>", "<p style='margin-top:0pt;margin-bottom:0pt;font-size:8pt;font-family:Verdana, sans-serif;font-style:normal;margin-left:0px;color:#000000;font-weight:normal;'>"));
                        }
                        if(szLine.StartsWith("<a")) {
                            html.Add(szLine.Replace("<a>", "<a style='font-size:8pt;font-family:Verdana, sans-serif;'>"));
                        }
                    }                                                       
                }
                foreach (string ln in html)  
                {  
                    Console.WriteLine("Voici le contenu du tableau : " + ln);  
                } 
            }

            return html;
        } 
        
        public bool ReadTemplate(string szPath, string szFile)
        {
            string line = "";
            string szStream = szPath + "\\" + szFile;
            var html = new List<string>();

            using (StreamReader sr = new StreamReader(szStream))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string szLine = line.Trim();
                    Console.WriteLine(line);
                    if (szLine.StartsWith("<content>")){
                        try 
                        {
                            string ln = "<tr><td>Column 1</td><td>Column 2</td></tr>";
                            StringBuilder sb = new StringBuilder();
                            int nb = ln.Length;
                            // sb.Insert(nb+1, ln);
                            sb.Append("<tr><td>Column 1</td><td>Column 2</td></tr>");
                            // ReadWrite rw = new ConvertToZendesk.ReadWrite();
                            // string test = new ReadWrite().AddHtml();
                            html.Add(sb.ToString());                                                        
                        }
                        catch (ArgumentOutOfRangeException e) 
                        {
                            Console.WriteLine(e.Message);
                        }                        
                    }   
		        }
	        }
            return true;
	    }

        public string AddHtml () {
            string ln = "A line of text.";
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><td>Column 1</td><td>Column 2</td></tr>");
            // sb.Insert(szLine, ln);
            sb.AppendLine(ln);

            return sb.ToString();            
        }              
    }
}
