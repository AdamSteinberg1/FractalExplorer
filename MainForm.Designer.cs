namespace FractalExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.glControl = new OpenTK.GLControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expand_button = new System.Windows.Forms.Button();
            this.iterLabel = new System.Windows.Forms.Label();
            this.colorMapLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerText = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.iterSlider = new HTAlt.WinForms.HTSlider();
            this.iterText = new System.Windows.Forms.TextBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightSlider = new HTAlt.WinForms.HTSlider();
            this.weightText = new System.Windows.Forms.TextBox();
            this.iterWarning = new System.Windows.Forms.Label();
            this.aaLabel = new System.Windows.Forms.Label();
            this.aaSlider = new HTAlt.WinForms.HTSlider();
            this.aaText = new System.Windows.Forms.TextBox();
            this.attribution = new System.Windows.Forms.Label();
            this.optionsPanel = new CxFlatUI.CxFlatGroupBox();
            this.reverseSwitch = new HTAlt.WinForms.HTSwitch();
            this.reverseLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(1184, 661);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            this.glControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseWheel);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // expand_button
            // 
            this.expand_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("expand_button.BackgroundImage")));
            this.expand_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.expand_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.expand_button.Location = new System.Drawing.Point(933, 0);
            this.expand_button.Name = "expand_button";
            this.expand_button.Size = new System.Drawing.Size(21, 661);
            this.expand_button.TabIndex = 6;
            this.expand_button.UseVisualStyleBackColor = true;
            this.expand_button.Click += new System.EventHandler(this.expand_button_Click);
            // 
            // iterLabel
            // 
            this.iterLabel.AutoSize = true;
            this.iterLabel.Location = new System.Drawing.Point(7, 65);
            this.iterLabel.Name = "iterLabel";
            this.iterLabel.Size = new System.Drawing.Size(115, 21);
            this.iterLabel.TabIndex = 2;
            this.iterLabel.Text = "Max Iterations: ";
            // 
            // colorMapLabel
            // 
            this.colorMapLabel.AutoSize = true;
            this.colorMapLabel.Location = new System.Drawing.Point(7, 156);
            this.colorMapLabel.Name = "colorMapLabel";
            this.colorMapLabel.Size = new System.Drawing.Size(79, 21);
            this.colorMapLabel.TabIndex = 3;
            this.colorMapLabel.Text = "ColorMap";
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.headerText);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(230, 53);
            this.headerPanel.TabIndex = 3;
            // 
            // headerText
            // 
            this.headerText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.headerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerText.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText.ForeColor = System.Drawing.Color.White;
            this.headerText.Location = new System.Drawing.Point(0, 0);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(230, 53);
            this.headerText.TabIndex = 0;
            this.headerText.Text = "Options";
            this.headerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.White;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(11, 180);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(207, 29);
            this.comboBox.TabIndex = 4;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // iterSlider
            // 
            this.iterSlider.BackColor = System.Drawing.SystemColors.Control;
            this.iterSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.iterSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.iterSlider.ForeColor = System.Drawing.Color.Black;
            this.iterSlider.LargeChange = ((uint)(5u));
            this.iterSlider.Location = new System.Drawing.Point(11, 89);
            this.iterSlider.Maximum = 1000;
            this.iterSlider.Minimum = 1;
            this.iterSlider.Name = "iterSlider";
            this.iterSlider.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.iterSlider.Size = new System.Drawing.Size(207, 48);
            this.iterSlider.SmallChange = ((uint)(1u));
            this.iterSlider.TabIndex = 5;
            this.iterSlider.Text = "htSlider1";
            this.iterSlider.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.iterSlider.ThumbSize = new System.Drawing.Size(16, 16);
            this.iterSlider.Value = 100;
            this.iterSlider.ValueChanged += new System.EventHandler(this.iterSlider_ValueChanged);
            // 
            // iterText
            // 
            this.iterText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iterText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.iterText.Location = new System.Drawing.Point(118, 64);
            this.iterText.Name = "iterText";
            this.iterText.Size = new System.Drawing.Size(100, 29);
            this.iterText.TabIndex = 6;
            this.iterText.TextChanged += new System.EventHandler(this.iterText_TextChanged);
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(7, 392);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(87, 21);
            this.weightLabel.TabIndex = 10;
            this.weightLabel.Text = "Smoothing";
            // 
            // weightSlider
            // 
            this.weightSlider.BackColor = System.Drawing.SystemColors.Control;
            this.weightSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.weightSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.weightSlider.ForeColor = System.Drawing.Color.Black;
            this.weightSlider.LargeChange = ((uint)(5u));
            this.weightSlider.Location = new System.Drawing.Point(11, 416);
            this.weightSlider.Name = "weightSlider";
            this.weightSlider.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.weightSlider.Size = new System.Drawing.Size(207, 48);
            this.weightSlider.SmallChange = ((uint)(1u));
            this.weightSlider.TabIndex = 11;
            this.weightSlider.Text = "htSlider3";
            this.weightSlider.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.weightSlider.ThumbSize = new System.Drawing.Size(16, 16);
            this.weightSlider.Value = 20;
            this.weightSlider.ValueChanged += new System.EventHandler(this.weightSlider_ValueChanged);
            // 
            // weightText
            // 
            this.weightText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.weightText.Location = new System.Drawing.Point(118, 391);
            this.weightText.Name = "weightText";
            this.weightText.Size = new System.Drawing.Size(100, 29);
            this.weightText.TabIndex = 12;
            this.weightText.TextChanged += new System.EventHandler(this.weightText_TextChanged);
            // 
            // iterWarning
            // 
            this.iterWarning.AutoSize = true;
            this.iterWarning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.iterWarning.ForeColor = System.Drawing.Color.Red;
            this.iterWarning.Location = new System.Drawing.Point(9, 125);
            this.iterWarning.Name = "iterWarning";
            this.iterWarning.Size = new System.Drawing.Size(193, 12);
            this.iterWarning.TabIndex = 13;
            this.iterWarning.Text = "High max iterations may cause slow down!";
            this.iterWarning.Visible = false;
            // 
            // aaLabel
            // 
            this.aaLabel.AutoSize = true;
            this.aaLabel.Location = new System.Drawing.Point(10, 295);
            this.aaLabel.Name = "aaLabel";
            this.aaLabel.Size = new System.Drawing.Size(99, 21);
            this.aaLabel.TabIndex = 14;
            this.aaLabel.Text = "Anti-Aliasing";
            // 
            // aaSlider
            // 
            this.aaSlider.BackColor = System.Drawing.SystemColors.Control;
            this.aaSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.aaSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.aaSlider.ForeColor = System.Drawing.Color.Black;
            this.aaSlider.LargeChange = ((uint)(5u));
            this.aaSlider.Location = new System.Drawing.Point(14, 319);
            this.aaSlider.Maximum = 5;
            this.aaSlider.Minimum = 1;
            this.aaSlider.Name = "aaSlider";
            this.aaSlider.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.aaSlider.Size = new System.Drawing.Size(207, 48);
            this.aaSlider.SmallChange = ((uint)(1u));
            this.aaSlider.TabIndex = 15;
            this.aaSlider.Text = "htSlider3";
            this.aaSlider.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.aaSlider.ThumbSize = new System.Drawing.Size(16, 16);
            this.aaSlider.Value = 5;
            this.aaSlider.ValueChanged += new System.EventHandler(this.aaSlider_ValueChanged);
            // 
            // aaText
            // 
            this.aaText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aaText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.aaText.Location = new System.Drawing.Point(121, 294);
            this.aaText.Name = "aaText";
            this.aaText.Size = new System.Drawing.Size(100, 29);
            this.aaText.TabIndex = 16;
            this.aaText.TextChanged += new System.EventHandler(this.aaText_TextChanged);
            // 
            // attribution
            // 
            this.attribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attribution.AutoSize = true;
            this.attribution.Location = new System.Drawing.Point(10, 631);
            this.attribution.Name = "attribution";
            this.attribution.Size = new System.Drawing.Size(197, 21);
            this.attribution.TabIndex = 17;
            this.attribution.Text = "created by Adam Steinberg";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.reverseLabel);
            this.optionsPanel.Controls.Add(this.reverseSwitch);
            this.optionsPanel.Controls.Add(this.attribution);
            this.optionsPanel.Controls.Add(this.aaText);
            this.optionsPanel.Controls.Add(this.aaSlider);
            this.optionsPanel.Controls.Add(this.aaLabel);
            this.optionsPanel.Controls.Add(this.iterWarning);
            this.optionsPanel.Controls.Add(this.weightText);
            this.optionsPanel.Controls.Add(this.weightSlider);
            this.optionsPanel.Controls.Add(this.weightLabel);
            this.optionsPanel.Controls.Add(this.iterText);
            this.optionsPanel.Controls.Add(this.iterSlider);
            this.optionsPanel.Controls.Add(this.comboBox);
            this.optionsPanel.Controls.Add(this.headerPanel);
            this.optionsPanel.Controls.Add(this.colorMapLabel);
            this.optionsPanel.Controls.Add(this.iterLabel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsPanel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.optionsPanel.HeaderStyle = null;
            this.optionsPanel.Location = new System.Drawing.Point(954, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.ShowText = false;
            this.optionsPanel.Size = new System.Drawing.Size(230, 661);
            this.optionsPanel.TabIndex = 3;
            this.optionsPanel.TabStop = false;
            this.optionsPanel.Text = "cxFlatGroupBox1";
            this.optionsPanel.ThemeColor = System.Drawing.Color.Transparent;
            // 
            // reverseSwitch
            // 
            this.reverseSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.reverseSwitch.Location = new System.Drawing.Point(176, 215);
            this.reverseSwitch.Name = "reverseSwitch";
            this.reverseSwitch.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.reverseSwitch.Size = new System.Drawing.Size(42, 19);
            this.reverseSwitch.TabIndex = 19;
            this.reverseSwitch.CheckedChanged += new HTAlt.WinForms.HTSwitch.CheckedChangedDelegate(this.htSwitch1_CheckedChanged);
            // 
            // reverseLabel
            // 
            this.reverseLabel.AutoSize = true;
            this.reverseLabel.Location = new System.Drawing.Point(7, 212);
            this.reverseLabel.Name = "reverseLabel";
            this.reverseLabel.Size = new System.Drawing.Size(138, 21);
            this.reverseLabel.TabIndex = 20;
            this.reverseLabel.Text = "Reverse Colormap";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.expand_button);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.glControl);
            this.MaximumSize = new System.Drawing.Size(1920, 1160);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FractalExplorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Button expand_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label iterLabel;
        private System.Windows.Forms.Label colorMapLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.ComboBox comboBox;
        private HTAlt.WinForms.HTSlider iterSlider;
        private System.Windows.Forms.TextBox iterText;
        private System.Windows.Forms.Label weightLabel;
        private HTAlt.WinForms.HTSlider weightSlider;
        private System.Windows.Forms.TextBox weightText;
        private System.Windows.Forms.Label iterWarning;
        private System.Windows.Forms.Label aaLabel;
        private HTAlt.WinForms.HTSlider aaSlider;
        private System.Windows.Forms.TextBox aaText;
        private System.Windows.Forms.Label attribution;
        private CxFlatUI.CxFlatGroupBox optionsPanel;
        private HTAlt.WinForms.HTSwitch reverseSwitch;
        private System.Windows.Forms.Label reverseLabel;
    }
}

