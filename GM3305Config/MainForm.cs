using System;
using System.Windows.Forms;
using Microsoft.Win32;

using GM3305Comm;
using System.Threading;

namespace GM3305Config
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            device_ = new Device();

            while (true) {
                if (!device_.Open()) {
                    var res = MessageBox.Show(this, "Failed to open filter driver!", Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (res == DialogResult.Retry)
                        continue;

                    Close();
                }

                break;
            }

            LoadSettings();
            Apply();

            deviceMonitor_ = new DeviceMonitor(Handle);
            deviceMonitor_.DeviceArrived += DeviceMonitor__DeviceArrived;
        }

        private void DeviceMonitor__DeviceArrived(DeviceMonitor mon, string name)
        {
            if (name.Contains("#VID_1D57&PID_FA0A#")) {
                Thread.Sleep(500);
                Apply();
            }
        }

        private void SaveSettings()
        {
            var cfg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\GM3305Config");
            cfg.SetValue("LEDEnabled", checkBoxLEDEnabled.Checked ? 1 : 0);
            cfg.SetValue("LEDStrength", comboBoxLEDStrength.SelectedIndex);
            cfg.SetValue("LEDBlinkSpeed", comboBoxLEDBlinkSpeed.SelectedIndex);
            cfg.SetValue("DPI", comboBoxDPI.SelectedIndex);
            cfg.SetValue("Hz", comboBoxHz.SelectedIndex);
        }

        private void LoadSettings()
        {
            var cfg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GM3305Config", false);
            if (cfg == null) {
                checkBoxLEDEnabled.Checked = true;
                comboBoxLEDStrength.SelectedIndex = (int)Device.Strength.High - 1;
                comboBoxLEDBlinkSpeed.SelectedIndex = (int)Device.BlinkSpeed.Fast;
                comboBoxDPI.SelectedIndex = (int)Device.DPI.DPI800;
                comboBoxHz.SelectedIndex = (int)Device.Hz.Hz500;
            } else {
                checkBoxLEDEnabled.Checked = (int)cfg.GetValue("LEDEnabled") > 0 ? true : false;
                comboBoxLEDStrength.SelectedIndex = (int)cfg.GetValue("LEDStrength");
                comboBoxLEDBlinkSpeed.SelectedIndex = (int)cfg.GetValue("LEDBlinkSpeed");
                comboBoxDPI.SelectedIndex = (int)cfg.GetValue("DPI");
                comboBoxHz.SelectedIndex = (int)cfg.GetValue("Hz");
            }
        }

        private void Apply()
        {
            device_.SetLEDEnabled(checkBoxLEDEnabled.Checked);
            device_.SetLEDStrength((Device.Strength)(comboBoxLEDStrength.SelectedIndex + 1));
            device_.SetLEDBlinkSpeed((Device.BlinkSpeed)comboBoxLEDBlinkSpeed.SelectedIndex);
            device_.SetDPI((Device.DPI)comboBoxDPI.SelectedIndex);
            device_.SetHz((Device.Hz)comboBoxHz.SelectedIndex);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Apply();
            SaveSettings();
        }

        private Device device_;

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                ShowInTaskbar = false;
                Hide();
            } else {
                ShowInTaskbar = true;
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                Show();
                WindowState = FormWindowState.Normal;
            } else if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxLEDEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var en = checkBoxLEDEnabled.Checked;
            labelLEDStrength.Enabled = en;
            comboBoxLEDStrength.Enabled = en;
            labelLEDBlinkSpeed.Enabled = en;
            comboBoxLEDBlinkSpeed.Enabled = en;
        }

        private DeviceMonitor deviceMonitor_;
    }
}
