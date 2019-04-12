<%@ Page  Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IS_technopark.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h2 style="text-align:center">ИНФОРМАЦИЯ О ПРОЕКТАНТАХ</h2>
<div style="float:left; margin-bottom:20px; text-align:left; margin-left:-100px">
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по ФИО"></asp:Label>
    <br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" />
    <br/>
</div>

<div style="float:left; margin-top:10px; margin-left:-100px">
<asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;LEARNER&quot;" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = 'qwe' WHERE 1=0" DeleteCommand="DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER" >
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" DataKeyNames="ID_LEARNER" OnRowCommand="GridView1_RowCommand" CellPadding="5" CellSpacing="3" AllowSorting="True" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible="false" />
            <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO"/>
            <asp:BoundField DataField="BIRTHDAY" HeaderText="День рождения" SortExpression="BIRTHDAY" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="CLASS" HeaderText="Класс" SortExpression="CLASS" ControlStyle-Width="60px"  ><ControlStyle Width="60px"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="SCHOOL" HeaderText="Школа" SortExpression="SCHOOL"/>     
            <asp:BoundField DataField="SHIFT" HeaderText="Смена" SortExpression="SHIFT" ControlStyle-Width="60px" > <ControlStyle Width="60px"></ControlStyle>
            </asp:BoundField>
             <asp:BoundField DataField="PHONE" HeaderText="Телефон" SortExpression="PHONE" />
            <asp:BoundField DataField="E_MAIL" HeaderText="E_MAIL" SortExpression="E_MAIL" />
            <asp:BoundField DataField="INTERESTS" HeaderText="Интересы" SortExpression="INTERESTS" />
            <asp:BoundField DataField="COMMENTS" HeaderText="Комментарии" SortExpression="COMMENTS"/>

            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>
                <%--<FooterTemplate>
                    <asp:ImageButton ImageUrl="~/img/plus.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px"/>
                </FooterTemplate>--%>

        <ItemStyle Width="60px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#A5D1F3" HorizontalAlign="Left"/>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <RowStyle BackColor="White" ForeColor="#333333"/>
        <SelectedRowStyle Wrap="True" />
        <SortedAscendingHeaderStyle ForeColor="Black" />
        <SortedDescendingCellStyle ForeColor="Black" />
</asp:GridView>
<asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
</div>
</asp:Content>
