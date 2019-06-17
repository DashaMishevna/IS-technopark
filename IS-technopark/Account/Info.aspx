<%@ Page  Title="Информация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="IS_technopark.Info" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;LEARNER&quot;" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = 'qwe' WHERE 1=0" DeleteCommand="DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER and 1=0" >
    </asp:SqlDataSource>
    <h2 style="text-align:center">ИНФОРМАЦИЯ О ПРОЕКТАНТАХ</h2>
    <div style="float:left; margin-top:10px; margin-left:-100px">
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по ФИО" style="margin-left:156px"></asp:Label>
    <br/>
    <asp:Button ID="Button3" runat="server" Text="Вывести всех" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" OnClick="Button3_Click" Height="32" style="text-align:center" />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:15px; margin-left:25px"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" Height="32" />
    <br/>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" DataKeyNames="ID_LEARNER" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"  CellPadding="5" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderWidth="0px" ForeColor="Black" GridLines="Vertical" CellSpacing="3" Width="1285px">
        <AlternatingRowStyle BackColor="#d2ecf9" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="34px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible="false" />
            <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO">
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="BIRTHDAY" HeaderText="Дата рождения" SortExpression="BIRTHDAY" DataFormatString="{0:dd/MM/yyyy}"><ItemStyle HorizontalAlign="Center" /><HeaderStyle Width="145px" Height="20px"></HeaderStyle> 
            </asp:BoundField>
            <asp:BoundField DataField="CLASS" HeaderText="Класс" SortExpression="CLASS" ControlStyle-Width="60px" ><ControlStyle Width="60px"></ControlStyle>
            <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="SCHOOL" HeaderText="Школа" SortExpression="SCHOOL"/>
            <asp:BoundField DataField="SHIFT" HeaderText="Смена" SortExpression="SHIFT" ControlStyle-Width="60px"> <ControlStyle Width="60px"></ControlStyle>
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="PHONE" HeaderText="Телефон" SortExpression="PHONE" />
            <asp:BoundField DataField="E_MAIL" HeaderText="E_mail" SortExpression="E_MAIL" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="INTERESTS" HeaderText="Интересы" SortExpression="INTERESTS" >
            <HeaderStyle Width="170px" />
            </asp:BoundField>
            <asp:BoundField DataField="COMMENTS" HeaderText="Комментарии" SortExpression="COMMENTS"/>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Вы уверены, что хотите удалить данного проектанта?');"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>

        <ItemStyle Width="60px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle HorizontalAlign="Left" BackColor="#ffe8e6"/>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#8fc6f0" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <PagerStyle BackColor="#8fc6f0" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle Wrap="True" BackColor="#ff9f97" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle ForeColor="Black" BackColor="#808080" />
        <SortedDescendingCellStyle ForeColor="Black" BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
<br>
<br>
<asp:Button ID="Button2" runat="server" Text="Вывести информацию о родителях" CssClass="btn btn-default" Font-Size="11pt" Height="30" BackColor="#CEE5F3" OnClick="Button2_Click"  style="align-items:center"/>
<br>
<asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT ID_PARENT, ID_LEARNER_P, FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION FROM TECHNOPARK.PARENT WHERE (PARENT.ID_LEARNER_P = 0)" UpdateCommand="UPDATE TECHNOPARK.PARENT SET FIO = 'qwe' WHERE 1=0" ></asp:SqlDataSource>
<br>
<asp:Label ID="Label3" runat="server" Text="" ForeColor="Gray"></asp:Label>
<asp:GridView ID="GridView2" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="ID_PARENT" DataSourceID="SqlDataSource1" Height="25px" CellPadding="5" Width="1240px" ForeColor="#333333" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderWidth="0px" CellSpacing="3" OnRowUpdating="GridView2_RowUpdating" OnRowEditing="GridView2_RowEditing" OnRowCommand="GridView2_RowCommand">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="ID_PARENT" HeaderText="ID_PARENT" ReadOnly="True" SortExpression="ID_PARENT" Visible="false"/>
        <asp:BoundField DataField="ID_LEARNER_P" HeaderText="ID_LEARNER_P" SortExpression="ID_LEARNER_P" Visible="false" />
        <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" />
        <asp:BoundField DataField="PHONE" HeaderText="Телефон" SortExpression="PHONE" />
        <asp:BoundField DataField="PHONE_WORK" HeaderText="Рабочий телефон" SortExpression="PHONE_WORK" />
        <asp:BoundField DataField="E_MAIL" HeaderText="E_mail" SortExpression="E_MAIL" />
        <asp:BoundField DataField="PLACE_WORK" HeaderText="Место работы" SortExpression="PLACE_WORK" />
        <asp:BoundField DataField="POSITION" HeaderText="Должность" SortExpression="POSITION" />
        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                   <%-- <asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel2" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>

        <ItemStyle Width="60px"></ItemStyle>
       </asp:TemplateField>
    </Columns>
        <EditRowStyle HorizontalAlign="Left" BackColor="#ffe8e6"/>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#8ED18E" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#DDF7DD" ForeColor="#333333" />  <%--ТУТ менять цвет с первой строки--%>
        <SelectedRowStyle Wrap="True" BackColor="#ff9f97" Font-Bold="True" ForeColor="White" />

    </asp:GridView>
</div>
</asp:Content>
