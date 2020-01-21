using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pimp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class PimpMyRevit : IExternalApplication
    {
        
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                ImageSource imgbg = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "maoria.jpg"), UriKind.Relative));

                ImageBrush picBrush = new ImageBrush();
                picBrush.ImageSource = imgbg;
                picBrush.AlignmentX = AlignmentX.Left;
                picBrush.AlignmentY = AlignmentY.Top;
                picBrush.Stretch = Stretch.None;
                picBrush.TileMode = TileMode.FlipXY;

                LinearGradientBrush gradientBrush = new LinearGradientBrush();

                gradientBrush.StartPoint = new System.Windows.Point(0, 0);

                gradientBrush.EndPoint = new System.Windows.Point(0, 1);

                gradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));

                gradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

                foreach (RibbonTab tab in ribbon.Tabs)
                {
                    
                    foreach (Autodesk.Windows.RibbonPanel panel in tab.Panels)
                    {
                        panel.CustomPanelTitleBarBackground = gradientBrush;
                        
                        //panel.CustomPanelBackground = gradientBrush;
                        panel.CustomPanelBackground = picBrush;
                    }
                }
            }
            catch (Exception)
            {

            }
            return Result.Succeeded;
        }


        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
