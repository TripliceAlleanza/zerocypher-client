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
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using CommandParser.Interface;
using CommandParser.Parser;
using CommandParser.Parser.Models;

namespace ZeroCypher {
    public partial class frmMain : Form {
        private SerialPort Serial = new SerialPort();
        private StringBuilder buffer = new StringBuilder();
        private List<Packet> OutputBuffer = new List<Packet>();
        JsonSchema JsonPacketValidator = new JsonSchemaGenerator().Generate(typeof(RecivedPacket));
        private CommandAnalyser Console = new CommandAnalyser();
        private long caretPos = 0;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            Console.Write = ConsoleWrite;
            CheckForIllegalCrossThreadCalls = false;
            UpdatePortList();
            UpdateComboBoxList();
            Serial.DataReceived += Serial_DataReceived;

        }

        private void ConsoleWrite(string text)
        {
            txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText("\n"+text); });
            caretPos = txtConsole.Lines.Length;
        }

        private void BlockEncodingAndDecoding()
        {

        }
        private void UpdateComboBoxList()
        {
            var obj = new string[] { "cesare", "trasposizione" };
            cobEncryptionType.DataSource = obj;
            cobDecryptionType.DataSource = obj;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            buffer.Append(Serial.ReadExisting());
            JObject data = JObject.Parse(buffer.ToString());
            if (data.IsValid(JsonPacketValidator))
            {
                RecivedPacket temp = RecivedPacket.Dserialize(buffer.ToString());
            }
        }

        private void UpdatePortList() {
            cobPortList.Items.Clear();
            cobPortList.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnUpdateList_Click(object sender, EventArgs e) {
            UpdatePortList();
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            try
            {
                if (!String.IsNullOrWhiteSpace(cobPortList.SelectedItem.ToString()) && !String.IsNullOrWhiteSpace(txtBaudeRate.Text))
                {
                    Serial.PortName = cobPortList.SelectedItem.ToString();
                    Serial.BaudRate = Convert.ToInt32(txtBaudeRate.Text);
                    Connect();
                }
                else
                    MessageBox.Show("Fill all the values before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Connect() {
            if (Serial.IsOpen)
                Serial.Close();
            Serial.Open();
        }

        private void btnEncrypt_Click(object sender, EventArgs e) {
            try
            {
                if (Serial.IsOpen)
                {
                    if (!String.IsNullOrWhiteSpace(TxtEncMessage.Text) && !String.IsNullOrWhiteSpace(txtEncryptionKey.Text) && !string.IsNullOrWhiteSpace(cobEncryptionType.SelectedItem.ToString()))
                    {
                        Packet pak = new Packet(TxtEncMessage.Text, txtEncryptionKey.Text, true, cobEncryptionType.SelectedItem.ToString(), "request");
                        pak.SetHashCode();
                        OutputBuffer.Add(pak);
                        Serial.Write(Packet.Serialize(pak, false)+ "\n");
                        txtConsole.AppendText($"Data sent to port: '{Serial.PortName}', to be encrypted, the data sent is: \r\n{Packet.Serialize(pak, true)} ");
                    }
                }
                else
                {
                    MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a value in the Combobox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brnDecryption_Click(object sender, EventArgs e) {
            try
            {
                if (Serial.IsOpen)
                {
                    if (!String.IsNullOrWhiteSpace(txtMessageDecryption.Text) && !String.IsNullOrWhiteSpace(txtDecryptionKey.Text) && !string.IsNullOrWhiteSpace(cobDecryptionType.SelectedItem.ToString()))
                    {
                        Packet pak = new Packet(txtMessageDecryption.Text, txtDecryptionKey.Text, false, cobDecryptionType.SelectedItem.ToString(), "request");
                        pak.SetHashCode();
                        OutputBuffer.Add(pak);
                        Serial.Write(Packet.Serialize(pak, false)+"\n");
                        txtConsole.AppendText($"Data sent to port: '{Serial.PortName}', to be decrypted, the data sent is:\r\n {Packet.Serialize(pak, true)} ");
                    }
                }
                else
                {
                    MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a value in the Combobox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtConsole_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    Console.Execute(ReadLine());
                    break;
                case Keys.OemQuestion:
                    //Parser.MoreInformation(Delegate.CreateDelegate((Control)txtConsole));
                    break;
            }
        }
        private string ReadLine()
        {
            string comm = "";
            for (; caretPos < txtConsole.Lines.LongLength;caretPos++)
            {
                comm += txtConsole.Lines[caretPos];
            }
            caretPos = txtConsole.SelectionStart;
            return comm;
        }
    }
}
