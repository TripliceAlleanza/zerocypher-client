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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudeRate = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.cobPortList = new System.Windows.Forms.ComboBox();
            this.tabEncoding = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cobEncryptionType = new System.Windows.Forms.ComboBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncryptionKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtEncMessage = new System.Windows.Forms.TextBox();
            this.grbEncoding = new System.Windows.Forms.GroupBox();
            this.tabDecoding = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cobDecryptionType = new System.Windows.Forms.ComboBox();
            this.brnDecryption = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDecryptionKey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMessageDecryption = new System.Windows.Forms.TextBox();
            this.grbDecoding = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabPorts.SuspendLayout();
            this.tabEncoding.SuspendLayout();
            this.tabDecoding.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConsole);
            this.tabControl1.Controls.Add(this.tabPorts);
            this.tabControl1.Controls.Add(this.tabEncoding);
            this.tabControl1.Controls.Add(this.tabDecoding);
            this.tabControl1.Location = new System.Drawing.Point(13, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(903, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.txtConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(895, 505);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPorts.Controls.Add(this.btnDisconnect);
            this.tabPorts.Controls.Add(this.label2);
            this.tabPorts.Controls.Add(this.label1);
            this.tabPorts.Controls.Add(this.txtBaudeRate);
            this.tabPorts.Controls.Add(this.btnConnect);
            this.tabPorts.Controls.Add(this.btnUpdateList);
            this.tabPorts.Controls.Add(this.cobPortList);
            this.tabPorts.Location = new System.Drawing.Point(4, 22);
            this.tabPorts.Name = "tabPorts";
            this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPorts.Size = new System.Drawing.Size(895, 505);
            this.tabPorts.TabIndex = 1;
            this.tabPorts.Text = "Port Setting";
            this.tabPorts.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port List:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baude Rate:";
            // 
            // txtBaudeRate
            // 
            this.txtBaudeRate.Location = new System.Drawing.Point(86, 139);
            this.txtBaudeRate.Name = "txtBaudeRate";
            this.txtBaudeRate.Size = new System.Drawing.Size(100, 20);
            this.txtBaudeRate.TabIndex = 3;
            this.txtBaudeRate.Text = "9600";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(300, 128);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(300, 92);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateList.TabIndex = 1;
            this.btnUpdateList.Text = "Update list";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // cobPortList
            // 
            this.cobPortList.FormattingEnabled = true;
            this.cobPortList.Location = new System.Drawing.Point(86, 92);
            this.cobPortList.Name = "cobPortList";
            this.cobPortList.Size = new System.Drawing.Size(156, 21);
            this.cobPortList.TabIndex = 0;
            // 
            // tabEncoding
            // 
            this.tabEncoding.Controls.Add(this.label5);
            this.tabEncoding.Controls.Add(this.cobEncryptionType);
            this.tabEncoding.Controls.Add(this.btnEncrypt);
            this.tabEncoding.Controls.Add(this.label4);
            this.tabEncoding.Controls.Add(this.txtEncryptionKey);
            this.tabEncoding.Controls.Add(this.label3);
            this.tabEncoding.Controls.Add(this.TxtEncMessage);
            this.tabEncoding.Controls.Add(this.grbEncoding);
            this.tabEncoding.Location = new System.Drawing.Point(4, 22);
            this.tabEncoding.Name = "tabEncoding";
            this.tabEncoding.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncoding.Size = new System.Drawing.Size(895, 505);
            this.tabEncoding.TabIndex = 2;
            this.tabEncoding.Text = "Encoding";
            this.tabEncoding.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type of encryption";
            // 
            // cobEncryptionType
            // 
            this.cobEncryptionType.FormattingEnabled = true;
            this.cobEncryptionType.Location = new System.Drawing.Point(527, 207);
            this.cobEncryptionType.Name = "cobEncryptionType";
            this.cobEncryptionType.Size = new System.Drawing.Size(233, 21);
            this.cobEncryptionType.TabIndex = 5;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(359, 286);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(137, 42);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Key:";
            // 
            // txtEncryptionKey
            // 
            this.txtEncryptionKey.Location = new System.Drawing.Point(58, 209);
            this.txtEncryptionKey.Name = "txtEncryptionKey";
            this.txtEncryptionKey.Size = new System.Drawing.Size(314, 20);
            this.txtEncryptionKey.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Message:";
            // 
            // TxtEncMessage
            // 
            this.TxtEncMessage.Location = new System.Drawing.Point(58, 50);
            this.TxtEncMessage.Multiline = true;
            this.TxtEncMessage.Name = "TxtEncMessage";
            this.TxtEncMessage.Size = new System.Drawing.Size(780, 118);
            this.TxtEncMessage.TabIndex = 0;
            // 
            // grbEncoding
            // 
            this.grbEncoding.Location = new System.Drawing.Point(22, 16);
            this.grbEncoding.Name = "grbEncoding";
            this.grbEncoding.Size = new System.Drawing.Size(849, 364);
            this.grbEncoding.TabIndex = 7;
            this.grbEncoding.TabStop = false;
            // 
            // tabDecoding
            // 
            this.tabDecoding.Controls.Add(this.label6);
            this.tabDecoding.Controls.Add(this.cobDecryptionType);
            this.tabDecoding.Controls.Add(this.brnDecryption);
            this.tabDecoding.Controls.Add(this.label7);
            this.tabDecoding.Controls.Add(this.txtDecryptionKey);
            this.tabDecoding.Controls.Add(this.label8);
            this.tabDecoding.Controls.Add(this.txtMessageDecryption);
            this.tabDecoding.Controls.Add(this.grbDecoding);
            this.tabDecoding.Location = new System.Drawing.Point(4, 22);
            this.tabDecoding.Name = "tabDecoding";
            this.tabDecoding.Size = new System.Drawing.Size(895, 505);
            this.tabDecoding.TabIndex = 3;
            this.tabDecoding.Text = "Decoding";
            this.tabDecoding.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Type of decryption";
            // 
            // cobDecryptionType
            // 
            this.cobDecryptionType.FormattingEnabled = true;
            this.cobDecryptionType.Location = new System.Drawing.Point(523, 219);
            this.cobDecryptionType.Name = "cobDecryptionType";
            this.cobDecryptionType.Size = new System.Drawing.Size(233, 21);
            this.cobDecryptionType.TabIndex = 12;
            // 
            // brnDecryption
            // 
            this.brnDecryption.Location = new System.Drawing.Point(355, 298);
            this.brnDecryption.Name = "brnDecryption";
            this.brnDecryption.Size = new System.Drawing.Size(137, 42);
            this.brnDecryption.TabIndex = 11;
            this.brnDecryption.Text = "Decryption";
            this.brnDecryption.UseVisualStyleBackColor = true;
            this.brnDecryption.Click += new System.EventHandler(this.brnDecryption_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Key:";
            // 
            // txtDecryptionKey
            // 
            this.txtDecryptionKey.Location = new System.Drawing.Point(54, 221);
            this.txtDecryptionKey.Name = "txtDecryptionKey";
            this.txtDecryptionKey.Size = new System.Drawing.Size(314, 20);
            this.txtDecryptionKey.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Message:";
            // 
            // txtMessageDecryption
            // 
            this.txtMessageDecryption.Location = new System.Drawing.Point(54, 62);
            this.txtMessageDecryption.Multiline = true;
            this.txtMessageDecryption.Name = "txtMessageDecryption";
            this.txtMessageDecryption.Size = new System.Drawing.Size(780, 118);
            this.txtMessageDecryption.TabIndex = 7;
            // 
            // grbDecoding
            // 
            this.grbDecoding.Location = new System.Drawing.Point(21, 24);
            this.grbDecoding.Name = "grbDecoding";
            this.grbDecoding.Size = new System.Drawing.Size(852, 386);
            this.grbDecoding.TabIndex = 14;
            this.grbDecoding.TabStop = false;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(300, 166);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 559);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Crypto";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabPorts.ResumeLayout(false);
            this.tabPorts.PerformLayout();
            this.tabEncoding.ResumeLayout(false);
            this.tabEncoding.PerformLayout();
            this.tabDecoding.ResumeLayout(false);
            this.tabDecoding.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbEncoding;
        private System.Windows.Forms.GroupBox grbDecoding;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

