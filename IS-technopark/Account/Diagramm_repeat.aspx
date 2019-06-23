<%@ Page Language="C#" Title="Статистика" AutoEventWireup="true" CodeBehind="Diagramm_repeat.aspx.cs" Inherits="IS_technopark.Account.Diagramm_repeat" MasterPageFile="~/Site.Master" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<h3 style="text-align:center"> Статистика повторных обращений</h3>
<h5 style="text-align:center"> Количество проектантов, которые прошли более одного проекта </h5>
<br />
<%--<div style="float:left; margin-left:350px;"> --%>
<div class='form-label' style="margin-left:50px">
<asp:Chart ID="Chart1" runat="server" Palette="None" PaletteCustomColors="#1870b4; #66cc00">
    <Series>
        <asp:Series Name="" ChartType="Pie"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <AxisY Title="Всего"></AxisY>
            <AxisX Title="Повторно пришли"></AxisX>
            </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
</div>
<div class='form-row' style="margin-bottom:400px; margin-left:80px; margin-top:20px">
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
<asp:Label ID="Label2" runat="server" Text="Label" Font-Size="14px"></asp:Label>
    <br />
<asp:Label ID="Label3" runat="server" Text="Label" Font-Size="14px" ForeColor="#4d9900"></asp:Label>
</div>
<br />
<br />

<%-- </div>--%>
</asp:Content>