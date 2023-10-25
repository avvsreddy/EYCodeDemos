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
            //FilterDelegate filter = new FilterDelegate(FilterByName);
            //pMgr.ShowProcessList(filter);

            // Client Dev 3
            //pMgr.ShowProcessList(500 * 1024 * 1024); // > 100MB
            //pMgr.ShowProcessList(FilterByMemSize);

            // client dev 4
            pMgr.ShowProcessList(FilterByThreads);

        }

        // client 2
        public static bool FilterByName(Process p)
        {
            if (p.ProcessName.StartsWith("S"))
                return true;
            else
                return false;
        }

        // client 3
        public static bool FilterByMemSize(Process p)
        {
            return p.WorkingSet64 >= 500 * 1024 * 1024;
        }

        // client 4
        public static bool FilterByThreads(Process p)
        {
            return p.Threads.Count >= 50;
        }
    }

    public delegate bool FilterDelegate(Process p);


    // Developer 1
    public class ProcessManager // OCP
    {

        public void ShowProcessList(FilterDelegate filter)
        {
            // code to display all running process in a system

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                // display process name starts with "S"
                if (filter(process))
                    Console.WriteLine(process.ProcessName);
            }
        }


    }
}