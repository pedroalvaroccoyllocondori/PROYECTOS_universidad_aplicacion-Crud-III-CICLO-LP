using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace partes
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }
        string user = "";
        string pass = "";

        private void inicio_Load(object sender, EventArgs e)
        {
            txt_id.Text = "introduzca el usuario";
            txt_id.ForeColor = Color.Gray;
           
            txt_contraseña.Text = "introduzca la contraseña";
            txt_contraseña.ForeColor = Color.Gray;

        }
        public void logear(string usuario, string contrasena)
        {
            try
            {
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);

                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from usuarios where usuarios =@usuario and  password=@pas", conn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pas", contrasena);
                SqlDataAdapter sba = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sba.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("se establecio coneccion");
                    menu llamar = new menu();
                    llamar.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("no establecio coneccion");

                }
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                
            }
        }


        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            logear(this.txt_id.Text, this.txt_contraseña.Text);
            txt_id.Text = "";
            txt_contraseña.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txt_id_Enter(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_id.ForeColor = Color.Black;

        }

        private void txt_id_Leave(object sender, EventArgs e)
        {
            user = txt_id.Text;
            if (user.Equals("Introduzca el usuario"))
            {
                txt_id.Text = "Introduzca el usuario";
                txt_id.ForeColor = Color.Gray;
            }
            else
            {
                if (user.Equals(""))
                {
                    txt_id.Text = "Introduzca el usuario";
                    txt_id.ForeColor = Color.Gray;

                }
                else
                {
                    txt_id.Text = user;
                    txt_id.ForeColor = Color.Black;
                }
            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            txt_contraseña.Text = "";
            txt_contraseña.ForeColor = Color.Black;

        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            pass = txt_contraseña.Text;
            if (pass.Equals("Introduzca la contraseña"))
            {
                txt_contraseña.Text = "Introduzca el usuario";
                txt_contraseña.ForeColor = Color.Gray;
            }
            else
            {
                if (pass.Equals(""))
                {
                    txt_contraseña.Text = "Introduzca la contraseña";
                    txt_contraseña.ForeColor = Color.Gray;

                }
                else
                {
                    txt_contraseña.Text = pass;
                    txt_contraseña.ForeColor = Color.Black;
                }
            }
        }
    }
}

