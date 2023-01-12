namespace fieroolle.Helpers
{
    public class FileManager
    {
        public static string SaveFile(string RootPath, string Folderpath, IFormFile file)
        {
            string name = file.FileName;
            name = name.Length > 64 ? name.Substring(name.Length - 64, 64) : name;
            name = Guid.NewGuid().ToString() + name;
            string path = Path.Combine(RootPath, Folderpath, name);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return name;
        }
        public static void DeleteFile(string RootPath, string Foldername, string filename)
        {
            string deletepath = Path.Combine(RootPath, Foldername, filename);
            if (System.IO.File.Exists(deletepath))
            {
                System.IO.File.Delete(deletepath);
            }
        }
    }
}
