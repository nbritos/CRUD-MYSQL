using Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class frClientes : Form
    {
        CLCliente objLogica = new CLCliente();

        public frClientes()
        {
            InitializeComponent();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado = true;

            CECliente objCliente = new CECliente();
            
            objCliente.Nombre= txtNombre.Text;
            objCliente.Apellido= txtApellido.Text;

            resultado=objLogica.ValidarDatos(objCliente);

            if (!resultado) { return; }
            else
            {
                if (nudID.Value == 0)
                {
                    objLogica.CrearCliente(objCliente);
                    MessageBox.Show("Cliente guardado!");
                }
                else
                {
                    objLogica.ActualizarCliente(objCliente,(int)nudID.Value);
                    MessageBox.Show("Cliente actualizado!");

                }

            }

           
            CargarGrid(); 
        }

        public void LimpiarForm()
        {
            nudID.Value = 0;
            txtNombre.Text = string.Empty;
            //mismo resultado que ="";
            txtApellido.Text = string.Empty;
            CargarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //objLogica.PruebaMySQL();
            objLogica.Eliminar((int)nudID.Value);
            CargarGrid();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //objLogica.TraerClientes();
        }

        private void CargarGrid()
        {
            dgvDatos.DataSource = objLogica.TraerClientes().Tables["tbl"];
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nudID.Value = (int)dgvDatos.CurrentRow.Cells["idclientes"].Value;
            txtNombre.Text = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = dgvDatos.CurrentRow.Cells["apellido"].Value.ToString();
        }
    }
}
