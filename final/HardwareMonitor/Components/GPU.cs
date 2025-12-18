using System;
using System.Collections.Generic;

namespace HardwareMonitor.Components
{
    public class GPU : HardwareComponent
    {
        private double frequency;
        private double memoryFrequency;
        private int memorySize;
        private double memoryUsed;
        private int fanSpeed;

        public GPU(string name, string model, int memorySize) : base(name, model)
        {
            this.memorySize = memorySize;
        }

        public override void UpdateMetrics()
        {
            utilization = new Random().NextDouble() * 100;
            temperature = 50 + (utilization / 3);
            frequency = 1.5 + (utilization / 200);
            memoryFrequency = 7.0;
            memoryUsed = (utilization / 100.0) * memorySize;
            fanSpeed = (int)(30 + (temperature / 90.0) * 70);
        }

        public override Dictionary<string, string> GetAllMetrics()
        {
            return new Dictionary<string, string>
            {
                ["Model"] = modelNumber,
                ["GPU Frequency"] = $"{frequency:F2} GHz",
                ["Memory Frequency"] = $"{memoryFrequency:F2} GHz",
                ["Memory Size"] = $"{memorySize} GB",
                ["Memory Used"] = $"{memoryUsed:F1} GB",
                ["Temperature"] = $"{temperature:F1} °C",
                ["Utilization"] = $"{utilization:F1} %",
                ["Fan Speed"] = $"{fanSpeed} %"
            };
        }

        public override string GetComponentType() => "GPU";
    }
}