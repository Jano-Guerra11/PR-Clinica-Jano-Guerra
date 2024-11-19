<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLPaciente.aspx.cs" Inherits="Vistas.ABMLPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="styleSheet" href="CSS/StyleSheet1.css" type="text/css"/>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: right;
        }
       
        .auto-style3 {
            margin-left: 109px;
            margin-top: 33px;
        }
        .auto-style4 {
            width: 100%;
        }
        
        .auto-style6 {
            font-size: large;
        }
        .auto-style7 {
            width: 109px;
        }
        .auto-style8 {
            width: 150px;
        }
        .auto-style9 {
            margin-left: 57px;
        }
        .auto-style10 {
            height: 40px;
        }
        .auto-style11 {
            width: 150px;
            height: 40px;
        }
     
             
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style6"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style4">
                <tr>
                    <td class="Titulo">
            <strong class="Titulo2">Agregar Paciente</strong></td>
                </tr>
            </table>
&nbsp;&nbsp;&nbsp;&nbsp; </strong></div>
        <table class="Tabla">
            <tr class="Fila1">
                <td class="Columna1">DNI:          <td class="Columna2">
                    <asp:TextBox ID="txtDni" runat="server" Width="139px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">NOMBRE:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtNombre" runat="server" Width="135px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">APELLIDO:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtApellido" runat="server" Width="132px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ForeColor="Red" ValidationGroup="1" ID="rfvApellido">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Columna1">SEXO:</td>
                <td class="Columna2">
                    <asp:DropDownList ID="ddlSexo" runat="server" Width="154px" Height="16px">
                        <asp:ListItem>-- Seleccione Sexo -- </asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSexo" ForeColor="Red" InitialValue="-- Seleccione Sexo --" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">NACIONALIDAD:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtNacionalidad" runat="server" Width="133px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">FECHA DE NACIMIENTO:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="130px" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Columna1">DIRECCION:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">PROVINCIA:</td>
                <td class="Columna2">
                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" Height="29px" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" Width="172px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Red" InitialValue="0" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">LOCALIDAD:</td>
                <td class="Columna2">
                    <asp:DropDownList ID="ddlLocalidad" runat="server" Height="30px" Width="154px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Red" InitialValue="0" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Columna1">TELEFONO:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="136px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="Columna1">CORREO:</td>
                <td class="Columna2">
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">*</asp:RegularExpressionValidator>
                </td>
                <td class="Columna2">
                    <asp:Button ID="btnAgregar" runat="server" Height="37px" Text="Agregar" Width="82px" ValidationGroup="1" OnClick="btnAgregar_Click" />
                </td>
                
            </tr>
        </table>
        <div>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style7">Dni:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFiltroDNi" runat="server" ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                   
                </tr>
                <tr>
                    <td class="auto-style7">Nombre</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFiltroNombre" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    
                </tr>
                <tr>
                    <td class="auto-style7">Apellido:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFiltroApellido" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                     <td class="auto-style11">
                         &nbsp;</td>
                    <td class="auto-style10"> 
                        <asp:Button ID="btnFiltrar" runat="server" CssClass="auto-style9" Height="32px" OnClick="btnFiltrar_Click" Text="Filtrar" Width="70px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnQuitarFiltros" runat="server" Height="32px" OnClick="btnQuitarFiltros_Click" Text="Quitar Filtros" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>

            </table>
        </div>
            <asp:GridView ID="grdPacientes" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CssClass="auto-style3" OnRowCancelingEdit="grdPacientes_RowCancelingEdit" OnRowEditing="grdPacientes_RowEditing" OnRowUpdating="grdPacientes_RowUpdating" OnRowUpdated="grdPacientes_RowUpdated" OnRowDeleting="grdPacientes_RowDeleting" AllowPaging="True" OnPageIndexChanging="grdPacientes_PageIndexChanging" OnRowDataBound="grdPacientes_RowDataBound" OnSelectedIndexChanged="grdPacientes_SelectedIndexChanged" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Dni">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Dni" runat="server" Text='<%# Bind("Dni_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dni" runat="server" Text='<%# Bind("Dni_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Nombre" runat="server" Text='<%# Bind("Nombre_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("nombre_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Apellido" runat="server" Text='<%# Bind("Apellido_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Apellido" runat="server" Text='<%# Bind("Apellido_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sexo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Sexo" runat="server" Text='<%# Bind("Sexo_P") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo_p") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_p") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha De Nacimiento">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_FechaDeNacimiento" runat="server" Text='<%# Bind("FechaDeNacimiento_P") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_FechaNacimiento" runat="server" Text='<%# Bind("FechaDeNacimiento_p") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Direccion" runat="server" Text='<%# Bind("dirección_P") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("dirección_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Localidad" runat="server" CssClass="auto-style26" Height="26px" Width="96px">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("nombreLocalidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("NombreProvincia_Pr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Correo" runat="server" Text='<%# Bind("Correo_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Bind("Correo_p") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Telefono" runat="server" Text='<%# Bind("Telefono_P") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Telefono" runat="server" Text='<%# Bind("Telefono_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajeConfirmacion" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbSi" runat="server" OnClick="lbSi_Click" Visible="False">SI</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbNo" runat="server" OnClick="lbNo_Click" Visible="False">NO</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajeBorrar" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
