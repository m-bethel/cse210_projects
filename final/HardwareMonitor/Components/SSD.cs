using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HardwareMonitor.Components
{
    public class SSD : HardwareComponent
    {
        private long totalCapacity;
        private long usedCapacity;
        private double readSpeed;
        private double writeSpeed;
        private int health;

        public SSD(string name, string model, long capacity) : base(name, model)
        {
            totalCapacity = capacity;
            health = 95;
        }

        public override void UpdateMetrics()
        {
            DriveInfo drive = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady);
            if (drive != null)
            {
                usedCapacity = drive.TotalSize - drive.AvailableFreeSpace;
                utilization = (double)usedCapacity / drive.TotalSize * 100;
            }
            temperature = 35 + new Random().NextDouble() * 10;
            readSpeed = 500 + new Random().NextDouble() * 200;
            writeSpeed = 450 + new Random().NextDouble() * 150;
        }

        public override Dictionary<string, string> GetAllMetrics()
        {
            return new Dictionary<string, string>
            {
                ["Model"] = modelNumber,
                ["Total Capacity"] = $"{totalCapacity} GB",
                ["Used Capacity"] = $"{usedCapacity / (1024*1024*1024)} GB",
                ["Free Capacity"] = $"{(totalCapacity - usedCapacity / (1024*1024*1024))} GB",
                ["Temperature"] = $"{temperature:F1} °C",
                ["Utilization"] = $"{utilization:F1} %",
                ["Read Speed"] = $"{readSpeed:F0} MB/s",
                ["Write Speed"] = $"{writeSpeed:F0} MB/s",
                ["Health"] = $"{health} %"
            };
        }

        public override string GetComponentType() => "SSD";
    }
}