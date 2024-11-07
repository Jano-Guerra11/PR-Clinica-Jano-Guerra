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
            margin-left: 542px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            <br />
            <br />
            <span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Turnos<br />
            </strong></span><span class="auto-style5">&nbsp;<span class="auto-style1"><strong>&nbsp;</strong></span></span><strong><span class="auto-style1"><br />
                </span>
                <span class="auto-style15">Filtrar</span></strong><span class="auto-style1"><table class="auto-style6">
                <tr>
                    <td class="auto-style12"><span class="auto-style5">Numero</span></td>
                    <td class="auto-style13"><span class="auto-style5"> <span class="auto-style1"><strong>
            <asp:DropDownList ID="ddlComparacion" runat="server" Height="16px" Width="82px">
                <asp:ListItem Value="=">igual a</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
            </asp:DropDownList>
                        </strong></span></span></td>
                    <td class="auto-style14">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                </span>
                <tr>
                    <td class="auto-style10">Nombre</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox2" runat="server" Width="118px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Horario</td>
                    <td class="auto-style9"><span class="auto-style1"><span class="auto-style5"><strong>
            <asp:DropDownList ID="ddlComparacionHorario" runat="server" Height="16px" Width="81px">
                <asp:ListItem Value="=">igual a</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
            </asp:DropDownList>
                        </strong></span>
                </span>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Estado</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="124px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnFiltrar" runat="server" Height="34px" Text="Filtrar" Width="67px" />
                    </td>
                </tr>
            </table>
            </span>
        </div>
        <div class="auto-style3">
            <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CssClass="auto-style4" OnSelectedIndexChanged="grdTurnos_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Numero">
                        <ItemTemplate>
                            <asp:Label ID="lblNumeroDeTurno" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paciente">
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lblNombreDelPaciente" runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horario">
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lblHorario" runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="196px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lblObservacion" runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEstados" runat="server" Width="199px">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="auto-style3">
                                <asp:Label ID="lblEstado" runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
