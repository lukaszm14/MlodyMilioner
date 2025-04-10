namespace MlodyMilioner
{
    partial class Wyjscie
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
            Tak = new Button();
            Nie = new Button();
            KoniecTextBox = new TextBox();
            SuspendLayout();
            // 
            // Tak
            // 
            Tak.Font = new Font("Segoe UI", 12F);
            Tak.Location = new Point(123, 287);
            Tak.Name = "Tak";
            Tak.Size = new Size(250, 70);
            Tak.TabIndex = 3;
            Tak.Text = "Tak";
            Tak.UseVisualStyleBackColor = true;
            Tak.Click += Tak_Click;
            // 
            // Nie
            // 
            Nie.Font = new Font("Segoe UI", 12F);
            Nie.Location = new Point(444, 287);
            Nie.Name = "Nie";
            Nie.Size = new Size(250, 70);
            Nie.TabIndex = 4;
            Nie.Text = "Nie";
            Nie.UseVisualStyleBackColor = true;
            Nie.Click += Nie_Click;
            // 
            // KoniecTextBox
            // 
            KoniecTextBox.Cursor = Cursors.No;
            KoniecTextBox.Enabled = false;
            KoniecTextBox.Font = new Font("Segoe UI", 16F);
            KoniecTextBox.Location = new Point(179, 184);
            KoniecTextBox.Name = "KoniecTextBox";
            KoniecTextBox.ReadOnly = true;
            KoniecTextBox.Size = new Size(456, 43);
            KoniecTextBox.TabIndex = 5;
            KoniecTextBox.Text = "Czy chcesz zakończyć rozgrywkę?";
            KoniecTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Wyjscie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(KoniecTextBox);
            Controls.Add(Nie);
            Controls.Add(Tak);
            Name = "Wyjscie";
            Text = "Wyjscie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Tak;
        private Button Nie;
        private TextBox KoniecTextBox;
    }
}