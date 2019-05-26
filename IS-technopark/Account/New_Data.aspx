<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Data.aspx.cs" Inherits="IS_technopark.Account.New_Data" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align:center;">НОВЫЕ ДАННЫЕ</h2>
    <br />
    <h4 style="text-align:left; font-weight:600; margin-left:0px">Добавить нового сотрудника</h4>
    <br />
    <div style="margin-left:0px; width: 1431px;">
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label_Position" runat="server" Text="Должность"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:DropDownList ID="DropDownList_Position" runat="server"></asp:DropDownList>
    </div>
    <br />
    <br />
    <div class='form-label' style="margin-left:0px; width:200px"">
    <asp:Label ID="Label_FIO" runat="server" Text="ФИО сотрудника"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:TextBox ID="TextBox_FIO" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class='form-label' style="margin-left:0px; width:200px">

    </div>
    </div>
    <br />

    <div class='form-label' style="margin-left:0px; width:200px">
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    </div>

 </asp:Content>