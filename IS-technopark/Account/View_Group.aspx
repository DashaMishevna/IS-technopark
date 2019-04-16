<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_Group.aspx.cs" Inherits="IS_technopark.Account.View_Group" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS" UpdateCommand="UPDATE TECHNOPARK.GROUPS SET TIME_CLASS = 'qwe' WHERE 1=0"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.ID_QUEUE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.QUEUE.TITLE_G = TECHNOPARK.GROUPS.TITLE INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.GROUPS.TITLE = '0')" ></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;STATUS_G&quot; FROM &quot;DIR_STATUS_GROUP&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;STATUS_L&quot; FROM &quot;DIR_STATUS_LEARNER&quot;"></asp:SqlDataSource>
    <br>
    <h2 style="text-align:center"> РАБОТА С ГРУППАМИ </h2>
    <br>
    <h4 style="text-align:left; font-weight:600 ">Поиск группы по шифру</h4>
    <br>
    <asp:Label ID="Label1" runat="server" Text="Введите шифр" style="margin-right:20px;"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Выбрать"  CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" OnClick="Button1_Click" />
    <br>
    <br>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID_GROUPT" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" BorderColor="White" CellSpacing="2" AllowPaging="True" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" />
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="EXPR1" HeaderText="EXPR1" SortExpression="EXPR1" />
            <asp:BoundField DataField="D_START" HeaderText="D_START" SortExpression="D_START" />
            <asp:BoundField DataField="D_END" HeaderText="D_END" SortExpression="D_END" />
            <asp:BoundField DataField="D_CONFERENCE" HeaderText="D_CONFERENCE" SortExpression="D_CONFERENCE" />
            <asp:BoundField DataField="TIME_CLASS" HeaderText="TIME_CLASS" SortExpression="TIME_CLASS" />
            <asp:BoundField DataField="PROJECT_THEME" HeaderText="PROJECT_THEME" SortExpression="PROJECT_THEME" />
            <asp:BoundField DataField="STATUS_G" HeaderText="STATUS_G" SortExpression="STATUS_G" />
            <asp:BoundField DataField="ID_GROUPT" HeaderText="ID_GROUPT" SortExpression="ID_GROUPT" Visible="false"/>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div>
                </EditItemTemplate>
        <ItemStyle Width="60px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#52C0FC" />
        <FooterStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
        <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#A5D1F3" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle Height="30px" BackColor="#C8E3F9" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br>
    <asp:Label ID="Label3" runat="server" Text="" ForeColor="Gray"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CellPadding="4" DataKeyNames="ID_QUEUE" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Width="30px"  runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
            <asp:BoundField DataField="STATUS_L" HeaderText="STATUS_L" SortExpression="STATUS_L" />
            <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" Visible ="false"/>
        </Columns>
        <EditRowStyle BackColor="#52C0FC" />
        <FooterStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
        <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#A5D1F3" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle Height="30px" BackColor="#C8E3F9" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Данные группы"></asp:Label>
    <br>
    <asp:Label ID="Label6" runat="server" Text="Дата начала занятий"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="Дата окончания занятий"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Дата конференции"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Время занятий"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <asp:Label ID="Label10" runat="server" Text="Тема проекта"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Статус группы"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="STATUS_G" DataValueField="STATUS_G"> </asp:DropDownList>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Добавить" OnClick="Button2_Click" />
    <br>
    <asp:Label ID="Label5" runat="server" Text="Данные проектанта"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Изменить статус"></asp:Label>
    <br/>
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox>--%> 
    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" DataSourceID="SqlDataSource4" DataTextField="STATUS_L" DataValueField="STATUS_L" ></asp:DropDownList>
    <br />
    <asp:Button ID="Button3" runat="server" Text="Добавить" OnClick="Button3_Click" />
</asp:Content>