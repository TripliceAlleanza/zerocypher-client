namespace CommandBuilder {
    partial class frmMain {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.TreeView = new System.Windows.Forms.TreeView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdbCreateCommand = new System.Windows.Forms.RadioButton();
            this.rdbCreateCommandArg = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grbInput = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.grbInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(12, 80);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(335, 346);
            this.TreeView.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(2, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(111, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 61);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(236, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(111, 30);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New File";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(261, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save current changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdbCreateCommand
            // 
            this.rdbCreateCommand.AutoSize = true;
            this.rdbCreateCommand.Location = new System.Drawing.Point(24, 28);
            this.rdbCreateCommand.Name = "rdbCreateCommand";
            this.rdbCreateCommand.Size = new System.Drawing.Size(106, 17);
            this.rdbCreateCommand.TabIndex = 9;
            this.rdbCreateCommand.TabStop = true;
            this.rdbCreateCommand.Text = "Create Command";
            this.rdbCreateCommand.UseVisualStyleBackColor = true;
            this.rdbCreateCommand.CheckedChanged += new System.EventHandler(this.rdbCreate_CheckedChanged);
            // 
            // rdbCreateCommandArg
            // 
            this.rdbCreateCommandArg.AutoSize = true;
            this.rdbCreateCommandArg.Location = new System.Drawing.Point(24, 51);
            this.rdbCreateCommandArg.Name = "rdbCreateCommandArg";
            this.rdbCreateCommandArg.Size = new System.Drawing.Size(154, 17);
            this.rdbCreateCommandArg.TabIndex = 10;
            this.rdbCreateCommandArg.TabStop = true;
            this.rdbCreateCommandArg.Text = "Create Command Argument";
            this.rdbCreateCommandArg.UseVisualStyleBackColor = true;
            this.rdbCreateCommandArg.CheckedChanged += new System.EventHandler(this.rdbCreate_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(67, 345);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 38);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete selected node";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // grbInput
            // 
            this.grbInput.Controls.Add(this.TxtDescription);
            this.grbInput.Controls.Add(this.btnDelete);
            this.grbInput.Controls.Add(this.txtName);
            this.grbInput.Controls.Add(this.rdbCreateCommandArg);
            this.grbInput.Controls.Add(this.lblDescription);
            this.grbInput.Controls.Add(this.rdbCreateCommand);
            this.grbInput.Controls.Add(this.lblInfo);
            this.grbInput.Controls.Add(this.lblName);
            this.grbInput.Controls.Add(this.btnSave);
            this.grbInput.Location = new System.Drawing.Point(353, 13);
            this.grbInput.Name = "grbInput";
            this.grbInput.Size = new System.Drawing.Size(454, 413);
            this.grbInput.TabIndex = 13;
            this.grbInput.TabStop = false;
            this.grbInput.Text = "1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 150);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Command Name";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(22, 103);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(326, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Select the command name to which the argument should be added ";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(22, 230);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(110, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Command Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(25, 167);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(382, 20);
            this.txtName.TabIndex = 3;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(25, 246);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(382, 20);
            this.TxtDescription.TabIndex = 4;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(119, 13);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(111, 30);
            this.btnSaveFile.TabIndex = 14;
            this.btnSaveFile.Text = "Save Current File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.grbInput);
            this.Name = "frmMain";
            this.Text = "Command Builder";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grbInput.ResumeLayout(false);
            this.grbInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdbCreateCommand;
        private System.Windows.Forms.RadioButton rdbCreateCommandArg;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grbInput;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSaveFile;
    }
}

