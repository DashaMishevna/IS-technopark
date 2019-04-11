<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Learner.aspx.cs" Inherits="IS_technopark.Account.Learner" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h2 style="text-align:center">ИНФОРМАЦИЯ О ПРОЕКТАНТАХ</h2>
    <br/>
<div style="float:left; margin-left:40px; margin-top:20px">
    <asp:Label ID="Label1" runat="server" Text="Поиск проектанта по ФИО"></asp:Label>
    <br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default"></asp:TextBox>
    <br/>
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click" />
    <br/>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Вывести полный список"></asp:Label>
    <br/>
    <asp:TextBox ID="TextBox2" runat="server" Text=""  CssClass="btn btn-default" ></asp:TextBox>
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Вывести" OnClick="Button2_Click" />
</div>

<div style="float:right; margin-left:20px;  margin-top:20px" >
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"  ></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" ReadOnly="True" SortExpression="ID_LEARNER" />
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
    </asp:GridView>--%>

    <asp:GridView ID="GridView2" runat="server" CellPadding="5" CellSpacing="3" HorizontalAlign="Left" AllowPaging="true"
         OnSelectedIndexChanged="GridView2_SelectedIndexChanged" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="372px" OnRowCommand="GridView2_RowCommand"> 
        
        <%--<Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/pen.png" runat="server" CommandName="Edit" ToolTip="Edit"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/home.png" runat="server" CommandName="Update" ToolTip="Update"/>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>--%>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="White" ForeColor="#333333" />
    </asp:GridView>
</div>


</asp:Content>
