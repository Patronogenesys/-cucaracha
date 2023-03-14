namespace Сucaracha
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            timerUpdate = new System.Windows.Forms.Timer(components);
            btnStart = new Button();
            SuspendLayout();
            // 
            // timerUpdate
            // 
            timerUpdate.Interval = 40;
            timerUpdate.Tick += Update;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(999, 576);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(181, 62);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 668);
            Controls.Add(btnStart);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "Cucaracha!!";
            Paint += MainForm_Paint;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
        private Button btnStart;
    }
}