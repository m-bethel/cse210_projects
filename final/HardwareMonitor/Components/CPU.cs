using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HardwareMonitor.Components
{

public class CPU : HardwareComponent
{
    private int coreCount;
    private double frequency;
    private double baseFrequency;
    private double maxFrequency;
    private Dictionary<int, double> coreTemperatures;
    private Dictionary<int, double> coreUtilizations;
    private PerformanceCounter? cpuCounter;

    public CPU(string name, string model, int cores) : base(name, model)
    {
        coreCount = cores;
        coreTemperatures = new Dictionary<int, double>();
        coreUtilizations = new Dictionary<int, double>();
        baseFrequency = 2.4;
        maxFrequency = 4.5;
        
        try
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue(); // First call always returns 0, prime it
        }
        catch
        {
            cpuCounter = null; // Fall back to simulated data
        }
    }

    public override void UpdateMetrics()
    {
        try
        {
            utilization = cpuCounter?.NextValue() ?? new Random().NextDouble() * 100;
        }
        catch
        {
            utilization = new Random().NextDouble() * 100; // Simulated fallback
        }
        
        temperature = 45 + (utilization / 2);
        frequency = baseFrequency + (utilization / 100.0) * (maxFrequency - baseFrequency);
        
        for (int i = 0; i < coreCount; i++)
        {
            coreUtilizations[i] = utilization + (new Random().NextDouble() * 10 - 5);
            coreTemperatures[i] = temperature + (new Random().NextDouble() * 5);
        }
    }

    public override Dictionary<string, string> GetAllMetrics()
    {
        return new Dictionary<string, string>
        {
            ["Model"] = modelNumber,
            ["Cores"] = coreCount.ToString(),
            ["Frequency"] = $"{frequency:F2} GHz",
            ["Base Frequency"] = $"{baseFrequency:F2} GHz",
            ["Max Frequency"] = $"{maxFrequency:F2} GHz",
            ["Temperature"] = $"{temperature:F1} °C",
            ["Utilization"] = $"{utilization:F1} %"
        };
    }

    public override string GetComponentType() => "CPU";
}
}