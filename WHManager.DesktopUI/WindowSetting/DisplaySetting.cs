using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WHManager.DesktopUI.WindowSetting.Interfaces;

namespace WHManager.DesktopUI.WindowSetting
{
    public class DisplaySetting : IDisplaySetting
    {
        public DisplaySetting() { }
        public void CenterWindowOnScreen(Window window)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
