using System.Windows.Forms;
using System.Drawing;

namespace HardwareMonitor.UI
{
public class MetricDisplay : Panel
{
    private Label nameLabel;
    private Label valueLabel;

    public MetricDisplay(string name)
    {
        Height = 30;
        Padding = new Padding(5);
        
        nameLabel = new Label { Text = name, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
        valueLabel = new Label { Text = "Loading...", AutoSize = true, Left = 200, Font = new Font("Arial", 10) };
        
        Controls.Add(nameLabel);
        Controls.Add(valueLabel);
    }

    public void UpdateValue(string value) => valueLabel.Text = value;
}
}