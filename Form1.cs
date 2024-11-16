namespace BatteryMonitorApp
{
    public partial class Form1 : Form
    {
        //public Form1()
        //{
        //    InitializeComponent();
        //}

        private void InitializeComponent()
        {
            btnStart = new Button();
            lblStatus = new Label();
            lblNotify = new Label();
            numNotify = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numNotify).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(106, 160);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(153, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(106, 66);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            // 
            // lblNotify
            // 
            lblNotify.AutoSize = true;
            lblNotify.Location = new Point(106, 113);
            lblNotify.Name = "lblNotify";
            lblNotify.Size = new Size(74, 15);
            lblNotify.TabIndex = 2;
            lblNotify.Text = "Notify at (%)";
            // 
            // numNotify
            // 
            numNotify.Location = new Point(186, 111);
            numNotify.Name = "numNotify";
            numNotify.Size = new Size(73, 23);
            numNotify.TabIndex = 3;
            numNotify.Value = new decimal(new int[] { 85, 0, 0, 0 });
            numNotify.ValueChanged += numNotify_ValueChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(517, 322);
            Controls.Add(numNotify);
            Controls.Add(lblNotify);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)numNotify).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void numNotify_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
