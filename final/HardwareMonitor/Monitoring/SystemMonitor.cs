using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HardwareMonitor.Components;

namespace HardwareMonitor.Monitoring
{
    public class SystemMonitor
    {
        private List<HardwareComponent> components = new List<HardwareComponent>();
        private System.Windows.Forms.Timer updateTimer;
        private int updateInterval = 1000;

        public SystemMonitor()  // No return type!
        {
            updateTimer = new System.Windows.Forms.Timer { Interval = updateInterval };
            updateTimer.Tick += (s, e) => UpdateAllComponents();
        }

        public void AddComponent(HardwareComponent component) => components.Add(component);
        public List<HardwareComponent> GetAllComponents() => components;
        public void UpdateAllComponents() => components.ForEach(c => c.UpdateMetrics());
        public void StartMonitoring() => updateTimer.Start();
        public void StopMonitoring() => updateTimer.Stop();
    }
}