namespace FERET_Login
{
    partial class RegisterForm
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
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword2 = new System.Windows.Forms.TextBox();
            this.radioButtonGenreM = new System.Windows.Forms.RadioButton();
            this.radioButtonGenreF = new System.Windows.Forms.RadioButton();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 52);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(369, 391);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxFullName.Location = new System.Drawing.Point(389, 13);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(225, 20);
            this.textBoxFullName.TabIndex = 3;
            this.textBoxFullName.Text = "Full Name";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxEmail.Location = new System.Drawing.Point(388, 39);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(226, 20);
            this.textBoxEmail.TabIndex = 4;
            this.textBoxEmail.Text = "Email Address";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxUsername.Location = new System.Drawing.Point(389, 85);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(225, 20);
            this.textBoxUsername.TabIndex = 7;
            this.textBoxUsername.Text = "Username";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPassword.Location = new System.Drawing.Point(389, 111);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(225, 20);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.Text = "Password";
            // 
            // textBoxPassword2
            // 
            this.textBoxPassword2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPassword2.Location = new System.Drawing.Point(389, 137);
            this.textBoxPassword2.Name = "textBoxPassword2";
            this.textBoxPassword2.Size = new System.Drawing.Size(225, 20);
            this.textBoxPassword2.TabIndex = 9;
            this.textBoxPassword2.Text = "Re-type Password";
            // 
            // radioButtonGenreM
            // 
            this.radioButtonGenreM.AutoSize = true;
            this.radioButtonGenreM.Location = new System.Drawing.Point(396, 163);
            this.radioButtonGenreM.Name = "radioButtonGenreM";
            this.radioButtonGenreM.Size = new System.Drawing.Size(48, 17);
            this.radioButtonGenreM.TabIndex = 10;
            this.radioButtonGenreM.TabStop = true;
            this.radioButtonGenreM.Text = "Male";
            this.radioButtonGenreM.UseVisualStyleBackColor = true;
            // 
            // radioButtonGenreF
            // 
            this.radioButtonGenreF.AutoSize = true;
            this.radioButtonGenreF.Location = new System.Drawing.Point(450, 163);
            this.radioButtonGenreF.Name = "radioButtonGenreF";
            this.radioButtonGenreF.Size = new System.Drawing.Size(59, 17);
            this.radioButtonGenreF.TabIndex = 11;
            this.radioButtonGenreF.TabStop = true;
            this.radioButtonGenreF.Text = "Female";
            this.radioButtonGenreF.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(510, 405);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(105, 38);
            this.buttonRegister.TabIndex = 12;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruction.Location = new System.Drawing.Point(9, 14);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(73, 17);
            this.labelInstruction.TabIndex = 13;
            this.labelInstruction.Text = "Instruction";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(389, 405);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 38);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 456);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.radioButtonGenreF);
            this.Controls.Add(this.radioButtonGenreM);
            this.Controls.Add(this.textBoxPassword2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.imageBox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPassword2;
        private System.Windows.Forms.RadioButton radioButtonGenreM;
        private System.Windows.Forms.RadioButton radioButtonGenreF;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}