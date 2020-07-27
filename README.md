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
#### If you just want to run it:
1. Download the repo and unzip it.
2. Navigate to the publish folder.
3. Run setup.exe.
4. If you have anti-virus software, it will block it because I am an unverified publisher. Disable your anti-virus and then run it.
5. Click through the installer.
6. Search for FractalExplorer in the Start Menu and run it!

#### If you want to compile it yourself:
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
The Mandelbrot set is a set of complex numbers that satisfy a special condition. In the image below the complex numbers in the complex plane are colored black if they are in the Mandelbrot Set, otherwise, they are white. 

![Basic Mandelbrot Set](https://upload.wikimedia.org/wikipedia/commons/5/56/Mandelset_hires.png)

To determine if a complex number is within the Mandelbrot set, you have to repeatedly perform a function on that number, and analyze the result after an infinite amount of iterations. The iterative function is 
> z<sub>n+1</sub> = z<sub>n</sub><sup>2</sup> + c,  
> z<sub>0</sub> = 0 + 0i  
where z<sub>n</sub> is the result after n interations and c is the complex number we are looking at.

If the limit of z<sub>n</sub> approaches infinity as n approaches infinity (diverges), then c is not in the Mandelbrot set. Otherwise, if it converges, c is in the Mandelbrot set.   There is a lot more nuance to it than this, but this is the basic idea. For more information see https://en.wikipedia.org/wiki/Mandelbrot_set.  

#### Making a Computer do the Math
One problem with the definition of the Mandelbrot set is that it requires iterating each point an infinite amount of times. This could take maybe a little bit longer than I have time for, so instead, I have just iterated each point a lot of times. This is what the slider `Max Iterations` controls in the options panel. I have found that a value of about 200 is a good balance of detail and performance.  
  
Another problem is determining how we should define when z<sub>n</sub> is "approaching infinity" and therefore the corresponding value for c is not in the Mandelbrot set. The way I did this is to define an escape radius, and if the magnitude of the complex number is bigger than the escape radius then we can safely assume it will diverge. I arbitrarily chose a value of 2000 for my escape radius. Technically, any value greater than two would work, but bigger values make the coloring look better.

#### Coloring Algorithm
The black and white image shown above shows which points are in the Mandelbrot set and which are not. However, Fractal Explorer uses a much more sophisticated coloring algorithm which generates a smooth gradient, representing how many iterations it took for a complex number to diverge. The actual algorithm is more complex than I want to go into here, but I used Logarithmic Mapping and Fractional Iteration Counts as detailed [here.](http://www.hpdz.net/TechInfo/Colorizing.htm) Essentially, the algorithm produces a float between 0 and 1 which I then feed into a colormap that produces the desired color. I used the SciColorMaps which are a C# implementation of the matplotlib colormaps.

#### Parallelization and OpenGL
In my first attempt at coding this project, I iterated through every pixel on the screen using a nested for loop running on the CPU. This means that every pixel is processed sequentially, which is pretty horrible for performance. Fortunately, the way each pixel is processed does not depend on any of the other pixels, which means the algorithm can be parallelized and run on the GPU instead of the CPU, drastically increasing performance. To do this I used OpenTK which is a C# wrapper for OpenGL. OpenGL is a powerful tool that can make incredibly detailed 3D scenes. However, for my purposes, I just used one quad that took up the entire window and all the processing took place in the fragment shader.

#### Zooming and Panning
I implemented zooming and panning using the magic of homogenous coordinates and matrix multiplication. I created one 3×3 transformation matrix which is updated anytime the user changes the camera. If the user pans the camera, the transformation matrix is multiplied by a translation matrix that is made based on how much the mouse moved. If the user zooms in, then the transformation matrix is multiplied by a zoom matrix based on the mouse's position and how much the scroll wheel rotated. This transformation matrix is then multiplied by each pixel's coordinates to get that specific complex number in the complex plane. For more information on homogenous coordinates and how the matrices were made see [here.](http://www.sm.luth.se/csee/courses/smd/158.2003/slides/Basic2DGraphics.pdf)

#### Anti-Aliasing
Before I had implemented anti-aliasing, I noticed that the fractal looked somewhat pixelated and jagged. You can see this by turning the anti-aliasing down to one, which essentially disables anti-aliasing. It looks bad because we are representing an infinitely detailed fractal on a discrete number of pixels. Therefore, each pixel is only a one-point sample of infinitely-many points. Anti-aliasing just means taking more samples per pixel and averaging the results. For more information check out [this thread](http://www.fractalforums.com/programming/antialiasing-fractals-how-best-to-do-it/) on fractalforums.com.  

#### Current Limitations
You may notice that you can only zoom in so far before everything becomes a pixelated mess. I suspect that this is because you eventually reach the end of floating-point numbers' precision. I'm currently looking into using doubles instead of floats which should allow more zooming.
