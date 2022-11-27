using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidades;
using System.Windows.Forms;
using System.Data;

namespace Capa_Datos
{
    public class CDCliente
    {
        string stringConexion = "Server=localhost;User=root;Password=;Port=3306;database=bd_crud_cs;";

        public void PruebaConexion() 
        {

            MySqlConnection objConexion = new MySqlConnection(stringConexion);

            try
            {
                objConexion.Open();
                MessageBox.Show("Conectado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion",ex.Message);
                return;
            }
            finally { objConexion.Close(); }
        }

        public void Crear(CECliente paramCECliente)
        {
            MySqlConnection objConexion = new MySqlConnection(stringConexion);
            string query = $"INSERT INTO clientes (nombre, apellido) VALUES ('{paramCECliente.Nombre}','{paramCECliente.Apellido}')";
            objConexion.Open();

            MySqlCommand comando = new MySqlCommand(query, objConexion);
            comando.ExecuteNonQuery();
            objConexion.Close();
            MessageBox.Show("Registro ingresado :)");

        }

        public DataSet Read()
        {
            MySqlConnection objConexion = new MySqlConnection(stringConexion);
            objConexion.Open();
            string query = $"SELECT * FROM clientes";

            MySqlDataAdapter adaptador = new MySqlDataAdapter(query,objConexion);
            DataSet dataSet = new DataSet();
            adaptador.Fill(dataSet,"tbl");
            
            objConexion.Close();
            return dataSet;
        }

        public void Update(CECliente paramCECliente, int paramID)
        {
            MySqlConnection objConexion = new MySqlConnection(stringConexion);
            string query = $"UPDATE clientes SET nombre='{paramCECliente.Nombre}', apellido = '{paramCECliente.Apellido}' WHERE idclientes = {paramID}";
            objConexion.Open();

            MySqlCommand comando = new MySqlCommand(query, objConexion);
            comando.ExecuteNonQuery();
            objConexion.Close();
            MessageBox.Show("Registro actualizado :)");
        }

        public void Delete(int paramID)
        {
            MySqlConnection objConexion = new MySqlConnection(stringConexion);
            string query = $"DELETE FROM clientes WHERE idclientes= {paramID}";
            objConexion.Open();

            MySqlCommand comando = new MySqlCommand (query, objConexion);   
            comando.ExecuteNonQuery();
            objConexion.Close();
            MessageBox.Show("//capadatos// Registro eliminado");
        }
    }
}
