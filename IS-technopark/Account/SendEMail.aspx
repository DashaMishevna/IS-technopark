<%@ Page Language="C#" Title="Рассылка сообщений" AutoEventWireup="true" CodeBehind="SendEMail.aspx.cs" Inherits="IS_technopark.Account.SendEMail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <br>
        <h2 style="text-align:center; width: 1289px;" >ОТПРАВКА СООБЩЕНИЙ</h2>
        <br>
        <img src="../img/email.png" Width="35" Height="30"/><asp:Label ID="Label5" runat="server" style="margin-left:10px" Text="Имя почтового ящика технопарка: schooltechn.yourname@gmail.com"></asp:Label>
        <br/>    
        <h5 style="text-align:left; margin-bottom:-6px; width: 1299px; font-size:13px; color: #125487;"> Рассылка сообщений родителям и обучающимся по выбранному направлению</h5>
        <div style="float:left; margin-top:10px; margin-left:100px; width: 1197px;">
        <div class='form-label'>
            <asp:Label ID="Label6" runat="server" Text="Выберете направление"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default" AutoPostBack="true" style="margin-right:15px; margin-bottom:10px" Height="30px" Width="280" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  ></asp:DropDownList>
            <asp:Label ID="Label7" runat="server" style="font-size:13px;" Text=""></asp:Label>
        </div>  
            <br />
            <br />
        <asp:Label ID="Label9" runat="server" Font-Size="13px" Text="Отправка сообщения на конкретный почтовый ящик" style="margin-left:-100px; font-size:13px; margin-top:5px; color: #125487;"></asp:Label>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label2" runat="server" Text="Кому:"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="txtTo" runat="server" Width="280" Height="37px" TextMode="MultiLine" CssClass="btn btn-default" style="resize:none; text-align:left; margin-bottom:10px"></asp:TextBox>
        </div>
        <br>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label3" runat="server" Text="Тема сообщения:"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="txtSubject" runat="server" Width="300" CssClass="btn btn-default" Style="text-align:left; margin-right:20px"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Рассылка сообщений выбранным проектантам." Visible="false" Font-Size="13px" ForeColor="#125487"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="" Visible="false" Font-Size="13px">></asp:Label>
        </div>
        <br>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label4" runat="server" Text="Текст сообщения:"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" Columns="40" CssClass="btn btn-default" Style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br><br><br>
            <br />
            <br />
            <br />
        <asp:Button ID="btnSend" runat="server" Text="Отправить"  OnClick="btnSend_Click"  CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="35px" />
        <br>
        <asp:Label ID="lblStatus" runat="server" Style="margin-left:-65px; margin-top:35px" />
    </div>
</asp:Content>