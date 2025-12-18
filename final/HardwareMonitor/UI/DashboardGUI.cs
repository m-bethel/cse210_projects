using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using HardwareMonitor.Components;
using System.Management;
using HardwareMonitor.Monitoring;

namespace HardwareMonitor.UI
{
    public class DashboardGUI : Form
    {
        private SystemMonitor monitor; 
        private TabControl mainTabControl = null!;
        private Dictionary<string, Panel> componentPanels = new Dictionary<string, Panel>();

        public DashboardGUI()
        {
            Text = "Hardware Monitoring Dashboard";
            Size = new Size(800, 600);
            
            monitor = new SystemMonitor(); 
            InitializeComponents();
            
            System.Windows.Forms.Timer refreshTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            refreshTimer.Tick += (s, e) => UpdateDisplay();
            refreshTimer.Start();
            
            monitor.StartMonitoring();
        }

        private void InitializeComponents()
        {
            // Get actual CPU info
            string cpuName = GetCPUName();
            int coreCount = Environment.ProcessorCount;
            monitor.AddComponent(new CPU(cpuName, cpuName, coreCount));

            // Get actual GPU info
            (string name, int memory) gpuInfo = GetGPUInfo();
            monitor.AddComponent(new GPU(gpuInfo.name, gpuInfo.name, gpuInfo.memory));

            // Get actual SSD info
            (string name, string model, long capacity) ssdInfo = GetSSDInfo();
            monitor.AddComponent(new SSD(ssdInfo.name, ssdInfo.model, ssdInfo.capacity));

            // Get actual RAM info
            (long totalGB, int speed, string type) ramInfo = GetRAMInfo();
            monitor.AddComponent(new RAM("System RAM", ramInfo.type, ramInfo.totalGB, ramInfo.type, ramInfo.speed));

            // Get actual WiFi info
            (string name, string model) wifiInfo = GetWiFiInfo();
            monitor.AddComponent(new WiFi(wifiInfo.name, wifiInfo.model));

            monitor.AddComponent(new Fan("CPU Fan", "Stock Cooler", "CPU"));

            mainTabControl = new TabControl { Dock = DockStyle.Fill };

            foreach (HardwareComponent component in monitor.GetAllComponents())
            {
                CreateTabForComponent(component);
            }

            Controls.Add(mainTabControl);
        }

        private string GetCPUName()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["Name"]?.ToString() ?? "Unknown CPU";
                    }
                }
            }
            catch
            {
                return "Unknown CPU";
            }
            return "Unknown CPU";
        }
        
        private (string name, int memory) GetGPUInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name, AdapterRAM FROM Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "Unknown GPU";
                        long ram = Convert.ToInt64(obj["AdapterRAM"]);
                        int ramGB = (int)(ram / (1024 * 1024 * 1024));
                        return (name, ramGB);
                    }
                }
            }
            catch 
            { 
            }
            return ("Unknown GPU", 4);
        }
        
        private (long totalGB, int speed, string type) GetRAMInfo()
        {
            long totalBytes = 0;
            int speed = 0;
            string memoryType = "Unknown";

            try
            {
                // Get total physical memory
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        totalBytes = Convert.ToInt64(obj["TotalPhysicalMemory"]);
                    }
                }

                // Get RAM speed and type
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Speed, MemoryType, SMBIOSMemoryType FROM Win32_PhysicalMemory"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        if (obj["Speed"] != null)
                        {
                            speed = Convert.ToInt32(obj["Speed"]);
                        }

                        if (obj["SMBIOSMemoryType"] != null)
                        {
                            int typeCode = Convert.ToInt32(obj["SMBIOSMemoryType"]);
                            memoryType = typeCode switch
                            {
                                20 => "DDR",
                                21 => "DDR2",
                                24 => "DDR3",
                                26 => "DDR4",
                                34 => "DDR5",
                                _ => $"Type {typeCode}"
                            };
                        }

                        break;
                    }
                }
            }
            catch 
            { 
            }

            long totalGB = totalBytes / (1024 * 1024 * 1024);
            return (totalGB > 0 ? totalGB : 16, speed > 0 ? speed : 2400, memoryType != "Unknown" ? memoryType : "DDR4");
        }

        
        private (string name, string model, long capacity) GetSSDInfo()
        {
            try
            {
                // Get physical disk info
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model, Size FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media'"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string model = obj["Model"]?.ToString() ?? "Unknown SSD";
                        long sizeBytes = Convert.ToInt64(obj["Size"]);
                        long sizeGB = sizeBytes / (1024 * 1024 * 1024);
                        
                        // Clean up the model name
                        string cleanModel = model.Trim();
                        return (cleanModel, cleanModel, sizeGB);
                    }
                }
            }
            catch 
            { 
            }
            return ("Unknown SSD", "Generic SSD", 512);
        }
        
        private (string name, string model) GetWiFiInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name, Description FROM Win32_NetworkAdapter WHERE NetConnectionStatus=2 AND PhysicalAdapter=True"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "";
                        string description = obj["Description"]?.ToString() ?? "";
                        
                        // Prefer WiFi/Wireless adapters
                        if (name.Contains("Wi-Fi", StringComparison.OrdinalIgnoreCase) || 
                            name.Contains("Wireless", StringComparison.OrdinalIgnoreCase) ||
                            description.Contains("802.11", StringComparison.OrdinalIgnoreCase))
                        {
                            return (name, description);
                        }
                    }
                    
                    // If no WiFi found, return first network adapter
                    searcher.Query.QueryString = "SELECT Name, Description FROM Win32_NetworkAdapter WHERE NetConnectionStatus=2 AND PhysicalAdapter=True";
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "";
                        string description = obj["Description"]?.ToString() ?? "";
                        return (name, description);
                    }
                }
            }
            catch 
            { 
            }
            return ("Unknown WiFi", "Generic WiFi Adapter");
        }
        
        private void CreateTabForComponent(HardwareComponent component)
        {
            TabPage tab = new TabPage(component.GetComponentType());
            Panel panel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            componentPanels[component.GetName()] = panel;
            tab.Controls.Add(panel);
            mainTabControl.TabPages.Add(tab);
        }

        private void UpdateDisplay()
        {
            foreach (HardwareComponent component in monitor.GetAllComponents())
            {
                Panel panel = componentPanels[component.GetName()];
                panel.Controls.Clear();
                
                Dictionary<string, string> metrics = component.GetAllMetrics();
                int y = 10;
                
                foreach (KeyValuePair<string, string> metric in metrics)
                {
                    MetricDisplay display = new MetricDisplay(metric.Key) { Top = y, Width = panel.Width - 20 };
                    display.UpdateValue(metric.Value);
                    panel.Controls.Add(display);
                    y += 35;
                }
            }
        }
    }
}