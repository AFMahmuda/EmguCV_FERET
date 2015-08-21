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
            this.label2 = new System.Windows.Forms.Label();
            this.labelStateHistory = new System.Windows.Forms.Label();
            this.labelActionData = new System.Windows.Forms.Label();
            this.labelStateData = new System.Windows.Forms.Label();
            this.labelStateAction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInstruction
            // 
            this.labelInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstruction.Location = new System.Drawing.Point(0, 0);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(583, 51);
            this.labelInstruction.TabIndex = 5;
            this.labelInstruction.Text = "Please Wait ...";
            this.labelInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(15, 69);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(640, 365);
            this.imageBox.TabIndex = 4;
            this.imageBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelInstruction);
            this.panel1.Location = new System.Drawing.Point(43, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 51);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // labelStateHistory
            // 
            this.labelStateHistory.AutoSize = true;
            this.labelStateHistory.Location = new System.Drawing.Point(661, 166);
            this.labelStateHistory.Name = "labelStateHistory";
            this.labelStateHistory.Size = new System.Drawing.Size(63, 13);
            this.labelStateHistory.TabIndex = 18;
            this.labelStateHistory.Text = "state history";
            // 
            // labelActionData
            // 
            this.labelActionData.AutoSize = true;
            this.labelActionData.Location = new System.Drawing.Point(748, 139);
            this.labelActionData.Name = "labelActionData";
            this.labelActionData.Size = new System.Drawing.Size(22, 13);
            this.labelActionData.TabIndex = 17;
            this.labelActionData.Text = ": ---";
            // 
            // labelStateData
            // 
            this.labelStateData.AutoSize = true;
            this.labelStateData.Location = new System.Drawing.Point(748, 126);
            this.labelStateData.Name = "labelStateData";
            this.labelStateData.Size = new System.Drawing.Size(22, 13);
            this.labelStateData.TabIndex = 16;
            this.labelStateData.Text = ": ---";
            // 
            // labelStateAction
            // 
            this.labelStateAction.AutoSize = true;
            this.labelStateAction.Location = new System.Drawing.Point(661, 126);
            this.labelStateAction.Name = "labelStateAction";
            this.labelStateAction.Size = new System.Drawing.Size(60, 26);
            this.labelStateAction.TabIndex = 15;
            this.labelStateAction.Text = "State\r\nLast Action";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 499);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStateHistory);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.labelActionData);
            this.Controls.Add(this.labelStateAction);
            this.Controls.Add(this.labelStateData);
            this.Name = "TrainingForm";
            this.Text = "FirstTimeTrainingForm";
            this.Load += new System.EventHandler(this.FirstTimeTrainingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstruction;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStateHistory;
        private System.Windows.Forms.Label labelActionData;
        private System.Windows.Forms.Label labelStateData;
        private System.Windows.Forms.Label labelStateAction;
    }
}