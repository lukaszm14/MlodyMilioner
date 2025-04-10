namespace MlodyMilioner
{
    partial class Start
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
            Graj = new Button();
            Wyjscie = new Button();
            NowaGra = new Button();
            SuspendLayout();
            // 
            // Graj
            // 
            Graj.Font = new Font("Segoe UI", 11F);
            Graj.Location = new Point(470, 256);
            Graj.Name = "Graj";
            Graj.Size = new Size(250, 70);
            Graj.TabIndex = 0;
            Graj.Text = "Graj";
            Graj.UseVisualStyleBackColor = true;
            Graj.Click += Graj_Click;
            // 
            // Wyjscie
            // 
            Wyjscie.Font = new Font("Segoe UI", 11F);
            Wyjscie.Location = new Point(470, 439);
            Wyjscie.Name = "Wyjscie";
            Wyjscie.Size = new Size(250, 70);
            Wyjscie.TabIndex = 2;
            Wyjscie.Text = "Wyjście";
            Wyjscie.UseVisualStyleBackColor = true;
            Wyjscie.Click += Wyjscie_Click;
            // 
            // NowaGra
            // 
            NowaGra.Font = new Font("Segoe UI", 11F);
            NowaGra.Location = new Point(470, 347);
            NowaGra.Name = "NowaGra";
            NowaGra.Size = new Size(250, 70);
            NowaGra.TabIndex = 3;
            NowaGra.Text = "NowaGra";
            NowaGra.UseVisualStyleBackColor = true;
            NowaGra.Click += NowaGra_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 913);
            Controls.Add(NowaGra);
            Controls.Add(Wyjscie);
            Controls.Add(Graj);
            Name = "Start";
            Text = "Start";
            ResumeLayout(false);
        }

        #endregion

        private Button Graj;
        private Button Wyjscie;
        private Button NowaGra;
    }
}