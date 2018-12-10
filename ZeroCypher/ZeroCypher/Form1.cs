using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZeroCypher.Models;

namespace ZeroCypher {
    public partial class frmMain : Form {
        private SerialPort Serial = new SerialPort();
        private List<Packet> OutputBuffer = new List<Packet>();

        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            UpdatePortList();
            Serial.DataReceived += Serial_DataReceived;

        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            throw new NotImplementedException();
        }

        private void UpdatePortList() {
            cobPortList.Items.Clear();
            cobPortList.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnUpdateList_Click(object sender, EventArgs e) {
            UpdatePortList();
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(cobPortList.SelectedItem.ToString()) && !String.IsNullOrWhiteSpace(txtBaudeRate.Text)) {
                Serial.PortName = cobPortList.SelectedItem.ToString();
                Serial.BaudRate = Convert.ToInt32(txtBaudeRate.Text);
                Connect();
            } else
                MessageBox.Show("Fill all the values before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Connect() {
            if (Serial.IsOpen)
                Serial.Close();
            Serial.Open();
        }

        private void btnEncrypt_Click(object sender, EventArgs e) {
            if (Serial.IsOpen) {
                if (!String.IsNullOrWhiteSpace(TxtEncMessage.Text) && !String.IsNullOrWhiteSpace(txtEncryptionKey.Text) && !string.IsNullOrWhiteSpace(cobEncryptionType.SelectedItem.ToString())) {
                    Packet pak = new Packet(TxtEncMessage.Text, txtEncryptionKey.Text, true, cobEncryptionType.SelectedItem.ToString(), "request");
                    pak.SetHashCode();
                    OutputBuffer.Add(pak);
                    Serial.Write(Packet.Serialize(pak,false));
                    txtConsole.AppendText($"Data sent to port: '{Serial.PortName}', to be encrypted, the data sent is: \r\n{Packet.Serialize(pak,true)} ");
                }
            } else {
                MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brnDecryption_Click(object sender, EventArgs e) {
            if (Serial.IsOpen) {
                if (!String.IsNullOrWhiteSpace(txtMessageDecryption.Text) && !String.IsNullOrWhiteSpace(txtDecryptionKey.Text) && !string.IsNullOrWhiteSpace(cobDecryptionType.SelectedItem.ToString())) {
                    Packet pak = new Packet(txtMessageDecryption.Text, txtDecryptionKey.Text, false, cobDecryptionType.SelectedItem.ToString(), "request");
                    pak.SetHashCode();                 
                    OutputBuffer.Add(pak);
                    Serial.Write(Packet.Serialize(pak,false));
                    txtConsole.AppendText($"Data sent to port: '{Serial.PortName}', to be decrypted, the data sent is:\r\n {Packet.Serialize(pak, true)} ");
                }
            } else {
                MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
