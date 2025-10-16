namespace HwTask2Practice6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            startBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(76, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(635, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(76, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(635, 23);
            textBox2.TabIndex = 1;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(76, 151);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(635, 23);
            startBtn.TabIndex = 2;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 27);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 216);
            Controls.Add(label1);
            Controls.Add(startBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button startBtn;
        private Label label1;
    }
}
