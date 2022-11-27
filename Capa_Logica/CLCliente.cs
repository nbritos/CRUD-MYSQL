using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Capa_Datos;
using System.Data;

namespace Capa_Logica
{
    public class CLCliente
    {
        CDCliente objCapaDatos=new CDCliente();

        public bool ValidarDatos(CECliente pObjCliente)
        {
            bool resultado = true;
            if (pObjCliente.Nombre==string.Empty)
            {
                MessageBox.Show("El nombre es obligatorio");
                resultado= false;
            }
            else if (pObjCliente.Apellido==string.Empty)
            {
                MessageBox.Show("El apellido es obligatorio");
                resultado= false;
            }
            
            return resultado;
        }

        public void PruebaMySQL()
        {
            objCapaDatos.PruebaConexion();
        }

        public void CrearCliente(CECliente paramCliente)
        {
            objCapaDatos.Crear(paramCliente);
        }

        public DataSet TraerClientes()
        {
           return objCapaDatos.Read();
        }

        public void ActualizarCliente(CECliente paramCliente, int paramID)
        {
            objCapaDatos.Update(paramCliente,paramID);
        }

        public void Eliminar(int paramID)
        {
            objCapaDatos.Delete(paramID);
        }
    }
}
