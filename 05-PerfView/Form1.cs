using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openView_Click(object sender, EventArgs e)
        {
            var view = new ItemView();

            if(memLeak.Checked) //EventHandler müssen entfernt werden - ansonsten gibt's memory leaks
                view.SizeChanged += ViewSizeChanged;

            view.Show();
        }

        void ViewSizeChanged(object sender, EventArgs e)
        {
            //Nix, aber ausreichend ...
        }
    }
}
