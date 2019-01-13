namespace CommandBuilder {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using CommandParser.Parser.Models;
    using Newtonsoft.Json;

    public partial class frmMain : Form {
        List<Command> CommandList;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
             CommandList = new List<Command>();
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
            //adding a command to the tree and to the list
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
            //adding a argument to a command
            if (rdbCreateCommandArg.Checked) {
                try {
                    if (TreeView.SelectedNode.Parent == null
                        && !String.IsNullOrWhiteSpace(txtName.Text)
                        && !String.IsNullOrWhiteSpace(TxtDescription.Text)) {
                        string CommandName = TreeView.SelectedNode.Text;
                        string ArgName = txtName.Text;
                        var CommandIndex = CommandList.FindIndex(x => x.Name == CommandName);
                        if (CommandIndex != -1) {
                            var ArgSearch = CommandList[CommandIndex].ExplicitArguments.Find(y => y.Name == ArgName);
                            if (ArgSearch == null) {
                                Command arg = new Command(txtName.Text, TxtDescription.Text);
                                TreeView.SelectedNode.Nodes.Add(txtName.Text);
                                CommandList[CommandIndex].ExplicitArguments.Add(arg);
                                MessageBox.Show("Command has been added");
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.json";
            openFile.FilterIndex = 1;
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            if (openFile.ShowDialog() == DialogResult.OK) // Test result.
            {
               
                string Json = File.ReadAllText(openFile.FileName);
                if (Json != "") {
                    AddToTreeView(Json);
                    lblFileName.Text = openFile.FileName;
                    grbInput.Visible = true;
                }
            }          
        }
        private void AddToTreeView(string Json) {
            CommandList.Clear();
            TreeView.Nodes.Clear();
            CommandList = JsonConvert.DeserializeObject<List<Command>>(Json);
            if (CommandList != null) {
                foreach (var command in CommandList) {
                    List<TreeNode> args = new List<TreeNode>();
                    foreach (var arg in command.ExplicitArguments) {
                        args.Add(new TreeNode(arg.Name));
                    }
                    TreeView.Nodes.Add(new TreeNode(command.Name, args.ToArray()));
                }

            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e) {
            File.WriteAllText(lblFileName.Text, JsonConvert.SerializeObject(CommandList,Formatting.Indented));
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            //delete rootnode
            if (TreeView.SelectedNode.Parent == null) {
                string CommandName = TreeView.SelectedNode.Text;
                CommandList.RemoveAt(CommandList.FindIndex(x => x.Name == CommandName));
                TreeView.SelectedNode.Remove();
            }
            else {
                string ArgName = TreeView.SelectedNode.Text;
                int commandIndex = CommandList.FindIndex(x => x.Name == TreeView.SelectedNode.Parent.Text);
                CommandList[commandIndex].ExplicitArguments.RemoveAt(CommandList[commandIndex].ExplicitArguments.FindIndex(x => x.Name == ArgName));
                TreeView.SelectedNode.Remove();
            }
        }
    }
}
