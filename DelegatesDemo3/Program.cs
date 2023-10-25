using System.Diagnostics;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client Developer 1
            ProcessManager pMgr = new ProcessManager();
            //pMgr.ShowProcessList();

            // Client Developer 2
            //pMgr.ShowProcessList("S");

            // Client Dev 3
            pMgr.ShowProcessList(500 * 1024 * 1024); // > 100MB

        }
    }


    // Developer 1
    public class ProcessManager // OCP
    {
        public void ShowProcessList()
        {
            // code to display all running process in a system

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                // display process name
                Console.WriteLine(process.ProcessName);
            }
        }

        public void ShowProcessList(string sw)
        {
            // code to display all running process in a system

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                // display process name starts with "S"
                if (process.ProcessName.StartsWith(sw))
                    Console.WriteLine(process.ProcessName);
            }
        }

        public void ShowProcessList(long size)
        {
            // code to display all running process in a system

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                // display process name based on mem size
                if (process.WorkingSet64 >= size)
                    Console.WriteLine(process.ProcessName);
            }
        }
    }
}