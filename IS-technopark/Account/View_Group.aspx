<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_Group.aspx.cs" Inherits="IS_technopark.Account.View_Group" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;GROUPS&quot;"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_GROUPT" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ID_GROUPT" HeaderText="ID_GROUPT" ReadOnly="True" SortExpression="ID_GROUPT" />
            <asp:BoundField DataField="ID_EMPLOYEES" HeaderText="ID_EMPLOYEES" SortExpression="ID_EMPLOYEES" />
            <asp:BoundField DataField="ID_PROJECT" HeaderText="ID_PROJECT" SortExpression="ID_PROJECT" />
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" />
            <asp:BoundField DataField="D_START" HeaderText="D_START" SortExpression="D_START" />
            <asp:BoundField DataField="D_END" HeaderText="D_END" SortExpression="D_END" />
            <asp:BoundField DataField="D_CONFERENCE" HeaderText="D_CONFERENCE" SortExpression="D_CONFERENCE" />
            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
            <asp:BoundField DataField="TIME_CLASS" HeaderText="TIME_CLASS" SortExpression="TIME_CLASS" />
            <asp:BoundField DataField="PROJECT_THEME" HeaderText="PROJECT_THEME" SortExpression="PROJECT_THEME" />
        </Columns>
</asp:GridView>
</asp:Content>