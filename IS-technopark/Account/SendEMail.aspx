<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEMail.aspx.cs" Inherits="IS_technopark.Account.SendEMail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<table style="font-family: Arial,'Segoe UI';">
                <tr>
                    <td colspan="3">
                        <span align="left">
                            <asp:Image ID="imgMail" runat="server" ImageUrl="~/Image/mail.png" Width="50px" Height="30px" />
                        </span>
                        <span style="font-size: 20px; margin-top: -5px">Отправка сообщений
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>From</td>
                    <td>:</td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>To</td>
                    <td>:</td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>Subject</td>
                    <td>:</td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>Message</td>
                    <td>:</td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="Right">
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                       
                    </td>
                </tr>

         <div class='form-label'>
    </div>
    <div class='form-row'>
    </div>
    <br>
    <br>
            </table>--%>
        <br>
        <h2 style="text-align:center" >ОТПРАВКА СООБЩЕНИЙ</h2>
        <br>
        <h5 style="text-align:left"> Рассылка сообщений родителям и обучающимся по выбранному направлению</h5>
        <div style="float:left; margin-top:10px; margin-left:100px">
        <div class='form-label'>
            <asp:Label ID="Label6" runat="server" Text="Выберете направление"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default" AutoPostBack="true" style="margin-right:15px;" Height="30px" Width="280" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  ></asp:DropDownList>
            <asp:Label ID="Label7" runat="server" style="font-size:13px;" Text=""></asp:Label>
        </div>
        <br>
        <br>
        </div>
        <br>
        <img src="../img/email.png" Width="35px" Height="30px"/><asp:Label ID="Label5" runat="server" style="margin-left:10px" Text="Имя почтового ящика технопарка: schooltechn.yourname@gmail.com"></asp:Label>

        <div style="float:left; margin-top:-10px; margin-left:100px">    
        <br>
        <div class='form-label'>
            <asp:Label ID="Label2" runat="server" Text="Кому:"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="txtTo" runat="server" Width="280" Height="40px" TextMode="MultiLine" CssClass="btn btn-default" style="resize:none; text-align:left; margin-bottom:10px"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label'>
            <asp:Label ID="Label3" runat="server" Text="Тема сообщения:"></asp:Label>
        </div>
        <div class='form-row'>
            <asp:TextBox ID="txtSubject" runat="server" Width="300" CssClass="btn btn-default" Style="text-align:left"></asp:TextBox>
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
        <br>
        <asp:Button ID="btnSend" runat="server" Text="Отправить"  OnClick="btnSend_Click"  CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="35px" />
        <br>
        <asp:Label ID="lblStatus" runat="server" Style="margin-left:-65px; margin-top:35px" />
    </div>
</asp:Content>