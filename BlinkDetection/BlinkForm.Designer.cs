namespace BlinkDetection
{
    partial class BlinkForm
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
                capture.Dispose();
                faceClassifier.Dispose();
                eyeClassifier.Dispose();
                eyePairClassifier.Dispose();

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
            this.imageBoxCam = new Emgu.CV.UI.ImageBox();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.labelInformationFace = new System.Windows.Forms.Label();
            this.labelInformationEyePair = new System.Windows.Forms.Label();
            this.labelInformationEyeLeft = new System.Windows.Forms.Label();
            this.labelInformationEyeRight = new System.Windows.Forms.Label();
            this.labelStateAction = new System.Windows.Forms.Label();
            this.labelStateData = new System.Windows.Forms.Label();
            this.labelActionData = new System.Windows.Forms.Label();
            this.labelStateHistory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCam)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxCam
            // 
            this.imageBoxCam.Location = new System.Drawing.Point(12, 60);
            this.imageBoxCam.Name = "imageBoxCam";
            this.imageBoxCam.Size = new System.Drawing.Size(640, 480);
            this.imageBoxCam.TabIndex = 2;
            this.imageBoxCam.TabStop = false;
            // 
            // labelInstruction
            // 
            this.labelInstruction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruction.Location = new System.Drawing.Point(401, 9);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(92, 22);
            this.labelInstruction.TabIndex = 3;
            this.labelInstruction.Text = "Instruction";
            this.labelInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInstruction.Click += new System.EventHandler(this.labelInstruction_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(658, 60);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(83, 65);
            this.labelInformation.TabIndex = 4;
            this.labelInformation.Text = "Information  \r\nFace Size        \r\nEye pair Size   \r\nL Eye Size        \r\nR Eye Siz" +
    "e        ";
            // 
            // labelInformationFace
            // 
            this.labelInformationFace.AutoSize = true;
            this.labelInformationFace.Location = new System.Drawing.Point(745, 73);
            this.labelInformationFace.Name = "labelInformationFace";
            this.labelInformationFace.Size = new System.Drawing.Size(31, 13);
            this.labelInformationFace.TabIndex = 6;
            this.labelInformationFace.Text = ": size";
            // 
            // labelInformationEyePair
            // 
            this.labelInformationEyePair.AutoSize = true;
            this.labelInformationEyePair.Location = new System.Drawing.Point(745, 86);
            this.labelInformationEyePair.Name = "labelInformationEyePair";
            this.labelInformationEyePair.Size = new System.Drawing.Size(31, 13);
            this.labelInformationEyePair.TabIndex = 7;
            this.labelInformationEyePair.Text = ": size";
            // 
            // labelInformationEyeLeft
            // 
            this.labelInformationEyeLeft.AutoSize = true;
            this.labelInformationEyeLeft.Location = new System.Drawing.Point(745, 99);
            this.labelInformationEyeLeft.Name = "labelInformationEyeLeft";
            this.labelInformationEyeLeft.Size = new System.Drawing.Size(31, 13);
            this.labelInformationEyeLeft.TabIndex = 8;
            this.labelInformationEyeLeft.Text = ": size";
            // 
            // labelInformationEyeRight
            // 
            this.labelInformationEyeRight.AutoSize = true;
            this.labelInformationEyeRight.Location = new System.Drawing.Point(745, 112);
            this.labelInformationEyeRight.Name = "labelInformationEyeRight";
            this.labelInformationEyeRight.Size = new System.Drawing.Size(31, 13);
            this.labelInformationEyeRight.TabIndex = 9;
            this.labelInformationEyeRight.Text = ": size";
            // 
            // labelStateAction
            // 
            this.labelStateAction.AutoSize = true;
            this.labelStateAction.Location = new System.Drawing.Point(658, 183);
            this.labelStateAction.Name = "labelStateAction";
            this.labelStateAction.Size = new System.Drawing.Size(60, 26);
            this.labelStateAction.TabIndex = 10;
            this.labelStateAction.Text = "State\r\nLast Action";
            // 
            // labelStateData
            // 
            this.labelStateData.AutoSize = true;
            this.labelStateData.Location = new System.Drawing.Point(745, 183);
            this.labelStateData.Name = "labelStateData";
            this.labelStateData.Size = new System.Drawing.Size(22, 13);
            this.labelStateData.TabIndex = 11;
            this.labelStateData.Text = ": ---";
            // 
            // labelActionData
            // 
            this.labelActionData.AutoSize = true;
            this.labelActionData.Location = new System.Drawing.Point(745, 196);
            this.labelActionData.Name = "labelActionData";
            this.labelActionData.Size = new System.Drawing.Size(22, 13);
            this.labelActionData.TabIndex = 12;
            this.labelActionData.Text = ": ---";
            // 
            // labelStateHistory
            // 
            this.labelStateHistory.AutoSize = true;
            this.labelStateHistory.Location = new System.Drawing.Point(658, 223);
            this.labelStateHistory.Name = "labelStateHistory";
            this.labelStateHistory.Size = new System.Drawing.Size(63, 13);
            this.labelStateHistory.TabIndex = 13;
            this.labelStateHistory.Text = "state history";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // BlinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 556);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStateHistory);
            this.Controls.Add(this.labelActionData);
            this.Controls.Add(this.labelStateData);
            this.Controls.Add(this.labelStateAction);
            this.Controls.Add(this.labelInformationEyeRight);
            this.Controls.Add(this.labelInformationEyeLeft);
            this.Controls.Add(this.labelInformationEyePair);
            this.Controls.Add(this.labelInformationFace);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.imageBoxCam);
            this.Name = "BlinkForm";
            this.Text = "Blink Detection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dispose);
            this.Load += new System.EventHandler(this.BlinkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxCam;
        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Label labelInformationFace;
        private System.Windows.Forms.Label labelInformationEyePair;
        private System.Windows.Forms.Label labelInformationEyeLeft;
        private System.Windows.Forms.Label labelInformationEyeRight;
        private System.Windows.Forms.Label labelStateAction;
        private System.Windows.Forms.Label labelStateData;
        private System.Windows.Forms.Label labelActionData;
        private System.Windows.Forms.Label labelStateHistory;
        private System.Windows.Forms.Label label2;
    }
}

