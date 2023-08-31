using System.Windows;
using System.Windows.Controls;

namespace DarkSkinWindow.UI.Units
{
    public class MaximizeButton : Button
    {
        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata (typeof (MaximizeButton), new FrameworkPropertyMetadata (typeof (MaximizeButton)));
        }
    }
}
