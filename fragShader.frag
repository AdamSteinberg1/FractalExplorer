#version 330 core
out vec4 FragColor;
layout(pixel_center_integer) in vec4 gl_FragCoord;

uniform float colorMap[768];
uniform mat3 transformationMatrix;
uniform int maxIter;
uniform float w;
uniform int supersample_factor;
uniform bool reverseColor;

float IterateMandelbrot( in vec2 c )
{
    const float B = 2000.0;

    float n = 1.0;
    vec2 z  = vec2(0.0);
    for( int i=1; i<maxIter; i++ )
    {
        z = vec2( z.x*z.x - z.y*z.y, 2.0*z.x*z.y ) + c; // z = z² + c
        if( dot(z,z)>(B*B) ) 
            break;
        n += 1.0;
    }
    if (n == maxIter)
        return maxIter;
  
    float dx = (log(log(B))-log(log(dot(z,z))))/log(2.0);
    return n + w * dx;
}

//unused distance estimation method
float DEM(in vec2 c) //http://www.imajeenyus.com/mathematics/20121112_distance_estimates/distance_estimation_method_for_fractals.pdf
{
    const float limit_radius = 2.0;
    vec2 z  = vec2(0.0);
    vec2 dz  = vec2(0.0);
    int count  = 1;
    for(int i = 0; i < maxIter; i++)
    {
     vec2 z_new = vec2( z.x*z.x - z.y*z.y, 2.0*z.x*z.y ) + c; // z = z² + c
     vec2 dz_new = vec2( 2.0 * (z.x * dz.x - z.y * dz.y) + 1.0, 2.0*(z.x * dz.y + z.y * dz.x)); // dz = 2*z*dz+1
     z = z_new;
     dz = dz_new;
     if (length(z)>limit_radius)
        break;
        
    //If in a periodic orbit, assume it is trapped
    if (z.x == 0.0 && z.y == 0.0) 
        return 0.0;

    if (i == maxIter-1)
        return 0.0;
    }

    return  0.5 * length(z) * log(length(z))/length(dz);
}

vec3 mapToColor(float m) //http://www.hpdz.net/TechInfo/Colorizing.htm
{   
    float u = log(m)/log(float(maxIter)); //u is range (0,1)
    if(u < 0.0)
        u= 0.0;
    if(reverseColor)
        u = 1-u;

    int i = int(255 * u) * 3;  

    float r = colorMap[i];
    float g = colorMap[i+1];
    float b = colorMap[i+2];
    return vec3(r,g,b);
}

vec3 getColor(vec2 coord)
{
    vec3 t_coord = transformationMatrix * vec3(coord, 1.0);
    //float m = DEM(t_coord.xy); 
    float m = IterateMandelbrot(t_coord.xy);
    return mapToColor(m);
}

vec3 antialias(vec2 coords) //http://www.fractalforums.com/programming/antialiasing-fractals-how-best-to-do-it/
{
    float r = 0.0f, g = 0.0f, b = 0.0f;
    for(int v =0; v < supersample_factor; v++)
    {
        for(int u =0; u < supersample_factor; u++)
        {
            float fx = float(coords.x) + float(u) / float(supersample_factor);
		    float fy = float(coords.y) + float(v) / float(supersample_factor);

            vec3 eval = getColor(vec2(fx, fy));

            r += eval.x;
            g += eval.y;
            b += eval.z;

        }
    }

    r /= float(supersample_factor * supersample_factor);
	g /= float(supersample_factor * supersample_factor);
	b /= float(supersample_factor * supersample_factor);
    return vec3(r,g,b);

}



void main()
{
    vec3 col = antialias(gl_FragCoord.xy);


    FragColor = vec4(col, 1.0f);
}

