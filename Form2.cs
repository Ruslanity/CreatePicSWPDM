using StandaloneApplicationCSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePicPDM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (listBoxSearchItem.SelectedIndex != -1)
            {
                foreach (var item in listBoxSearchItem.SelectedItems)
                {
                    form1.listBox1.Items.Add(item);
                }                          
            }
            this.Close();
        }
    }
}
