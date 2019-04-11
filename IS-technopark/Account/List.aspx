<%@ Page  Title="List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="IS_technopark.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h2 style="text-align:center">ИНФОРМАЦИЯ О ПРОЕКТАНТАХ</h2>
<div style="float:left; margin-bottom:20px; text-align:left; margin-left:-100px"">
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по ФИО"></asp:Label>
    <br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" />
    <br/>
</div>

<div style="float:left; margin-top:10px; margin-left:-100px">
<asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:Technopark %>" ProviderName="<%$ ConnectionStrings:Technopark.ProviderName %>" SelectCommand="SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.QUEUE.STATUS, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = 'qwe' WHERE 1=0" DeleteCommand="DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER" >
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand" CellPadding="5" CellSpacing="3" AllowSorting="True" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="DATE_REGISTRATION" SortExpression="DATE_REGISTRATION"/>
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS"/>
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" ControlStyle-Width="60px"  >
            </asp:BoundField>
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE"/>     
            <asp:BoundField DataField="LABORATORY" HeaderText="LABORATORY" SortExpression="LABORATORY" ControlStyle-Width="60px" > 
            </asp:BoundField>
             <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
            <asp:BoundField DataField="D_T_RECORD" HeaderText="D_T_RECORD" SortExpression="D_T_RECORD" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
        </Columns>
        <EditRowStyle BackColor="#A5D1F3"/>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="White" ForeColor="#333333"/>
        <SelectedRowStyle Wrap="True" />
</asp:GridView>
<asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
</div>
</asp:Content>
