using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Desafio_Encode.SQL
{
    internal class ConexionBD
    {

        private SqlConnection Conexion = new SqlConnection();
        private string cadena = "Data Source=10.100.100.102\\SQLSERVER2008;Initial Catalog=DesafioEncode; User ID=pasantes; Password=sqladmin;";


        public SqlConnection Conetar()
        {

            try
            {

                Conexion = new SqlConnection(cadena);

                if (Conexion.State.Equals(ConnectionState.Open))
                {
                    Conexion.Close();
                }
                else
                {
                    Conexion.Open();
                }


            }
            catch (Exception ex)
            {


               



            }

            return Conexion;

        }

    }
}