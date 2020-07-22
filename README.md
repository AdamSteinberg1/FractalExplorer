# FractalExplorer

This is a visual representation of the Mandelbrot Set with the following features
* Camera-zooming
* Camera-moving
* Adjustable max iteration count
* Anti-aliasing
* Coloring using matplotlib colormaps
* Adjustable amount of fractional iterations  

![](gifs/demo1.gif)
  
This was built using C# Windows Forms with the following packages:
*  [HTAlt.WinForms](https://www.nuget.org/packages/HTAlt.WinForms/0.1.4.2?_src=template)
*  [OpenTK.GLControl](https://www.nuget.org/packages/OpenTK.GLControl/3.1.0?_src=template)
*  [SciColorMaps](https://www.nuget.org/packages/ar1st0crat.SciColorMaps/1.0.2?_src=template)

#### Build Instructions
1. Install Visual Studio with the .NET Desktop Development Workload
2. Clone the repo.
3. Open FractalExplorer.sln with Visual Studio
4. If a prompt appears about which .NET Framework to target, select version 4.7.2.
5. Click Start with the green play button next to it to compile and run.

