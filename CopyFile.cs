namespace ConvertToZendesk
{
    public class CopyFile
    {
        public bool Copy() {
            string sourceDir = @"C:\scripts\ConvertToZendesk\IN";
            string backupDir = @"C:\scripts\ConvertToZendesk\OUT";

            try
            {
                // string[] picList = Directory.GetFiles(sourceDir, "*.jpg");
                string[] txtList = Directory.GetFiles(sourceDir, "*.html");

                // // Copy picture files.
                // foreach (string f in picList)
                // {
                //     // Remove path from the file name.
                //     string fName = f.Substring(sourceDir.Length + 1);

                //     // Use the Path.Combine method to safely append the file name to the path.
                //     // Will overwrite if the destination file already exists.
                //     File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                // }

                // Copy text files.
                foreach (string f in txtList)
                {

                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));
                    }

                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }

                // // Delete source files that were copied.
                // foreach (string f in txtList)
                // {
                //     File.Delete(f);
                // }
                // foreach (string f in picList)
                // {
                //     File.Delete(f);
                // }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
            return true;            
        }
    }
}
