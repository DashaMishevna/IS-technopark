<%@ Page  Title="Очередь" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Queue.aspx.cs" Inherits="IS_technopark.Account.List_Queue" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.DIR_PROJECTS.ID_LABORATORY = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES WHERE (TECHNOPARK.DIR_PROJECTS.TITLE = 'DropDownList2.Text')"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;STATUS_L&quot; FROM &quot;DIR_STATUS_LEARNER&quot;"></asp:SqlDataSource>
    <h2 style="text-align:center">ОЧЕРЕДЬ</h2>
    
    <div style="float:left; margin-top:10px; margin-left:-100px">
    
    <asp:Label ID="Label2" runat="server" Text="Вывод информации по названию проекта" style="width:200px; height:30px; font-size:14px; margin-bottom:15px; margin-left:171px" Font-Italic="False" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Вывод информации по ФИО проектанта" style= "height:30px; font-size:14px; margin-bottom:15px; margin-left:70px;" Font-Italic="False" Font-Bold="True"></asp:Label>   
    <asp:Label ID="Label14" runat="server" Text="Вывод информации по статусу проектанта" style= "height:30px; font-size:14px; margin-bottom:15px; margin-left:75px;" Font-Bold="True"></asp:Label>
    <br/>
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox>--%> 
    <asp:Button ID="Button5" runat="server" Text="Вывести всех" CssClass="btn btn-default" Font-Size="12pt"  style="text-align:center" BackColor="#CEE5F3" Height="32px" OnClick="Button5_Click"/>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default" Height="32px" style="margin-left:40px;"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Выбрать" Height="32px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" OnClick="Button1_Click" />
    <asp:TextBox ID="TextBox1" runat="server" Height="32px" CssClass="btn btn-default" Font-Size="11pt" style="margin-left:60px; text-align:left" ></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Выбрать" Height="32px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" OnClick="Button3_Click"  />
    <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="STATUS_L" DataValueField="STATUS_L" style="margin-left:60px" CssClass="btn btn-default"  Width="250" Height="32px"></asp:DropDownList>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Выбрать" Height="32px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3"  />
    <br/>
    <br/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID_LEARNER,ID_QUEUE" CellPadding="5" CellSpacing="3" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" BorderWidth="0px" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#d2ecf9" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Width="30px" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" Visible="false">
            </asp:BoundField>
            <asp:BoundField DataField="ID_QUEUE" HeaderText="ID_QUEUE" SortExpression="ID_QUEUE" Visible="false" >
            </asp:BoundField>
            <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" > 
            <HeaderStyle Width="170px" />
            </asp:BoundField>
            <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="Дата записи" SortExpression="DATE_REGISTRATION" DataFormatString="{0:dd/MM/yyyy}">
            <HeaderStyle Width="130px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CLASS" HeaderText="Класс" SortExpression="CLASS" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="SHIFT" HeaderText="Смена" SortExpression="SHIFT" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TITLE" HeaderText="Проект" SortExpression="TITLE" >
            <HeaderStyle Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="LABORATORY" HeaderText="Направление" SortExpression="LABORATORY" HeaderStyle-Width="150px"><HeaderStyle Width="150px"></HeaderStyle></asp:BoundField>
            <asp:BoundField DataField="STATUS_L" HeaderText="Статус" SortExpression="STATUS_L" >
            <HeaderStyle Width="170px" />
            </asp:BoundField>
            <asp:BoundField DataField="D_T_RECORD" HeaderText="D_T_RECORD" SortExpression="D_T_RECORD" Visible="false" />
            <asp:BoundField DataField="INTERESTS" HeaderText="Интересы" SortExpression="INTERESTS" />

            <%--<asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"> 
            <ItemTemplate> 
            <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/> 
            <%--<asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you certain you want to delete this product?');"/>
            </ItemTemplate> 
            <EditItemTemplate> 
            <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/> 
            <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div> 
            </EditItemTemplate> 
            <ItemStyle Width="60px"></ItemStyle> 
            </asp:TemplateField>--%>
        </Columns>
        <EditRowStyle HorizontalAlign="Left" BackColor="#ffe8e6"/>
        <HeaderStyle BackColor="#8fc6f0" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <PagerStyle BackColor="#8FC6F0" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle Wrap="True" BackColor="#ff9f97" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle ForeColor="Black" BackColor="#808080" />
        <SortedDescendingCellStyle ForeColor="Black" BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br/>
    <br/>
    <asp:Label ID="Label4" runat="server" Text="Новая запись на проект" style="width:200px; height:30px; font-size:16px;" Font-Italic="False" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="Изменить статус проектанту" style="width:200px; height:30px; font-size:15px; margin-left:331px" Font-Italic="False" Font-Bold="True"></asp:Label>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label1" runat="server" Text="Направление" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
    <div class='form-row' style="width:260px">
    <asp:DropDownList ID="DropDownList2" runat="server" Width="250px" DataTextField="LABORATORY" DataValueField="LABORATORY" CssClass="btn btn-default" AutoPostBack="True"  Height="30px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <asp:Label ID="Label8" runat="server" Text="Статус" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:130px"></asp:Label>
    <asp:DropDownList ID="DropDownList5" runat="server" Width="250px"  CssClass="btn btn-default" DataTextField="STATUS_L" DataValueField="STATUS_L" Height="30px"></asp:DropDownList>
    <br/>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label3" runat="server" Text="Проект" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
    <div class='form-row' style="width:260px">
    <asp:DropDownList ID="DropDownList3" runat="server" Width="250px" DataTextField="TITLE" DataValueField="TITLE"  CssClass="btn btn-default"  Height="30px" ></asp:DropDownList>
    </div>
    <asp:Button ID="Button6" runat="server" Text="Изменить" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="35px" style="margin-left:130px" OnClick="Button6_Click"/>
    <asp:Label ID="Label9" runat="server" Text="" style="margin-left:20px" ></asp:Label>
    <br/>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label5" runat="server" Text="Дата записи" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
     <div class='form-row' style="width:260px">
    <asp:TextBox ID="TextBox2" TextMode="Date" Width="250px" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right: 20px"></asp:TextBox>
    </div>
    <br/>
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Добавить" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="35px" OnClick="Button2_Click"/>
    <br />
    <asp:Label ID="Label13" runat="server" Text=""  ForeColor="Red"></asp:Label>

 </div>  




</asp:Content>
