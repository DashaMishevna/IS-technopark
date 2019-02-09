<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Learner.aspx.cs" Inherits="IS_technopark.Account.Learner" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div style="float:left; margin-left:50px" >
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"  ></asp:SqlDataSource>
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <%--<asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" ReadOnly="True" SortExpression="ID_LEARNER" />--%>
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
            <asp:BoundField DataField="BIRTHDAY" HeaderText="BIRTHDAY" SortExpression="BIRTHDAY" />
            <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" />
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" />
            <asp:BoundField DataField="E_MAIL" HeaderText="E_MAIL" SortExpression="E_MAIL" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
            <asp:BoundField DataField="COMMENTS" HeaderText="COMMENTS" SortExpression="COMMENTS" />
        </Columns>
         <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
         <RowStyle BackColor="White" ForeColor="#333333" />
         
    </asp:GridView>
    <br/>
    <asp:GridView ID="GridView2" runat="server"> </asp:GridView>
    <br/>
    
    <br/>
   
</div>

<div style="float:right; margin-right:50px">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Выбор сотрудников определенной должности"></asp:Label>
    <br/>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br/>
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click" />
</div>

</asp:Content>
