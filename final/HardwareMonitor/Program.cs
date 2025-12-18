using System;
using System.Windows.Forms;
using HardwareMonitor.UI;

namespace HardwareMonitor
{

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new DashboardGUI());
    }
}
}