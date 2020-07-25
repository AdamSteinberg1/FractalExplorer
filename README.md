# FractalExplorer

This is a visual representation of the Mandelbrot set with the following features
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

### Build Instructions
1. Install Visual Studio with the .NET Desktop Development Workload.
2. Clone the repo.
3. Open FractalExplorer.sln with Visual Studio.
4. If a prompt appears about which .NET Framework to target, select version 4.7.2.
5. Click Start with the green play button next to it to compile and run.

### Controls
* Use the mouse scroll wheel to zoom in on the cursor's current location.
* Click and drag to move the camera around.
* Click on the button on the right side of the window to expand the options panel.

### How It Works
#### The Math
The Mandelbrot set is a set of complex numbers that satisfy a special condition. In the image below the complex numbers in the complex plane are colored black if they are in the Mandelbrot Set, otherwise they are white. 

![Basic Mandelbrot Set](https://upload.wikimedia.org/wikipedia/commons/5/56/Mandelset_hires.png)

To determine if a complex number is within the Mandelbrot set, you have to repeatedly perform a function on that number, and analyze the result after an infinite amount of iterations. The iterative function is 
> z<sub>n+1</sub> = z<sub>n</sub><sup>2</sup> + c,  
> z<sub>0</sub> = 0 + 0i  
where z<sub>n</sub> is the result after n interations and c is the complex number we are looking at.

If the limit of z<sub>n</sub> approaches infinity as n approaches infinity (diverges), then c is not in the Mandelbrot set. Otherwise if it converges, c is in the Mandelbrot set.   There is a lot more nuance to it than this, but this is the basic idea. For more information see https://en.wikipedia.org/wiki/Mandelbrot_set.  

#### Making a Computer do the Math
One problem with the definition of the Mandelbrot set is that it requires iterating each point an infinite amount of times. This could take maybe a little bit longer than I have time for, so instead I have just iterated each point a lot of times. This is what the slider `Max Iterations` controls in the options panel. I have found that a value of about 200 is a good balance of detail and performance.  
Another problem is determining how we should define when z<sub>n</sub> is deemed "approaching infinity" and therefore the corresponding value for c is not in the Mandelbrot set.   ...
  README is still a work in progress
