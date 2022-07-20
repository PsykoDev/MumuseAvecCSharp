using System.Runtime.InteropServices;


namespace MumuseAvecCSharp
{
    internal class NewDirectory
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CreateDirectory(String path, SECURITY_ATTRIBUTES lpSecurityAttributes);

        [StructLayout(LayoutKind.Sequential)]
        public class SECURITY_ATTRIBUTES
        {
            internal int nLength = 0;
            public IntPtr lpSecurityDescriptor;
        }

        public static bool CreateFolder(string path, string name)
        {
            var lpSecurityAttributes = new SECURITY_ATTRIBUTES();
            var security = new System.Security.AccessControl.DirectorySecurity();
            lpSecurityAttributes.nLength = Marshal.SizeOf(lpSecurityAttributes);
            byte[] src = security.GetSecurityDescriptorBinaryForm();
            IntPtr dest = Marshal.AllocHGlobal(src.Length);
            Marshal.Copy(src, 0, dest, src.Length);
            lpSecurityAttributes.lpSecurityDescriptor = dest;
            return CreateDirectory(Path.Combine(path, name), lpSecurityAttributes);
        }

    }
}
