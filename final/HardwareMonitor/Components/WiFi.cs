using System;
using System.Collections.Generic;

namespace HardwareMonitor.Components
{
    public class WiFi : HardwareComponent
    {
        private string ssid;
        private int signalStrength;
        private double downloadSpeed;
        private double uploadSpeed;
        private string macAddress;
        private bool isConnected;

        public WiFi(string name, string model) : base(name, model)
        {
            macAddress = "00:1A:2B:3C:4D:5E";
            isConnected = true;
        }

        public override void UpdateMetrics()
        {
            ssid = "MyNetwork";
            signalStrength = 75 + new Random().Next(-10, 10);
            downloadSpeed = 50 + new Random().NextDouble() * 50;
            uploadSpeed = 10 + new Random().NextDouble() * 20;
            utilization = (downloadSpeed + uploadSpeed) / 1.2;
            temperature = 45 + new Random().NextDouble() * 5;
        }

        public override Dictionary<string, string> GetAllMetrics()
        {
            return new Dictionary<string, string>
            {
                ["Model"] = modelNumber,
                ["SSID"] = ssid,
                ["MAC Address"] = macAddress,
                ["Signal Strength"] = $"{signalStrength} %",
                ["Connected"] = isConnected ? "Yes" : "No",
                ["Download Speed"] = $"{downloadSpeed:F1} Mbps",
                ["Upload Speed"] = $"{uploadSpeed:F1} Mbps",
                ["Temperature"] = $"{temperature:F1} °C"
            };
        }

        public override string GetComponentType() => "WiFi";
    }
}