using System;
using System.Management;
using System.Media;
using System.Timers;
using System.Windows.Forms;

namespace BatteryMonitorApp
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer monitorTimer;
        private int notifyPercentage;

        public Form1()
        {
            InitializeComponent();
            lblStatus.Text = "Set notification percentage and start monitoring.";
            monitorTimer = new System.Timers.Timer(30000); // Check every 30 seconds
            monitorTimer.Elapsed += MonitorBattery;
            btnStart.Click += BtnStart_Click; // Attach event handler for the button
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            notifyPercentage = (int)numNotify.Value;
            lblStatus.Text = $"Monitoring started. Notify at {notifyPercentage}%";
            monitorTimer.Start();
        }

        private void MonitorBattery(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        var batteryStatus = Convert.ToInt32(obj["BatteryStatus"]); // 2 = Charging
                        var estimatedCharge = Convert.ToInt32(obj["EstimatedChargeRemaining"]);

                        if (batteryStatus == 2) // Battery is charging
                        {
                            Invoke(new Action(() =>
                            {
                                lblStatus.Text = $"Battery: {estimatedCharge}% (Charging)";
                                if (estimatedCharge >= notifyPercentage)
                                {
                                    NotifyUser();
                                }
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                lblStatus.Text = $"Battery: {estimatedCharge}% (Not Charging)";
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    lblStatus.Text = $"Error: {ex.Message}";
                }));
            }
        }

        private void NotifyUser()
        {
            monitorTimer.Stop(); // Stop monitoring temporarily
            lblStatus.Text = "Notification: Unplug the charger!";

            // Play notification sound
            string filePath = @"F:\Projects\BatteryMonitorApp\Ring\pianos.wav";
            SoundPlayer player = new SoundPlayer(filePath);
            player.Play();

            // Show a message box
            MessageBox.Show(
                $"Battery has reached {notifyPercentage}%. Please unplug the charger!",
                "Battery Monitor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Stop the sound after message box is closed
            player.Stop();

            monitorTimer.Start(); // Restart monitoring
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            monitorTimer.Stop();
            monitorTimer.Dispose();
        }

        private Button btnStart;
        private Label lblStatus;
        private Label lblNotify;
        private NumericUpDown numNotify;
    }
}
