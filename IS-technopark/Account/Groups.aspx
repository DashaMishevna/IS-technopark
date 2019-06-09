<%@ Page Language="C#" Title="Группы" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="IS_technopark.Account.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT FIO FROM TECHNOPARK.EMPLOYEES WHERE (POSITION = 2)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.LEARNER.PHONE, TECHNOPARK.LEARNER.INTERESTS, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.QUEUE.ID_QUEUE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER = 1)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER = 1) AND (TECHNOPARK.DIR_LABORATORIES.LABORATORY = 'Физика')">
    </asp:SqlDataSource>
    <br>
    <h2 style="text-align:center"> СОЗДАНИЕ ГРУППЫ </h2>
    <div style="float:right; text-align:left; margin-right:-110px; margin-top:-7px; font-size:13px">
        <br>
        <h4 style="text-align:left; font-weight:600 ">Выберите обучающихся</h4> <asp:Label ID="Label9" runat="server" Text="" ForeColor="Gray"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_LEARNER,ID_QUEUE" DataSourceID="SqlDataSource2" style="font-size:12px; max-width:950px; height:30px;" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField> 
                <ItemTemplate> 
                <asp:CheckBox ID="SelectLearner" Width="30px" runat="server" /> 
                </ItemTemplate> 
                   <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField> 
                <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible='false' HeaderStyle-Width="205px"> <HeaderStyle Width="205px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO"><HeaderStyle Width="130px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="Дата записи" SortExpression="DATE_REGISTRATION" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}"> <ItemStyle HorizontalAlign="Center"></ItemStyle><HeaderStyle Width="100px"></HeaderStyle>  
                </asp:BoundField> 
                <asp:BoundField DataField="CLASS" HeaderText="Класс" SortExpression="CLASS" ItemStyle-HorizontalAlign="Center"> <ItemStyle HorizontalAlign="Center"></ItemStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="SHIFT" HeaderText="Смена" SortExpression="SHIFT" ItemStyle-HorizontalAlign="Center"> <ItemStyle HorizontalAlign="Center"></ItemStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="SCHOOL" HeaderText="Школа" SortExpression="SCHOOL" HeaderStyle-Width="120px"> <HeaderStyle Width="120px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="PHONE" HeaderText="Телефон" SortExpression="PHONE"> 
                </asp:BoundField> 
                <asp:BoundField DataField="INTERESTS" HeaderText="Интересы" SortExpression="INTERESTS"><HeaderStyle Width="115px"></HeaderStyle>   
                </asp:BoundField> 
                <asp:BoundField DataField="LABORATORY" HeaderText="Направление" SortExpression="LABORATORY"><HeaderStyle Width="105px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="TITLE" HeaderText="Проект" SortExpression="TITLE"> <HeaderStyle Width="250px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" Visible='false'/>
            </Columns>
            <EditRowStyle BackColor="#FFD0D7" />
            <FooterStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
            <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#A5D1F3" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Height="30px" BackColor="#C9E9FC" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

        <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_LEARNER,ID_QUEUE" DataSourceID="SqlDataSource2" style="font-size:13px; max-width:950px; height:30px;" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
               <asp:TemplateField> 
                <ItemTemplate> 
                <asp:CheckBox ID="SelectLearner" Width="30px" runat="server" /> 
                </ItemTemplate> 
                   <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField> 
                <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible='false' HeaderStyle-Width="205px"> <HeaderStyle Width="205px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" > 
                </asp:BoundField> 
                <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="ДАТА ЗАПИСИ" SortExpression="DATE_REGISTRATION" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}"> <ItemStyle HorizontalAlign="Center"></ItemStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="CLASS" HeaderText="КЛАСС" SortExpression="CLASS" ItemStyle-HorizontalAlign="Center"> <ItemStyle HorizontalAlign="Center"></ItemStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="SHIFT" HeaderText="СМЕНА" SortExpression="SHIFT" ItemStyle-HorizontalAlign="Center"> <ItemStyle HorizontalAlign="Center"></ItemStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="SCHOOL" HeaderText="ШКОЛА" SortExpression="SCHOOL" HeaderStyle-Width="120px"> <HeaderStyle Width="120px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="LABORATORY" HeaderText="НАПРАВЛЕНИЕ" SortExpression="LABORATORY" HeaderStyle-Width="105" ><HeaderStyle Width="105px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="TITLE" HeaderText="ПРОЕКТ" SortExpression="TITLE" HeaderStyle-Width="225"> <HeaderStyle Width="225px"></HeaderStyle> 
                </asp:BoundField> 
                <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" Visible='false'/>
            </Columns>
            <EditRowStyle BackColor="#FFD0D7" />
            <FooterStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
            <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#A5D1F3" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Height="30px" BackColor="#C9E9FC" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>--%>
        <br/>
        <asp:Button ID="Button2" runat="server" Text="Рассылка сообщений" OnClick="Button2_Click" Font-Size="11pt" BackColor="#CEE5F3" CssClass="btn btn-default"  />
        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
    </div>

    <div style="float:left; margin-left:-140px;"> 
        <br>
        <h4 style="text-align:left; font-weight:600 ">Данные о группе</h4>
        <br>
        <div style="margin-top: 4px; float:left; width:170px; height:30px; font-size:14px;">
            <asp:Label ID="Label2" runat="server" Text="ФИО Преподавателя *"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" CssClass="btn btn-default" DataTextField="FIO" DataValueField="FIO" AutoPostBack="True" Width="200px"> </asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:170px; height:30px; font-size:14px;">
            <asp:Label ID="Label3" runat="server" Text="Направление *"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList2" runat="server" style="max-width:200px" CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  Height="30px" Width="225px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:170px; height:30px; font-size:14px;">
            <asp:Label ID="Label4" runat="server" Text="Проект *"></asp:Label>
        </div>
        <div class='form-row'style="width:300px;" >
            <asp:DropDownList ID="DropDownList3" runat="server" style="max-width:200px" CssClass="btn btn-default" AutoPostBack="True"  Width="200px"  Height="30px"></asp:DropDownList>
        </div>
       <%-- <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label5" runat="server" Text="Шифр группы*"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;"> 
            <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>--%>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:170px; height:30px; font-size:14px;">
            <asp:Label ID="Label6" runat="server" Text="Тема проекта"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:170px; height:30px; font-size:14px;">
            <asp:Label ID="Label7" runat="server" Text="Время занятий"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:160px; height:30px; font-size:14px; margin-right:10px">
            <asp:Label ID="Label8" runat="server" Text="Дополнительный поиск по интересам"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:CheckBox ID="CheckBox1" runat="server"  Width="15px" Height="15px"  TextAlign="Left"   Text=" " AutoPostBack="True" Font-Strikeout="False" BackColor="#FFFF99" />
            <%--<asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3" CssClass="btn btn-default" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"> </asp:DropDownList>--%>
        </div>
        <br>
        <br/>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Добавить" Width="220px" Height="35px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" OnClick="Button1_Click" OnClientClick="i=2"  />
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
     </div>
    <div class="form-group" style=" text-align:center; margin-top:500px">
        
    </div>
 </asp:Content>