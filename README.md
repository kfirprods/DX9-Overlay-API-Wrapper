DX9-Overlay-API-Wrapper
=======================
A fork of JohnnyCrazy's .NET wrapper (https://github.com/JohnnyCrazy/DX9-Overlay-API-Wrapper/tree/master/DX9OverlayWrapper) with the purpose of creating a NuGET package (and possibly translating some of the German documentation to English)

Get it on NuGET: https://www.nuget.org/packages/DX9OverlayAPIWrapper/

=======================

A .NET Wrapper for the [DX9-Overlay-API](https://github.com/agrippa1994/DX9-Overlay-API)


##### Usage Example

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using DX9OverlayAPIWrapper;

namespace DX9OverlayWrapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DX9Overlay.SetParam("process", "GFXTest.exe");
            DX9Overlay.DestroyAllVisual(); // Remove any pre-existing visuals
            TextLabel text = new TextLabel("Arial", 20, TypeFace.None, new Point(5, 5), Color.Red, "Test123", true, true);
            Thread.Sleep(5000);
            text.Text = "Text2"; // Update text
            Thread.Sleep(5000);
            text.Color = Color.Cyan; // Update color
            Thread.Sleep(5000);
            text.Destroy(); // Remove the text
        }
    }
}

```

