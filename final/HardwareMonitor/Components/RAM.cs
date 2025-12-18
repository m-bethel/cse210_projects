using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HardwareMonitor.Components
{
    public class RAM : HardwareComponent
    {
        private long totalMemory;
        private long usedMemory;
        private double frequency;
        private string memoryType;
        private PerformanceCounter ramCounter;

        public RAM(string name, string model, long totalMemory, string type, int speed) : base(name, model)
        {
            this.totalMemory = totalMemory;
            this.memoryType = type;
            this.frequency = speed;
            
            try
           {
                ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                ramCounter.NextValue();
            }
            catch
            {
                ramCounter = null;
            }
        }

        public override void UpdateMetrics()
        {
            try
            {
                utilization = ramCounter?.NextValue() ?? new Random().NextDouble() * 100;
            }
            catch
            {
                utilization = new Random().NextDouble() * 100; // Simulated fallback
            }
            
            usedMemory = (long)(totalMemory * (utilization / 100.0));
            temperature = 40 + new Random().NextDouble() * 5;
        }

        public override Dictionary<string, string> GetAllMetrics()
        {
            return new Dictionary<string, string>
            {
                ["Model"] = modelNumber,
                ["Type"] = memoryType,
                ["Frequency"] = $"{frequency} MHz",
                ["Total Memory"] = $"{totalMemory} GB",
                ["Used Memory"] = $"{usedMemory:F1} GB",
                ["Available Memory"] = $"{totalMemory - usedMemory:F1} GB",
                ["Temperature"] = $"{temperature:F1} °C",
                ["Utilization"] = $"{utilization:F1} %"
            };
        }

        public override string GetComponentType() => "RAM";
    }
}