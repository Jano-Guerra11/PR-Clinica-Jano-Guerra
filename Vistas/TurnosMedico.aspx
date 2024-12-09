<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosMedico.aspx.cs" Inherits="Vistas.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            margin-left: 33px;
            margin-right: 4px;
        }
        .auto-style5 {
            font-size: large;
        }
        .auto-style6 {
            width: 33%;
            margin-right: 0px;
        }
        .auto-style7 {
            width: 434px;
        }
        .auto-style9 {
            width: 139px;
        }
        .auto-style10 {
            width: 243px;
            font-size: large;
        }
        .auto-style12 {
            width: 243px;
            height: 24px;
        }
        .auto-style13 {
            width: 139px;
            height: 24px;
        }
        .auto-style14 {
            width: 434px;
            height: 24px;
        }
        .auto-style15 {
            font-size: x-large;
        }
        .auto-style16 {
            width: 625px;
            height: 24px;
        }
        .auto-style17 {
            width: 625px;
        }
        .auto-style18 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            <br />
            <br />
            <span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Turnos<br />
            </strong></span><span class="auto-style5">&nbsp;<span class="auto-style1"><strong>&nbsp;</strong><asp:HyperLink ID="hlVolverAlMenu" runat="server" CssClass="auto-style5" NavigateUrl="~/MenuMedicos.aspx">Volver al menu</asp:HyperLink>
            </span></span><strong><span class="auto-style1"><br />
                </span>
                <span class="auto-style15">Filtrar</span></strong><span class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <table class="auto-style6">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">
                        &nbsp;</td>
                    <td class="auto-style16">
                        &nbsp;</td>
                </tr>
                </span>
                <tr>
                    <td class="auto-style10">Nombre</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNombre" runat="server" Width="118px"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        <table class="auto-style18">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Apellido</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Fecha</td>
                    <td class="auto-style9"><span class="auto-style1"><span class="auto-style5"><strong>
            <asp:DropDownList ID="ddlComparacionFecha" runat="server" Height="16px" Width="81px">
                <asp:ListItem Value="=">igual a</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
            </asp:DropDownList>
                        </strong></span>
                </span>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Estado</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlEstado" runat="server" Height="16px" Width="124px">
                            <asp:ListItem>-- estado -- </asp:ListItem>
                            <asp:ListItem>indefinido</asp:ListItem>
                            <asp:ListItem>presente</asp:ListItem>
                            <asp:ListItem>ausente</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnFiltrar" runat="server" Height="34px" Text="Filtrar" Width="67px" OnClick="btnFiltrar_Click" />
                    </td>
                    <td class="auto-style17">
                        <asp:Button ID="btnMostrarTodos" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar Todos" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style17">
                        &nbsp;</td>
                </tr>
            </table>
            </span>
        </div>
        <div class="auto-style3">
            <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CssClass="auto-style4"  OnRowDataBound="grdTurnos_RowDataBound" OnRowCancelingEdit="grdTurnos_RowCancelingEdit" OnRowEditing="grdTurnos_RowEditing" OnRowUpdating="grdTurnos_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Numero">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Numero" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Numero" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paciente">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Nombre" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lbl_it_NombrePaciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_Eit_Fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horario">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Horario" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Observacion" runat="server" TextMode="MultiLine" Width="196px" Text='<%# Bind("Observacion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lbl_it_Observacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEstados" runat="server" Width="199px" SelectedValue='<%# Bind("Estado") %>'>
                                <asp:ListItem>indefinido</asp:ListItem>
                                <asp:ListItem>presente</asp:ListItem>
                                <asp:ListItem>ausente</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
