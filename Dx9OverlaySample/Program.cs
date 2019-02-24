using System;
using DX9OverlayAPIWrapper;

namespace Dx9OverlaySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dx9Overlay.SetParam("use_window", "1"); // Use the window name to find the process
            Dx9Overlay.SetParam("window", "GTA:SA:MP");

            Dx9Overlay.DestroyAllVisual();

            var label = new TextLabel("Arial", 12, 500, 300, System.Drawing.Color.Red, "Sample Text", shadow: false);

            try
            {
                while (true)
                {
                    Console.WriteLine("Type in new font size:");
                    var newFontSize = int.Parse(Console.ReadLine());

                    label.FontSize = newFontSize;
                }
            }
            finally
            {
                Dx9Overlay.DestroyAllVisual();

                Console.WriteLine("Ran into an error, so all visuals were destroyed. Hit enter to exit this program");
                Console.ReadLine();
            }
        }
    }
}
