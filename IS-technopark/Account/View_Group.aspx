<%@ Page EnableEventValidation="true" Language="C#" title="Просмотр групп" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_Group.aspx.cs" Inherits="IS_technopark.Account.View_Group" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0 order by TECHNOPARK.GROUPS.TITLE" UpdateCommand="UPDATE TECHNOPARK.GROUPS SET TIME_CLASS = 'qwe' WHERE 1=0"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.ID_QUEUE, TECHNOPARK.LEARNER.PHONE, TECHNOPARK.LEARNER.E_MAIL FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.QUEUE.TITLE_G = TECHNOPARK.GROUPS.TITLE INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.GROUPS.TITLE = '0')" ></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;STATUS_G&quot; FROM &quot;DIR_STATUS_GROUP&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;STATUS_L&quot; FROM &quot;DIR_STATUS_LEARNER&quot;"></asp:SqlDataSource>
    <br>
    <div style="float:left; margin-left:-100px">
    <h2 style="text-align:center"> РАБОТА С ГРУППАМИ </h2>
    <asp:Label ID="Label6" runat="server" Text="Шифр группы - Номер лаборатории_Дата создания группы_Номер проекта.Номер группы" style="width:200px; height:30px; font-size:12px; margin-right: 10px;" ForeColor="#336699"></asp:Label>
    <h5 style="text-align:left; font-weight:600; margin-top:4px">Поиск группы по шифру</h5>
    <asp:Label ID="Label7" runat="server" Text="Выберите группу" style="text-align:center; margin-right:10px"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-default" style="text-align:center; margin-right:10px"></asp:DropDownList>
    <asp:Button ID="Button5" runat="server" Text="Выбрать" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center; margin-right:12px" OnClick="Button5_Click" />
    
    <asp:Button ID="Button4" runat="server" Text="Вывести все группы" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center; margin-right:12px" OnClick="Button4_Click" />
    
    <asp:Label ID="Label1" runat="server" Text="Введите шифр" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:10px;"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Выбрать" OnClick="Button1_Click" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center" />
   <%-- <asp:Button ID="Button4" runat="server" Text="Вывести группу"  CssClass="btn btn-default" Font-Size="12pt" BackColor="#A5D1F3" Height="33px" style="text-align:center; margin-left:10px" OnClick="Button4_Click" />--%>
        
    <br>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Данные группы" style="width:200px; height:30px; font-size:15px; margin-right:12px; margin-bottom:20px" Font-Italic="False" Font-Bold="True"></asp:Label>
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_GROUPT,TITLE" DataSourceID="SqlDataSource1" style="font-size:12px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  OnRowUpdating="GridView1_RowUpdating" BorderColor="#999999" BorderWidth="0px" AllowPaging="True" BackColor="White" CellSpacing="3">
        <AlternatingRowStyle BackColor="White" />
        <Columns> 
            <asp:BoundField DataField="TITLE" HeaderText="Шифр" SortExpression="TITLE" />
            <asp:BoundField DataField="FIO" HeaderText="ФИО преподавателя" SortExpression="FIO" > <HeaderStyle Width="205px"></HeaderStyle> </asp:BoundField>
            <asp:BoundField DataField="EXPR1" HeaderText="Проект" SortExpression="EXPR1" />
            <asp:BoundField DataField="D_START" HeaderText="Начало занятий ̥" SortExpression="D_START" DataFormatString="{0:dd/MM/yyyy}"> <HeaderStyle Width="90px"></HeaderStyle> 
            <ItemStyle HorizontalAlign="Center"/> </asp:BoundField>
            <asp:BoundField DataField="D_END" HeaderText="Последнее занятие ̥" SortExpression="D_END"  DataFormatString="{0:dd/MM/yyyy}"> <HeaderStyle Width="90px"></HeaderStyle> <ItemStyle HorizontalAlign="Center"/>
            </asp:BoundField>
            <asp:BoundField DataField="D_CONFERENCE" HeaderText="Дата конференции ̥" SortExpression="D_CONFERENCE" DataFormatString="{0:dd/MM/yyyy}"><HeaderStyle Width="100px"></HeaderStyle> 
            <ItemStyle HorizontalAlign="Center"/> </asp:BoundField>
            <asp:BoundField DataField="TIME_CLASS" HeaderText="Время занятий ̥" SortExpression="TIME_CLASS" />
            <asp:BoundField DataField="PROJECT_THEME" HeaderText="Тема проекта ̥" SortExpression="PROJECT_THEME" />
            <asp:BoundField DataField="STATUS_G" HeaderText="Статус группы" SortExpression="STATUS_G" />
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
        <EditRowStyle BackColor="#FFD0D7" />
        <FooterStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
        <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#A5D1F3" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle Height="30px" BackColor="#d2e9f9" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br>
    <asp:Label ID="Label11" runat="server" Text="Статус группы" style="width:200px; height:30px; font-size:16px; margin-right: 10px" Visible="false"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" DataSourceID="SqlDataSource3" DataTextField="STATUS_G" DataValueField="STATUS_G" style="margin-right: 10px" CssClass="btn btn-default" Width="250"  Visible="false"/> </asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Обновить" OnClick="Button2_Click" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center"  Visible="false"/>
    <br />
    <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Данные проектантов" style="width:200px; height:30px; font-size:16px; margin-right: 10px;" Font-Italic="False" Font-Bold="True" Visible="false"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_QUEUE" DataSourceID="SqlDataSource2" CellPadding="5"  ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderWidth="0px" CellSpacing="3" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Width="25px"  runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" />
            <asp:BoundField DataField="CLASS" HeaderText="Класс" SortExpression="CLASS" > 
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="STATUS_L" HeaderText="Статус" SortExpression="STATUS_L" />
            <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" Visible="false"/>
            <asp:BoundField DataField="PHONE" HeaderText="Телефон" SortExpression="PHONE" />
            <asp:BoundField DataField="E_MAIL" HeaderText="E_mail" SortExpression="E_MAIL" />
        </Columns>
        <EditRowStyle HorizontalAlign="Left" BackColor="#ffe8e6"/>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#8ED18E" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#DDF7DD" ForeColor="#333333" />  <%--ТУТ менять цвет с первой строки--%>
    </asp:GridView>
    <asp:Label ID="Label3" runat="server" Text="" ForeColor="Gray"></asp:Label>

    <%--<asp:Label ID="Label6" runat="server" Text="Дата начала занятий" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox2" TextMode="Date" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right: 20px"></asp:TextBox>
    <asp:Label ID="Label7"  runat="server" Text="Дата окончания занятий" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox3" TextMode="Date" runat="server"  CssClass="btn btn-default" style="text-align:left;  margin-right: 20px"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Дата конференции" style="width:200px; height:30px; font-size:16px;"></asp:Label>
    <asp:TextBox ID="TextBox4" TextMode="Date" runat="server"  CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Время занятий" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server"  CssClass="btn btn-default" style="text-align:left;  margin-right: 20px"></asp:TextBox>
    <asp:Label ID="Label10" runat="server" Text="Тема проекта" style="width:200px; height:30px; font-size:16px;"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server"  CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
    <br />
    <br />--%>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Изменить статус" style="width:200px; height:30px; font-size:16px; margin-right: 10px" Visible="false"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" DataSourceID="SqlDataSource4" DataTextField="STATUS_L" DataValueField="STATUS_L" CssClass="btn btn-default" Width="250" Visible="false"></asp:DropDownList>
    <asp:Button ID="Button3" runat="server" Text="Обновить" OnClick="Button3_Click" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center" Visible="false"/>
    <br />
    <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
    <br />
      </div>
</asp:Content>