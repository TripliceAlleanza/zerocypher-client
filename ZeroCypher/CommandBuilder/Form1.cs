using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CommandParser.Parser.Models;

namespace CommandBuilder {
    public partial class frmMain : Form {
        List<Command> CommandList = new List<Command>();
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            rdbCreateCommand.Checked = true;
            lblInfo.Visible = false;
            grbInput.Visible = false;
        }

        private void rdbCreate_CheckedChanged(object sender, EventArgs e) {
            if (rdbCreateCommandArg.Checked) {
                lblInfo.Visible = true;
                lblName.Text = "Argument Name: ";
                lblDescription.Text = "Argument Description: ";
            }
            else {
                
                lblInfo.Visible = false;
                lblName.Text = "Command Name: ";
                lblDescription.Text = "Command Description: ";
            }
        }

        private void btnNew_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog();
            save.CheckFileExists = false;
            save.CheckPathExists = true;
            save.DefaultExt = "json";
            if (save.ShowDialog() == DialogResult.OK) {
                lblFileName.Text = save.FileName;
                grbInput.Visible = true;
                File.Create(save.FileName).Dispose();
            }
            save.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (rdbCreateCommand.Checked) {
                if(!String.IsNullOrWhiteSpace(txtName.Text) && !String.IsNullOrWhiteSpace(TxtDescription.Text)) {
                    string CommandName= txtName.Text;
                    if (CommandList.Find(x => x.Name == CommandName) == null) {
                        Command Comm = new Command(CommandName, TxtDescription.Text);
                        TreeView.Nodes.Add(CommandName);
                        CommandList.Add(Comm);
                        MessageBox.Show("Command has been added");
                    }
                }

            }
            if (rdbCreateCommandArg.Checked) {

                if (!String.IsNullOrWhiteSpace(txtName.Text) && !String.IsNullOrWhiteSpace(TxtDescription.Text)) {
                    string CommandName = txtName.Text;
                    if (CommandList.Find(x => x.Name == CommandName) == null) {
                        Command Comm = new Command(CommandName, TxtDescription.Text);
                        TreeView.Nodes.Add(CommandName);
                        CommandList.Add(Comm);
                        MessageBox.Show("Command has been added");
                    }
                }
            }
        }
    }
}
