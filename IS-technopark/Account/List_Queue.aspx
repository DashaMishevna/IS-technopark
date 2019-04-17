<%@ Page  Title="List_Queue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Queue.aspx.cs" Inherits="IS_technopark.Account.List_Queue" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
<h2 style="text-align:center">ОЧЕРЕДЬ</h2>
<div style="float:left; margin-bottom:20px; text-align:left; margin-left:-100px">
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по проекту"></asp:Label>
    <br/>
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox>--%> 
    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="btn btn-default" AutoPostBack="True"  Height="30px"  ></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Выбрать"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" OnClick="Button1_Click" />
    <br/>
</div>

<div style="float:left; margin-top:10px; margin-left:-100px">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="5" CellSpacing="3" AllowSorting="True" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" HeaderStyle-HorizontalAlign="Center">
            </asp:BoundField>
            <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" HeaderStyle-Width="120px" >
            </asp:BoundField>
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="DATE_REGISTRATION" SortExpression="DATE_REGISTRATION" />
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" />
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" />
            <asp:BoundField DataField="LABORATORY" HeaderText="LABORATORY" SortExpression="LABORATORY" HeaderStyle-Width="150px">
            </asp:BoundField>
            <asp:BoundField DataField="STATUS_L" HeaderText="STATUS_L" SortExpression="STATUS_L" />
            <asp:BoundField DataField="D_T_RECORD" HeaderText="D_T_RECORD" SortExpression="D_T_RECORD" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
        </Columns>
        <EditRowStyle BackColor="#A5D1F3" HorizontalAlign="Left"/>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" Height="35px" Font-Size="14px" />
        <RowStyle BackColor="White" ForeColor="#333333"/>
        <SelectedRowStyle Wrap="True" />
        <SortedAscendingHeaderStyle ForeColor="Black" />
        <SortedDescendingCellStyle ForeColor="Black" />
    </asp:GridView>
    <br/>
    <br/>
    <asp:Label ID="Label4" runat="server" Text="Записать на проект" style="width:200px; height:30px; font-size:16px;  margin-right: 10px" Font-Italic="False" Font-Bold="True"></asp:Label>
    <br/>
    <asp:Label ID="Label1" runat="server" Text="Направление" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" DataTextField="STATUS_L" DataValueField="STATUS_L" ></asp:DropDownList>
    <asp:Label ID="Label3" runat="server" Text="Проект" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" Height="30px" DataTextField="STATUS_L" DataValueField="STATUS_L" ></asp:DropDownList>
    <asp:Label ID="Label5" runat="server" Text="Дата записи" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox2" TextMode="Date" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right: 20px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Добваить" OnClick="Button3_Click" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="30px"/>
    <br />
    <asp:Label ID="Label13" runat="server" Text=""></asp:Label>

 </div>  




</asp:Content>
