<%@ Page  Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IS_technopark.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center">ИНФОРМАЦИЯ О ПРОЕКТАНТАХ</h2>
    <br/>
    <asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;LEARNER&quot;" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = 'qwe' WHERE 1=0" DeleteCommand="DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER" >
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" DataKeyNames="ID_LEARNER" OnRowCommand="GridView1_RowCommand" CellPadding="5" CellSpacing="3" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible="false" />
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO"/>
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" ControlStyle-Width="60px"  ><ControlStyle Width="60px"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="BIRTHDAY" HeaderText="BIRTHDAY" SortExpression="BIRTHDAY" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL"/>
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" ControlStyle-Width="60px" > <ControlStyle Width="60px"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="E_MAIL" HeaderText="E_MAIL" SortExpression="E_MAIL" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
            <asp:BoundField DataField="COMMENTS" HeaderText="COMMENTS" SortExpression="COMMENTS"/>

            <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/pen.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/home.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/plus.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>
                <%--<FooterTemplate>
                    <asp:ImageButton ImageUrl="~/img/plus.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px"/>
                </FooterTemplate>--%>

<ItemStyle Width="60px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#A5D1F3"/>
        <HeaderStyle BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="White" ForeColor="#333333"/>
        <SelectedRowStyle Wrap="True" />
    </asp:GridView>

    <br>
    <br>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBoxFirst" Text='<%# Eval("TextBoxFirst")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"/>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox1" Text='<%# Eval("Num")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"/>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox2" Text='<%# Eval("Date")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" />
    <br>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <br>
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
     <br>
    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox8" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <br>
    <br>
    <div class="form-group" style="text-align:center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="10pt" BackColor="#CEE5F3" />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>

</asp:Content>
