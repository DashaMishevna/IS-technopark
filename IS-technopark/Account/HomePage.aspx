<%@ Page  Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IS_technopark.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
<asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;LEARNER&quot;" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = 'qwe' WHERE 1=0"  DeleteCommand="DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER" >
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="ID_LEARNER" OnRowCommand="GridView1_RowCommand" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible="False" />

            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" ItemStyle-Width="100px"/>
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" ItemStyle-Width="30px" />
            <asp:BoundField DataField="BIRTHDAY" HeaderText="BIRTHDAY" SortExpression="BIRTHDAY"  ItemStyle-Width="30px"/>
            <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" ItemStyle-Width="30px"/>
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" ItemStyle-Width="30px" />
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" ItemStyle-Width="30px"/>
            <asp:BoundField DataField="E_MAIL" HeaderText="E_MAIL" SortExpression="E_MAIL" ItemStyle-Width="30px" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" ItemStyle-Width="30px"/>
            <asp:BoundField DataField="COMMENTS" HeaderText="COMMENTS" SortExpression="COMMENTS" ItemStyle-Width="100px"/>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/pen.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>
                </ItemTemplate>
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="TextBoxFirst" Text='<%# Eval("FirstName")%>' runat="server"/>
                </EditItemTemplate>--%>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/home.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/img/plus.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#6699FF" Font-Size="10pt" />
    </asp:GridView>

    <asp:TextBox ID="TextBoxFirst" Text='<%# Eval("TextBoxFirst")%>' runat="server"/>
    <asp:TextBox ID="TextBox1" Text='<%# Eval("Num")%>' runat="server"/>
    <asp:TextBox ID="TextBox2" Text='<%# Eval("Date")%>' runat="server"/>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
</asp:Content>
