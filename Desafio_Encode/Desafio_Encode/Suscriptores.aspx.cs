using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Desafio_Encode
{
    public partial class Suscriptores : System.Web.UI.Page
    {

        
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            try { 
            
            
                SQL.ConexionBD con = new SQL.ConexionBD();

                var dt = new DataTable();
                string consulta = "select *,CONVERT(char(200),DECRYPTBYPASSPHRASE('llave',Password)) as [Pass] from Suscriptor where NumeroDocumento=" + tbNDoc.Text+ " and TipoDocumento="+seleccion.Value;

                SqlDataAdapter da = new SqlDataAdapter(consulta, con.Conetar());
                DataSet ds = new DataSet();
                da.Fill(ds);

                dt = ds.Tables[0];


                tbNombre.Text = dt.Rows[0]["Nombre"].ToString();
                tbApellido.Text = dt.Rows[0]["Apellido"].ToString();
                tbDireccion.Text = dt.Rows[0]["Direccion"].ToString();
                tbMail.Text = dt.Rows[0]["Email"].ToString();
                tbTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                tbUsuario.Text = dt.Rows[0]["NombreUsuario"].ToString();
                tbContrasena.Text = dt.Rows[0]["Pass"].ToString();

               

                btnModificar.Enabled = true;
                HabilitarInput();


            }
            catch 
            {
                

                string msg = "Este documento no esta registrado cree un nuevo suscriptor";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);

                btnNuevo.Enabled = true;
                HabilitarInput();
            }



        }

       
        protected void btnModificar_Click(object sender, EventArgs e)
        {

            if (tbNombre.Text!="" || tbApellido.Text!=""||tbNDoc.Text!=""||tbUsuario.Text!=""||tbContrasena.Text!="")
            {
                try
                {
                    SQL.ConexionBD con = new SQL.ConexionBD();

                    string cargar = "update Suscriptor set Nombre=@nombre, Apellido=@apellido, NumeroDocumento=@dni, TipoDocumento=@tipo, Direccion=@dir, Telefono=@telefono, Email=@mail, NombreUsuario=@user, Password=(ENCRYPTBYPASSPHRASE('llave',@pass)) where NumeroDocumento='" + tbNDoc.Text + "'";
                    SqlCommand cmd = new SqlCommand(cargar, con.Conetar());

                    cmd.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", tbApellido.Text);
                    cmd.Parameters.AddWithValue("@dni", long.Parse(tbNDoc.Text));
                    cmd.Parameters.AddWithValue("@tipo", int.Parse(seleccion.Value));
                    cmd.Parameters.AddWithValue("@dir", tbDireccion.Text);
                    cmd.Parameters.AddWithValue("@telefono", tbTelefono.Text);
                    cmd.Parameters.AddWithValue("@mail", tbMail.Text);
                    cmd.Parameters.AddWithValue("@user", tbUsuario.Text);
                    cmd.Parameters.AddWithValue("@pass", tbContrasena.Text);

                    cmd.ExecuteNonQuery();



                    string msg = "Modificacion con exito";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                       "Advertencia",
                       "alert('" + msg + "');", true);
                    Limpiar();
                    inhabilitarInput();
                    btnModificar.Enabled = false;
                    btnNuevo.Enabled = false;

                }
                catch
                {
                    string msg = "Error en la modificacion ''verifique que todos los campos esten completos y correctos''";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                       "Advertencia",
                       "alert('" + msg + "');", true);
                    Limpiar();
                    inhabilitarInput();
                    btnModificar.Enabled = false;
                    btnNuevo.Enabled = true;
                }

            }
            else
            {
                string msg = "Error en la modificacion ''verifique que todos los campos esten completos y correctos''";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg + "');", true);
                Limpiar();
                inhabilitarInput();
                btnModificar.Enabled = false;
                btnNuevo.Enabled = true;
            }


        }



        private void HabilitarInput()
        {
            tbNombre.Enabled = true;
            tbApellido.Enabled = true;
            tbDireccion.Enabled = true;
            tbMail.Enabled = true;
            tbTelefono.Enabled = true;
            tbUsuario.Enabled = true;
            tbContrasena.Enabled = true;
            seleccion.Disabled = false;
        }

        private void inhabilitarInput()
        {
            tbNombre.Enabled = false;
            tbApellido.Enabled = false;
            tbDireccion.Enabled = false;
            tbMail.Enabled = false;
            tbTelefono.Enabled = false;
            tbUsuario.Enabled = false;
            tbContrasena.Enabled = false;
            seleccion.Disabled = false;
        }

        private void Limpiar()
        {
            tbNombre.Text = "";
            tbApellido.Text ="" ;
            tbDireccion.Text = "";
            tbMail.Text = "";
            tbTelefono.Text = "";
            tbUsuario.Text = "";
            tbContrasena.Text = "";
            tbNDoc.Text = "";
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            if (tbNombre.Text!="" && tbApellido.Text != "" && tbNDoc.Text != "" && tbUsuario.Text != "" && tbContrasena.Text!= "")
            {


                try
                {
                    SQL.ConexionBD con = new SQL.ConexionBD();

                    string cargar = "insert into Suscriptor (Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Password)values(@nombre,@apellido,@dni,@tipo,@dir,@telefono,@mail,@user,ENCRYPTBYPASSPHRASE('llave',@pass)) ";
                    SqlCommand cmd = new SqlCommand(cargar, con.Conetar());

                    cmd.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", tbApellido.Text);
                    cmd.Parameters.AddWithValue("@dni", long.Parse(tbNDoc.Text));
                    cmd.Parameters.AddWithValue("@tipo", int.Parse(seleccion.Value));
                    cmd.Parameters.AddWithValue("@dir", tbDireccion.Text);
                    cmd.Parameters.AddWithValue("@telefono", tbTelefono.Text);
                    cmd.Parameters.AddWithValue("@mail", tbMail.Text);
                    cmd.Parameters.AddWithValue("@user", tbUsuario.Text);
                    cmd.Parameters.AddWithValue("@pass", tbContrasena.Text);

                    cmd.ExecuteNonQuery();



                    string msg = "Carga con exito";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                       "Advertencia",
                       "alert('" + msg + "');", true);
                    Limpiar();
                    inhabilitarInput();
                    btnModificar.Enabled = false;
                    btnNuevo.Enabled = false;

                }
                catch
                {
                    string msg = "Error en la carga ''verifique que todos los campos esten completos y correctos''";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                       "Advertencia",
                       "alert('" + msg + "');", true);
                    Limpiar();
                    inhabilitarInput();
                    btnModificar.Enabled = false;
                    btnNuevo.Enabled = false;
                }
            }
            else if(tbNombre.Text == "" || tbApellido.Text == "" || tbNDoc.Text == "" || tbUsuario.Text == "" || tbContrasena.Text == "")
            {
                string msg2= "Error en la carga ''verifique que todos los campos esten completos y correctos''";
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "Advertencia",
                   "alert('" + msg2 + "');", true);
                Limpiar();
                inhabilitarInput();
                btnModificar.Enabled = false;
                btnNuevo.Enabled = false;
            }
        }



        

        protected void btnAceptar_Click(object sender, EventArgs e)
        {



            Limpiar();
            inhabilitarInput();
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            inhabilitarInput();
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
        }
    }

}




