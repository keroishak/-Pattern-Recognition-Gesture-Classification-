using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel
{
    class ProcessManager
    {
        /// <summary>
        /// corresponding struct that holds all application data needed
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct AppHandle
        {
            public IntPtr process;
            public IntPtr window;
            public ulong pid;
            public bool valid;
        }

        /// <summary>
        /// create process function signature
        /// </summary>
        /// <param name="path">path to application exe</param>
        /// <param name="handle">handle as an output</param>
        /// <returns>true if created successfully, false otherwise</returns>
        [DllImport("WinAPIWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MSCreateProcess(StringBuilder path, out AppHandle handle);

        /// <summary>
        /// minimize function signature
        /// </summary>
        /// <param name="handle">handle of application to be minimized</param>
        /// <returns>true if successeded, false otherwise</returns>
        [DllImport("WinAPIWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MSMinimize(ref AppHandle handle);

        /// <summary>
        /// gets HWND handle to process
        /// </summary>
        /// <param name="handle">application handle</param>
        /// <returns>true if successeded, false otherwise</returns>
        [DllImport("WinAPIWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MSGetWindowHandle(ref AppHandle handle);

        /// <summary>
        /// restores application window
        /// </summary>
        /// <param name="handle">application handle</param>
        /// <returns>true if successeded, false otherwise</returns>
        [DllImport("WinAPIWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MSRestore(ref AppHandle handle);

        /// <summary>
        /// terminates a process
        /// </summary>
        /// <param name="handle">application handle</param>
        /// <returns>true if successeded, false otherwise</returns>
        [DllImport("WinAPIWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MSTerminate(ref AppHandle handle);


        public static AppHandle CreateProcess(string path)
        {
            AppHandle handle;
            StringBuilder str = new StringBuilder(path.Length);
            str.Append(path.ToCharArray());
            bool res = MSCreateProcess(str, out handle);
            res = MSGetWindowHandle(ref handle);

            return handle;
        }

        public static bool Minimize(AppHandle handle)
        {
            return MSMinimize(ref handle);
        }

        public static bool Restore(AppHandle handle)
        {
            return MSRestore(ref handle);
        }

        public static bool Terminate(AppHandle handle)
        {
            return MSTerminate(ref handle);
        }
    }
}
