<%@ Page Language="C#" Title="Запись на проект" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Learners.aspx.cs" Inherits="IS_technopark.Account.Learners" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
   <br>
    <h2 style="text-align:center;">ЗАПИСЬ НА ПРОЕКТ</h2>
    <div style="margin-left:100px; width: 1200px;">
        <h4 style="text-align:left; font-weight:600; margin-left:-100px">Данные о ребенке</h4>
        <div class='form-label'>
            <asp:Label ID="Label2" runat="server" Text="ФИО *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBoxFirst" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px; text-align:left"/> 
            <%--<asp:TextBox ID="TextBox1"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px"/>
            <asp:TextBox ID="TextBox2"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" />--%>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label3" runat="server" Text="Направление *" ></asp:Label>
        </div>
        <div class='form-row'>
            <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-right:20px; height:30px; Width:280px"></asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="Проект *" style="margin-right:5px"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="btn btn-default" AutoPostBack="True" Width="210px"  Height="30px" ></asp:DropDownList>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label5" runat="server" Text="Школа *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox3" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px; text-align:left"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Класс *" style="margin-right:5px"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="btn btn-default" style="margin-right:20px"> 
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
        </asp:DropDownList>
            <asp:Label ID="Label7" runat="server" Text="Смена *" style="margin-right:5px"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server"  CssClass="btn btn-default" >
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <br>
        <br>
        <div class='form-label'>
             <asp:Label ID="Label8" runat="server" Text="Дата рождения *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox4" runat="server" Width="280px" Height="30px" TextMode="Date" CssClass="btn btn-default" Style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label9" runat="server" Text="Телефон"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox5" runat="server" Width="500px" Height="30px" CssClass="btn btn-default" Style="text-align:left" TextMode="Phone"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label10" runat="server" Text="E-mail" ></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox6" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" Style="text-align:left" TextMode="Email" ></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label11" runat="server" Text="Дата записи *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox7" runat="server" Width="280px" Height="30px" TextMode="Date"  CssClass="btn btn-default" style="margin-right:20px; text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label19" runat="server" Text="Интересы"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="LABORATORY" DataValueField="LABORATORY" SelectionMode="Multiple" CssClass="btn btn-default" Width="280px" Height="60px" style="text-align:left; margin-right:20px" Font-Size="11pt"></asp:ListBox>
            <asp:Label ID="Label20" runat="server" Text="Комментарии"></asp:Label>
            <asp:TextBox ID="TextBox16" runat="server" Width="300px" Height="60px" TextMode="MultiLine"  style="resize:none; text-align:left"  CssClass="btn btn-default"></asp:TextBox>
        </div>
        <br>
        <br>
        <br>
        <br>
        <h4 style="text-align:left; font-weight:600; margin-left:-100px">Данные о родителях</h4>
        <div class='form-label'>
            <asp:Label ID="Label13" runat="server" Text="ФИО *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox8" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px; text-align:left"/> 
           <%-- <asp:TextBox ID="TextBox9"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px"/>
            <asp:TextBox ID="TextBox10"  runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" />--%>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label14" runat="server" Text="Телефон *"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox11" runat="server" Width="500px" Height="30px" CssClass="btn btn-default" style="margin-right:20px; text-align:left"  ToolTip="Телефон начинается с 8" TextMode="Phone"></asp:TextBox>
            <asp:Label ID="Label15" runat="server" Text="Телефон рабочий" style="margin-right:5px"></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server" Width="500px" Height="30px" CssClass="btn btn-default" Style="text-align:left" ></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label16" runat="server" Text="E-mail" ></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox13" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" Style="text-align:left" TextMode="Email" ></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label17" runat="server" Text="Место работы *" ></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="TextBox14" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" style="margin-right:20px; text-align:left"></asp:TextBox>
            <asp:Label ID="Label18" runat="server" Text="Должность" style="margin-right:5px" ></asp:Label>
            <asp:TextBox ID="TextBox15" runat="server" Width="500px" Height="30px"  CssClass="btn btn-default" Style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
    </div>
    <br>
    <div class="form-group" style="text-align:center;">
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3"  />
    </div>
</asp:Content>