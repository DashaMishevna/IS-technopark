<%@ Page Title="Diagramm" Language="C#" AutoEventWireup="true" CodeBehind="Diagramm.aspx.cs" Inherits="IS_technopark.Account.Diagramm" MasterPageFile="~/Site.Master"  %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center"> СТАТИСТИКА</h2>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Диаграмма по направлениям" CssClass="btn btn-default" Font-Size="10pt" BackColor="#d6e9f5" ForeColor="#1e577b" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Воронка по году" CssClass="btn btn-default" Font-Size="10pt" BackColor="#d6e9f5" ForeColor="#1e577b" />
    <br />
    <asp:Chart ID="Chart1" runat="server" Height="550px" Width="550px">
        <Series>
        <asp:Series Name="" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" ShadowColor="LightSkyBlue"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="">
            </asp:Legend>
        </Legends>
    </asp:Chart>

    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
</asp:Content>