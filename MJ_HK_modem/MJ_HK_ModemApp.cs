using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJ_HK_modem
{
    public partial class MJ_HK_ModemApp : Form
    {
        private SerialPortDriver serialDriver;
        private readonly string connectionSuccess = "Successfully connected to a specified port!";
        private readonly string connectionError = "Couldn't connect to a specified port!";
        private readonly string inputError = "There was no port selected!";

        public MJ_HK_ModemApp()
        {
            InitializeComponent();
            serialDriver = new SerialPortDriver(DataReceived);

            AvailablePortsList.Items.AddRange(serialDriver.GetAvailablePortList());
            if (AvailablePortsList.Items.Count > 0) AvailablePortsList.SelectedIndex = 0;

            AppendCommandLineToTerminalOutput("test");
            AppendCommandLineToTerminalOutputResponse("odpowiedz");
            AppendCommandLineToTerminalOutput("dalem gitare");
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = ((SerialPort)sender).ReadExisting();
            AppendCommandLineToTerminalOutputResponse(data.TrimStart());
            if(data.ToLower().Replace(" ",  "") == "ring")
            {
                Button_Odbierz.Enabled = true;
                Button_Rozlacz.Enabled = true;
            }
        }

        private void Button_Zadzwon_Click(object sender, EventArgs e)
        {
            string command = "atd " + TextBox_SecondModem.Text;
            serialDriver.TransmitData(command);
            AppendCommandLineToTerminalOutput(command);
        }

        private void Button_Czuwaj_Click(object sender, EventArgs e)
        {
            string command = "ath";
            serialDriver.TransmitData(command);
            AppendCommandLineToTerminalOutput(command);
        }

        private void Button_Odbierz_Click(object sender, EventArgs e)
        {
            string command = "ata";
            serialDriver.TransmitData(command);
            AppendCommandLineToTerminalOutput(command);
        }

        private void Button_Rozlacz_Click(object sender, EventArgs e)
        {
            string command = "atr";
            serialDriver.TransmitData(command);
            AppendCommandLineToTerminalOutput(command);
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var selectedPort = (string)AvailablePortsList.SelectedItem;
            if (selectedPort != string.Empty)
            {
                if (serialDriver.Connect(selectedPort))
                {
                    ConnectButton.Enabled = false;
                    DisconnectButton.Enabled = true;
                    Button_Czuwaj.Enabled = true;
                    Button_Zadzwon.Enabled = true;

                    AppendCommandLineToTerminalOutput("Success - Connected");
                }
                else MessageBox.Show(connectionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else MessageBox.Show(inputError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            serialDriver.Disconnect();
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            Button_Czuwaj.Enabled = false;
            Button_Zadzwon.Enabled = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            AvailablePortsList.Items.AddRange(serialDriver.GetAvailablePortList());
            if (AvailablePortsList.Items.Count > 0)
            {
                AvailablePortsList.SelectedIndex = 0;
            }
        }

        private void WindowClosed(object sender, FormClosingEventArgs e)
        {
            serialDriver.Disconnect();
        }

        private void Button_CommandSend_Click(object sender, EventArgs e)
        {
            var data = TextBox_CommandToSend.Text;
            if (data != string.Empty)
            {
                serialDriver.TransmitData(data);
                AppendCommandLineToTerminalOutput(data);
                TextBox_CommandToSend.Text = string.Empty;
            }
        }


        public void AppendCommandLineToTerminalOutput(string commandLine)
        {
            this.TerminalOutput.Text = this.TerminalOutput.Text + ">" + commandLine + "\n";
        }
        public void AppendCommandLineToTerminalOutputResponse(string commandLine)
        {
            this.TerminalOutput.Text = this.TerminalOutput.Text + "#" + commandLine+ "\n";
        }

    }
}
