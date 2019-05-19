using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForm
{
    public partial class GaussForm : Form
    {
        private Point mouseLocation;
        

        public GaussForm()
        {
            InitializeComponent();
            lbltitle.Text = this.Text;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {   
                Point mpos = Control.MousePosition;
                mpos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mpos;
            }
        }
 
        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
            Refresh();
        }

        private void Btnmin_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Minimized;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.btnclose.Location = new System.Drawing.Point(this.Width - btnclose.Width, panel1.Height - btnclose.Height);
            this.btnmax.Location = new System.Drawing.Point(this.Width - btnmax.Width - btnclose.Width-3, panel1.Height - btnmax.Height);
            this.btnmin.Location = new System.Drawing.Point(this.Width - btnmin.Width - btnmax.Width - btnclose.Width-6, panel1.Height - btnmin.Height);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }


        //override
        public void Add(Control c)
        {
            c.Location = new System.Drawing.Point(c.Location.X, c.Location.Y + panel1.Height);
            Controls.Add(c);
        }


    }
}
