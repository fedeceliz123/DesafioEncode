using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Desafio_Encode.SQL
{
     class Consultas:ConexionBD
    {
        public Boolean UserExiste(string usuario)
        {
            
            string consulta = "select NombreUsuario from Suscriptor where NombreUsuario='"+usuario+"'";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            SqlDataReader dr = cmd.ExecuteReader();



            return dr.Read();

        }


        public Boolean TieneSub(string user)
        {
            string consulta = "select IdSuscriptor from Suscripcion where IdSuscriptor = (select IdSuscriptor from Suscriptor where NombreUsuario='"+user+"' )";
            SqlCommand cmd = new SqlCommand(consulta, Conetar());
            SqlDataReader dr = cmd.ExecuteReader();



            return dr.Read();
        }

        public int recuperarID(string user)
        {
            string consulta = "select IdSuscriptor from Suscriptor where NombreUsuario='"+user+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = new DataTable();
            dt = ds.Tables[0];

            int id = int.Parse(dt.Rows[0]["IdSuscriptor"].ToString());

            return id;



        }


        public void RegistrarSub(string user)
        {
            int id = recuperarID(user);
            DateTime fecha = DateTime.Now;
            string fechaM = fecha.ToString("dd-MM-yyyy");

            string insert = "insert into Suscripcion (IdSuscriptor,FechaAlta)values(@id,@fecha)";

            SqlCommand cmd = new SqlCommand(insert,Conetar());

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@fecha",fechaM );
            cmd.ExecuteNonQuery();


        }




    }
}