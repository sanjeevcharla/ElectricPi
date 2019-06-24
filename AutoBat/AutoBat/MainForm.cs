using System;
using System.Net.Http;
using System.Windows.Forms;

namespace AutoBat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MonitorTimer.Start();
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            CheckBatteryPercentage();
        }

        private void CheckBatteryPercentage()
        {
            int batteryPercentage = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            if (batteryPercentage < MinBattery.Value)
                TurnOnCharger();
            else
                TurnOffCharger();
        }

        private void TurnOffCharger()
        {
            SendRequest(0);
        }

        private void TurnOnCharger()
        {
            SendRequest(1);
        }

        private async void SendRequest(int flag)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync($"{ServerURL.Text}{flag}");
            }
        }
    }
}
