<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionDeTurnos.aspx.cs" Inherits="Vistas.AsignacionDeTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 90%;
            margin-left: 61px;
            margin-right: 0px;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 100%;
            margin-top: 34px;
        }
        .auto-style7 {
            width: 233px;
        }
        .auto-style8 {
            width: 233px;
            height: 30px;
        }
        .auto-style9 {
            height: 30px;
        }
        .auto-style10 {
            height: 268px;
        }
        .auto-style11 {
            height: 57px;
        }
        .auto-style12 {
            text-align: center;
            height: 57px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <div class="auto-style5">
                <strong><span class="auto-style3">Asignacion De Turnos</span><br class="auto-style3" />
                </strong>
                <asp:HyperLink ID="hlVolverAlMenu" runat="server" NavigateUrl="~/MenuAdministrador.aspx">Volver al menu</asp:HyperLink>
            </div>
        <table class="auto-style2">
            <tr>
                <td>ESPECIALIDAD:          <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="17px" Width="266px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                        <asp:ListItem>-- Seleccione Especialidad --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="Red" InitialValue="-- Seleccione Especialidad --" ValidationGroup="3">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>
                    Horarios disponibles<br />
                    <asp:Label ID="lblNoDisponible" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">MEDICO:<td class="auto-style10">
                    <asp:DropDownList ID="ddlMedicos" runat="server" Height="16px" Width="258px" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                        <asp:ListItem>-- Seleccione Medico --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMedico" runat="server" ControlToValidate="ddlMedicos" ForeColor="Red" InitialValue="-- Seleccione Medico --" ValidationGroup="3">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style10">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="330px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td class="auto-style10">
                    <asp:ListBox ID="lbHorarios" runat="server" Height="264px" Width="201px"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="rfvHorario" runat="server" ControlToValidate="lbHorarios" ForeColor="Red" ValidationGroup="3" InitialValue="Horario Ocupado">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style10">
                    </td>
            </tr>
            <tr>
                <td>DNI PACIENTE:</td>
                <td>
                    <asp:TextBox ID="txtDniPaciente" runat="server" Height="19px" Width="202px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtDniPaciente" ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvExistePaciente" runat="server" ControlToValidate="txtDniPaciente" ForeColor="Red" OnServerValidate="cvExistePaciente_ServerValidate" ValidationGroup="3">Paciente Inexistente</asp:CustomValidator>
                    <br />
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    </td>
                <td class="auto-style12">
                    <asp:Button ID="btnAgregar" runat="server" Height="53px" Text="Agregar Turno" Width="153px" ValidationGroup="3" OnClick="btnAgregar_Click" />
                </td>
                <td class="auto-style11">
                    </td>
                <td class="auto-style11">
                    </td>
                <td class="auto-style11"></td>
            </tr>
        </table>
        </div>
        <table class="auto-style6">
            <tr>
                <td class="auto-style7">Nombre<br />
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td>Apellido<br />
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar DNI" />
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblDni" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTurnos_RowDataBound" AutoGenerateDeleteButton="True" OnRowDeleting="grdTurnos_RowDeleting" OnSelectedIndexChanged="grdTurnos_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>
                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dni del paciente">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_DniPaciente" runat="server" Text='<%# Bind("DniPaciente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paciente">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Paciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Legajo Del medico">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_LegajoMedico" runat="server" Text='<%# Bind("LegajoMedico") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medico">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Medico" runat="server" Text='<%# Bind("Medico") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Horario">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observacion">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Observacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensajeConfirmacion" runat="server"></asp:Label>
        <p>
            <asp:LinkButton ID="lbSi" runat="server" OnClick="lbSi_Click" Visible="False">SI</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbNo" runat="server" Visible="False">NO</asp:LinkButton>
        </p>
    </form>
</body>
</html>
