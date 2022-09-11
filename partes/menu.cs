using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace partes
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar llamar = new agregar();
            llamar.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            actualizar llamar = new actualizar();
            llamar.Show();
            this.Hide();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size = new Size(width: 138, height: 95);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(width: 154, height: 109);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Size = new Size(width: 138, height: 95);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Size = new Size(width: 154, height: 109);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Size = new Size(width: 138, height: 95);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size(width: 154, height: 109);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Size = new Size(width: 152, height: 95);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new Size(width: 132, height: 109);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminar llamar = new eliminar();
            llamar.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultas llamar = new consultas();
            llamar.Show();
            this.Hide();
        }
    }
}
