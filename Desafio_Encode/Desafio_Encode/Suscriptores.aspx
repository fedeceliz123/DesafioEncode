<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suscriptores.aspx.cs" Inherits="Desafio_Encode.Suscriptores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" >
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          
      



            <div class="container-fluid">
    
    <h2>Subcripciòn</h2>
    <h3>Para realizar subcripciòn complete los siguientes datos</h3>
    <hr />
    <div class="container">
    <h3>Buscar subcriptor</h3>
        <div class="row">
            <div class="col">
                <h6>Tipo Documento</h6>
                
                <select class="form-select" aria-label="Default select example" id="seleccion" runat="server" >
                   
                     <option value="1">DNI</option>
                    <option value="2">CUIT</option>
                </select>
            </div>
            <div class="col">
                <h6>Numero de documento</h6>
                
                <asp:TextBox  CssClass="form-control" ID="tbNDoc" runat="server" type="number"  ></asp:TextBox>
            </div>
            <div class="col">
                
                <asp:Button  CssClass="btn btn-success mt-4" Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />

            </div>
        </div>
        <hr />
        
            
                 <h3>Datos subcriptor</h3>
                <div class="row mt-3">
                    <div class="col">
                        <h6>Nombre</h6>
                        <asp:TextBox  CssClass="form-control" ID="tbNombre" runat="server" type="text"  Enabled="false" ></asp:TextBox>
                    </div>
                    <div class="col">
                        <h6>Apellido</h6>
                        <asp:TextBox  CssClass="form-control" ID="tbApellido" runat="server" type="text"  Enabled="false" ></asp:TextBox>
                    </div>
                    <div class="col">
                       
                        <asp:Button  CssClass="btn btn-primary mt-4" Text="Modificar" runat="server" ID="btnModificar"   Enabled="False" OnClick="btnModificar_Click"    />
                        
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <h6>Direccion</h6>
                        <asp:TextBox  CssClass="form-control" ID="tbDireccion" runat="server" type="text"  Enabled="false" ></asp:TextBox>

                    </div>
                    <div class="col">
                        <h6>Email</h6>
                        <asp:TextBox  CssClass="form-control" ID="tbMail" runat="server" type="email"  Enabled="false" ></asp:TextBox>

                    </div>
                    <div class="col">
                        
                       <asp:Button  CssClass="btn btn-info text-light mt-4" Text="Nuevo" runat="server" ID="btnNuevo" OnClick="btnNuevo_Click"  Enabled="False"/>

                    </div>
                </div>
                <div class="row mt-3">
                 <div class="col-4">
                     <h6>Telefono</h6>
                     <asp:TextBox  CssClass="form-control" ID="tbTelefono" runat="server" type="number"  Enabled="false" ></asp:TextBox>

                 </div>

                </div>
                <div class="row mt-3">
                    <div class="col">
                        <h6>Usuario</h6>
                       <asp:TextBox  CssClass="form-control" ID="tbUsuario" runat="server" type="tect"  Enabled="false" ></asp:TextBox>

                    </div>
                    <div class="col">
                        <h6>Contraseña</h6>
                       <asp:TextBox  CssClass="form-control" ID="tbContrasena" runat="server" type="text"  Enabled="false" ></asp:TextBox>

                    </div>
                    <div class="col">
                    </div>

                    </div>



            


        
       <hr />

        
        <div class="row">
            <div class="col-1">
               
                 <asp:Button  CssClass="btn btn-success" Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
            </div>
            <div class="col-1">
                
                <asp:Button  CssClass="btn btn-ligth border-dark" Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

        </div>
    </div>

        
     


    </div>

     
        
    </form>
</body>
</html>
