using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel
{

    class AppModel
    {
        /// <summary>
        /// handle to application that's opend
        /// </summary>
        private ProcessManager.AppHandle m_handle;

        public string Application { get; private set; }
        public bool IsOpen { get; private set; }

        public AppModel(string appPath)
        {
            Application = appPath;
            IsOpen = false;
        }

        public void Open()
        {
            m_handle = ProcessManager.CreateProcess(Application);
            IsOpen = true;
        }

        public void Close()
        {
            if (IsOpen)
            {
                IsOpen = !ProcessManager.Terminate(m_handle);
            }
        }

        public void Minimize()
        {
            if (IsOpen)
                ProcessManager.Minimize(m_handle);
        }

        public void Restore()
        {
            if (IsOpen)
                ProcessManager.Restore(m_handle);
        }
    }
}
