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
    public partial class consultas : Form
    {
        public consultas()
        {
            InitializeComponent();
        }

        private void txt_consulta_codigo_KeyUp(object sender, KeyEventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from productos where codigo like('" + txt_consulta_codigo.Text + "%') ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void consultas_Load(object sender, EventArgs e)
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

            autocompletar(txt_consulta_nombre);
            autocompletarcodigo(txt_consulta_codigo);
            autocompletarfecha(txt_consulta_fecha);
            autocompletarcantidad(txt_consulta_cantidad);


        }

        private void txt_consulta_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from productos where nombre like('" + txt_consulta_nombre.Text + "%') ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txt_consulta_cantidad_KeyUp(object sender, KeyEventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from productos where cantidad like('" + txt_consulta_cantidad.Text + "%') ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void txt_consulta_fecha_KeyUp(object sender, KeyEventArgs e)
        {
            String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from productos where fecha like('" + txt_consulta_fecha.Text + "%') ";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void autocompletarcantidad(TextBox cajatexto)
        {
            try
            {
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("select cantidad from productos ", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cajatexto.AutoCompleteCustomSource.Add(dr["cantidad"].ToString());

                }
                dr.Close();


            }
            catch (Exception p)
            {
                MessageBox.Show("no se pudo autocompletar" + p.ToString());
            }
        }


        public void autocompletarfecha(TextBox cajatexto)
        {
            try
            {
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("select fecha from productos ", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cajatexto.AutoCompleteCustomSource.Add(dr["fecha"].ToString());

                }
                dr.Close();


            }
            catch (Exception p)
            {
                MessageBox.Show("no se pudo autocompletar" + p.ToString());
            }
        }
        public void autocompletar(TextBox cajatexto)
        {
            try
            {
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("select nombre from productos ", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cajatexto.AutoCompleteCustomSource.Add(dr["nombre"].ToString());

                }
                dr.Close();


            }
            catch (Exception p)
            {
                MessageBox.Show("no se pudo autocompletar" + p.ToString());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            menu llamar = new menu();
            llamar.Show();
            this.Hide();
        }
    }
}
