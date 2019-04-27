<%@ Page  Title="List_Queue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Queue.aspx.cs" Inherits="IS_technopark.Account.List_Queue" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.DIR_PROJECTS.ID_LABORATORY = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES WHERE (TECHNOPARK.DIR_PROJECTS.TITLE = 'DropDownList2.Text')"></asp:SqlDataSource>
    <h2 style="text-align:center">ОЧЕРЕДЬ</h2>
    
    <div style="float:left; margin-top:10px; margin-left:-100px">
    
    <asp:Label ID="Label2" runat="server" Text="Поиск проектанта по проекту" style="width:200px; height:30px; font-size:16px; margin-bottom:15px" Font-Italic="False" Font-Bold="True"></asp:Label>
    <br/>
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:17px"></asp:TextBox>--%> 
    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="btn btn-default" Height="30px"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Выбрать" Height="35px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3" OnClick="Button1_Click" />
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
            <HeaderStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="ДАТА РЕГИСТРАЦИИ" SortExpression="DATE_REGISTRATION" DataFormatString="{0:dd/MM/yyyy}">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CLASS" HeaderText="КЛАСС" SortExpression="CLASS" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="SHIFT" HeaderText="СМЕНА" SortExpression="SHIFT" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TITLE" HeaderText="ПРОЕКТ" SortExpression="TITLE" >
            <HeaderStyle Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="LABORATORY" HeaderText="НАПРАВЛЕНИЕ" SortExpression="LABORATORY" HeaderStyle-Width="150px"><HeaderStyle Width="150px"></HeaderStyle></asp:BoundField>
            <asp:BoundField DataField="STATUS_L" HeaderText="СТАТУС" SortExpression="STATUS_L" >
            <HeaderStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="D_T_RECORD" HeaderText="D_T_RECORD" SortExpression="D_T_RECORD" />
            <asp:BoundField DataField="INTERESTS" HeaderText="ИНТЕРЕСЫ" SortExpression="INTERESTS" />

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
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#8fc6f0" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle Wrap="True" BackColor="#ff9f97" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle ForeColor="Black" BackColor="#808080" />
        <SortedDescendingCellStyle ForeColor="Black" BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br/>
    <br/>
    <asp:Label ID="Label4" runat="server" Text="Записать на проект" style="width:200px; height:30px; font-size:16px;" Font-Italic="False" Font-Bold="True"></asp:Label>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label1" runat="server" Text="Направление" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
    <div class='form-row'>
    <asp:DropDownList ID="DropDownList2" runat="server" Width="250px" DataTextField="LABORATORY" DataValueField="LABORATORY" CssClass="btn btn-default" AutoPostBack="True"  Height="30px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <br/>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label3" runat="server" Text="Проект" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
    <div class='form-row'>
    <asp:DropDownList ID="DropDownList3" runat="server" Width="250px" DataTextField="TITLE" DataValueField="TITLE"  CssClass="btn btn-default" AutoPostBack="True"  Height="30px" ></asp:DropDownList>
    </div>
    <br/>
    <br/>
    <div class='form-label'>
    <asp:Label ID="Label5" runat="server" Text="Дата записи" style="width:200px; height:30px; font-size:16px; margin-right:10px; margin-left:100px"></asp:Label>
    </div>
     <div class='form-row'>
    <asp:TextBox ID="TextBox2" TextMode="Date" Width="250px" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right: 20px"></asp:TextBox>
    </div>
    <br/>
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Добавить" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="35px" OnClick="Button2_Click"/>
    <br />
    <asp:Label ID="Label13" runat="server" Text=""></asp:Label>

 </div>  




</asp:Content>
