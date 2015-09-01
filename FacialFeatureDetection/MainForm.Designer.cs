namespace FaceRecognitionProject
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.imageBoxCameraMain = new Emgu.CV.UI.ImageBox();
            this.buttonLoadClassifier = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelClassifier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraMain)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(93, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // imageBoxCameraMain
            // 
            this.imageBoxCameraMain.BackColor = System.Drawing.Color.Gainsboro;
            this.imageBoxCameraMain.Location = new System.Drawing.Point(12, 66);
            this.imageBoxCameraMain.Name = "imageBoxCameraMain";
            this.imageBoxCameraMain.Size = new System.Drawing.Size(625, 470);
            this.imageBoxCameraMain.TabIndex = 2;
            this.imageBoxCameraMain.TabStop = false;
            // 
            // buttonLoadClassifier
            // 
            this.buttonLoadClassifier.Location = new System.Drawing.Point(502, 12);
            this.buttonLoadClassifier.Name = "buttonLoadClassifier";
            this.buttonLoadClassifier.Size = new System.Drawing.Size(135, 23);
            this.buttonLoadClassifier.TabIndex = 3;
            this.buttonLoadClassifier.Text = "Load Classifier";
            this.buttonLoadClassifier.UseVisualStyleBackColor = true;
            this.buttonLoadClassifier.Click += new System.EventHandler(this.buttonLoadClassifier_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // labelClassifier
            // 
            this.labelClassifier.AutoSize = true;
            this.labelClassifier.Location = new System.Drawing.Point(12, 42);
            this.labelClassifier.Name = "labelClassifier";
            this.labelClassifier.Size = new System.Drawing.Size(144, 13);
            this.labelClassifier.TabIndex = 4;
            this.labelClassifier.Text = "Classifier Name ( not loaded )";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 551);
            this.Controls.Add(this.labelClassifier);
            this.Controls.Add(this.buttonLoadClassifier);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.imageBoxCameraMain);
            this.Name = "MainForm";
            this.Text = "Facial Feature Detection";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxCameraMain;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonLoadClassifier;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelClassifier;
    }
}