<%@ Page  Title="List_Queue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Queue.aspx.cs" Inherits="IS_technopark.Account.List_Queue" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
<h2 style="text-align:center">ОЧЕРЕДЬ</h2>
<div style="float:left; margin-bottom:20px; text-align:left; margin-left:-100px">
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по проекту"></asp:Label>
    <br/>
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox>--%> 
    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="btn btn-default" AutoPostBack="True"  Height="30px" DataSourceID="SqlDataSource2" DataTextField="LABORATORY" DataValueField="LABORATORY" ></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Выбрать"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" OnClick="Button1_Click" />
    <br/>
</div>

<div style="float:left; margin-top:10px; margin-left:-100px">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.QUEUE.STATUS, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="5" CellSpacing="3" AllowSorting="True" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" HeaderStyle-HorizontalAlign="Center">
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="ДАТА ЗАПИСИ" SortExpression="DATE_REGISTRATION" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="120px" ><HeaderStyle Width="130px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CLASS" HeaderText="КЛАСС" SortExpression="CLASS" />
            <asp:BoundField DataField="SHIFT" HeaderText="СМЕНА" SortExpression="SHIFT" />
            <asp:BoundField DataField="TITLE" HeaderText="ПРОЕКТ" SortExpression="TITLE" />
            <asp:BoundField DataField="LABORATORY" HeaderText="ЛАБОРАТОРИЯ" SortExpression="LABORATORY" />
            <asp:BoundField DataField="STATUS" HeaderText="СТАТУС" SortExpression="STATUS" />
            <asp:BoundField DataField="D_T_RECORD" HeaderText="ПЕРЕНОС ЗАПИСИ" SortExpression="D_T_RECORD" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="150px"><HeaderStyle Width="150px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="INTERESTS" HeaderText="ИНТЕРЕСЫ" SortExpression="INTERESTS" />
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                   <%-- <asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>
                <ItemStyle Width="60px"></ItemStyle>
             </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#A5D1F3" HorizontalAlign="Left"/>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" Height="35px" Font-Size="14px" />
        <RowStyle BackColor="White" ForeColor="#333333"/>
        <SelectedRowStyle Wrap="True" />
        <SortedAscendingHeaderStyle ForeColor="Black" />
        <SortedDescendingCellStyle ForeColor="Black" />
    </asp:GridView>
    
    

 </div>  




</asp:Content>
