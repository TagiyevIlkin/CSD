using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSD.Utility
{
    public static class FileMethod
    {
        public static string GetUniqueFileNameMethod(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString()
                      + Path.GetExtension(fileName).ToLowerInvariant();
        }

        public static void CreatePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void DeleteFile(string path)
        {
            if (path!= null)
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
        }
    }
}
