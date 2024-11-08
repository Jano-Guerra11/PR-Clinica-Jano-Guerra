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
        .auto-style13 {
            width: 147px;
        }
        .auto-style14 {
            width: 147px;
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
            width: 213px;
        }
        .auto-style17 {
            height: 30px;
            width: 213px;
        }
        .auto-style18 {
            height: 29px;
            width: 213px;
        }
        .auto-style19 {
            height: 27px;
            width: 213px;
        }
        .auto-style20 {
            height: 28px;
            width: 213px;
        }
        .auto-style21 {
            height: 31px;
            width: 213px;
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
            width: 213px;
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
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style7">
            <strong>&nbsp; </strong>
            <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style6"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">
            <strong>Agregar Medico</strong></td>
                </tr>
            </table>
            </strong>
        </div>
        <table class="auto-style2">
            <tr>
                <td>LEGAJO:          <td>
                    <asp:TextBox ID="txtLegajo" runat="server" Width="139px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style13">DNI:</td>
                <td>
                    <asp:TextBox ID="txtDni" runat="server" Width="135px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">NOMBRE:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="132px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ForeColor="Red" ValidationGroup="1" ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>APELLIDO:</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" Width="133px"></asp:TextBox>
                </td>
                <td class="auto-style13">SEXO:</td>
                <td>
                    <asp:DropDownList ID="ddlSexo" runat="server" Width="145px">
                        <asp:ListItem>-- Seleccione Sexo -- </asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">FECHA DE NACIMIENTO:</td>
                <td>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="130px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>NACIONALIDAD:</td>
                <td>
                    <asp:TextBox ID="txtNacionalidad" runat="server" Width="138px"></asp:TextBox>
                </td>
                <td class="auto-style13">PROVINCIA:</td>
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
                </td>
                <td class="auto-style13">CORREO:</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    DIRECCION:
                    </td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">ESPECIALIDAD:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="ddlEspecialidades" runat="server">
                        <asp:ListItem>-- Seleccione Especialidad --</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
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
                        <asp:CheckBox ID="cbLunes" runat="server" AutoPostBack="True" OnCheckedChanged="cbLunes_CheckedChanged" />
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
                        <asp:CheckBox ID="cbMartes" runat="server" AutoPostBack="True" OnCheckedChanged="cbMartes_CheckedChanged" />
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
                        <asp:CheckBox ID="cbMiercoles" runat="server" AutoPostBack="True" OnCheckedChanged="cbMiercoles_CheckedChanged" />
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
                        <asp:CheckBox ID="cbJueves" runat="server" AutoPostBack="True" OnCheckedChanged="cbJueves_CheckedChanged" />
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
                        <asp:CheckBox ID="cbViernes" runat="server" AutoPostBack="True" OnCheckedChanged="cbViernes_CheckedChanged" />
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
                        <asp:CheckBox ID="cbSabado" runat="server" AutoPostBack="True" OnCheckedChanged="cbSabado_CheckedChanged" />
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
                        <asp:CheckBox ID="cbDomingo" runat="server" AutoPostBack="True" OnCheckedChanged="cbDomingo_CheckedChanged" />
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
                    <asp:Button ID="btnAgregar" runat="server" Height="37px" Text="Agregar" Width="82px" ValidationGroup="1" OnClick="btnAgregar_Click" />
                &nbsp;&nbsp;
                    </td>
                    <td class="auto-style35">

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </p>
            <asp:GridView ID="grdMedicos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CssClass="auto-style3" AutoGenerateSelectButton="True" OnSelectedIndexChanging="grdMedicos_SelectedIndexChanging" OnRowDeleting="grdMedicos_RowDeleting" OnRowCancelingEdit="grdMedicos_RowCancelingEdit" OnRowEditing="grdMedicos_RowEditing" OnRowUpdating="grdMedicos_RowUpdating"   >
                <Columns>
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
                            <asp:DropDownList ID="ddl_Eit_Sexo" runat="server">
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
                            <asp:DropDownList ID="ddl_eit_Localidad" runat="server" SelectedValue='<%# Bind("IdLocalidad") %>'>
                                <asp:ListItem Value="1">Campana</asp:ListItem>
                                <asp:ListItem Value="2">pacheco</asp:ListItem>
                                <asp:ListItem Value="3">Retiro</asp:ListItem>
                                <asp:ListItem Value="4">San Isidro</asp:ListItem>
                                <asp:ListItem Value="5">Colon</asp:ListItem>
                                <asp:ListItem Value="6">Concordia</asp:ListItem>
                                <asp:ListItem Value="7">Gualeguay</asp:ListItem>
                                <asp:ListItem Value="8">gualeguachu</asp:ListItem>
                                <asp:ListItem Value="9">Arocena</asp:ListItem>
                                <asp:ListItem Value="10">Rafaela</asp:ListItem>
                                <asp:ListItem Value="11">Rosario</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("nombreLocalidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server"  SelectedValue='<%# Bind("IdProvincia_Pr") %>'>
                                <asp:ListItem Value="1">Buenos Aires</asp:ListItem>
                                <asp:ListItem Value="2">Entre Rios</asp:ListItem>
                                <asp:ListItem Value="3">Santa Fe</asp:ListItem>
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
                            <asp:DropDownList ID="ddl_Eit_Especialidad" runat="server" SelectedValue='<%# Bind("IdEspecialidad_Esp") %>'>
                                <asp:ListItem Value="0">Pediatria</asp:ListItem>
                                <asp:ListItem Value="1">Ginecologia</asp:ListItem>
                                <asp:ListItem Value="2">Cardiologia</asp:ListItem>
                                <asp:ListItem Value="3">Radiologia</asp:ListItem>
                                <asp:ListItem Value="4">Traumatologia</asp:ListItem>
                                <asp:ListItem Value="5">Cirugia</asp:ListItem>
                                <asp:ListItem Value="6">Dermatologia</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_It_Especialidad" runat="server" Text='<%# Bind("NombreEspecialidad_Esp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <asp:Label ID="lblMedicoSeleccionado" runat="server"></asp:Label>
        <asp:Label ID="lblMensajeEliminar" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnVerJornada" runat="server" Height="30px" OnClick="btnVerJornada_Click" Text="Ver Dias Y Horarios" Width="179px" />
        <br />
        <br />
        <asp:GridView ID="grdJornadaLaboral" runat="server" Visible="False">
        </asp:GridView>
    </form>
</body>
</html>
