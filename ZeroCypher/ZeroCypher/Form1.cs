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
        private string consoletext = "Console --";
        private SerialPort Serial = new SerialPort();
        private StringBuilder buffer = new StringBuilder();
        private List<String> CommandBuffer = new List<string>();
        private List<Packet> OutputBuffer = new List<Packet>();
        JsonSchema JsonPacketValidator = new JsonSchemaGenerator().Generate(typeof(RecivedPacket));
        private CommandAnalyser Console = new CommandAnalyser();
        private bool Ready = false;
        private long caretPos = 0;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            Serial.Parity = Parity.Even;
            Serial.StopBits = StopBits.Two;
            Serial.DataBits = 8;
            Console.Write = ConsoleWrite;
            Console.OpenConnection = Connect;
            Console.Serialinfo = SerialInformation;
            Console.CloseConnection = Disconnect;
            Console.SendData = SendData;
            CheckForIllegalCrossThreadCalls = false;
            txtConsole.AppendText(consoletext);
            UpdatePortList();
            UpdateComboBoxList();
            Serial.DataReceived += Serial_DataReceived;
            BlockEncodingAndDecoding();

        }

        private void ConsoleWrite(string text) {
            txtConsole.SelectionColor = Color.Cyan;
            //not a ENTER
            if (text != "") {

                if (text[text.Length - 1] != '\n')
                    txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText("\n" + text + '\n'); });
                else
                    txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText("\n" + text); });
            }
            else {
                //ENTER
                txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText("\n" + text); });
            }
            txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText(consoletext); });
            txtConsole.SelectionColor = Color.White;
            caretPos = txtConsole.Lines.GetUpperBound(0);
        }

        private void BlockEncodingAndDecoding() {
            grbEncoding.Enabled = false;
            grbDecoding.Enabled = false;
        }
        private void UnlockEncodingAndDecoding() {
            grbEncoding.Enabled = true;
            grbDecoding.Enabled = true;
        }
        private void UpdateComboBoxList() {           
            cobEncryptionType.DataSource = GetAlgorithms();
            cobDecryptionType.DataSource = GetAlgorithms();
        }
        private string[] GetAlgorithms() {
            return new string[] { "cesare", "trasposizione"};
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            //string dr = Serial.ReadTo("\n\r").Replace("\0", "").Replace("\n", "");
            buffer.Append(Serial.ReadTo("\n\r").Replace("\0", "").Replace("\n", ""));
            //ConsoleWrite(dr);
            try {
                JObject data = JObject.Parse(buffer.ToString());
                if (data.IsValid(JsonPacketValidator)) {
                    RecivedPacket temp = RecivedPacket.Dserialize(buffer.ToString());
                    if (temp.status == "writing") {
                        BlockEncodingAndDecoding();
                    }
                    if (temp.status == "done") {
                        ConsoleWrite($"Task: {temp.id} has been completed.");
                        UnlockEncodingAndDecoding();
                    }
                    if(temp.status == "ready.") {
                        UnlockEncodingAndDecoding();
                        ConsoleWrite($"Device ready to receive commands");
                    }
                    buffer.Clear();
                }
            }catch(Exception ex) {
                MessageBox.Show($"Message: {ex.Message}\n\n Source:{ex.Source}\n\n Stack Trace:{ex.StackTrace}\n\n Target using reflection{ex.TargetSite.ToString()}");
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
            try {
                if (!String.IsNullOrWhiteSpace(cobPortList.SelectedItem.ToString()) && !String.IsNullOrWhiteSpace(txtBaudeRate.Text)) {
                    Serial.PortName = cobPortList.SelectedItem.ToString();
                    Serial.BaudRate = Convert.ToInt32(txtBaudeRate.Text);
                    Connect();
                }
                else
                    MessageBox.Show("Fill all the values before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Connect() {
            if (Serial.IsOpen)
                Serial.Close();
            try {
                Serial.Open();
                MessageBox.Show("Serial port opened successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception e) {
                MessageBox.Show($"Can't open serial port {Serial.PortName}, {e.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private void Connect(string name, int baudeRate) {
            try {
                Serial.PortName = name;
                Serial.BaudRate = baudeRate;
                if (Serial.IsOpen)
                    Serial.Close();
                Serial.Open();
                ConsoleWrite($"Connected to: {Serial.PortName}");
            }
            catch (Exception ex) {
                ConsoleWrite(ex.Message + "\n");
            }
        }
        private void Disconnect() {
            try {
                if (Serial.IsOpen) {
                    Serial.Close();
                    ConsoleWrite($"Disconnected from: {Serial.PortName}");
                }
            }
            catch (Exception ex) {
                ConsoleWrite(ex.Message + "\n");
            }
        }
        private void SendData(string msg, int key, string type, bool mode) {
            if (type == "cesare") {
                Packet pak = new Packet(msg, key.ToString(), mode, type, "request");
                pak.SetHashCode();
                OutputBuffer.Add(pak);
                Serial.Write(Packet.Serialize(pak, false) + "\n");
                ConsoleWrite($"Data sent to port: '{Serial.PortName}', to be encrypted, the request ID is: {pak.id} ");
            }
            else {
                string types = "";
                string[] temp = GetAlgorithms();
                for (int i = 0; i < temp.Length; i++) {
                    if (i != temp.GetUpperBound(0))
                        types += temp[i] + ", ";
                    else
                        types += temp[i];
                }
                ConsoleWrite($"Invalid Type, please use: {types}");
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e) {
            try {
                if (Serial.IsOpen) {
                    if (!String.IsNullOrWhiteSpace(TxtEncMessage.Text) && !String.IsNullOrWhiteSpace(txtEncryptionKey.Text) && !string.IsNullOrWhiteSpace(cobEncryptionType.SelectedItem.ToString())) {
                        Packet pak = new Packet(TxtEncMessage.Text, txtEncryptionKey.Text, true, cobEncryptionType.SelectedItem.ToString(), "request");
                        pak.SetHashCode();
                        OutputBuffer.Add(pak);
                        Serial.Write(Packet.Serialize(pak, false) + "\n");
                        ConsoleWrite($"Data sent to port: '{Serial.PortName}', to be encrypted, the data sent is: \r\n{Packet.Serialize(pak, true)} ");
                    }
                }
                else {
                    MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) {
                MessageBox.Show("Select a value in the Combobox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brnDecryption_Click(object sender, EventArgs e) {
            try {
                if (Serial.IsOpen) {
                    if (!String.IsNullOrWhiteSpace(txtMessageDecryption.Text) && !String.IsNullOrWhiteSpace(txtDecryptionKey.Text) && !string.IsNullOrWhiteSpace(cobDecryptionType.SelectedItem.ToString())) {
                        Packet pak = new Packet(txtMessageDecryption.Text, txtDecryptionKey.Text, false, cobDecryptionType.SelectedItem.ToString(), "request");
                        pak.SetHashCode();
                        OutputBuffer.Add(pak);
                        Serial.Write(Packet.Serialize(pak, false) + "\n");
                        ConsoleWrite($"Data sent to port: '{Serial.PortName}', to be decrypted, the data sent is:\r\n {Packet.Serialize(pak, true)} ");
                    }
                }
                else {
                    MessageBox.Show("The Client is not connected to a serial port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) {
                MessageBox.Show("Select a value in the Combobox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtConsole_KeyDown(object sender, KeyEventArgs e) {

            switch (e.KeyCode) {
                case Keys.Enter:
                    e.Handled = true;
                    string comm = ReadLine();
                    if (!String.IsNullOrWhiteSpace(comm))
                        Console.Execute(comm);
                    else
                        ConsoleWrite("");
                    break;
                case Keys.Oem4:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    string temp = ReadLine();
                    Console.Execute(temp+"?");
                    //ConsoleWrite("");
                    txtConsole.AppendText(temp);
                    break;
            }
        }
        private string ReadLine() {
            string comm = "";
            try {
                for (; caretPos < txtConsole.Lines.LongLength; caretPos++) {
                    comm += txtConsole.Lines[caretPos];
                }
            }
            catch (IndexOutOfRangeException) {
                //TODO: don't know... i'll do something later...
            }
            caretPos = txtConsole.Lines.GetUpperBound(0);
            try {
                return comm = comm.Remove(0, consoletext.Length).Trim();
            }
            catch (ArgumentOutOfRangeException) {
                return comm = "INVALID";
            }
        }
        private void SerialInformation() {
            string info = "";
            if (Serial.IsOpen)
                info += $"Connected to: {Serial.PortName}\nBaude rate: {Serial.BaudRate}";
            else
                info += $"Serial Port is not connected";
            ConsoleWrite(info);
        }

        private void btnDisconnect_Click(object sender, EventArgs e) {
            if(Serial.IsOpen)
                Serial.Close();
            MessageBox.Show("Serial port closed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
