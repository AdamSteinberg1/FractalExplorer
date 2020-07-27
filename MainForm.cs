using OpenTK;
using OpenTK.Graphics.OpenGL;
using SciColorMaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FractalExplorer
{
    public partial class MainForm : Form
    {
        private Shader shader;
        private int VertexArrayObject;
        private int VertexBufferObject;
        private int ElementBufferObject;
        private Matrix3 transformationMatrix;
        private int maxIterations = 100;
        private int superSampleFactor = 3;
        private float colorWeight = 1.0f;
        private bool reverseColor;
        private int warningThreshold = 300;
        private bool dragging = false;
        private Point lastMouse;
        private bool expanded = true;
        ColorMap cmap;

        float[] vertices = //our rectangle
{
             1.0f,  1.0f, 0.0f,  // top right
             1.0f, -1.0f, 0.0f,  // bottom right
            -1.0f, -1.0f, 0.0f,  // bottom left
            -1.0f,  1.0f, 0.0f   // top left
        };


        uint[] indices =
        {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

        public MainForm()
        {
            InitializeComponent();
            comboBox.Items.AddRange(ColorMap.Palettes.ToArray());
            comboBox.SelectedItem = "plasma";
            cmap = new ColorMap(comboBox.SelectedItem.ToString());

            iterText.Text = maxIterations.ToString();
            iterSlider.Value = maxIterations;

            aaText.Text = superSampleFactor.ToString();
            aaSlider.Value = superSampleFactor;

            weightText.Text = colorWeight.ToString();
            weightSlider.Value = (int)(colorWeight * (weightSlider.Maximum - weightSlider.Minimum));
        }

        private void glControl_Load(object sender, System.EventArgs e)
        {
            float initScale = 4.0f;
            float baseFactor = initScale / Math.Min(glControl.Width, glControl.Height);

            float newWidth = baseFactor * glControl.Width;
            float newHeight = baseFactor * glControl.Height;

            transformationMatrix = CreateTranslation(newWidth * 0.5f, newHeight * 0.5f) * CreateScale(baseFactor);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // decides the color of the window after it gets cleared between frames.

            //put vertex data on GPU
            VertexBufferObject = GL.GenBuffer(); //this int is a buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject); //hey this int is going to correspond to type arraybuffer
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw); //put the triangle into the buffer

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            // shader = new Shader("..\\..\\vertShader.vert", "..\\..\\fragShader.frag");
            shader = new Shader(Properties.Resources.vertShader, Properties.Resources.fragShader);
            shader.Use();

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0); //how to interpret the vertex data
            GL.EnableVertexAttribArray(0);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Bind the shader
            shader.Use();

            // Bind the VAO
            GL.BindVertexArray(VertexArrayObject);



            shader.SetMatrix3("transformationMatrix", transformationMatrix);
            shader.SetInt("maxIter", maxIterations);
            shader.SetInt("supersample_factor", superSampleFactor);
            shader.SetBool("reverseColor", reverseColor);
            shader.SetFloat("w", colorWeight);

            shader.SetFloatArray("colorMap", serializeColorMap(cmap));


            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            glControl.SwapBuffers();
        }

        private void glControl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            int MouseX = e.X;
            int MouseY = Height - e.Y; //e.Y measures from the top down, but we want from the bottom up
            Vector3 position = transformationMatrix * new Vector3(MouseX, MouseY, 1.0f);


            float sensitivity = 0.001f;
            float zoomFactor = 1 - e.Delta * sensitivity;

            transformationMatrix = CreateTranslation(-position.X, -position.Y) * CreateScale(zoomFactor) * CreateTranslation(position.X, position.Y) * transformationMatrix;

            //maxIterations = (int)(a * Math.Exp(-x) + b);
            iterText.Text = maxIterations.ToString();
            iterSlider.Value = maxIterations;

            glControl.Invalidate();
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            lastMouse.X = e.X;
            lastMouse.Y = e.Y;
        }

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                float sensitivity = 1.0f;
                float zoomAmount = transformationMatrix.M22;
                float xOffset = (e.X - lastMouse.X) * sensitivity * zoomAmount;
                float yOffset = -(e.Y - lastMouse.Y) * sensitivity * zoomAmount;
                transformationMatrix = CreateTranslation(xOffset, yOffset) * transformationMatrix;
                glControl.Invalidate();
                lastMouse.X = e.X;
                lastMouse.Y = e.Y;
            }
        }

        private static float[] serializeColorMap(ColorMap cmap) //converts a colorMap to a 1d float array in row major order
        {
            List<float> serializedList = new List<float>();
            foreach (var color in cmap.Colors())
            {
                serializedList.Add(color.R / 255.0f);
                serializedList.Add(color.G / 255.0f);
                serializedList.Add(color.B / 255.0f);
            }
            return serializedList.ToArray();
        }

        private static Matrix3 CreateTranslation(float x, float y)
        {
            Matrix3 toReturn = Matrix3.Identity;
            toReturn.M13 = -x;
            toReturn.M23 = -y;
            return toReturn;
        }

        private static Matrix3 CreateScale(float s)
        {
            Matrix3 toReturn = Matrix3.Identity;
            toReturn.M11 = s;
            toReturn.M22 = s;
            return toReturn;
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            glControl.Invalidate();
        }

        private void expand_button_Click(object sender, EventArgs e)
        {
            if (expanded)
            {
                expanded = false;
                optionsPanel.Width = 0;

                expand_button.BackgroundImage = Properties.Resources.left_chevron;
            }
            else
            {
                expanded = true;
                optionsPanel.Width = 230;
                expand_button.BackgroundImage = Properties.Resources.right_chevron;
            }
        }

        private void iterText_TextChanged(object sender, EventArgs e)
        {
            int temp;
            try
            {
                temp = Int32.Parse(iterText.Text);
                iterSlider.Value = temp;
                maxIterations = temp;
                iterText.ForeColor = Color.Black;
                if (maxIterations > warningThreshold)
                    iterWarning.Visible = true;
                else
                    iterWarning.Visible = false;

                glControl.Invalidate();
            }
            catch (Exception)
            {
                iterText.ForeColor = Color.Red;
            }

        }

        private void iterSlider_ValueChanged(object sender, EventArgs e)
        {
            maxIterations = iterSlider.Value;
            iterText.Text = maxIterations.ToString();
            if (maxIterations > warningThreshold)
                iterWarning.Visible = true;
            else
                iterWarning.Visible = false;

            glControl.Invalidate();
        }


        private void aaText_TextChanged(object sender, EventArgs e)
        {
            int temp;
            try
            {
                temp = Int32.Parse(aaText.Text);
                aaSlider.Value = temp;
                superSampleFactor = temp;
                aaText.ForeColor = Color.Black;

                glControl.Invalidate();
            }
            catch (Exception)
            {
                aaText.ForeColor = Color.Red;
            }
        }

        private void aaSlider_ValueChanged(object sender, EventArgs e)
        {
            superSampleFactor = aaSlider.Value;
            aaText.Text = superSampleFactor.ToString();
            glControl.Invalidate();
        }

        private void weightText_TextChanged(object sender, EventArgs e)
        {
            float temp;
            try
            {
                temp = float.Parse(weightText.Text);
                weightSlider.Value = (int)Math.Round(temp * (weightSlider.Maximum - weightSlider.Minimum));
                colorWeight = temp;
                iterText.ForeColor = Color.Black;
                glControl.Invalidate();
            }
            catch (Exception)
            {
                iterText.ForeColor = Color.Red;
            }
        }

        private void weightSlider_ValueChanged(object sender, EventArgs e)
        {
            colorWeight = (float)weightSlider.Value / (weightSlider.Maximum - weightSlider.Minimum);
            weightText.Text = colorWeight.ToString();
            glControl.Invalidate();
        }


        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmap = new ColorMap(comboBox.SelectedItem.ToString());
            glControl.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            expand_button.PerformClick();
        }

        private void htSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            reverseColor = reverseSwitch.Checked;
            glControl.Invalidate();
        }
    }
}
