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
 * customized userForm, not resizable
 */
namespace CustomForm
{
    public partial class GaussForm : Form
    {
        private Point mouseLocation;
        private int oldHeight;
        private int oldWidth;

        public GaussForm()
        {
            InitializeComponent();
            
        }

        // "drag"
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

    }
        //"drag"
    private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {   
                Point mpos = Control.MousePosition;
                mpos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mpos;
            }
            
        }

           //close form    
        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //fullsize
        private void Btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                Refresh();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Refresh();
            }
        }
        //minimize
        void Btnmin_Click(object sender, EventArgs e)
        {
            if ((this.WindowState == FormWindowState.Normal)|| (this.WindowState == FormWindowState.Maximized))
            {
                this.WindowState = FormWindowState.Minimized;
                Refresh();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Refresh();
            }
        }

        //intercepting and forwarding "dragging events" 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            this.btnclose.Location = new System.Drawing.Point(this.Width - btnclose.Width, panel1.Height - btnclose.Height);
            this.btnmax.Location = new System.Drawing.Point(this.Width - btnmax.Width - btnclose.Width-3, panel1.Height - btnmax.Height);
            this.btnmin.Location = new System.Drawing.Point(this.Width - btnmin.Width - btnmax.Width - btnclose.Width-6,
            panel1.Height - btnmin.Height);           
        }

        //intercepting and forwarding "dragging events" 
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        //intercepting and forwarding "dragging events" 
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }


        // Adding components to a form, adjusting coordinates
        public void Add(Control c)
        {
            c.Location = new System.Drawing.Point(c.Location.X, c.Location.Y + panel1.Height);
            Controls.Add(c);
        }

        //setting a title
        private void GaussForm_Load(object sender, EventArgs e)
        {
            lbltitle.Text = Text;
        }
    }
}
