<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Learners.aspx.cs" Inherits="IS_technopark.Account.Learners" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <asp:TextBox ID="TextBox10" runat="server" OnTextChanged="TextBox10_TextChanged"></asp:TextBox>
    
    <p>
    </p>
    <asp:DropDownList ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource1" CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
    <br>
    <br>
    <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="btn btn-default" AutoPostBack="True"></asp:DropDownList>
   
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
   
    <br>
    <br>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBoxFirst" Text='<%# Eval("TextBoxFirst")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"/>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox1" Text='<%# Eval("Num")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"/>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox2" Text='<%# Eval("Date")%>' runat="server" Width="225px" Height="30px"  CssClass="btn btn-default" />
    <br>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <br>
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
     <br>
    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox8" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
    <br>
    <br>
    <div class="form-group" style="text-align:center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="10pt" BackColor="#CEE5F3" />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>


</asp:Content>