﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEMail.aspx.cs" Inherits="IS_technopark.Account.SendEMail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table style="font-family: Arial,'Segoe UI';">
                <tr>
                    <td colspan="3">
                        <span align="left">
                            <asp:Image ID="imgMail" runat="server" ImageUrl="~/Image/mail.png" Width="50px" Height="30px" />
                        </span>
                        <span style="font-size: 20px; margin-top: -5px">Sending Email through SMTP IIS
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>From</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>To</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtTo" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Subject</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Message</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" Columns="40"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="Right">
                        <asp:Button ID="btnSend" runat="server" Text="Send mail" OnClick="btnSend_Click" BackColor="#009999" ForeColor="White" Font-Bold="true" BorderColor="#009999" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblStatus" runat="server" />
                    </td>
                </tr>
            </table>


</asp:Content>