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

namespace ZeroCypher
{
    public partial class frmMain : Form
    {
        private SerialPort Serial = new SerialPort();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdatePortList();
            
        }

        private void UpdatePortList()
        {
            cobPortList.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            UpdatePortList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(cobPortList.SelectedItem.ToString()) && String.IsNullOrWhiteSpace(txtBaudeRate.ToString()))
            {
                if()
            }
        }
    }
}
