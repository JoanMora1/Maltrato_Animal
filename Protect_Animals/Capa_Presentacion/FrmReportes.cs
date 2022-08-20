using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using System.IO;

namespace Capa_Presentacion
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        public bool editar = false;
        string ruta;
        public string IdReporte;

        E_Reporte e_Reporte = new E_Reporte();
        N_Reporte n_Reporte = new N_Reporte();

        public void LimpiarCajas()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            maskedTextBox1.Text = "";
        }

        public void MostrarDatos(string buscar)
        {
            N_Reporte n_Reporte = new N_Reporte();
            dataGridView1.DataSource = n_Reporte.ListandoReporte(buscar);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    FileStream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    FileInfo fi = new FileInfo(ruta);
                    byte[] binData = new byte[stream.Length];
                    stream.Read(binData, 0, Convert.ToInt32(stream.Length));

                    pictureBox1.Image = Image.FromStream(stream);
                    e_Reporte.NOMBRE = txtNombre.Text;
                    e_Reporte.APELLIDO = txtApellido.Text;
                    e_Reporte.CORREO = txtCorreo.Text;
                    e_Reporte.TELEFONO = maskedTextBox1.Text;
                    e_Reporte.FOTO = binData;

                    n_Reporte.InsertandoReporte(e_Reporte);
                    MessageBox.Show("Reporte agregado");
                    LimpiarCajas();
                    MostrarDatos("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el reporte");
                }
            }
            if (editar == true)
            {
                try
                {
                    e_Reporte.ID_REPORTE = Convert.ToInt32(IdReporte);
                    e_Reporte.NOMBRE = txtNombre.Text;
                    e_Reporte.APELLIDO = txtApellido.Text;
                    e_Reporte.CORREO = txtCorreo.Text;
                    e_Reporte.TELEFONO = maskedTextBox1.Text;

                    n_Reporte.EditandoReporte(e_Reporte);
                    MessageBox.Show("Reporte Editado");
                    LimpiarCajas();
                    MostrarDatos("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar.");
                }
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                IdReporte = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar.");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            examinar.Filter = "image files|*.jpg;*.png;*.gif;*.ico;.*;";
            DialogResult dres1 = examinar.ShowDialog();
            if (dres1 == DialogResult.Abort)
                return;
            if (dres1 == DialogResult.Cancel)
                return;
            ruta = examinar.FileName;
            pictureBox1.Image = Image.FromFile(examinar.FileName);
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            MostrarDatos("");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
