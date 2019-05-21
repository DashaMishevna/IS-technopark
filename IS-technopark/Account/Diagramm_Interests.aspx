<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diagramm_Interests.aspx.cs" Inherits="IS_technopark.Account.Diagramm_Interests" MasterPageFile="~/Site.Master"  %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Series1" Legend="Legend1" XValueType="Int32" YValueType="Int32"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>

</asp:Content>
