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
    public partial class actualizar : Form
    {
        public actualizar()
        {
            InitializeComponent();
        }

        private void actualizar_Load(object sender, EventArgs e)
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

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            // obtenemos los datos del formulario
          
            cargarGrilla();
            actualizar_datos(txt_codigo.Text,txt_nombre.Text,txt_cantidad.Text,maskedTextBox1.Text);
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            txt_cantidad.Text = "";
            maskedTextBox1.Text = "";
           

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
        public void actualizar_datos(string codigo, string nombre, string cantidad, string fecha)

        {

            try
            {
                
                int Cantidad = Convert.ToInt16(cantidad);

                //conexiòn
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("actualizar", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigo", codigo);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@cantidad",Cantidad);
                command.Parameters.AddWithValue("@fecha", fecha);

                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Datos Actualizados correctamente!");



            }
            catch (Exception y)
            {
                MessageBox.Show("error al ingresar los datos");
            }

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

        private void btn_actualizar_MouseHover(object sender, EventArgs e)
        {

            btn_actualizar.Size = new Size(width: 174, height: 129);
        }

        private void btn_actualizar_MouseLeave(object sender, EventArgs e)
        {

            btn_actualizar.Size = new Size(width: 154, height: 109);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu llamar = new menu();
            llamar.Show();
            this.Hide();
        }
    }
}
