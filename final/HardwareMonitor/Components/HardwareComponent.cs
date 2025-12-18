using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Management;

namespace HardwareMonitor.Components
{
// Abstract Base Class
public abstract class HardwareComponent
{
    protected string name;
    protected string modelNumber;
    protected double temperature;
    protected double utilization;

    public HardwareComponent(string name, string model)
    {
        this.name = name;
        this.modelNumber = model;
    }

    public string GetName() => name;
    public string GetModelNumber() => modelNumber;
    public double GetTemperature() => temperature;
    public double GetUtilization() => utilization;

    public abstract void UpdateMetrics();
    public abstract Dictionary<string, string> GetAllMetrics();
    public abstract string GetComponentType();
}
}