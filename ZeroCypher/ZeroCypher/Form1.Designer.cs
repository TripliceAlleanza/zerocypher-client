namespace ZeroCypher
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.tabPorts = new System.Windows.Forms.TabPage();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudeRate = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.cobPortList = new System.Windows.Forms.ComboBox();
            this.tabEncoding = new System.Windows.Forms.TabPage();
            this.grbEncoding = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cobEncryptionType = new System.Windows.Forms.ComboBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncryptionKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtEncMessage = new System.Windows.Forms.TextBox();
            this.tabDecoding = new System.Windows.Forms.TabPage();
            this.grbDecoding = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMessageDecryption = new System.Windows.Forms.TextBox();
            this.cobDecryptionType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.brnDecryption = new System.Windows.Forms.Button();
            this.txtDecryptionKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbPortSetting = new System.Windows.Forms.GroupBox();
            this.grbCalibration = new System.Windows.Forms.GroupBox();
            this.lblA = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.lblZ = new System.Windows.Forms.Label();
            this.btnSendCalibration = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabPorts.SuspendLayout();
            this.tabEncoding.SuspendLayout();
            this.grbEncoding.SuspendLayout();
            this.tabDecoding.SuspendLayout();
            this.grbDecoding.SuspendLayout();
            this.grbPortSetting.SuspendLayout();
            this.grbCalibration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConsole);
            this.tabControl1.Controls.Add(this.tabPorts);
            this.tabControl1.Controls.Add(this.tabEncoding);
            this.tabControl1.Controls.Add(this.tabDecoding);
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(903, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.txtConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 23);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(895, 504);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(6, 7);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(883, 492);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "";
            this.txtConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsole_KeyDown);
            // 
            // tabPorts
            // 
            this.tabPorts.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.tabPorts.BackColor = System.Drawing.Color.Silver;
            this.tabPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPorts.Controls.Add(this.grbCalibration);
            this.tabPorts.Controls.Add(this.grbPortSetting);
            this.tabPorts.Location = new System.Drawing.Point(4, 23);
            this.tabPorts.Name = "tabPorts";
            this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPorts.Size = new System.Drawing.Size(895, 504);
            this.tabPorts.TabIndex = 1;
            this.tabPorts.Text = "Setting";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Red;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisconnect.Location = new System.Drawing.Point(260, 107);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(86, 23);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port List:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baud Rate:";
            // 
            // txtBaudeRate
            // 
            this.txtBaudeRate.Location = new System.Drawing.Point(31, 99);
            this.txtBaudeRate.Name = "txtBaudeRate";
            this.txtBaudeRate.Size = new System.Drawing.Size(100, 22);
            this.txtBaudeRate.TabIndex = 3;
            this.txtBaudeRate.Text = "9600";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Lime;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Location = new System.Drawing.Point(260, 69);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateList.Location = new System.Drawing.Point(260, 33);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(86, 23);
            this.btnUpdateList.TabIndex = 1;
            this.btnUpdateList.Text = "Update list";
            this.btnUpdateList.UseVisualStyleBackColor = false;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // cobPortList
            // 
            this.cobPortList.FormattingEnabled = true;
            this.cobPortList.Location = new System.Drawing.Point(31, 52);
            this.cobPortList.Name = "cobPortList";
            this.cobPortList.Size = new System.Drawing.Size(156, 22);
            this.cobPortList.TabIndex = 0;
            // 
            // tabEncoding
            // 
            this.tabEncoding.BackColor = System.Drawing.Color.Silver;
            this.tabEncoding.Controls.Add(this.grbEncoding);
            this.tabEncoding.Location = new System.Drawing.Point(4, 23);
            this.tabEncoding.Name = "tabEncoding";
            this.tabEncoding.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncoding.Size = new System.Drawing.Size(895, 504);
            this.tabEncoding.TabIndex = 2;
            this.tabEncoding.Text = "Encoding";
            // 
            // grbEncoding
            // 
            this.grbEncoding.Controls.Add(this.label5);
            this.grbEncoding.Controls.Add(this.cobEncryptionType);
            this.grbEncoding.Controls.Add(this.btnEncrypt);
            this.grbEncoding.Controls.Add(this.label4);
            this.grbEncoding.Controls.Add(this.txtEncryptionKey);
            this.grbEncoding.Controls.Add(this.label3);
            this.grbEncoding.Controls.Add(this.TxtEncMessage);
            this.grbEncoding.Location = new System.Drawing.Point(24, 21);
            this.grbEncoding.Name = "grbEncoding";
            this.grbEncoding.Size = new System.Drawing.Size(843, 375);
            this.grbEncoding.TabIndex = 7;
            this.grbEncoding.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type of encryption";
            // 
            // cobEncryptionType
            // 
            this.cobEncryptionType.FormattingEnabled = true;
            this.cobEncryptionType.Location = new System.Drawing.Point(506, 194);
            this.cobEncryptionType.Name = "cobEncryptionType";
            this.cobEncryptionType.Size = new System.Drawing.Size(233, 22);
            this.cobEncryptionType.TabIndex = 5;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Lime;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncrypt.Location = new System.Drawing.Point(338, 273);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(137, 42);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Key:";
            // 
            // txtEncryptionKey
            // 
            this.txtEncryptionKey.Location = new System.Drawing.Point(37, 196);
            this.txtEncryptionKey.Name = "txtEncryptionKey";
            this.txtEncryptionKey.Size = new System.Drawing.Size(314, 22);
            this.txtEncryptionKey.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Message:";
            // 
            // TxtEncMessage
            // 
            this.TxtEncMessage.Location = new System.Drawing.Point(37, 37);
            this.TxtEncMessage.Multiline = true;
            this.TxtEncMessage.Name = "TxtEncMessage";
            this.TxtEncMessage.Size = new System.Drawing.Size(780, 118);
            this.TxtEncMessage.TabIndex = 0;
            // 
            // tabDecoding
            // 
            this.tabDecoding.BackColor = System.Drawing.Color.Silver;
            this.tabDecoding.Controls.Add(this.grbDecoding);
            this.tabDecoding.Location = new System.Drawing.Point(4, 23);
            this.tabDecoding.Name = "tabDecoding";
            this.tabDecoding.Size = new System.Drawing.Size(895, 504);
            this.tabDecoding.TabIndex = 3;
            this.tabDecoding.Text = "Decoding";
            // 
            // grbDecoding
            // 
            this.grbDecoding.Controls.Add(this.label6);
            this.grbDecoding.Controls.Add(this.txtMessageDecryption);
            this.grbDecoding.Controls.Add(this.cobDecryptionType);
            this.grbDecoding.Controls.Add(this.label8);
            this.grbDecoding.Controls.Add(this.brnDecryption);
            this.grbDecoding.Controls.Add(this.txtDecryptionKey);
            this.grbDecoding.Controls.Add(this.label7);
            this.grbDecoding.Location = new System.Drawing.Point(22, 20);
            this.grbDecoding.Name = "grbDecoding";
            this.grbDecoding.Size = new System.Drawing.Size(852, 382);
            this.grbDecoding.TabIndex = 14;
            this.grbDecoding.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Type of decryption";
            // 
            // txtMessageDecryption
            // 
            this.txtMessageDecryption.Location = new System.Drawing.Point(39, 37);
            this.txtMessageDecryption.Multiline = true;
            this.txtMessageDecryption.Name = "txtMessageDecryption";
            this.txtMessageDecryption.Size = new System.Drawing.Size(780, 118);
            this.txtMessageDecryption.TabIndex = 7;
            // 
            // cobDecryptionType
            // 
            this.cobDecryptionType.FormattingEnabled = true;
            this.cobDecryptionType.Location = new System.Drawing.Point(508, 194);
            this.cobDecryptionType.Name = "cobDecryptionType";
            this.cobDecryptionType.Size = new System.Drawing.Size(233, 22);
            this.cobDecryptionType.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "Message:";
            // 
            // brnDecryption
            // 
            this.brnDecryption.BackColor = System.Drawing.Color.Lime;
            this.brnDecryption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.brnDecryption.Location = new System.Drawing.Point(340, 273);
            this.brnDecryption.Name = "brnDecryption";
            this.brnDecryption.Size = new System.Drawing.Size(137, 42);
            this.brnDecryption.TabIndex = 11;
            this.brnDecryption.Text = "Decryption";
            this.brnDecryption.UseVisualStyleBackColor = false;
            this.brnDecryption.Click += new System.EventHandler(this.brnDecryption_Click);
            // 
            // txtDecryptionKey
            // 
            this.txtDecryptionKey.Location = new System.Drawing.Point(39, 196);
            this.txtDecryptionKey.Name = "txtDecryptionKey";
            this.txtDecryptionKey.Size = new System.Drawing.Size(314, 22);
            this.txtDecryptionKey.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Key:";
            // 
            // grbPortSetting
            // 
            this.grbPortSetting.Controls.Add(this.btnDisconnect);
            this.grbPortSetting.Controls.Add(this.label2);
            this.grbPortSetting.Controls.Add(this.label1);
            this.grbPortSetting.Controls.Add(this.txtBaudeRate);
            this.grbPortSetting.Controls.Add(this.btnConnect);
            this.grbPortSetting.Controls.Add(this.btnUpdateList);
            this.grbPortSetting.Controls.Add(this.cobPortList);
            this.grbPortSetting.Location = new System.Drawing.Point(30, 40);
            this.grbPortSetting.Name = "grbPortSetting";
            this.grbPortSetting.Size = new System.Drawing.Size(383, 225);
            this.grbPortSetting.TabIndex = 7;
            this.grbPortSetting.TabStop = false;
            this.grbPortSetting.Text = "Port setting";
            // 
            // grbCalibration
            // 
            this.grbCalibration.Controls.Add(this.btnSendCalibration);
            this.grbCalibration.Controls.Add(this.txtZ);
            this.grbCalibration.Controls.Add(this.lblZ);
            this.grbCalibration.Controls.Add(this.txtA);
            this.grbCalibration.Controls.Add(this.lblA);
            this.grbCalibration.Location = new System.Drawing.Point(470, 40);
            this.grbCalibration.Name = "grbCalibration";
            this.grbCalibration.Size = new System.Drawing.Size(392, 225);
            this.grbCalibration.TabIndex = 8;
            this.grbCalibration.TabStop = false;
            this.grbCalibration.Text = "Calibration";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(18, 33);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(119, 14);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "Letter \'A\' angle";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(21, 52);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 22);
            this.txtA.TabIndex = 1;
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(21, 99);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(100, 22);
            this.txtZ.TabIndex = 3;
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(18, 80);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(119, 14);
            this.lblZ.TabIndex = 2;
            this.lblZ.Text = "Letter \'Z\' angle";
            // 
            // btnSendCalibration
            // 
            this.btnSendCalibration.BackColor = System.Drawing.Color.Lime;
            this.btnSendCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendCalibration.Location = new System.Drawing.Point(201, 69);
            this.btnSendCalibration.Name = "btnSendCalibration";
            this.btnSendCalibration.Size = new System.Drawing.Size(86, 23);
            this.btnSendCalibration.TabIndex = 4;
            this.btnSendCalibration.Text = "Calibrate";
            this.btnSendCalibration.UseVisualStyleBackColor = false;
            this.btnSendCalibration.Click += new System.EventHandler(this.btnSendCalibration_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(909, 551);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Crypto";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabPorts.ResumeLayout(false);
            this.tabEncoding.ResumeLayout(false);
            this.grbEncoding.ResumeLayout(false);
            this.grbEncoding.PerformLayout();
            this.tabDecoding.ResumeLayout(false);
            this.grbDecoding.ResumeLayout(false);
            this.grbDecoding.PerformLayout();
            this.grbPortSetting.ResumeLayout(false);
            this.grbPortSetting.PerformLayout();
            this.grbCalibration.ResumeLayout(false);
            this.grbCalibration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.TabPage tabPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.ComboBox cobPortList;
        private System.Windows.Forms.TabPage tabEncoding;
        private System.Windows.Forms.TabPage tabDecoding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaudeRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cobEncryptionType;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEncryptionKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtEncMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cobDecryptionType;
        private System.Windows.Forms.Button brnDecryption;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDecryptionKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMessageDecryption;
        private System.Windows.Forms.GroupBox grbDecoding;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox grbEncoding;
        private System.Windows.Forms.GroupBox grbCalibration;
        private System.Windows.Forms.GroupBox grbPortSetting;
        private System.Windows.Forms.Button btnSendCalibration;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblA;
    }
}

