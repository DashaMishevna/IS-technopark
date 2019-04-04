<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Learners.aspx.cs" Inherits="IS_technopark.Account.Learners" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <p>
    </p>
    <h2 style="text-align:center">ЗАПИСЬ НА ПРОЕКТ</h2>
    <div style=" margin: 10px; text-align:justify; font-size: 20px; font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;"  >
    <br>
    <asp:Label ID="Label2" runat="server" Text="Фамилия" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBoxFirst" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" style="margin-right:50px"/> 
    <asp:Label ID="Label3" runat="server" Text="Имя" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox1"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" style="margin-right:50px"/>
    <asp:Label ID="Label4" runat="server" Text="Отчество" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox2"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" />
    <br>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Направление" style="margin-right:5px"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-right:50px"></asp:DropDownList>
    <asp:Label ID="Label6" runat="server" Text="Проект" style="margin-right:5px"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="btn btn-default" AutoPostBack="True"></asp:DropDownList>
    <br>
    <br>
    <asp:Label ID="Label7" runat="server" Text="Школа" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" style="margin-right:50px"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Класс" style="margin-right:5px"></asp:Label>
    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="btn btn-default" style="margin-right:50px"> 
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
        <asp:ListItem Value="10"></asp:ListItem>
        <asp:ListItem Value="11"></asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label9" runat="server" Text="Смена" style="margin-right:5px"></asp:Label>
    <asp:DropDownList ID="DropDownList5" runat="server"  CssClass="btn btn-default" >
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
    </asp:DropDownList>
    <br>
    <br>
    <asp:Label ID="Label10" runat="server" Text="Дата Рождения" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Width="225px" Height="30px" Type="date" CssClass="btn btn-default" style="margin-right:50px"></asp:TextBox>
    <asp:Label ID="Label11" runat="server" Text="Телефон" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Width="225px" Height="30px" CssClass="btn btn-default" style="margin-right:50px"></asp:TextBox>
    <asp:Label ID="Label12" runat="server" Text="E-mail" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="Label13" runat="server" Text="Дата записи на проект" style="margin-right:5px"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server" Width="225px" Height="30px" Type="Date"  CssClass="btn btn-default" style="margin-right:50px"></asp:TextBox>
    <asp:Label ID="Label14" runat="server" Text="Статус" style="margin-right:5px"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-default">
        <asp:ListItem Value="Приглашен в РШТ"></asp:ListItem>
        <asp:ListItem Value="Выполняет проект"></asp:ListItem>
        <asp:ListItem Value="Успешно завершил проект"></asp:ListItem>
        <asp:ListItem Value="Отчислен как переставший посещать"></asp:ListItem>
        <asp:ListItem Value="Отчислен за нарушение правил распорядка"></asp:ListItem>
        <asp:ListItem Value="Перенес приглашение на срок"></asp:ListItem>
        <asp:ListItem Value="Отказался окончательно"></asp:ListItem>
        <asp:ListItem Value="Нет связи с ребенком"></asp:ListItem>
        <asp:ListItem Value="Повторная запись"></asp:ListItem>
    </asp:DropDownList>
    <br>
    <br>
     <asp:TextBox ID="TextBox8" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    
    </div>
    <div class="form-group" style="text-align:center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="10pt" BackColor="#CEE5F3" />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>


</asp:Content>