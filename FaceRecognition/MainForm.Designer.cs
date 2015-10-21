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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabRecognition = new System.Windows.Forms.TabPage();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDetected = new System.Windows.Forms.Label();
            this.imageBoxCameraMain = new Emgu.CV.UI.ImageBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabTrain = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBoxCameraTrain = new Emgu.CV.UI.ImageBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabControl1.SuspendLayout();
            this.tabRecognition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraMain)).BeginInit();
            this.tabTrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabRecognition);
            this.TabControl1.Controls.Add(this.tabTrain);
            this.TabControl1.Location = new System.Drawing.Point(12, 9);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(649, 564);
            this.TabControl1.TabIndex = 0;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.ChangeTab);
            // 
            // tabRecognition
            // 
            this.tabRecognition.AccessibleDescription = "";
            this.tabRecognition.AccessibleName = "";
            this.tabRecognition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabRecognition.Controls.Add(this.labelDescription);
            this.tabRecognition.Controls.Add(this.labelDetected);
            this.tabRecognition.Controls.Add(this.imageBoxCameraMain);
            this.tabRecognition.Controls.Add(this.buttonStop);
            this.tabRecognition.Controls.Add(this.buttonStart);
            this.tabRecognition.Location = new System.Drawing.Point(4, 22);
            this.tabRecognition.Name = "tabRecognition";
            this.tabRecognition.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecognition.Size = new System.Drawing.Size(641, 538);
            this.tabRecognition.TabIndex = 0;
            this.tabRecognition.Text = "Recog";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(122, 516);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(41, 13);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Desc : ";
            // 
            // labelDetected
            // 
            this.labelDetected.AutoSize = true;
            this.labelDetected.Location = new System.Drawing.Point(6, 516);
            this.labelDetected.Name = "labelDetected";
            this.labelDetected.Size = new System.Drawing.Size(57, 13);
            this.labelDetected.TabIndex = 4;
            this.labelDetected.Text = "Detected :";
            // 
            // imageBoxCameraMain
            // 
            this.imageBoxCameraMain.BackColor = System.Drawing.Color.Gainsboro;
            this.imageBoxCameraMain.Location = new System.Drawing.Point(7, 37);
            this.imageBoxCameraMain.Name = "imageBoxCameraMain";
            this.imageBoxCameraMain.Size = new System.Drawing.Size(625, 470);
            this.imageBoxCameraMain.TabIndex = 2;
            this.imageBoxCameraMain.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(88, 7);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(7, 7);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tabTrain
            // 
            this.tabTrain.Controls.Add(this.label1);
            this.tabTrain.Controls.Add(this.imageBoxCameraTrain);
            this.tabTrain.Controls.Add(this.buttonCapture);
            this.tabTrain.Controls.Add(this.labelName);
            this.tabTrain.Controls.Add(this.textBoxName);
            this.tabTrain.Location = new System.Drawing.Point(4, 22);
            this.tabTrain.Name = "tabTrain";
            this.tabTrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrain.Size = new System.Drawing.Size(641, 538);
            this.tabTrain.TabIndex = 1;
            this.tabTrain.Text = "Train";
            this.tabTrain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter Name";
            // 
            // imageBoxCameraTrain
            // 
            this.imageBoxCameraTrain.BackColor = System.Drawing.Color.Gainsboro;
            this.imageBoxCameraTrain.Location = new System.Drawing.Point(8, 6);
            this.imageBoxCameraTrain.Name = "imageBoxCameraTrain";
            this.imageBoxCameraTrain.Size = new System.Drawing.Size(625, 470);
            this.imageBoxCameraTrain.TabIndex = 7;
            this.imageBoxCameraTrain.TabStop = false;
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(482, 496);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(151, 33);
            this.buttonCapture.TabIndex = 6;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 459);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(63, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Enter Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(81, 506);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(189, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 608);
            this.Controls.Add(this.TabControl1);
            this.Name = "MainForm";
            this.Text = "Face Recogition";
            this.TabControl1.ResumeLayout(false);
            this.tabRecognition.ResumeLayout(false);
            this.tabRecognition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraMain)).EndInit();
            this.tabTrain.ResumeLayout(false);
            this.tabTrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCameraTrain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;  
        private System.Windows.Forms.TabPage tabRecognition;
        private System.Windows.Forms.TabPage tabTrain;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private Emgu.CV.UI.ImageBox imageBoxCameraMain;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDetected;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonCapture;
        private Emgu.CV.UI.ImageBox imageBoxCameraTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ImageList imageList1;
    }
}