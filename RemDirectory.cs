using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MumuseAvecCSharp
{
    internal class RemDirectory
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool RemoveDirectory(string lpPathName);


        public static void Delete(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be an empty string.");
            }

            char[] dirSeps = { '\\', '/' };

            string normalizedPath = path;

            int minDirSepPos = 4;
            if (normalizedPath.Contains("UNC"))
            {
                minDirSepPos = 6;
            }

            int minLength = -1;
            try
            {
                for (int i = 0; i < minDirSepPos; i++)
                {
                    minLength = normalizedPath.IndexOfAny(dirSeps, ++minLength);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentException("Invalid path specified: " + path);
            }

            while (true)
            {
                if (!RemoveDirectory(path))
                {
                   // throw LongPathCommon.GetExceptionFromLastWin32Error();
                }

                normalizedPath = normalizedPath.Remove(normalizedPath.LastIndexOfAny(dirSeps));

                if (normalizedPath.Length <= minLength)
                {
                    break;
                }
            }
        }
    }
}
