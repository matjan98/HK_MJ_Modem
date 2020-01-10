using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJ_HK_modem
{
    public partial class MJ_HK_ModemApp : Form
    {
        public MJ_HK_ModemApp()
        {
            InitializeComponent();
        }

        private void Button_Zadzwon_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_Czuwaj_Click(object sender, EventArgs e)
        {

        }

        private void Button_Rozlacz_Click(object sender, EventArgs e)
        {

        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            //var selectedPort = (string)AvailablePortsList.SelectedItem;
            //if (selectedPort != string.Empty)
            //{
            //    if (serialDriver.Connect(selectedPort))
            //    {
            //        ConnectButton.Enabled = false;
            //        DisconnectButton.Enabled = true;
            //        TransmitButton.Enabled = true;
            //        SendButton.Enabled = true;

            //        MessageBox.Show(connectionSuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else MessageBox.Show(connectionError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else MessageBox.Show(inputError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            //serialDriver.Disconnect();
            //ConnectButton.Enabled = true;
            //DisconnectButton.Enabled = false;
            //TransmitButton.Enabled = false;
            //SendButton.Enabled = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            //AvailablePortsList.Items.AddRange(serialDriver.GetAvailablePortList());
            //if (AvailablePortsList.Items.Count > 0)
            //{
            //    AvailablePortsList.SelectedIndex = 0;
            //}
        }



        public void AppendCommandLineToTerminalOutput(string commandLine)
        {
            throw new NotFiniteNumberException();

            //this.TerminalOutput.Text;
        }
    }
}
