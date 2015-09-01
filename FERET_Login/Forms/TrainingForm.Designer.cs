namespace FERET_Login
{
    partial class TrainingForm
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
            this.labelInstruction = new System.Windows.Forms.Label();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStateHistory = new System.Windows.Forms.Label();
            this.labelActionData = new System.Windows.Forms.Label();
            this.labelStateData = new System.Windows.Forms.Label();
            this.labelStateAction = new System.Windows.Forms.Label();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.labelRemaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInstruction
            // 
            this.labelInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstruction.Location = new System.Drawing.Point(0, 0);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(640, 51);
            this.labelInstruction.TabIndex = 5;
            this.labelInstruction.Text = "Please Wait ...";
            this.labelInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(15, 69);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(640, 480);
            this.imageBox.TabIndex = 4;
            this.imageBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonFinish);
            this.panel1.Controls.Add(this.labelRemaining);
            this.panel1.Controls.Add(this.labelInstruction);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 51);
            this.panel1.TabIndex = 6;
            // 
            // labelStateHistory
            // 
            this.labelStateHistory.AutoSize = true;
            this.labelStateHistory.Location = new System.Drawing.Point(674, 109);
            this.labelStateHistory.Name = "labelStateHistory";
            this.labelStateHistory.Size = new System.Drawing.Size(63, 13);
            this.labelStateHistory.TabIndex = 18;
            this.labelStateHistory.Text = "state history";
            // 
            // labelActionData
            // 
            this.labelActionData.AutoSize = true;
            this.labelActionData.Location = new System.Drawing.Point(761, 82);
            this.labelActionData.Name = "labelActionData";
            this.labelActionData.Size = new System.Drawing.Size(22, 13);
            this.labelActionData.TabIndex = 17;
            this.labelActionData.Text = ": ---";
            // 
            // labelStateData
            // 
            this.labelStateData.AutoSize = true;
            this.labelStateData.Location = new System.Drawing.Point(761, 69);
            this.labelStateData.Name = "labelStateData";
            this.labelStateData.Size = new System.Drawing.Size(22, 13);
            this.labelStateData.TabIndex = 16;
            this.labelStateData.Text = ": ---";
            // 
            // labelStateAction
            // 
            this.labelStateAction.AutoSize = true;
            this.labelStateAction.Location = new System.Drawing.Point(674, 69);
            this.labelStateAction.Name = "labelStateAction";
            this.labelStateAction.Size = new System.Drawing.Size(60, 26);
            this.labelStateAction.TabIndex = 15;
            this.labelStateAction.Text = "State\r\nLast Action";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(562, 28);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinish.TabIndex = 20;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Location = new System.Drawing.Point(254, 38);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(118, 13);
            this.labelRemaining.TabIndex = 21;
            this.labelRemaining.Text = "X more capture to finish";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStateHistory);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.labelActionData);
            this.Controls.Add(this.labelStateAction);
            this.Controls.Add(this.labelStateData);
            this.Name = "TrainingForm";
            this.Text = "FirstTimeTrainingForm";
            this.Load += new System.EventHandler(this.TrainingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstruction;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelStateHistory;
        private System.Windows.Forms.Label labelActionData;
        private System.Windows.Forms.Label labelStateData;
        private System.Windows.Forms.Label labelStateAction;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Label labelRemaining;
    }
}