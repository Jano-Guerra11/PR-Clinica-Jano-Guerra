<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMLMedico.aspx.cs" Inherits="Vistas.ABMLMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style6 {
            font-size: large;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style7 {
            text-align: right;
        }
        .auto-style2 {
            width: 80%;
            margin-left: 61px;
            margin-right: 0px;
        }
        .auto-style9 {
            height: 49px;
        }
        .auto-style11 {
            width: 175px;
        }
        .auto-style12 {
            width: 175px;
            height: 49px;
        }
        .auto-style14 {
            width: 238px;
            height: 49px;
        }
        .auto-style3 {
            margin-left: 40px;
            margin-top: 33px;
        }
        .auto-style15 {
            width: 39%;
            margin-top: 16px;
            margin-left: 195px;
        }
        .auto-style16 {
            height: 32px;
            width: 216px;
        }
        .auto-style17 {
            height: 30px;
            width: 216px;
        }
        .auto-style18 {
            height: 29px;
            width: 216px;
        }
        .auto-style19 {
            height: 27px;
            width: 216px;
        }
        .auto-style20 {
            height: 28px;
            width: 216px;
        }
        .auto-style21 {
            height: 31px;
            width: 216px;
        }
        .auto-style28 {
            height: 45px;
            width: 172px;
        }
        .auto-style35 {
            height: 45px;
            width: 74px;
        }
        .auto-style36 {
            height: 32px;
            width: 74px;
            text-align: center;
        }
        .auto-style37 {
            height: 32px;
            text-align: center;
            width: 199px;
        }
        .auto-style44 {
            height: 32px;
            width: 199px;
        }
        .auto-style45 {
            height: 30px;
            width: 199px;
        }
        .auto-style46 {
            height: 29px;
            width: 199px;
        }
        .auto-style47 {
            height: 27px;
            width: 199px;
        }
        .auto-style48 {
            height: 28px;
            width: 199px;
        }
        .auto-style49 {
            height: 31px;
            width: 199px;
        }
        .auto-style50 {
            height: 32px;
            width: 74px;
        }
        .auto-style51 {
            height: 30px;
            width: 74px;
        }
        .auto-style52 {
            height: 29px;
            width: 74px;
        }
        .auto-style53 {
            height: 27px;
            width: 74px;
        }
        .auto-style54 {
            height: 28px;
            width: 74px;
        }
        .auto-style55 {
            height: 31px;
            width: 74px;
        }
        .auto-style56 {
            height: 32px;
            width: 216px;
            text-align: center;
        }
        .auto-style57 {
            height: 32px;
            width: 172px;
        }
        .auto-style58 {
            height: 30px;
            width: 172px;
        }
        .auto-style59 {
            height: 29px;
            width: 172px;
        }
        .auto-style60 {
            height: 27px;
            width: 172px;
        }
        .auto-style61 {
            height: 28px;
            width: 172px;
        }
        .auto-style62 {
            height: 31px;
            width: 172px;
        }
        .auto-style63 {
            width: 238px;
        }
        .auto-style64 {
            width: 305px;
        }
        .auto-style65 {
            text-align: center;
        }
        .auto-style66 {
            width: 238px;
            height: 43px;
        }
        .auto-style67 {
            width: 305px;
            height: 43px;
        }
        .auto-style68 {
            height: 43px;
        }
        .Titulo2{
    background-color:chartreuse;
    border-radius:20px;
    padding:10px;
}
        .auto-style69 {
            width: 112px;
        }
        .auto-style70 {
            width: 177px;
        }
        .auto-style71 {
            width: 132px;
        }
        .auto-style72 {
            width: 151px;
        }
        .auto-style73 {
            width: 111px;
        }
        .auto-style74 {
            width: 152px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style7">
               
            <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style6"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">
            <strong>Agregar Medico<br />
                        </strong>
            </strong>
                        <asp:HyperLink ID="hlVolverAlMenu" runat="server" CssClass="auto-style6" NavigateUrl="~/MenuAdministrador.aspx">Volver al menu</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style2">
            <tr>
                <td>LEGAJO:          <td>
                    <asp:TextBox ID="txtLegajo" runat="server" Width="139px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvLegajo" runat="server" ControlToValidate="txtLegajo" OnServerValidate="cvLegajo_ServerValidate" ValidationGroup="1">legajo existente</asp:CustomValidator>
                </td>
                <td class="auto-style63">DNI:</td>
                <td>
                    <asp:TextBox ID="txtDni" runat="server" Width="135px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">NOMBRE:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="132px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="1" ID="rfvNombre">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>APELLIDO:</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" Width="133px"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style63">SEXO:</td>
                <td>
                    <asp:DropDownList ID="ddlSexo" runat="server" Width="145px">
                        <asp:ListItem>-- Seleccione Sexo -- </asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ForeColor="Red" InitialValue="-- Seleccione Sexo --" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">FECHA DE NACIMIENTO:</td>
                <td>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="130px" TextMode="Date"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>NACIONALIDAD:</td>
                <td>
                    <asp:TextBox ID="txtNacionalidad" runat="server" Width="138px"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style63">PROVINCIA:</td>
                <td>
                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" Height="29px"  Width="177px" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                        <asp:ListItem>-- Seleccione Provincia --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Red" InitialValue="0" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">LOCALIDAD:</td>
                <td>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" Height="30px" Width="177px">
                        <asp:ListItem>-- Seleccione Localidad --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Red" InitialValue="0" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>TELEFONO:</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" Width="136px"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style63">CORREO:</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">
                    DIRECCION:
                    </td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">ESPECIALIDAD:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="ddlEspecialidades" runat="server">
                        <asp:ListItem>-- Seleccione Especialidad --</asp:ListItem>
                    </asp:DropDownList>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" ForeColor="Red" InitialValue="-- Seleccione Especialidad --" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style14">Nombre usuario:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            <strong>
                    <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style9">
                    <br />
                </td>
            </tr>
            </table>
        <p>
            <table class="auto-style15">
                <tr>
                    <td class="auto-style57">DIAS DE ATENCION</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style37">HORARIO ENTRADA</td>
                    <td class="auto-style56">HORARIO SALIDA</td>
                </tr>
                <tr>
                    <td class="auto-style57">
                        <asp:Label ID="lblLunes" runat="server" Text="LUNES"></asp:Label>
                    </td>
                    <td class="auto-style50">
                        <asp:CheckBox ID="cbLunes" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style44">
                        <asp:TextBox ID="txtEntradaLunes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txtSalidaLunes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style58">
                        <asp:Label ID="lblMartes" runat="server" Text="MARTES"></asp:Label>
                    </td>
                    <td class="auto-style51">
                        <asp:CheckBox ID="cbMartes" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style45">
                        <asp:TextBox ID="txtEntradaMartes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtSalidaMartes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style59">
                        <asp:Label ID="lblMiercoles" runat="server" Text="MIERCOLES"></asp:Label>
                    </td>
                    <td class="auto-style52">
                        <asp:CheckBox ID="cbMiercoles" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style46">
                        <asp:TextBox ID="txtEntradaMiercoles" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtSalidaMiercoles" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style60">
                        <asp:Label ID="lblJueves" runat="server" Text="JUEVES"></asp:Label>
                    </td>
                    <td class="auto-style53">
                        <asp:CheckBox ID="cbJueves" runat="server" AutoPostBack="True" />
                    </td>
                    <td class="auto-style47">
                        <asp:TextBox ID="txtEntradaJueves" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txtSalidaJueves" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style61">
                        <asp:Label ID="lblViernes" runat="server" Text="VIERNES"></asp:Label>
                    </td>
                    <td class="auto-style54">
                        <asp:CheckBox ID="cbViernes" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style48">
                        <asp:TextBox ID="txtEntradaViernes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtSalidaViernes" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style58">
                        <asp:Label ID="lblSabado" runat="server" Text="SABADO"></asp:Label>
                    </td>
                    <td class="auto-style51">
                        <asp:CheckBox ID="cbSabado" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style45">
                        <asp:TextBox ID="txtEntradaSabado" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtSalidaSabado" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style62">
                        <asp:Label ID="lblDomingo" runat="server" Text="DOMINGO"></asp:Label>
                    </td>
                    <td class="auto-style55">
                        <asp:CheckBox ID="cbDomingo" runat="server" AutoPostBack="True"  />
                    </td>
                    <td class="auto-style49">
                        <asp:TextBox ID="txtEntradaDomingo" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtSalidaDomingo" runat="server" TextMode="Time" Visible="False" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style28">
                        &nbsp;</td>
                    <td class="auto-style35">

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">
                    <asp:Button ID="btnAgregar" runat="server" Height="37px" Text="Agregar" Width="82px" ValidationGroup="1" OnClick="btnAgregar_Click" />
                &nbsp;&nbsp;
                    </td>
                    <td class="auto-style35">

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </p>
            Filtrar Resultados:<table class="auto-style4">
            <tr>
                <td class="auto-style66">Legajo</td>
                <td class="auto-style67">
                    <asp:TextBox ID="txtFiltroLegajo" runat="server" Width="228px"></asp:TextBox>
                </td>
                <td class="auto-style68"></td>
            </tr>
            <tr>
                <td class="auto-style63">Dni</td>
                <td class="auto-style64">
                    <asp:TextBox ID="txtFiltroDni" runat="server" Width="225px"></asp:TextBox>
                </td>
                <td class="auto-style65">
                    <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style63">Apellido</td>
                <td class="auto-style64">
                    <asp:TextBox ID="txtFiltroApellido" runat="server" Width="222px"></asp:TextBox>
                </td>
                <td class="auto-style65">
                    <asp:Button ID="btnMostrarTodos" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar Todos" />
                </td>
            </tr>
            <tr>
                <td class="auto-style63">Especialidad</td>
                <td class="auto-style64">
                    <asp:DropDownList ID="ddlFiltroEspecialidad" runat="server" Height="21px" Width="204px">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="grdMedicos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" CssClass="auto-style3"  OnRowDeleting="grdMedicos_RowDeleting" OnRowCancelingEdit="grdMedicos_RowCancelingEdit" OnRowEditing="grdMedicos_RowEditing" OnRowUpdating="grdMedicos_RowUpdating" OnRowCommand="grdMedicos_RowCommand"  AllowPaging="True" AutoGenerateEditButton="True" OnPageIndexChanging="grdMedicos_PageIndexChanging" PageSize="5" OnRowDataBound="grdMedicos_RowDataBound"   >
                <Columns>
                    <asp:ButtonField CommandName="verDiasYhorarios" Text="Ver Dias y Horarios" />
                    <asp:TemplateField HeaderText="Legajo">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_Eit_Legajo" runat="server" Text='<%# Bind("Legajo_Me") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Legajo" runat="server" Text='<%# Bind("Legajo_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dni">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Dni" runat="server" Text='<%# Bind("Dni_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dni" runat="server" Text='<%# Bind("Dni_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Nombre" runat="server" Text='<%# Bind("Nombre_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("nombre_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Apellido" runat="server" Text='<%# Bind("Apellido_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Apellido" runat="server" Text='<%# Bind("Apellido_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sexo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Eit_Sexo" runat="server" SelectedValue='<%# Bind("Sexo_Me") %>'>
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha De Nacimiento">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_FechaDeNacimiento" runat="server" Text='<%# Bind("FechaDeNacimiento_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_FechaNacimiento" runat="server" Text='<%# Bind("fechaDeNacimiento_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Direccion" runat="server" Text='<%# Bind("dirección_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("dirección_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Localidad" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("nombreLocalidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("NombreProvincia_Pr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Correo" runat="server" Text='<%# Bind("Correo_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Bind("Correo_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Eit_Telefono" runat="server" Text='<%# Bind("teléfono_Me") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Telefono" runat="server" Text='<%# Bind("teléfono_Me") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Eit_Especialidad" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Especialidad" runat="server" Text='<%# Bind("NombreEspecialidad_Esp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <asp:Label ID="lblMensajeConfirmacion" runat="server" Visible="False" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbSi" runat="server" OnClick="lbSi_Click" Visible="False">SI</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbNo" runat="server" OnClick="lbNo_Click" Visible="False">NO</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lblMensajeEliminar" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblLegajoSeleccionado" runat="server"></asp:Label>
        <asp:GridView ID="grdJornadaLaboral" runat="server" AutoGenerateEditButton="True" OnRowCancelingEdit="grdJornadaLaboral_RowCancelingEdit" OnRowEditing="grdJornadaLaboral_RowEditing" OnRowUpdating="grdJornadaLaboral_RowUpdating" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" OnRowDeleting="grdJornadaLaboral_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Dia">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_eit_Dias" runat="server" SelectedValue='<%# Bind("DIA") %>'>
                            <asp:ListItem>Lunes</asp:ListItem>
                            <asp:ListItem>Martes</asp:ListItem>
                            <asp:ListItem>Miercoles</asp:ListItem>
                            <asp:ListItem>Jueves</asp:ListItem>
                            <asp:ListItem>Viernes</asp:ListItem>
                            <asp:ListItem>Sabado</asp:ListItem>
                            <asp:ListItem>Domingo</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Dia" runat="server" Text='<%# Bind("DIA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingreso">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_eit_Ingreso" runat="server" Text='<%# Bind("INGRESO") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Ingreso" runat="server" Text='<%# Bind("INGRESO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Egreso">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_eit_Egreso" runat="server" Text='<%# Bind("EGRESO") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Egreso" runat="server" Text='<%# Bind("EGRESO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensajeActualizado" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblConfirmacionEliminar" runat="server" ForeColor="Blue" Visible="False"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbSi2" runat="server" OnClick="lbSi2_Click" Visible="False">SI</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbNo2" runat="server" OnClick="lbNo2_Click" Visible="False">NO</asp:LinkButton>
        <br />
        &nbsp;<br />
        <table class="auto-style4">
            <tr>
                <td class="auto-style69">Agregar dia:</td>
                <td class="auto-style70">
            <strong>
                    <asp:DropDownList ID="ddlAgregarDia" runat="server" SelectedValue='<%# Bind("DIA") %>'>
                        <asp:ListItem>-- Dia --</asp:ListItem>
                        <asp:ListItem>Lunes</asp:ListItem>
                        <asp:ListItem>Martes</asp:ListItem>
                        <asp:ListItem>Miercoles</asp:ListItem>
                        <asp:ListItem>Jueves</asp:ListItem>
                        <asp:ListItem>Viernes</asp:ListItem>
                        <asp:ListItem>Sabado</asp:ListItem>
                        <asp:ListItem>Domingo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAgregarDia" runat="server" ControlToValidate="ddlAgregarDia" ForeColor="Red" InitialValue="-- Dia --" ValidationGroup="dia">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style71">Hora ingreso:</td>
                <td class="auto-style72">
                    <asp:TextBox ID="txtAgregarIngreso" runat="server" TextMode="Time"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAgregarIngreso" runat="server" ControlToValidate="txtAgregarIngreso" ForeColor="Red" ValidationGroup="dia">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style73">Hora egreso:</td>
                <td class="auto-style74">
                    <asp:TextBox ID="txtAgregarEgreso" runat="server" TextMode="Time"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAgregarEgreso" runat="server" ControlToValidate="txtAgregarEgreso" ForeColor="Red" ValidationGroup="dia">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnAgregarDia" runat="server" OnClick="btnAgregarDia_Click" Text="Agregar" ValidationGroup="dia" />
                </td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
