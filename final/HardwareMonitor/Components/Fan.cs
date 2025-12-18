using System;
using System.Collections.Generic;

namespace HardwareMonitor.Components
{
    public class Fan : HardwareComponent
    {
        private int currentSpeed;
        private int maxSpeed;
        private string location;

        public Fan(string name, string model, string location) : base(name, model)
        {
            this.location = location;
            maxSpeed = 3000;
        }

        public override void UpdateMetrics()
        {
            currentSpeed = 1000 + new Random().Next(0, 2000);
            utilization = (double)currentSpeed / maxSpeed * 100;
            temperature = 30 + new Random().NextDouble() * 10;
        }

        public override Dictionary<string, string> GetAllMetrics()
        {
            return new Dictionary<string, string>
            {
                ["Model"] = modelNumber,
                ["Location"] = location,
                ["Current Speed"] = $"{currentSpeed} RPM",
                ["Max Speed"] = $"{maxSpeed} RPM",
                ["Speed Percentage"] = $"{utilization:F1} %",
                ["Temperature"] = $"{temperature:F1} °C"
            };
        }

        public override string GetComponentType() => "Fan";
    }
}