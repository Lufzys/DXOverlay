using Overlay.NET;
using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXOverlay
{
    class Overlay
    {
        private OverlayPlugin overlayPlugin;
        private ProcessSharp _processSharp;

        public void Init(string processName)
        {
            var process = System.Diagnostics.Process.GetProcessesByName(processName).FirstOrDefault();

            overlayPlugin = new OverlayRenderer();
            _processSharp = new ProcessSharp(process, MemoryType.Remote);

            var FPS = 1000;
            var fpsValid = int.TryParse(Convert.ToString(FPS, CultureInfo.InvariantCulture), NumberStyles.Any,
                NumberFormatInfo.InvariantInfo, out int fps);

            var d3DOverlay = (OverlayRenderer)overlayPlugin;
            d3DOverlay.Settings.Current.UpdateRate = 1000 / fps;
            overlayPlugin.Initialize(_processSharp.WindowFactory.MainWindow);
            overlayPlugin.Enable();

            while (true)
            {
                Render(d3DOverlay);
                overlayPlugin.Update();
                Thread.Sleep(1);
            }
        }

        public void Render(OverlayRenderer render)
        {
            Size WindowSize = new Size(render.OverlayWindow.Width, render.OverlayWindow.Height);
            Point MousePos = new Point(Cursor.Position.X - render.OverlayWindow.X, Cursor.Position.Y - render.OverlayWindow.Y);

            render.Line(WindowSize.Width / 2 - 10, WindowSize.Height / 2, WindowSize.Width / 2 + 10, WindowSize.Height / 2, Color.Green);
            render.Line(WindowSize.Width / 2, WindowSize.Height / 2 - 10, WindowSize.Width / 2, WindowSize.Height / 2 + 10, Color.Green);

            // Drawing stuff
            /* Line
             *  Rectangle
             *  Circle
             *  Text
             */
        }
    }
}
