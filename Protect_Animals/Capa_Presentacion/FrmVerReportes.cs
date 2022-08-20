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

namespace Capa_Presentacion
{
    public partial class FrmVerReportes : Form
    {
        public FrmVerReportes()
        {
            InitializeComponent();
        }

        E_Reporte e_Reporte = new E_Reporte();
        N_Reporte n_Reporte = new N_Reporte();

        public void MostrarDatos(string buscar)
        {
            dataGridView1.DataSource = n_Reporte.ListandoReporte(buscar);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FrmVerReportes_Load(object sender, EventArgs e)
        {
            MostrarDatos("");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                e_Reporte.ID_REPORTE = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                n_Reporte.EliminandoReporte(e_Reporte);

                MessageBox.Show("Reporte Eliminado.");
                MostrarDatos("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea eliminar.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarDatos(txtBuscar.Text);
        }
    }
}
