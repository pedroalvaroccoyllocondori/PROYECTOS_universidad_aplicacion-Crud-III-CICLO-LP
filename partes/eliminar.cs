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

namespace partes
{
    public partial class eliminar : Form
    {
        public eliminar()
        {
            InitializeComponent();
        }

        private void eliminar_Load(object sender, EventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand Comando = new SqlCommand("listar", conn);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            autocompletarcodigo(txt_codigo);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
           
            cargarGrilla();
            eliminar_datos(txt_codigo.Text);
            txt_codigo.Text = "";
        }
        public void eliminar_datos(string codigo)

        {

            try
            {
                

                //conexiòn
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("eliminar", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigo", codigo);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Datos Eliminados  correctamente!");



            }
            catch (Exception y)
            {
                MessageBox.Show("error al ingresar los datos");
            }

        }
        void cargarGrilla()
        {

            //conexiòn
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand Comando = new SqlCommand("listar", conn);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from productos where codigo like('" + textBox1.Text + "%') ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void autocompletarcodigo(TextBox cajatexto)
        {
            try
            {
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("select codigo from productos ", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cajatexto.AutoCompleteCustomSource.Add(dr["codigo"].ToString());

                }
                dr.Close();


            }
            catch (Exception p)
            {
                MessageBox.Show("no se pudo autocompletar" + p.ToString());
            }
        }


        private void btn_eliminar_MouseHover(object sender, EventArgs e)
        {

            btn_eliminar.Size = new Size(width: 237, height: 137);
        }

        private void btn_eliminar_MouseLeave(object sender, EventArgs e)
        {

            btn_eliminar.Size = new Size(width: 207, height: 117);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu llamar = new menu();
            llamar.Show();
            this.Hide();
        }
    }
}
