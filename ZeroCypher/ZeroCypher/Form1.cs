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
using CommandParser.Parser;
using CommandParser.Parser.Models;

namespace ZeroCypher {
    public partial class frmMain : Form {
        private string consoletext = "Console --";
        private SerialPort Serial = new SerialPort();
        private StringBuilder buffer = new StringBuilder();
        private List<Packet> OutputBuffer = new List<Packet>();
        JsonSchema JsonPacketValidator = new JsonSchemaGenerator().Generate(typeof(RecivedPacket));
        private CommandAnalyser Console = new CommandAnalyser();
        private bool Ready = false;
        private long caretPos = 0;

        string[] CommadBuffer = new string[20];     //circular buffer
        byte CircularBufferWriteIndex = 0;
        byte CircularBufferReadIndex = 0;

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

        private void AddToCommandBuffer(string text) {
            if (CommadBuffer[(CircularBufferWriteIndex + CommadBuffer.Length - 1) % CommadBuffer.Length] != text) {
                CommadBuffer[CircularBufferWriteIndex] = text;
                CircularBufferWriteIndex = Convert.ToByte((CircularBufferWriteIndex + CommadBuffer.Length + 1) % CommadBuffer.Length);
            }
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
        private void ConsoleBufferWrite(string text) {
            txtConsole.Invoke((MethodInvoker)delegate { txtConsole.AppendText(text); });
        }

        private void BlockEncodingAndDecoding() {
            grbEncoding.Enabled = false;
            grbDecoding.Enabled = false;
            grbCalibration.Enabled = false;
        }
        private void UnlockEncodingAndDecoding() {
            grbEncoding.Enabled = true;
            grbDecoding.Enabled = true;
            grbCalibration.Enabled = true;
        }
        private void UpdateComboBoxList() {           
            cobEncryptionType.DataSource = GetAlgorithms();
            cobDecryptionType.DataSource = GetAlgorithms();
        }
        private string[] GetAlgorithms() {
            return new string[] { "cesare", "trasposizione", "testo"};
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            string dr = Serial.ReadTo("\n").Replace("\0", "").Replace("\r", "");
            ConsoleWrite(dr);
            buffer.Append(dr);
            try {
                JObject data = JObject.Parse(buffer.ToString());
                if (data.IsValid(JsonPacketValidator)) {
                    RecivedPacket temp = RecivedPacket.Dserialize(buffer.ToString());
                    if (temp.status == "writing" || temp.status == "wait") {
                        BlockEncodingAndDecoding();
                        Ready = false;
                    }
                    if (temp.status == "done") {
                        ConsoleWrite($"Task: {temp.id} has been completed.");
                        UnlockEncodingAndDecoding();
                        Ready = true;
                    }
                    if(temp.status == "ready.") {
                        UnlockEncodingAndDecoding();
                        ConsoleWrite($"Device ready to receive commands");
                        Ready = true;
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
            if (cobPortList.Items.Count > 1)
                cobPortList.SelectedIndex = 1;
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
                    var pak = new Packet("","",false,"","ping");
                    Serial.Write(Packet.Serialize(pak, true));
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
        private void SendData(string msg, string key, string type, bool mode) {
            if (/*type == "cesare" &&*/ GetAlgorithms().ToList<string>().Find(x => x == type) != null) {
                if (Ready) {
                    int n;
                    if (type == "cesare" && int.TryParse(key, out n) || type == "trasposizione" && !int.TryParse(key, out n)) {
                        Packet pak = new Packet(msg, key.ToString(), mode, type, "request");
                        pak.SetHashCode();
                        OutputBuffer.Add(pak);
                        Serial.Write(Packet.Serialize(pak, false) + "\n");
                        ConsoleWrite($"Data sent to port: '{Serial.PortName}', to be encrypted, the request ID is: {pak.id} ");
                    }
                    else {
                        ConsoleWrite("cesare requires a numeric key and transposizione requires a non numeric key.");
                    }
                }
                else
                    MessageBox.Show("The arduino isn't ready. please retry.");
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
                    if (!String.IsNullOrWhiteSpace(TxtEncMessage.Text) && (!String.IsNullOrWhiteSpace(txtEncryptionKey.Text) || cobEncryptionType.Text == "testo") && !string.IsNullOrWhiteSpace(cobEncryptionType.SelectedItem.ToString())) {
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
                        if (Ready) {
                            Packet pak = new Packet(txtMessageDecryption.Text, txtDecryptionKey.Text, false, cobDecryptionType.SelectedItem.ToString(), "request");
                            pak.SetHashCode();
                            OutputBuffer.Add(pak);
                            Serial.Write(Packet.Serialize(pak, false) + "\n");
                            ConsoleWrite($"Data sent to port: '{Serial.PortName}', to be decrypted, the data sent is:\r\n {Packet.Serialize(pak, true)} ");
                        }
                        else
                            MessageBox.Show("The arduino isn't ready. please retry.");
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
                    if (!String.IsNullOrWhiteSpace(comm)) {
                        AddToCommandBuffer(comm);
                        CircularBufferReadIndex = CircularBufferWriteIndex;
                        CircularBufferReadIndex--;
                        Console.Execute(comm);
                    }
                    else
                        ConsoleWrite("");
                    break;
                case Keys.Oem4:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    string temp = ReadLine();
                    Console.Execute(temp + "?");
                    //ConsoleWrite("");
                    txtConsole.AppendText(temp);
                    break;
                case Keys.Up:
                    e.Handled = true;
                    //txtConsole.Lines[txtConsole.Lines.LongLength- 1] = consoletext;
                    txtConsole.SelectionStart = txtConsole.GetFirstCharIndexFromLine(txtConsole.Lines.Length - 1);
                    txtConsole.SelectionLength = txtConsole.Lines[txtConsole.Lines.Length - 1].Length + 1;
                    txtConsole.SelectedText = String.Empty;
                    for (int i = 0; i < CommadBuffer.Length; i++) {
                        if (CommadBuffer[(CircularBufferReadIndex + CommadBuffer.Length - 1) % CommadBuffer.Length] != null) {
                            var testing = (CircularBufferReadIndex + CommadBuffer.Length - 1) % CommadBuffer.Length;
                            ConsoleBufferWrite(consoletext + CommadBuffer[(CircularBufferReadIndex + CommadBuffer.Length - 1) % CommadBuffer.Length]);
                            CircularBufferReadIndex = Convert.ToByte((CircularBufferReadIndex + CommadBuffer.Length - 1) % CommadBuffer.Length);
                            break;
                        }
                        CircularBufferReadIndex = Convert.ToByte((CircularBufferReadIndex + CommadBuffer.Length - 1) % CommadBuffer.Length);
                    }
                    break;
                case Keys.Down:
                    txtConsole.SelectionStart = txtConsole.GetFirstCharIndexFromLine(txtConsole.Lines.Length - 1);
                    txtConsole.SelectionLength = txtConsole.Lines[txtConsole.Lines.Length - 1].Length + 1;
                    txtConsole.SelectedText = String.Empty;
                    for (int i = 0; i < CommadBuffer.Length; i++) {
                        if (CommadBuffer[(CircularBufferReadIndex + CommadBuffer.Length + 1) % CommadBuffer.Length] != null) {
                            var testing = (CircularBufferReadIndex + CommadBuffer.Length + 1) % CommadBuffer.Length;
                            ConsoleBufferWrite(consoletext + CommadBuffer[(CircularBufferReadIndex + CommadBuffer.Length + 1) % CommadBuffer.Length]);
                            CircularBufferReadIndex = Convert.ToByte((CircularBufferReadIndex + CommadBuffer.Length + 1) % CommadBuffer.Length);
                            break;
                        }
                        CircularBufferReadIndex = Convert.ToByte((CircularBufferReadIndex + CommadBuffer.Length + 1) % CommadBuffer.Length);
                    }
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

        private void btnSendCalibration_Click(object sender, EventArgs e) {
            try {
                int A = Convert.ToInt32(txtA.Text);
                int Z = Convert.ToInt32(txtZ.Text);
                if (Ready) {
                    Packet pak = new Packet(A.ToString() + ";" + Z.ToString(), "Nani", false, "Omae wa mou Shindeiru", "calibration");
                    pak.SetHashCode();
                    Serial.Write(Packet.Serialize(pak, false));

                }
                else {
                    MessageBox.Show("The arduino isn't ready. please retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (InvalidCastException) {
                MessageBox.Show("Angle values must be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAlphabet_Click(object sender, EventArgs e) {
            if (Serial.IsOpen) {
                var pak = new Packet("any", "any", true, "showalphabet", "request");
                pak.SetHashCode();
                string str = Packet.Serialize(pak, false);
                ConsoleWrite(str);
                Serial.Write(str);
            }
            else {
                MessageBox.Show("Serial post is closed, please connect first.");
            }
        }
    }
}
