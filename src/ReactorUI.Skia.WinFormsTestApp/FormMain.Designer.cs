namespace ReactorUI.Skia.WinFormsTestApp
{
    partial class FormMain
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
            this.skiaView = new SkiaSharp.Views.Desktop.SKControl();
            this.SuspendLayout();
            // 
            // skiaView
            // 
            this.skiaView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skiaView.Location = new System.Drawing.Point(0, 0);
            this.skiaView.Name = "skiaView";
            this.skiaView.Size = new System.Drawing.Size(800, 450);
            this.skiaView.TabIndex = 0;
            this.skiaView.Text = "skControl1";
            this.skiaView.PaintSurface += new System.EventHandler<SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs>(this.SkiaView_PaintSurface);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.skiaView);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SkiaSharp.Views.Desktop.SKControl skiaView;
    }
}

