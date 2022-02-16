using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXOverlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DXOverlay";
            Console.WriteLine(" DXOverlay");
            Overlay overlay = new Overlay();
            overlay.Init("hl2");
        }
    }
}
