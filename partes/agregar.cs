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
    public partial class agregar : Form
    {
        public agregar()
        {
            InitializeComponent();
        }

        private void agregar_Load(object sender, EventArgs e)
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
        }


        public void agregar_datos( string codigo ,string nombre ,string  cantidad ,string fecha)

        {

            try
            {

                int Codigo = Convert.ToInt16(codigo);
                int Cantidad = Convert.ToInt16(cantidad);



                //conexiòn
                String cadena = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                //ingresamos el procedimiento almacenado con los parametros
                SqlCommand command = new SqlCommand("agregar", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigo", Codigo);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@cantidad", Cantidad);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Datos Ingresados correctamente!");

                
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

        private void btn_agregar_MouseHover(object sender, EventArgs e)
        {
            btn_agregar.Size = new Size(width: 180, height: 148);
        }

        private void btn_agregar_MouseLeave(object sender, EventArgs e)
        {
            btn_agregar.Size = new Size(width: 160, height: 128);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // metodo para ingresar datos
            agregar_datos(txt_codigo.Text, txt_nombre.Text, txt_cantidad.Text, maskedTextBox1.Text);
            //meodo para cargar el datagrid modificado
            cargarGrilla();
            //ponemos los textbox en blanco despues que se ejecutan
            txt_cantidad.Text = "";
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            maskedTextBox1.Text = "";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            // metodo para ingresar datos
            agregar_datos(txt_codigo.Text, txt_nombre.Text, txt_cantidad.Text, maskedTextBox1.Text);
            //meodo para cargar el datagrid modificado
            cargarGrilla();
            //ponemos los textbox en blanco despues que se ejecutan
            txt_cantidad.Text = "";
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            maskedTextBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            menu llamar = new menu();
            llamar.Show();
            this.Hide();
        }
    }
}
